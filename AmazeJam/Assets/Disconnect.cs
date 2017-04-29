using UnityEngine;
using System.Collections;



public class Disconnect : MonoBehaviour {

private bool isActive = false;



	void OnTriggerEnter(Collider other) {
		if(other.tag == "Arm"){
		Debug.Log("testARM");
		isActive = true;

		}
		}
	void OnTriggerExit(Collider other){
		isActive = false;
		} 

 	void Update(){
		if (isActive && Input.GetMouseButtonDown(0)){
		Debug.Log ("MousePreesed"); 
		Application.LoadLevelAsync (1);}

}
		}