using UnityEngine;
using System.Collections;

public class DropMask : MonoBehaviour {

	public GameObject mask;
	public GameObject tears;
	public bool droped = false; 


	
	void Update () {
		if (!droped && Input.GetKeyDown("q") || !droped && Input.GetMouseButtonDown(1)){
		mask.SetActive(false);
		tears.SetActive(false);
		droped = true; 
		}
		else if (droped && Input.GetKeyDown("q") || droped && Input.GetMouseButtonDown(1)){
		mask.SetActive(true);
		tears.SetActive(true); 
		droped = false;

	
	}
}
}