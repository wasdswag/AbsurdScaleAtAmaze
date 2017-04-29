using UnityEngine;
using System.Collections;

public class trezvost : MonoBehaviour {

float drunks;
public float trezvoSpeed;
Renderer rend;

	// Use this for initialization
	void Start () {
	rend = GetComponent<Renderer>();
	rend.material.shader = Shader.Find("FX/Glass/Stained BumpDistort");


	
	}
	
	// Update is called once per frame
	void Update () {

	drunks = rend.material.GetFloat("_BumpAmt");
	if (drunks > 0f){
	rend.material.SetFloat("_BumpAmt", Mathf.MoveTowards(drunks, 0f, trezvoSpeed+0.01f)  );
	}
	if (drunks < 0f){
	rend.material.SetFloat("_BumpAmt", 0f);
	}
	}
}
