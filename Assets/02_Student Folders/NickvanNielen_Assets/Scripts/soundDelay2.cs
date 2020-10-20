using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundDelay2 : MonoBehaviour
{
    public AudioSource sound1;
    private bool enabled1 = false;
    private bool enabled2 = false;
    private bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled1 && enabled2 && !disabled) {
            enabled1 = false;
            enabled2 = false;
            disabled = true;
            StartCoroutine(waitForIt());
            
        }
    }

    public void enable1() {
        enabled1 = true;
    }

    public void enable2() {
        enabled2 = true;
    }

    IEnumerator waitForIt() {
        yield return new WaitForSeconds(1);
        sound1.Play();
    }
}
