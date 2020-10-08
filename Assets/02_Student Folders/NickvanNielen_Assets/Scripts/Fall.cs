using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private bool fall = false;

    public AudioSource sound1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fall) {
            transform.Rotate((float)24, (float)40, 0);
            transform.position -= new Vector3(0, (float)3.5, 0);
            sound1.Play();
            fall = false;
        }
    }

    public void setFall() {
        fall = true;
    }
}
