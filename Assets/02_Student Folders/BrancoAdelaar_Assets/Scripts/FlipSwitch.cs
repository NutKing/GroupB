using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : MonoBehaviour
{
    float speed = 0.5f;
	float timer;
	float timerLength = 0.5f;
	bool lowering = false;
	bool rising = false;
	Vector3 defaultButton = new Vector3(0f,0f,0f);
	public Transform button;
	
	
	bool isTriggered = false;
    
	Collider hitBox;    
	public Light indicator;
	public GameObject[] doors;
	
    // Start is called before the first frame update
    void Start()
    {
       hitBox = GetComponent<Collider>();
	   
    }

    // Update is called once per frame
    void Update()
    {
        if(lowering && timer > 0f) {
			button.Translate(-Vector3.up * speed * Time.deltaTime);
			timer -= Time.deltaTime;
		} else if(lowering && timer <= 0f) {
			lowering = false;
			timer = timerLength;
		}
		
		if (rising && timer > 0f) {
			button.Translate(Vector3.up * speed * Time.deltaTime);
			timer -= Time.deltaTime;
		} else if (rising && timer <= 0f) {
			rising = false;
			timer = timerLength;
			button.localPosition = defaultButton;
		}
    }
    
    void OnTriggerEnter (Collider other) {
		PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
		if(player == null) {
			return;
		}
		
		isTriggered = !isTriggered;
		lowering = isTriggered;
		rising = !isTriggered;
		timer = timerLength;
		indicator.enabled = !isTriggered;
		foreach(GameObject door in doors) {
			IDoor gate = door.GetComponent<IDoor>();
			gate.OpenCloseDoor();
		}
    }
}
