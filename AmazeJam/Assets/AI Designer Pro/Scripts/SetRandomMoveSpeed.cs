/*
	SAMPLE SCRIPT SHOWING HOW TO SET RANDOM MOVE SPEED 
	ON START

	ATTACH THIS SCRIPT TO ANY AI-ENABLED AGENT AND IT WILL
	CREATE A RANDOM MOVE SPEED WHEN SCENE LOADS.

	THIS IS USED IN THE AERIAL -RACING DEMO TO CREATE SIMPLE
	OPPONENT VARIATIONS.

	(c) 2014-2017 AIBotSystem.com
	aibotsystem@gmail.com	
*/

using UnityEngine;
using System.Collections;

public class SetRandomMoveSpeed : MonoBehaviour {

	public float minSpd = 160;
	public float maxSpd = 300;

	// Use this for initialization
	void Start () {
		GetComponent<AIDesigner.MovementController>().topSpeed = Random.Range(minSpd, maxSpd);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
