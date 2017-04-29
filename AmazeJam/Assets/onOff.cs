using UnityEngine;
using System.Collections;

public class onOff : MonoBehaviour {

	public GameObject Soffit1;
	public GameObject Soffit;





	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
       Soffit.SetActive(false);
	   Soffit1.SetActive(false);
		
    }
}
	
	}

