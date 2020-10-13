using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStalactite : MonoBehaviour
{
    private bool goDown = false;
    private float timer = 0.9f;
    private bool disabled = false;
    public float speed = 2f;

    public Transform stalactite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goDown && timer > 0f) {
            stalactite.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
    }

    public void setFall() {
        if (!disabled) {
            disabled = true;
            goDown = true;
        }
    }
}
