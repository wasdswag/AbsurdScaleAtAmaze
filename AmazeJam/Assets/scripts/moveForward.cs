using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.position += Vector3.left * speed * Time.deltaTime; 
	
	}
}
