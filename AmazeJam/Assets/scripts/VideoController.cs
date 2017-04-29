using UnityEngine;
using System.Collections;

public class VideoController : MonoBehaviour {

	public MovieTexture movieTexture;

	// Use this for initialization
	void Start () {
movieTexture.loop = true;
GetComponent<Renderer>().material.mainTexture = movieTexture;movieTexture.Play ();
}
	
	}
	
