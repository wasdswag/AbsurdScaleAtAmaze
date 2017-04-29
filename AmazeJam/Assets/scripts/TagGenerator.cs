using UnityEngine;
using System.Collections;

public class TagGenerator : MonoBehaviour {

	public float numTags;	
	public GameObject[] tags = new GameObject[16] ;
	public float spawnTime = 3f;
	public float spawnDelay = 3f;
	public float lifeTime = 5f;
	private GameObject[] tagsGenerated; 
	

	
	
	// Use this for initialization
	void Start () {
	
	
			
		InvokeRepeating ("Tag", spawnDelay, spawnTime );
		
		}
	

	
	// Update is called once per frame
	void Tag () {
		
		GameObject tagClone = Instantiate(tags[Random.Range (0, tags.Length)], transform.position, Quaternion.identity) as GameObject;
	
	Destroy (tagClone, lifeTime);
		
		}
		
	
	
}