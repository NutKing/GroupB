using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Trigger))]
public class TriggerDoor : MonoBehaviour {

    private Trigger _trigger;

    private bool _moving;
    private Vector3 _moved;

    public List<GameObject> objects;
    public float distance = 9f;
    public float velocity = 1f;
    public Vector3 movement = Vector3.down;

    // Use this for initialization
    protected void Start() {
        _trigger = GetComponent<Trigger>();
        _trigger.OnTrigger += () => _moving = true;
    }

    // Update is called once per frame
    protected void Update() {
        if (_moving) {
            Vector3 move = movement * velocity * Time.deltaTime;

            objects.ForEach(o => o.transform.Translate(move));

            _moved += move;
            if (_moved.magnitude > (movement * distance).magnitude) {
                _moving = false;
            }
        }
    }

}
