using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] public KeyType keyType;

    public enum KeyType
    {
        Iron,
        Gold
    }
    public KeyType GetKeyType()
    {
        return keyType;
    }
}
