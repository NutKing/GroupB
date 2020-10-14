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
    }

    public void RemoveKey(Key.KeyType keyType) {
        keyList.Remove(keyType);
        Debug.Log("Key used" + keyType);
    }
    
    public bool ContainsKey (Key.KeyType keyType) {
        return keyList.Contains(keyType);
    }
   
    private void OnTriggerEnter(Collider collider) {
        Key key = collider.GetComponent<Key>();
        if (key != null) {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
    }
}
