using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour {





	// Use this for initialization
	void Start () {

		WebCamDevice[] devices = WebCamTexture.devices;
        for( var i = 0 ; i < devices.Length ; i++ )
        Debug.Log(devices[i].name);        
    
		WebCamTexture webcamTexture = new WebCamTexture(128,64,24);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
		webcamTexture.Stop();
		webcamTexture.Play();
	}




}
