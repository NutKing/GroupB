using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator_noTransform : MonoBehaviour
{
    private bool inRange2 = false;
    private bool activated = false;
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public float timer = 8.6f;
    // public AudioSource sound1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange2 && activated && timer > 0f) {
            timer -= Time.deltaTime;
        }
        if (inRange2 && activated && timer <= 0f) {
            activated = false;
            PlayerCC.maxSpeedOnGround = 6f;
            PlayerCC.maxSpeedInAir = 6f;
            // sound1.Play();
        }
        if(activated) {
            PlayerCC.maxSpeedOnGround = 0.0001f;
            PlayerCC.maxSpeedInAir = 0.0001f;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = true;
        }
    }

    private void OnTriggerExit(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = false;
        }
    }

    public void activate() {
        if (!disabled) {
            activated = true;
            disabled = true;
        }
    }
}
