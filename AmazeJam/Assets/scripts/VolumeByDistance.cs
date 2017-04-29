using UnityEngine;
using System.Collections;

public class VolumeByDistance : MonoBehaviour {

	// расстояние, с которого громкость начинает затухать
	public float startDistance = 50f;
	// расстояние, на котором доходит до 0
	public float endDistance = 20f;

	Transform player;
	AudioSource aud;

	float diffDistance; // храним разницу между стартом затухания и концом

	void Start() {
		// название объекта FPS
		player = GameObject.Find ("FPSController").transform;

		aud = GetComponent<AudioSource> ();
		diffDistance = startDistance - endDistance;
	}
	

	void Update () {

		float d = Vector3.Distance (transform.position, player.position);

		if ( d < startDistance  ) {
			aud.volume = Mathf.Lerp( 0,1f, (d-endDistance)/ diffDistance  );
		}
	
	}
}
