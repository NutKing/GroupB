using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class door_open : MonoBehaviour
{
    public float speed = 1f;
    bool isOpen = false;
    bool isClosing = false;
    float timer;
    float timerLength = 1f;

    public Transform top;
    public Transform bottom;
    public Transform topleft;
    public Transform topright;
    public Transform bottomleft;
    public Transform bottomright;
    public Collider hitbox;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && timer > 0f)
        {
           // top.Translate(Vector3.left * Time.deltaTime * speed);
            top.Translate(Vector3.forward * Time.deltaTime * speed);
            bottom.Translate(Vector3.forward * Time.deltaTime * speed);
            bottomleft.Translate(Vector3.left * Time.deltaTime * speed);
            bottomright.Translate(Vector3.right * Time.deltaTime * speed);
            topleft.Translate(Vector3.left * Time.deltaTime * speed);
            topright.Translate(Vector3.right * Time.deltaTime * speed);


            timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            isOpen = true;
            timer = timerLength;
        }
    }
}