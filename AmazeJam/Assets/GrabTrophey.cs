using UnityEngine;
using System.Collections;

public class GrabTrophey : MonoBehaviour {


private bool isActive = false;
public GameObject trophey;



	void OnTriggerEnter(Collider other) {
		if(other.tag == "trophey"){
		Debug.Log("TROPHEY");
		isActive = true;

		}

} 	void Update(){
		if (isActive && Input.GetMouseButtonDown(0)){
		Debug.Log ("MousePreesed");
		Destroy(trophey); 
		}

}
		}