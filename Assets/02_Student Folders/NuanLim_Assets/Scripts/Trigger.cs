using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health), typeof(AutoTranslation))]
public class Trigger : MonoBehaviour {

    private Health _health;
    private ResettableHealth _rhealth;
    private AutoTranslation _trans;

    private bool _waiting;
    private float _elapsed;

    public UnityAction OnTrigger;

    public AutoTranslation action;

    [HideInInspector]
    public bool isToggle;

    [HideInInspector]
    public float resetDelay = 1f;

    public bool IsEnabled { get; private set; }

    // Start is called before the first frame update
    private void Start() {
        _health = GetComponent<Health>();
        _health.onDie += OnDie;

        if (isToggle) {
            _rhealth = GetComponent<ResettableHealth>();
            if (!_rhealth) {
                throw new MissingComponentException("Toggleable trigger requires ResettableHealth");
            }
        }

        _trans = GetComponent<AutoTranslation>();
        _trans.OnStopped += StoppedMoving;
    }

    private void OnDie() {
        if (isToggle) {
            IsEnabled = !IsEnabled;
        }

        _health.invincible = true;

        OnTrigger?.Invoke();
        _trans.Trigger();

        if (action) {
            if (!isToggle || IsEnabled) {
                action.Trigger();
            } else {
                action.Reset();
            }
        }
    }

    private void StoppedMoving() {
        if (isToggle) {
            if (!_trans.IsResetting) {
                _waiting = true;
            } else {
                _health.invincible = false;
                _rhealth.Revive();
            }
        }
    }

    private void Update() {
        if (_waiting) {
            _elapsed += Time.deltaTime;
            if (_elapsed > resetDelay) {
                _elapsed = 0;
                _waiting = false;

                _trans.Reset();
            }
        }
    }
}
