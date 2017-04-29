/*
	SAMPLE SCRIPT SHOWING HOW TO CREATE A RANDOM MELEE ATTACK TIME
	FOR BETTER REALISM

	USAGE: Add this script to an AI-enabled prefab that has the Melee Attack controller attached

	(c) 2014-2017 AIBotSystem.com
	aibotsystem@gmail.com

*/

using UnityEngine;
using System.Collections;

public class MeleeAttackTimeVariation : MonoBehaviour {

	private AIDesigner.MeleeAttackBasic meleeController;
	private float originalAttackTime = 0;

	// Use this for initialization
	void Start () {
		// cache our attached Melee Controller
		meleeController = GetComponent<AIDesigner.MeleeAttackBasic>();

		// store the original attack time for reference:
		if (meleeController != null){
			originalAttackTime = meleeController.timeBetweenAttacks;

			// change the attack time delay every 2 seconds:
			InvokeRepeating("RandomAttackTime", 2, 2);
		}	
	}
	
	void RandomAttackTime(){
		if (meleeController != null && meleeController.enabled){
			// randomize the attack time and insert it into Melee Controller:

			meleeController.timeBetweenAttacks = Mathf.Clamp(originalAttackTime + (Random.Range(-2, 2)), 0.01f, 60);
			// in this example, we add (or subtract) a random number between -2 and +2
			// and add that number to the Melee Controller's timeBetweenAttacks
			// this will vary the attack time delay for better realism
		} else {
			// if melee controller doesn't exist or is disabled, then disable this script:
			CancelInvoke();
			this.enabled = false;
		}
	}


}
