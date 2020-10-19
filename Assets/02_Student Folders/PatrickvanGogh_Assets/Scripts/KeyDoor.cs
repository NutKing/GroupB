using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public Transform Door1;
    public Transform Door2;
    public float speed = 2;
    public float z = 3;

    public void OpenDoor()
    {
            while (Door1.localPosition.z < z)
        {
                Door1.Translate(Vector3.forward * Time.deltaTime * speed);
                Door2.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
    }
}