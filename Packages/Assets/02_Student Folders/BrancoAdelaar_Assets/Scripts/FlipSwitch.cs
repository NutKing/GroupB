using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : MonoBehaviour
{
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
        
    }
    
    void OnTriggerEnter (Collider other) {
		PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
		if(player == null) {
			return;
		}
		
		isTriggered = !isTriggered;
		indicator.enabled = !isTriggered;
		foreach(GameObject door in doors) {
			IDoor gate = door.GetComponent<IDoor>();
			gate.OpenCloseDoor();
		}
    }
}
