using UnityEngine;
using System.Collections;

public class GeneratorTransform : MonoBehaviour {

	public float width = 10f;
	
	public float speed = 5f;	
	private bool movingRight = true;
	
	public float xmax;
	public float xmin;
	

	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else {
			transform.position += Vector3.left * speed * Time.deltaTime;  
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		
		if (leftEdgeOfFormation < xmin){
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax){
			movingRight = false;
			
		}
		
		
		
		
		
	}	
	
}
