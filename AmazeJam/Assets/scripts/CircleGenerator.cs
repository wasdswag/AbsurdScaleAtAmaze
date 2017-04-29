using UnityEngine;
using System.Collections;

public class CircleGenerator : MonoBehaviour {

	public GameObject linePrefab;
	public float spawnTime = 3f;
	public float lifeTime = 5f;
	private GameObject  lineClone;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Line", 0, spawnTime  );
		
	}
	
	// Update is called once per frame
	void Line () {
		
	lineClone = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject ;
	//lineClone.transform.parent = GameObject.Find("Main Camera").transform;  
	Destroy (lineClone, lifeTime);
		
		
	}
	
}