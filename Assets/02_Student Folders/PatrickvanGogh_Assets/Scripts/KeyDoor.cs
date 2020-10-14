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

    bool isOpen = false;
    bool opening = false;

    public float speed = 5;
    public float z = 2f;

    public Transform Door1;
    public Transform Door2;

    Vector3 Door1DefPos = new Vector3(0, 0, 0);
    Vector3 Door2DefPos = new Vector3(0, 0, 1.5f);

    public void OpenDoor()
    {
        {
            if (opening && Door1.localPosition.z < z)
            {
                Door1.Translate(Vector3.forward * Time.deltaTime * speed);
                Door2.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
            else if (opening)
            {
                opening = false;
                // soundEffect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                opening = true;
                Debug.Log("Open Button Door");
            }
        }
    }
}
