using UnityEngine;

[RequireComponent(typeof(AutoTranslation))]
public class ProgressionDeath : MonoBehaviour {

    private Health _health;
    private AutoTranslation _trans;

    public GameObject objective;

    private void Start() {
        _health = objective.GetComponent<Health>();
        _health.onDie += OnDie;

        _trans = GetComponent<AutoTranslation>();
    }

    private void OnDie() {
        _trans.Trigger();
    }
}
