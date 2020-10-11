using System.Collections.Generic;
using System.Linq;
using Assets._02_Student_Folders.NuanLim_Assets.Scripts;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private Health _health;

    private bool _dead;
    private List<(Transform, Vector3, bool)> _keys;
    
    public List<GameObject> keys;
    public float distance = -1f;
    public float velocity = 1f;

    // Start is called before the first frame update
    private void Start() {
        _health = GetComponent<Health>();
        _health.onDie += OnDie;

        _keys = keys.Select(k => (k.transform, k.transform.position.copy(), false)).ToList();

    }

    // Update is called once per frame
    private void Update() {
        if (_dead && _keys.Any(e => e.Item3)) {
            Vector3 movement = Vector3.down * velocity * Time.deltaTime;

            for (int i = 0; i < _keys.Count; ++i) {
                (Transform t, Vector3 start, bool lowering) = _keys[i];
                if (!lowering) {
                    continue;
                }

                t.Translate(movement);

                if (t.position.y - start.y < distance) {
                    _keys[i] = (t, start, false);
                }
            }
        }
    }

    private void OnDie() {
        _dead = true;
        for (int i = 0; i < _keys.Count; ++i) {
            _keys[i] = (_keys[i].Item1, _keys[i].Item2, true);
        }
    }
}
