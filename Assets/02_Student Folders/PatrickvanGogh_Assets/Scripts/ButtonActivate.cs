using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    bool isOpen = false;
    bool opening = false;
    bool inArea = false;

    public float speed = 5;
    public float z = 2f;

    public Transform Door1;
    public Transform Door2;
    public Transform RedButton;
    public AudioSource soundeffect;

    Vector3 Door1DefPos = new Vector3(0, 0, 0);
    Vector3 Door2DefPos = new Vector3(0, 0, 1.5f);
    void start()
    {
        Door1DefPos = Door1.localPosition;
        Door2DefPos = Door2.localPosition;
        z += Door1.localPosition.z;
    }

    void OnTriggerEnter(Collider collider)
    {
        Actor check = collider.GetComponent<Actor>();
        if (check == null) return;
        inArea = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea == true)
        {
            opening = true;
            soundeffect.Play();
            Debug.Log("Open Button Door");
        }
        if (opening && Door1.localPosition.z < z)
        {
            Door1.Translate(Vector3.forward * Time.deltaTime * speed);
            Door2.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
        else if (opening)
        {
            opening = false;
        }
    }
}