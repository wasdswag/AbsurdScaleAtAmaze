using UnityEngine;
using System.Collections;

public class LoverBehaviour : MonoBehaviour {
	
	public float distance = 10f;
	public float loversDistance = 6f;
	public float checkInterval = 0.2f; // как часто проверять расстояние
	public bool isCheckDistance = true; // провеklkрять ли вообще
	
	public bool isWalking = true; // танцует ли персонаж при старте сцены

	GameObject[] otherLovers; // ищем других нпс
	
	Transform player;
	Animator animator;
	LookAtMe lookingScript;
	//BodyRot bodyRotScript;
	
	void Start() {
		// название объекта FPS
		player = GameObject.Find ("FPSController").transform;
		animator = GetComponent<Animator> ();
		// путь к объекту со скриптом LookAtMe в иерархии объекта-персонажа
		lookingScript = transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck").GetComponent<LookAtMe> ();
		//bodyRotScript = GetComponent<BodyRot>();

		otherLovers = GameObject.FindGameObjectsWithTag("Respawn"); // находим любовников

		// при рождении объекта запускаем проверку дистанции раз в checkInterval секундorig:Spine2/mixamorig:Neck").GetComponent<LookAtMe> ();
		
		StartCoroutine ( SlowDistanceCheck() );
	}
	
	
	IEnumerator SlowDistanceCheck() {
		while (isCheckDistance) {
			// ждем checkInterval секунд
			yield return new WaitForSeconds ( checkInterval );
			

			// сравниваем расстояния
			
			// если не танцуем и дистанция становится больше нужной, начинаем танцевать
			if (!isWalking && (Vector3.Distance (transform.position, player.position) > distance)) {
				animator.SetTrigger ("Walk");
				isWalking = true;
				lookingScript.enabled = false;
		

				
				Debug.Log ("walking");
				
				
			} // если танцуем и дистанция становится меньше нужной, замираем
			else if (isWalking && (Vector3.Distance (transform.position, player.position) < distance)) {
				animator.SetTrigger ("Idle");

				isWalking = false;
				lookingScript.enabled = true;
		
				
				Debug.Log ("looking");
			}

			for (int i = 0; i < otherLovers.Length ; i++ ) { 
			if (Vector3.Distance(transform.position, otherLovers[i].transform.position) < loversDistance
			&& transform.position.x > otherLovers[i].transform.position.x) {
			animator.SetTrigger ("StepRight");}
			if (Vector3.Distance(transform.position, otherLovers[i].transform.position) < loversDistance
			&& transform.position.x < otherLovers[i].transform.position.x){
			animator.SetTrigger ("StepLeft");
			}
			else if (Vector3.Distance(transform.position, otherLovers[i].transform.position) > loversDistance){
			animator.SetTrigger ("Walk");
			}

			 



		}
		
	}}}

