using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator_door : MonoBehaviour
{
    private bool inRange2 = false;
    private bool activated = false;
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public Transform door;
    public float timer = 3f;
    public float speed = 3f;
    public AudioSource sound1;
    public AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange2 && activated && timer > 0f) {
            sound1.volume = Mathf.Lerp(0.6f, 0f, (3f - timer) / 3f);
            door.Translate(Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (inRange2 && activated && timer <= 0f) {
            activated = false;
            PlayerCC.maxSpeedOnGround = 6f;
            PlayerCC.maxSpeedInAir = 6f;
            sound1.Stop();
            sound2.Play();
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = true;
            if(activated) {
                sound1.Play();
                PlayerCC.maxSpeedOnGround = 0.0001f;
                PlayerCC.maxSpeedInAir = 0.0001f;
            }
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
