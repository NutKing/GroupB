using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoTranslation : MonoBehaviour {
    private Vector3 _moved;

    public List<GameObject> objects;
    public float distance = 1f;
    public float velocity = 1f;
    public Vector3 movement = Vector3.down;

    public UnityAction OnStopped;
    public UnityAction OnResetted;

    public bool IsMoving { get; private set; }

    public bool IsResetting { get; private set; }

    private void Update() {
        if (IsMoving) {
            Vector3 move = movement * (IsResetting ? -velocity : velocity) * Time.deltaTime;

            objects.ForEach(obj => obj.transform.Translate(move));

            _moved += move;
            if (_moved.magnitude >= (movement * distance).magnitude) {
                Vector3 error = movement * ((movement * distance).magnitude - _moved.magnitude);

                objects.ForEach(obj => obj.transform.Translate(error));

                OnStopped?.Invoke();
                if (IsResetting) {
                    OnResetted?.Invoke();
                }

                IsMoving = false;
                IsResetting = false;
                _moved = Vector3.zero;
            }
        }
    }

    public void Trigger() {
        if (!IsMoving) {
            IsMoving = true;
        }
    }

    public void Reset() {
        if (!IsMoving) {
            IsMoving = true;
            IsResetting = true;
        }
    }
}
