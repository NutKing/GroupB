using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractButton : MonoBehaviour
{
    public bool inRange;
    public KeyCode pressable;
    public UnityEvent interactAction;
    public GameObject Player;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) {
            if (Input.GetKeyDown(pressable)) {
                interactAction.Invoke();
                sound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player) {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider collision) {
        if(collision.gameObject == Player) {
            inRange = false;
        }
    }
}
