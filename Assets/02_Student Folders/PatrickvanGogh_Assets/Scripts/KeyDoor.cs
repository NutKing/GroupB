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

    public void OpenDoor()
    {
            Door1.Translate(Vector3.forward * Time.deltaTime * speed);
            Door2.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
}
