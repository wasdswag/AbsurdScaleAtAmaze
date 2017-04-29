using UnityEngine;
using System.Collections;

public class DialogueActivator : MonoBehaviour {
	// текст возникает с этой дистанции
	public float startDistance = 50f;
	public float endDistance = 20f;
	public GameObject txt;
	Transform player;


	float diffDistance;


	void Start(){
		player = GameObject.Find ("FPSController").transform;
		diffDistance = startDistance - endDistance;





	}

void Update(){

		float d = Vector3.Distance (transform.position, player.position);
		if ( d < startDistance) {
	
	txt.SetActive(true); 

		 
	
		}
		else if ( d > startDistance) { 
		txt.SetActive(false);

			 
	

		}
		}

		}

      
		

