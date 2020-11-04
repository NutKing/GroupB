﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaActivator_salactite : MonoBehaviour
{
    private bool inRange2 = false;
    private bool activated = false;
    private bool disabled = false;
    public GameObject Player2;
    public PlayerCharacterController PlayerCC;
    public Transform stalactite;
    public float timer = 1.3f;
    public float speed = 20f;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange2 && activated && timer > 0f) {
            stalactite.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (inRange2 && activated && timer <= 0f) {
            activated = false;
            PlayerCC.maxSpeedOnGround = 6f;
            PlayerCC.maxSpeedInAir = 6f;
            sound1.Stop();
            sound2.Play();
            sound2.time = 0.3f;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = true;
            if(activated) {
                sound1.Play();
                sound3.Play();
                sound1.time = 1f;
                PlayerCC.maxSpeedOnGround =  0.0001f;
                PlayerCC.maxSpeedInAir = 0.0001f;
            }
        }
    }

    private void OnTriggerExit(Collider collision) {
        if(collision.gameObject == Player2) {
            inRange2 = false;
        }
    }

    public void activate() {
        if (!disabled) {
            activated = true;
            disabled = true;
        }
    }
}
