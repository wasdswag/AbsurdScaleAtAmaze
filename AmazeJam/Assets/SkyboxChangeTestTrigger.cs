using UnityEngine;
using System.Collections;

public class SkyboxChangeTestTrigger : MonoBehaviour {

	// расстояние, с которого громкость начинает затухать
	float startDistance = 30f;
	// расстояние, на котором доходит до 0
	float endDistance = 20f;

	float sunStartDist = 20f;
	float sunEndDist = 2f;
//	public GameObject txt;
	Transform player;
	//public GameObject light;

	Light dirlight; 
	//GameObject dirlight;

	Light spot;
	Transform sun;
	float inc = 0.01f;
	//float incValue;
	//Light spot;
	bool ondist;


	//public GameObject clouds1;
	//public GameObject clouds2;

	float diffDistance;
	float sunDiff;


	void Start(){
		player = GameObject.Find ("FPSController").transform;
		//clouds = GetComponent<Ani>();
		diffDistance = startDistance - endDistance;
		sunDiff = sunStartDist - sunEndDist;
		//light.SetActive(false); 
		dirlight = GameObject.Find("Directional Light").GetComponent<Light>();
		dirlight.intensity = 2f; 
//		spot = GameObject.Find("mixamorig:Hips/mixamorig:Spine/spot").GetComponent<Light>();
		sun = GameObject.Find("Directional Light").transform;




	}

void Update(){


		float d = Vector3.Distance (transform.position, player.position);

		float incValue = Mathf.Clamp(inc, 1f,3.3f);
		inc = incValue;
		if (d < 20f){
		inc += 0.2f * Time.deltaTime; 
			sun.Rotate (Vector3.left * Mathf.Lerp(20f, 0.01f, (d-sunEndDist)/sunDiff) * Time.deltaTime);

		}

		if (d <= startDistance && d >= 20f){
		inc = Mathf.Lerp(inc, 1.00f, (d-endDistance)/ diffDistance);
		}



		RenderSettings.skybox.SetFloat("_AtmosphereThickness",  inc);
		//dirlight.intensity = Mathf.Lerp(0.001f, 2.00f, (d-endDistance)/diffDistance);

		}


			//		spot.intensity = Mathf.Lerp(8.00f, 0.001f, (d-endDistance)/diffDistance);Distance
		//spot.enabled = true;
		//sun.rotation =  new Vector3 (Mathf.Lerp(50f, 200f, (d-endDistance)/diffDistance), transform.rotation.y, transform.rotation.z);

//	txt.SetActive(true); 
		//light.SetActive(true);
		//spot.SetActive(true); 
		 
	
		
	//	else if ( d > startDistance) { 
//		txt.SetActive(false);
		//v/.zdspot.intensity = 0f;
		//spot.enabled = false;
		//light.SetActive(false); 
		//spot.SetActive(false); 
		//}

		}

      
		


