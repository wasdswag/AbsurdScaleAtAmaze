using UnityEngine;
using System.Collections;

public class TearsFill : MonoBehaviour {

	
	public float speed = 0.1f;	
	private bool movingUp = true;
	
	public float ymax = 0.1f;
	//public float ymin;

	
	// Use this for initialization
	void OnEnable () {
		transform.localPosition = new Vector3(0.02f, -1.2f, 0.77f);
		movingUp = true;


		}
	
	void Update () {
		if (movingUp) {
			transform.localPosition += Vector3.up * speed * Time.deltaTime;
		
	

		}
		float upEdgeOfFormation = transform.localPosition.y;
		if (upEdgeOfFormation > ymax){
		movingUp = false;
			
		}
		}
	void OnDisable(){
		transform.localPosition = new Vector3(0.02f, -1.2f, 0.77f);
		movingUp = false;


	}
		}
		
		
		
		
		

