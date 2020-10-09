using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeCollider : MonoBehaviour
{
    public MeshCollider col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeCol() {
        col.enabled = false;
    }
}
