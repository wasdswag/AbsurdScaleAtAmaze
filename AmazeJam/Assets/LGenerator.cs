using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGenerator : MonoBehaviour {

public GameObject [] large;
Transform fpc;
int index;
GameObject currentObject;
bool isgenerated;

	// Use this for initialization
	void Start () {
	fpc = GameObject.Find("FPSController").transform;
	index = Random.Range(0, large.Length);
	isgenerated = false;
	}
	
	// Update is called once per frame
	void Update () {
	float d = Vector3.Distance(fpc.position, transform.position);
	if (d  >600f){
	isgenerated = true;

	}
	else {
	isgenerated = false;
	}


	if (isgenerated){
	currentObject = Instantiate(large[index]) as GameObject;
	currentObject.transform.parent = gameObject.transform;

	isgenerated = false;


	}





	}
}
