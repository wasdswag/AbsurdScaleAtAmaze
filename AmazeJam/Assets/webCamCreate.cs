using UnityEngine;
using System.Collections;

public class webCamCreate : MonoBehaviour {

	public GameObject mirror;
	public GameObject wolf;
	Transform player;
	public float distance = 10f;



	void Start () {
	player = GameObject.Find ("FPSController").transform;

	WebCamDevice[] devices = WebCamTexture.devices;
	int cameraCount = devices.Length;
	if (cameraCount > 0) {
	InvokeRepeating("Webcam", 0, 1);}
	else {
	InvokeRepeating("Werewolf", 0, 1);

	}


	}

	void Webcam () {

	if (Vector3.Distance (transform.position, player.position) < distance) {
	mirror.SetActive(true);

	}	

	}


	void Werewolf () {
	if (Vector3.Distance (transform.position, player.position) < distance) {
	wolf.SetActive(true);
	if (Vector3.Distance (transform.position, player.position) > distance) {
	wolf.SetActive(false);
	}

	}	


	}
}
