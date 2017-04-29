/*
	THIS SCRIPT POWERS ALL BULLETS TO MOVE FORWARD

	YOU CAN REMOVE OR RENAME THIS SCRIPT, BUT THEN YOU WILL NEED
	SOME OTHER SCRIPT TO DRIVE YOUR PROJECTILE FORWARD.

	WHAT THIS DOES:  If useRigidbodyForce is not checked, 
	it will push the bullet forward every tick, by the 'bulletForce'
	number you specify.  If useRigidbodyForce is checked, then
	it will exert a Rigidbody Physics force on the bullet instead.

	If you use Rigidbody physics, the bulletForce number should *usually*
	be set LOWER than the non-Rigidbody number, or bullet will travel too fast.

	If you're using AI Designer Pro, you have access to Ranged Attack ADVANCED Controller,
	which allows you to use Hit-scan shooting instead of projectiles.  If you're using
	hit-scan shooting, you don't need this script.


	(c) 2014-2017 AIBotSystem.com
	aibotsystem@gmail.com

*/

using UnityEngine;
using System.Collections;
using AIDesigner;


namespace AIDesigner{

[AddComponentMenu("AI Designer/Weapon Scripts/Projectile (Add to Bullet)")]

// add this component in case other AI sees this bullet's collider as an obstacle
// what this does is if any object has ExcludeFromObstacleAvoidance component attached,
// the bullet will ignore it on damage.

[RequireComponent (typeof (AIDesigner.ExcludeFromObstacleAvoidance))]

public class Projectile : MonoBehaviour {

	public float bulletForce = 25f;
	public bool useRigidbodyForce = false;	// set to true if you want to use Rigidbody physics on this bullet
											// WARNING: Using this Rigidbody setting can severely hamper performance
											// if you have lots of bullets flying around.
											// If you do have lots of bullets, we suggest leaving this UNCHECKED.
											// If you check this, you must add a RIGIDBODY

	private Transform myTransform;			// cache our bullet's Transform for better performance


	void Start(){

		myTransform = transform;

		// fire bullet forward using rigidbody physics push:
		if (useRigidbodyForce && GetComponent<Rigidbody>() != null){
			Rigidbody r = GetComponent<Rigidbody>();
			Vector3 forwardDir = myTransform.TransformDirection(Vector3.forward);
			
			// reset previous physics:
			r.velocity = Vector3.zero;

			r.AddForce(forwardDir * bulletForce);
		}
	}

	void FixedUpdate(){
		// fire bullet forward using translate (less CPU usage):
		if (!useRigidbodyForce){
			myTransform.Translate(0,0, (Time.deltaTime * bulletForce));
		}
	}





}
}