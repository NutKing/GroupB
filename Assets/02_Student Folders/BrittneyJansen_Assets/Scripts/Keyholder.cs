using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyholder : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keylist = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(Key.KeyType keyType)
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType)
    }

    public bool ContainsKey(Key.Keytype keytype)
    {
        return keyList.Contains(keytype);
    }

    private void OntriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
    }
}
