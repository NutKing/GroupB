using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundDelay : MonoBehaviour
{
    public AudioSource sound1;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForIt());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitForIt() {
        yield return new WaitForSeconds(4);
        sound1.Play();
    }
}
