using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {

	public float distance = 10f;
	public float checkInterval = 0.2f; // как часто проверять расстояние
	public bool isCheckDistance = true; // проверять ли вообще
	
	public bool isDancing = true; // танцует ли персонаж при старте сцены
	
	Transform player;
	Animator animator;

	
	void Start() {
		// название объекта FPS
		player = GameObject.Find ("FPSController").transform;
		animator = GetComponent<Animator> ();



		StartCoroutine ( SlowDistanceCheck() );
	}
	
	
	IEnumerator SlowDistanceCheck() {
		while (isCheckDistance) {
			// ждем checkInterval секунд
			yield return new WaitForSeconds ( checkInterval );
			
			// Debug.Log (Vector3.Distance (transform.position, player.position) );
			
			// сравниваем расстояния
			
			// если не танцуем и дистанция становится больше нужной, начинаем танцевать
			if (!isDancing && (Vector3.Distance (transform.position, player.position) > distance)) {
				animator.SetTrigger ("Dance");
				isDancing = true;
			

				
		
				
				
			} // если танцуем и дистанция становится меньше нужной, замираем
			else if (isDancing && (Vector3.Distance (transform.position, player.position) < distance)) {
				animator.SetTrigger ("Idle");
				isDancing = false;

				
			
			}
		}
		
	}
}
