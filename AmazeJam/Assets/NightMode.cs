using UnityEngine;
using System.Collections;

public class NightMode : MonoBehaviour {

	public float startDistance = 50f;
	public float endDistance = 20f;
	float diffDistance;


Light light;
GameObject[] npc; 
Transform player;




	// Use this for initialization
	void Start () {
	npc = GameObject.FindGameObjectsWithTag("Respawn");
	diffDistance = startDistance - endDistance;

	player = GameObject.Find ("FPSController").transform;
	light = GetComponent<Light>();
	light.intensity = 2f;


	
	}

	// Update is called once per frame
	void Update () {
		npc = GameObject.FindGameObjectsWithTag("Respawn");
		for (int i = 0; i < npc.Length; i++){
		float d = Vector3.Distance (npc[i].transform.position, player.position);
//		Debug.Log(d + "is here");
		if (d < startDistance) {
		light.intensity = Mathf.Lerp(0.001f, 3.00f, (d-endDistance)/diffDistance);
		}
		}}
		}




