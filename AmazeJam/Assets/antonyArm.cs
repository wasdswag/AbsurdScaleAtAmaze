using UnityEngine;
using System.Collections;

public class antonyArm : MonoBehaviour {

	public GameObject FPC;
	public GameObject Anton;
	public GameObject arm;

	public float distance = 12f;



	void Update () {
	if (Vector3.Distance (Anton.transform.position, FPC.transform.position) < distance){
	//Debug.Log ("COM"); 
	arm.SetActive(true);
	}
	else if (Vector3.Distance (Anton.transform.position, FPC.transform.position) > distance){
//		Debug.Log ("outCOM"); 
	arm.SetActive(false);
	} 


	
	}
}