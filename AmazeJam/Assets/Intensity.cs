using UnityEngine;
using System.Collections;

public class Intensity : MonoBehaviour {

Light light;
public float step = 0.1f;


	// Use this for initialization
	void OnEnable () {
	light = GetComponent<Light>();
	light.intensity = 0f;

	
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity += step * Time.deltaTime;
		//if (light.intensity >= 6f){
		//light.intensity = 6f;
		//}  
	
	}
}
