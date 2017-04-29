/*
	Sample script that monitors a bot or animal's needs (e.g. thirst, hunger)
	 and prints it to the screen during gameplay. This can be used to test
	 if an animal is acting correctly and if certain needs are being increased too quickly/slowly.

	 Usage: 
	 1) Make sure you have an agent in scene setup with Emotion controller, needs, and goals
	 	- the wildlife advanced template sets this up for you with default Thirst, Hunger needs/goals
	 
	 2) Add a blank gameobject to scene.
	 3) Add this script to gameobject
	 4) Drag the agent in scene to the 'agent'  slot of this script.
	 5) Play scene.
	


	(C) 2014-2017 AIBotSystem.com  All Rights Reserved. 
	[aibotsystem@gmail.com]

*/

using UnityEngine;
using System.Collections;

using AIDesigner;

public class UIMonitorAgentNeeds : MonoBehaviour {

	public GameObject agent;

	private AIDesigner.Brain agentBrain;
	private AIDesigner.EmotionController agentEmo;
	private AIDesigner.GoalController agentGoals;
	private AIDesigner.Identity agentID;

	private bool canProceed = false;

	// Use this for initialization
	void Start () {
		agentID = agent.GetComponent<AIDesigner.Identity>();
		agentBrain = agent.GetComponent<AIDesigner.Brain>();
		agentEmo = agent.GetComponent<AIDesigner.EmotionController>();
		agentGoals = agent.GetComponent<AIDesigner.GoalController>();

		canProceed = (agentID != null && agentBrain != null && agentEmo != null && agentGoals != null);
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (canProceed){
			GUI.Label(new Rect(10, 10, 400, 20), "AGENT NAME: " + agentID.charName);	

			// print either current goal activity or other activity:
			// check if any goals are active:
			if (agentGoals.currentGoalName == ""){

				string listOfActiveActions = "";	// holds list of active [brain] action names

				// no goals active, so let's get the brain's current activity:
				// we can check which actions are active in the Brain component,
				// by looping through each AIAction in the Brain's List<AIDesigner.AIActions> list
				foreach(AIDesigner.AIActions action in agentBrain.aiActions){
					if (action.active){
						// this action is active, so add it to list of active actions:
						listOfActiveActions = listOfActiveActions + action.Name + " | ";
					}
				}	

				// we can either print the action names:
				GUI.Label(new Rect(10, 30, 400, 20), "CURRENT STATE: " + listOfActiveActions);	
			} else {
				// or... if a goal is active, so we print the goal instead:
				GUI.Label(new Rect(10, 30, 400, 20), "CURRENT STATE: (GOAL) " + agentGoals.currentGoalName);	
			}

			

			// print need's flags as statuses:
			string tempStatus = "";
			for(int a=0; a < agentEmo.needs.Length; a++){

				if(agentBrain.GetFlag(agentEmo.needs[a].needConditions[0].enableThisFlag) == true){
					// this need's flag is active
					// therefore, this agent must be needy in this area,
					// so add this status to tempStatus before printing
					tempStatus = tempStatus + " | IS " + agentEmo.needs[a].needConditions[0].enableThisFlag;
				}
			}

			if (tempStatus == ""){
				// all needs satisfied:
				GUI.Label(new Rect(10, 50, 400, 20), "CURRENT NEEDS: None (Satisfied)");					
			} else {
				// at least 1 need is not satisfied:
				GUI.Label(new Rect(10, 50, 400, 20), "CURRENT NEEDS: " + tempStatus);					
			}




			// loop and print out values of needs:
			for(int a=0; a < agentEmo.needs.Length; a++){
				GUI.Label(new Rect(10, (70 + (a*20)), 400, 20), agentEmo.needs[a].varName + " Level: " + agentEmo.needs[a].value);					
			}

		}
	}




}
