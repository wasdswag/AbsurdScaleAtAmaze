using UnityEngine;
using System.Collections;

public class Theatre : MonoBehaviour {


	public GameObject theatre;
	public GameObject house;
	public GameObject NPC;
	public GameObject Sink;
	public GameObject FPC;
	public GameObject mirror;
	public GameObject light;

	public float distance = 2f;



	void Update () {
	if (Vector3.Distance (theatre.transform.position, FPC.transform.position) < distance){
	house.SetActive(false);
	NPC.SetActive(false);
	 

	}

	else if (Vector3.Distance (theatre.transform.position, FPC.transform.position) > distance){
	house.SetActive(true);
	NPC.SetActive(true);
	} 


	
	}
}