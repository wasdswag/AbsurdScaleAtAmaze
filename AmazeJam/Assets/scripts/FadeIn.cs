using UnityEngine;
using System.Collections;
using UnityEngine.UI; 


public class FadeIn : MonoBehaviour {
private Image fading;
public float alphaS;
public float duration;



	// Use this for initialization
	void Start () {
	fading = GetComponent<Image>();
	fading.CrossFadeAlpha(alphaS, duration, false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
