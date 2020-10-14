using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyholder : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(Key.KeyType keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keytype);
    }

    private void OntriggerEnter(Collider collider)
    {
        Key key = collider.GetComponent<key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
    }
}
