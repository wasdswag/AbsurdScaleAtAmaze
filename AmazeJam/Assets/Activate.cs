using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

public GameObject tip;
public GameObject FPC;

public float distance = 5f;

		// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	if (Vector3.Distance (tip.transform.position, FPC.transform.position) < distance){
	tip.SetActive(true);}
	else if (Vector3.Distance (tip.transform.position, FPC.transform.position) > distance){

	tip.SetActive(false);
	} 

	
	}
}


