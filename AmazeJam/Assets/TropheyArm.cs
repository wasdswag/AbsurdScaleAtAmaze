using UnityEngine;
using System.Collections;

public class TropheyArm : MonoBehaviour {

	public GameObject Arm2;
	Ray ray;
	private RaycastHit hit;
	public float rate = 0.2f;
	private bool isActive = true;

	void Awake(){

	StartCoroutine( Arm() ); 

	}

	IEnumerator Arm(){
	while (isActive){
	yield return new WaitForSeconds (rate);
	ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
	if (Physics.Raycast(ray, out hit, 6f) && hit.collider.tag == "Arm") {
	Arm2.SetActive(true);
	}
	else { Arm2.SetActive(false); }}}
	}

