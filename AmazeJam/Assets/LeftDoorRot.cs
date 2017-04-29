using UnityEngine;
using System.Collections;

public class LeftDoorRot : MonoBehaviour {
float rotValue;
public float wideOpen = 30f;
public float speed = 100f;
public float minRot = -1f;
public float maxRot = 140f;
public float yRot = 0f;


	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		rotValue = Time.deltaTime * speed;

		yRot = Mathf.Clamp(yRot, minRot, maxRot);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot+rotValue, transform.eulerAngles.z);
		//transform.Rotate(0, rotValue, 0);
//		if (rotValue >= 90f ){
//		speed = 0f;
//
//		}

	}
}
