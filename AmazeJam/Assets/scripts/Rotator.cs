using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

//public float speed = 1f;
//public GameObject FPC;
public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	//float discodist = Vector3.Distance(FPC.transform.position, transform.position);

		transform.Rotate (Vector3.up * speed * Time.deltaTime); 
		//transform.Rotate(0,0,Time.deltaTime);
	//	transform.position = Vector3.up / discodist * Time.deltaTime;
	}
}
