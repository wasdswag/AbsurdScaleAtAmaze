using UnityEngine;
using System.Collections;

public class RayArrayGenerator : MonoBehaviour {

	

	public GameObject rays;
	public float spawnTime = 0.01f;
	public float spawnDelay = 2f;
	public float lifeTime = 3f;
	private GameObject rayClone;

	void Start(){
	InvokeRepeating ("Ray", spawnDelay, spawnTime );
		
		}

	// Update is called once per frame
	void Ray () {
		
	rayClone = Instantiate(rays, transform.position, Quaternion.identity) as GameObject;
	Destroy (rayClone, lifeTime);
		
		}
		
	
	
}
	
