using UnityEngine;
using System.Collections;

public class CreepyDancer : MonoBehaviour {
	
	public float distance = 10f;
	public float checkInterval = 0.2f; // как часто проверять расстояние
	public bool isCheckDistance = true; // проверять ли вообще
	
	public bool isDancing = true; // танцует ли персонаж при старте сцены
	
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


		// при рождении объекта запускаем проверку дистанции раз в checkInterval секундorig:Spine2/mixamorig:Neck").GetComponent<LookAtMe> ();
		
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
				lookingScript.enabled = false;
			//	bodyRotScript.enabled = false;

				
				Debug.Log ("dancing");
				
				
			} // если танцуем и дистанция становится меньше нужной, замираем
			else if (isDancing && (Vector3.Distance (transform.position, player.position) < distance)) {
				animator.SetTrigger ("Idle");

				isDancing = false;
				lookingScript.enabled = true;
			//	bodyRotScript.enabled = true;
				
				Debug.Log ("looking");
			}
		}
		
	}
}
