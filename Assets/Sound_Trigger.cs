using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Trigger : MonoBehaviour
{
    [SerializeField] AudioSource TriggerSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            TriggerSound.Play();
        }
    }
}