/*
	Convenient spawn tool for prototyping or actual game.
	Place this on a blank gameobject, anywhere in scene that you want to spawn object.

	Insert object into 'spawnThis'

	When it detects the created object is destroyed, it will spawn another at same loc.

		(c) 2014-2017 AIBotSystem.com
		aibotsystem@gmail.com

*/

using UnityEngine;
using System.Collections;

public class SpawnerTool : MonoBehaviour {

	public GameObject spawnThis;
	public float checkIfDestroyedTime = 3f;	// greater than 0
	public bool autoRespawnWhenDestroyed = true;
	private GameObject spawnedObject = null;

	// Use this for initialization
	void Start () {
		if (spawnThis != null){
			Invoke("FirstSpawn", checkIfDestroyedTime);
		}
	}
	

	void FirstSpawn(){
		Spawn();
		InvokeRepeating("CheckIfDestroyed", checkIfDestroyedTime, checkIfDestroyedTime);
	}

	void CheckIfDestroyed(){
		if (spawnedObject == null){
			if (autoRespawnWhenDestroyed){
				Spawn();	
			}
		}
	}

	void Spawn(){
		spawnedObject = Instantiate(spawnThis, transform.position, transform.rotation) as GameObject;
	}

}
