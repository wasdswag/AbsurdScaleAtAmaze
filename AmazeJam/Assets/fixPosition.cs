using UnityEngine;
using System.Collections;

public class fixPosition : MonoBehaviour {


	public float distance = 10f;
	public float Y1 = 7.97f;
	public float Y2 = 6.97f;


	public bool isActive = true; // активен ли скрипт
	public float rate = 0.2f;
	
	Transform player;

	
	void Start() {
		// название объекта FPS
		player = GameObject.Find ("FPSController").transform;
		StartCoroutine (CheckFixDistance());
		}
		IEnumerator CheckFixDistance(){
		while (isActive){
		yield return new WaitForSeconds(rate);
	
			if (Vector3.Distance (transform.position, player.position) > distance) {
			transform.position = new Vector3 (this.transform.position.x, Y1, this.transform.position.z); 
		
			} 
			else if (Vector3.Distance (transform.position, player.position) < distance) {
			transform.position = new Vector3 (this.transform.position.x, Y2, this.transform.position.z); 
	

				
			}
		}
		
	}}