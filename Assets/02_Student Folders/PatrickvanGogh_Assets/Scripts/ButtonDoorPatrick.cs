using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoorPatrick : MonoBehaviour
{
    bool isOpen = false;
    bool opening = false;
    bool closing = false;

    public float speed = 5;
    public float z = 2f;

    public Transform Door1;
    public Transform Door2;

    Collider ButtonDoorTrigger;

    Vector3 Door1DefPos = new Vector3(0, 0, 0);
    Vector3 Door2DefPos = new Vector3(0, 0, 1.5f);

    //public AudioSource soundeffect;

    // Above is the general execution of the button door opening.
    // Update is called once per frame
    void start()
    {
        ButtonDoorTrigger = GetComponent<Collider>();
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

}
