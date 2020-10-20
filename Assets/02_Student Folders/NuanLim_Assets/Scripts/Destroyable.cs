using UnityEngine;

[RequireComponent(typeof(Health))]
public class Destroyable : MonoBehaviour {

    private Health _health;
    private Material _material;
    private int _prev_index;

    public float damageAtStart;
    public GameObject renderTarget;
    public Texture2D[] progress;

    private void Start() {
        _material = renderTarget.GetComponent<Renderer>().material;

        _health = GetComponent<Health>();
        _health.onDamaged += OnDamaged;
        _health.onDie += OnDie;

        if (damageAtStart != 0f) {
            _health.TakeDamage(damageAtStart, gameObject);
        }
    }

    private void OnDamaged(float value, GameObject source) {
        int index = Mathf.Clamp(
            Mathf.RoundToInt( progress.Length 
                             * (1 - _health.currentHealth / _health.maxHealth)),
            0, progress.Length - 1);

        if (index != _prev_index) {
            _prev_index = index;
            _material.mainTexture = progress[index];
        }
    }

    private void OnDie() {
        gameObject.SetActive(false);
    }
}
