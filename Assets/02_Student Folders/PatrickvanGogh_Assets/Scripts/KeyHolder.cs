using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour {
        private List<Key.KeyType> keyList;

        private void Awake() {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType) {
        keyList.Add(keyType);
        Debug.Log("Key picked up" + keyType); 
        // Key pickup
    }

    public void RemoveKey(Key.KeyType keyType) {
        keyList.Remove(keyType);
        Debug.Log("Key used" + keyType);
        // Key is destroyed
    }
    
    public bool ContainsKey (Key.KeyType keyType) {
        return keyList.Contains(keyType);
    }
   
    private void OnTriggerEnter(Collider collider) {
        Debug.Log("Enter Door");
        Key key = collider.GetComponent<Key>();
        if (key != null) {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
            // Player picks up key and it's destroyed in-game
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                // Player is holding the relevant key
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }

    }
}
