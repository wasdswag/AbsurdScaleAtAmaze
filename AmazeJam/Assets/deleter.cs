using UnityEngine;
using System.Collections;



public class deleter : MonoBehaviour {


	public GameObject []  target ;

	// Use this for initialization
	void Update () {
	for (int i = 0; i < target.Length; i++){
	Destroy(target[i]);

	}
	
	}}
	
