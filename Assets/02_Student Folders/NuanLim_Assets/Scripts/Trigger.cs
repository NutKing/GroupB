using System.Collections.Generic;
using System.Linq;
using Assets._02_Student_Folders.NuanLim_Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Trigger : MonoBehaviour {

    private Health _health;

    private bool _moving;
    private Vector3 _moved;

    public UnityAction OnTrigger;

    public List<GameObject> keys;
    public float distance = 1f;
    public float velocity = 1f;
    public Vector3 movement = Vector3.down;

    // Start is called before the first frame update
    protected void Start() {
        _health = GetComponent<Health>();
        _health.onDie += () => {
            _moving = true;
            OnTrigger.Invoke();
        };
    }

    // Update is called once per frame
    protected void Update() {
        if (_moving) {
            Vector3 move = movement * velocity * Time.deltaTime;

            keys.ForEach(o => o.transform.Translate(move));

            _moved += move;
            if (_moved.magnitude > (movement * distance).magnitude) {
                _moving = false;
                // Destroying the objects gave a bunch of errors so whatever
            }
        }
    }
}
