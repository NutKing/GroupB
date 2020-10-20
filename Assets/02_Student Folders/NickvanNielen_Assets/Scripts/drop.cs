using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    private bool activated = false;
    private bool disabled = false;
    public float timer = 1.3f;
    public float speed = 2f;
    public AudioSource sound1;
    public Transform holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && timer > 0f) {
            sound1.volume = Mathf.Lerp(0.6f, 0f, (1.3f - timer) / 1.3f);
            holder.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (activated && timer <= 0f) {
            activated = false;
            sound1.Stop();
        }
    }

    public void activate() {
        if (!disabled) {
            sound1.Play();
            activated = true;
            disabled = true;
        }
    }
}
