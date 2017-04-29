using UnityEngine;
using System.Collections;

public class EmissionDelay : MonoBehaviour {

	public float startDistance = 50f;
	public float endDistance = 20f;
	float diffDistance;

	public bool isActive = false;
	public float delay = 5f;


	[Range(0f,1f)]
	public float r = 0.8f;
	[Range(0f,1f)]
	public float g = 0.3f;
	[Range(0f,1f)]
	public float b = 0.5f;





	public Renderer mask;
	Color emiss;
	GameObject[] npc; 


	void Start () {
	npc = GameObject.FindGameObjectsWithTag("Respawn");
	diffDistance = startDistance - endDistance;
	mask = GetComponentInChildren<Renderer>(); 
	emiss = mask.material.color;

	}

	void Update () {
	for (int i = 0; i < npc.Length; i++){
	float d = Vector3.Distance (transform.position, npc[i].transform.position);
	if (d < startDistance) { 
	Warning();
	if(isActive && d < startDistance) {
		emiss = new Color(Mathf.Lerp(r, 0f, (d-endDistance)/ diffDistance), Mathf.Lerp(g, 0f, (d-endDistance)/ diffDistance), Mathf.Lerp(b, 0f, (d-endDistance)/ diffDistance));
		mask.material.SetColor("_EmissionColor", emiss);
		isActive = false;

		}
		}

	}
	}

	void Warning(){
		StartCoroutine (TimeToGo() );
	}

	
		IEnumerator TimeToGo() {
		yield return new WaitForSeconds (delay);
		isActive = true;

	}
}