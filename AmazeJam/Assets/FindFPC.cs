using UnityEngine;
using System.Collections;

public class FindFPC : MonoBehaviour {


AIDesigner.Brain b;
GameObject player;

	void Awake(){
	player = GameObject.Find("FPSController");
	transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
	b = GetComponent<AIDesigner.Brain>();
	b.SetConditionGroupMoveToObject("Chase enemies",  player);

	StartCoroutine (FixRotation());
	StartCoroutine (StopCheckRot());

	}



	// Use this for initialization
	IEnumerator FixRotation(){
	while (true){
	yield return new WaitForSeconds(0.0f);	
	transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);



	}


	}

	IEnumerator StopCheckRot(){

	while (true){

	yield return new WaitForSeconds(4.0f);	
	StopAllCoroutines();
	yield break;

	}
	}}


