﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private bool fall = false;
    private bool disabled = false;
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
            transform.position -= new Vector3(0, (float)3.9, 0);
            sound1.Play();
            sound1.time = 4f;
            fall = false;
        }
    }

    public void setFall() {
        if (!disabled) {
            fall = true;
            disabled = true;
        }
    }
}
