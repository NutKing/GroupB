using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDown : MonoBehaviour
{
    public Transform elevator;

    private bool goDown = false;
    private bool playOnce = true;

    private float timer = 17.4f;

    public float speed = 2f;

    public AudioSource sound1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goDown && timer > 0f) {
            elevator.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (timer <= 0f && playOnce) {
            playOnce = false;
            sound1.Play();
        }
    }

    public void moveDown() {
        goDown = !goDown;
    }
}
