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
    public AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goDown && timer > 0f) {
            sound2.volume = Mathf.Lerp(0.2f, 0f, (17.4f - timer) / 17.4f);
            elevator.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        if (timer <= 0f && playOnce) {
            playOnce = false;
            sound2.Stop();
            sound1.Play();
            sound1.time = 0.7f;
        }
    }

    public void moveDown() {
        goDown = !goDown;
        if (goDown && playOnce) {
            sound2.Play();
            sound2.time = 1f;
        }
        else if (playOnce) {
            sound2.Stop();
        }
        
    }
}
