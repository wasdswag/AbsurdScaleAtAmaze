using UnityEngine;
using System.Collections;

public class OnSinkEntered : MonoBehaviour {
	public GameObject Arm;


	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
      
	   Arm.SetActive(true);
		
    }
}
	
	}
