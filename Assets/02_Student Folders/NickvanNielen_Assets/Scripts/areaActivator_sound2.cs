using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator_sound2 : MonoBehaviour
{
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public AudioSource sound1;
    public int delay = 16;
    public bool freeze = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player2 && !disabled) {
            if (freeze) {
                PlayerCC.maxSpeedOnGround = 0.0001f;
                PlayerCC.maxSpeedInAir = 0.0001f;
            }
            StartCoroutine(waitForIt());
            disabled = true;
        }
    }

    IEnumerator waitForIt() {
        sound1.Play();
        yield return new WaitForSeconds(delay);
        if (freeze) {
            PlayerCC.maxSpeedOnGround = 6f;
            PlayerCC.maxSpeedInAir = 6f;
        }
    }
}
