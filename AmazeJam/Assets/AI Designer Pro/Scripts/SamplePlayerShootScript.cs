/*

	Simple script to allow player to shoot objects forward.
	Set a bullet type (the same ones the AI uses) into
	the "bulletType" slot.

	See FPS demo on how this is done.


	(c) 2014-2017 AIBotSystem.com
	aibotsystem@gmail.com

*/

using UnityEngine;
using System.Collections;

public class SamplePlayerShootScript : MonoBehaviour {

	// load a bullet type:
	public GameObject bulletType;
	public float fireTime = 0.2f;
	// shoot from this position, usually placed at tip of gun
	public Transform shootPosition;


	// get the object pool:
	private AIDesigner.ObjectPool objectPool;

	// Use this for initialization
	void Start () {

		// find the Object pool in scene:
		objectPool = (AIDesigner.ObjectPool) FindObjectOfType(typeof(AIDesigner.ObjectPool));

		if (objectPool == null){
			Debug.Log("No object pool detected!");
		} else {
			// start firing mechanism:
			InvokeRepeating("CheckFire", fireTime, fireTime);

		}
	}
	
	void CheckFire(){
		if (Input.GetButton("Fire1")){
			GameObject tempBullet = null;

			// request a new bullet from the object pool:
			tempBullet = objectPool.GetObject(bulletType); // returns GameObject type

			// check that it exists:
			if (tempBullet != null){
				// place this bullet at the firing position:
				tempBullet.transform.position = shootPosition.position;

				// rotate this bullet to same as shoot position:
				tempBullet.transform.rotation = shootPosition.rotation;

				// fill in the bullet's Attacker Info with the human player
				// if the bullet has an attached AttackerInfo component:
				// note: this is purely optional but is useful for keeping score of
				// who killed who				
				if (tempBullet.GetComponent<AIDesigner.AttackerInfo>() != null){
					tempBullet.GetComponent<AIDesigner.AttackerInfo>().attackerFaction = GetComponent<AIDesigner.Identity>().faction;
					tempBullet.GetComponent<AIDesigner.AttackerInfo>().attacker = gameObject;
				}
			
			}
		}
	}
}
