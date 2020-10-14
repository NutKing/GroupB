using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Brittney : MonoBehaviour
{

    [SerializeField] private KeyType Keytype;

    public enum KeyType
    {
        Purple,
        Blue
    }

    public KeyType GetKeyType()
    {
        return KeyType; 
    }
}
