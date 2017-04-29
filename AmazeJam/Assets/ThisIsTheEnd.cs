using UnityEngine;
using System.Collections;

public class ThisIsTheEnd : MonoBehaviour {

	public Transform FPC;
	public GameObject house;
	//public float ofset;
	//private float SinkPos;
	//public float speed = 0.002f

	//public float speed;

	void Start () {
		


	}

	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (transform.position, FPC.position);



		transform.position = new Vector3 (386.91f*(dist/100),-9.04f,100.77f); 



		}}