using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    [SerializeField]
    GameObject Deur;
    public AudioSource Sound;
    public ParticleSystem Partpart;

    public void OnTriggerEnter(Collider other)
    {
        Deur.transform.position += new Vector3(0, -5.3f, 0);
        Sound.Play();
        Partpart.Play();
    }
}