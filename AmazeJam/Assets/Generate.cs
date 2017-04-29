using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

public Transform player;
Vector3 pos;

GameObject currentObject;
bool isgenerated;
public GameObject [] creations;


	// Use this for initialization
	void Start () {
//	InvokeRepeating("LaunchGen", 0f, f);
	StartCoroutine (GenerateObj());

	}

	IEnumerator GenerateObj(){
	while(true){
	yield return new WaitForSeconds(4f);
	pos = player.position + Vector3.forward * 100;

	currentObject = Instantiate(creations[Random.Range(0, creations.Length)], pos, Quaternion.identity) as GameObject;


	}



	}

}
