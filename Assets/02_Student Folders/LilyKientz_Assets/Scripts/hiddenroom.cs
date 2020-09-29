using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class hiddenroom : MonoBehaviour
{
    public float speed = 1f;
    bool isOpen = false;
    float timer;
    float timerLength = 1f;

    public Transform hatch1;
    public Transform hatch2;
    public Transform lift;
    public Collider hitbox;
    public Transform robot;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && timer > 0f) 
        { 
            hatch1.Translate(Vector3.left * Time.deltaTime * speed);
            hatch2.Translate(Vector3.right * Time.deltaTime * speed);
            lift.Translate(Vector3.up * Time.deltaTime * speed * 2);
            robot.Translate(Vector3.up * Time.deltaTime * speed * 2);
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
