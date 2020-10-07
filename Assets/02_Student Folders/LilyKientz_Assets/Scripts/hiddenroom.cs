using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class hiddenroom : MonoBehaviour
{
    public float speed = 1f;
    bool isOpen = false;
    bool isOnNav = false;
    float timer = 1f;
    float timerLength = 1f;

    public Transform hatch1;
    public Transform hatch2;
    public Transform lift;
    public Collider hitbox;
    public Transform robot;
    public GameObject robot1;

    
    // Start is called before the first frame update
    void Start()
    {
        robot1.GetComponent<NavMeshAgent>().enabled = false;
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
        if (timer <= 0f && isOnNav == false) 
        { 
            robot1.GetComponent<NavMeshAgent>().enabled = true;
            isOnNav = true;
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
