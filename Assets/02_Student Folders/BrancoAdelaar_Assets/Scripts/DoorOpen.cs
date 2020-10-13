using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IDoor
{

    float speed = 3f;
    bool isOpen = false;
	bool opening = false;
	bool closing = false;
    float timer;
	float timerLength = 0.5f;
	Vector3 door1Default = new Vector3(0,0,0);
	Vector3 door2Default = new Vector3(0,0,1.5f);
	
	public bool startIsOpen = false;

    public Transform door1;
    public Transform door2;
    public AudioSource doorSound;
	
    // Start is called before the first frame update
    void Start()
    {
        isOpen = startIsOpen;
		if(isOpen) {
			door1.Translate(-Vector3.forward * 1.55f);
			door2.Translate(Vector3.forward * 1.55f);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(opening && timer > 0f) {
			door1.Translate(-Vector3.forward * Time.deltaTime * speed);
			door2.Translate(Vector3.forward * Time.deltaTime * speed);
			timer -= Time.deltaTime;
		} else if (opening && timer <= 0f) {
			opening = false;
			timer = timerLength;
		}
		
		if(closing && timer > 0f) {
			door1.Translate(Vector3.forward * Time.deltaTime * speed);
			door2.Translate(-Vector3.forward * Time.deltaTime * speed);
			timer -= Time.deltaTime;
		} else if (closing && timer <= 0f) {
			closing = false;
			timer = timerLength;
			door1.localPosition = door1Default;
			door2.localPosition = door2Default;
		}
		
    }
	
	public void OpenCloseDoor() {
		if(!isOpen) {
			opening = true;
			closing = false;
			isOpen = true;
			doorSound.Play();
		} else {
			closing = true;
			opening = false;
			isOpen = false;
			doorSound.Play();
		}
		timer = timerLength;
		
	}
}
