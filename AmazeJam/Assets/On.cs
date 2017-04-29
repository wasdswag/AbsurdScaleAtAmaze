using UnityEngine;
using System.Collections;

public class On : MonoBehaviour {


	public GameObject Soffit1;
	public GameObject Soffit;





	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
       Soffit.SetActive(true);
	   Soffit1.SetActive(true);
		
    }
}
	
	}
