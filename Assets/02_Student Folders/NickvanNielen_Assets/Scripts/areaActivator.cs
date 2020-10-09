using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator : MonoBehaviour
{
    private bool inRange2 = false;
    private bool activated = false;
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public Transform stairs;
    private float timer = 3.6f;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange2 && activated && timer > 0f) {
            stairs.Translate(Vector3.up * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (inRange2 && activated && timer <= 0f) {
            activated = false;
            PlayerCC.maxSpeedOnGround = 6f;
            PlayerCC.maxSpeedInAir = 6f;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = true;
            if(activated) {
                PlayerCC.maxSpeedOnGround = 0f;
                PlayerCC.maxSpeedInAir = 0f;
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
