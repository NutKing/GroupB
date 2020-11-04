using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator_sound : MonoBehaviour
{
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public AudioSource sound1;
    public MeshCollider col;
    public MeshCollider col2;
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
            PlayerCC.maxSpeedOnGround = 0.0001f;
            PlayerCC.maxSpeedInAir = 0.0001f;
            StartCoroutine(waitForIt());
            disabled = true;
        }
    }

    IEnumerator waitForIt() {
        sound1.Play();
        yield return new WaitForSeconds(16);
        PlayerCC.maxSpeedOnGround = 6f;
        PlayerCC.maxSpeedInAir = 6f;
        col.enabled = false;
        col2.enabled = false;
    }
}
