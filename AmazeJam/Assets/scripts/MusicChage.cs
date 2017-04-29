using UnityEngine;
using System.Collections;

public class MusicChage : MonoBehaviour {

private AudioSource music;



public float mDist = 0.001f;
public float pitchStep = 60f;


public GameObject FPC;
public GameObject Dinamic; 

	

private float clamp;

public float lowPitch = 0.3f;
public float highPitch = 1.0f;


	// Use this for initialization
	void Start () {

		music = Dinamic.GetComponent<AudioSource>();

		//rot = stroboscope.GetComponent<Rotator>(); 



	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(FPC.transform.position, Dinamic.transform.position);
		//Debug.Log(dist);

		clamp = Mathf.Lerp(lowPitch, highPitch, dist/pitchStep); 
		music.pitch = clamp;

		if (clamp <= 0.4f) { music.pitch = 0.4f;}



		}

	}
	

