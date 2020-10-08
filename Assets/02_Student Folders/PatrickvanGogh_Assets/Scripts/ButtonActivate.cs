using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    bool isOpen = false;
    bool opening = false;
    

    public float speed = 5;
    public float z = 2f;

    public Transform Door1;
    public Transform Door2;
    public Transform GreenButton;

    Vector3 Door1DefPos = new Vector3(0, 0, 0);
    Vector3 Door2DefPos = new Vector3(0, 0, 1.5f);
    void start()
    {
        Door1DefPos = Door1.localPosition;
        Door2DefPos = Door2.localPosition;
        z += Door1.localPosition.z;
    }

    void Update()
    {
        if (opening && Door1.localPosition.z < z)
        {
            Door1.Translate(Vector3.forward * Time.deltaTime * speed);
            Door2.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
        else if (opening)
        {
            opening = false;
            // soundEffect.Stop();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            opening = true;
        }


    }
}