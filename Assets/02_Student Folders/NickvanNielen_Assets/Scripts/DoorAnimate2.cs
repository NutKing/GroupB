using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimate2 : MonoBehaviour
{
    private bool disabled = true;
    private float timer = 2f;
    public AudioSource sound1;
    public float speed = 2f;
    public int delay = 2;
    private bool enabled1 = false;
    private bool enabled2 = false;
    public Transform door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enabled1 && enabled2 && disabled) {
            enabled1 = false;
            enabled2 = false;
            StartCoroutine(waitForIt());
        }
        if (!disabled && timer > 0f) {
            door.Translate(Vector3.up * Time.deltaTime * speed);
            timer -= Time.deltaTime;
            sound1.volume = Mathf.Lerp(0.6f, 0f, (2f - timer) / 2f);
        }
        else if (!disabled && timer <= 0f) {
            disabled = true;
            sound1.Stop();
        }
    }

    IEnumerator waitForIt() {
        yield return new WaitForSeconds(delay);
        sound1.Play();
        yield return new WaitForSeconds(0.5f);
        disabled = false;
    }

    public void enable1() {
        enabled1 = true;
    }

    public void enable2() {
        enabled2 = true;
    }
}
