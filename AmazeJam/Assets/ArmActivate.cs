using UnityEngine;
using System.Collections;

public class ArmActivate : MonoBehaviour {

	public GameObject arm;
	//public GameObject house;
	//public GameObject NPC;
	//public GameObject Sink;
	public GameObject FPC;
	public GameObject mirror;
	public GameObject light;

	public float distance = 12f;



	void Update () {
	if (Vector3.Distance (mirror.transform.position, FPC.transform.position) < distance){
	arm.SetActive(true);
	light.SetActive(true); 

	}

	else if (Vector3.Distance (mirror.transform.position, FPC.transform.position) > distance){
	arm.SetActive(false);
	light.SetActive(false);
	} 


	
	}
}