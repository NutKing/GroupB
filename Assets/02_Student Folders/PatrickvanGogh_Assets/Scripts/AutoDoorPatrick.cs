using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

// This code is for doors that open when the player is near.

public class AutoDoorPatrick : MonoBehaviour
{
    bool isOpen = false;
    bool opening = false;
    bool closing = false;

    public float speed = 5;
    public float z = 2f;

    public Transform Door1;
    public Transform Door2;

    Collider AutoDoorTrigger;

    Vector3 Door1DefPos = new Vector3(0, 0, 0);
    Vector3 Door2DefPos = new Vector3(0, 0, 1.5f);

    //public AudioSource soundeffect;

    void start()
    {
        AutoDoorTrigger = GetComponent<Collider>();
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
        else if (closing && Door1.localPosition.z > Door1DefPos.z)
        {
            Door1.Translate(-Vector3.forward * Time.deltaTime * speed);
            Door2.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (closing)
        {
            closing = false;
         //   Door1.localPosition = Door1DefPos;
         //   Door2.localPosition = Door2DefPos;
         // soundEffect.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Actor check = other.GetComponent<Actor>();

        if (check == null) return;

        if (!isOpen)
        {
        //  soundEffect.Play();
            isOpen = true;
            opening = true;
            closing = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Actor check = other.GetComponent<Actor>();

        if (check == null) return;

        if (isOpen)
        {
         // soundEffect.Play();
            opening = false;
            closing = true;
            isOpen = false;
        }

    }
}