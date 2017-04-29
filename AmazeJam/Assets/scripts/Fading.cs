﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Fading : MonoBehaviour {

public float fadeInTime;

private Image fadePanel;
private Color currentColor = Color.black ;


	// Use this for initialization
	void Start () {
	fadePanel = GetComponent<Image>(); 
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.timeSinceLevelLoad < fadeInTime ){
		float alphaChange = Time.deltaTime / fadeInTime;
		currentColor.a -= alphaChange;
		fadePanel.color = currentColor;     
	} else {
			gameObject.SetActive(false);  
		}
	}
}
