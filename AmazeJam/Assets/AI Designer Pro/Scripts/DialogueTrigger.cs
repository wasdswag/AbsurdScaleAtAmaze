/*
	Sample script showing how to integrate with built-in dialogue system
	Attach this to player, attach Dialogue Controller to NPC
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	private float rangeToDetectDialogue = 2;
	public float rangeToEndDialogue = 5f;
	public GameObject dialogueWindow;
	public Text txtNPCDialogue;
	public Text txtPlayerChoices;

	private AIDesigner.Brain npcBrain;	// holds the NPC we're having the dialogue with
										// having this access allows us to "freeze" the NPC
										// while we're having a convo so it doesn't run off
										// or attack enemies

	private AIDesigner.DialogueController dialogueController;	// holds the dialogue controller
																// attached to the NPC

	[Header("RUNTIME MANUAL SETTINGS")]	
	public int triggerSpeechUniqueID = 0;	// the NPC's speech Id to play.
											// this ties in directly with player responses...
											// so if a player response is supposed to trigger Speech ID 3,
											// set this to 3 and it will play the npc's speech at ID 3


	[Header("RUNTIME USE")]
	public string npcSays = "";
	public Transform targetNPC;
	public AIDesigner.DialogueController.PlayerResponse[] playerResponses;
	public int[] playerReplyGoToID;
	private bool firstTime = true;	
	private bool isInConversation = false;
	private SphereCollider sphereColl;

	// Use this for initialization
	void Start () {
		// create a sphere collider trigger with our range... will be used
		// to detect objects that can start dialogue:
		sphereColl = gameObject.AddComponent<SphereCollider>();
		sphereColl.radius = rangeToDetectDialogue;
		sphereColl.isTrigger = true;
	}
	

	void Update(){
		// check for player input
		// keys 1, 2, 3, 4 -- which corresponds to player responses when dialogue is initiated:

		if (isInConversation){

			// first check if the dist to NPC is high,
			// if so, end convo:
			if (Vector3.Distance(transform.position, targetNPC.position) > rangeToEndDialogue){
				EndConversation();
			}


			else if (Input.GetKeyUp(KeyCode.Alpha1) && playerResponses != null && playerResponses.Length >= 1){
				triggerSpeechUniqueID = playerResponses[0].gotoID;	// .gotoID is an int
																	// that refers to the ID of the NPC speech to play next
															// in this example, we use playerResponses[0]				
															// because this is for input key #1, which is the first
															// item of player responses (index 0)
				// play the next speech:
				DoSpeech();
			}

			else if (Input.GetKeyUp(KeyCode.Alpha2) && playerResponses != null && playerResponses.Length >= 2){
				triggerSpeechUniqueID = playerResponses[1].gotoID;
				DoSpeech();
			}

			else if (Input.GetKeyUp(KeyCode.Alpha3) && playerResponses != null && playerResponses.Length >= 3){
				triggerSpeechUniqueID = playerResponses[2].gotoID;
				DoSpeech();
			}

			else if (Input.GetKeyUp(KeyCode.Alpha4) && playerResponses != null && playerResponses.Length >= 4){
				triggerSpeechUniqueID = playerResponses[3].gotoID;
				DoSpeech();
			}

			// if you have more than 4 responses, you'd continue this pattern here...
			//
			// else if (Input.GetKeyUp(KeyCode.Alpha2) && playerResponses.Length >= 2){
			// 	triggerSpeechUniqueID = playerResponses[1].gotoID;
			// 	DoSpeech();
			// }

		}
	}



     void OnTriggerEnter(Collider other) {
    	if (!isInConversation){
			if (other.gameObject != gameObject)  {
				targetNPC = other.gameObject.transform;
				dialogueController = other.gameObject.GetComponent<AIDesigner.DialogueController>();

				if (dialogueController != null){
					// this object we hit has a dialogue controller, let's first check if
					// there is any available dialogue (maybe all speeches have been played)

					// we can use GetFirstSpeech(playerObject) to test
					// if a first initiation dialogue is available.
					// It will return an int,  -1 if NOT AVAILABLE
					// and 0 or greater if AVAILABLE. 0 OR GREATER is also the
					// index of the first selected speech to play
					if (dialogueController.GetFirstSpeech(gameObject) != -1){
						// first, reset the paramters incase we had a previous convo:
						firstTime = true;
						triggerSpeechUniqueID = 0;

						// freeze the ai:
						npcBrain = other.gameObject.GetComponent<AIDesigner.Brain>();
						//npcBrain.Freeze();	// handy freeze function that freezes all AI functionality
						npcBrain.FreezeAIOnly();	// handy freeze function that freezes all AI functionality
													// this is the same as Freeze() except it does not freeze
													// the animator, so you can still play any animations

						// show dialogue window:
						dialogueWindow.SetActive(true);

						// start talking:
						DoSpeech();

						isInConversation = true;	// important, or this event will keep firing
					}
				}
			}
    	}
    }


	void DoSpeech(){
		// get speech text:
		if (firstTime){
			dialogueController.StartConvo();
			int firstSpeechUniqueID = dialogueController.GetFirstSpeech(gameObject);
			
			npcSays = dialogueController.GetSpeechByID(firstSpeechUniqueID);	
			firstTime = false;

			// this step is important:  we must tell the Dialogue controller
			// that we used this speech text, so it can mark it as hasPlayed
			// in the future, if you have "playOnce" checked on that particular speech,
			// it will not play, because it's already played once:
			dialogueController.MarkHasPlayed(firstSpeechUniqueID);
			// in the future, if you wanted to check if this speech has already been played,
			// or to mark it as played so the dialogue engine doesn't play it:
			// check: dialogueController.speeches[array id].hasPlayed == true/false
			// mark: dialogueController.MarkHasPlayed(array id);
			
			// for example, let's say you only want the NPC to say something ONCE
			// for the rest of the game. You want this to persist when the player 
			// saves the game.  You can save the status of certain speeches
			// by getting their hasPlayed boolean, and on Loading a saved game,
			// mark certain speeches as played using MarkHasPlayed()

		} else {
			npcSays = dialogueController.GetSpeechByID(triggerSpeechUniqueID);	

			// this step is important:  we must tell the Dialogue controller
			// that we used this speech text, so it can mark it as hasPlayed
			// in the future, if you have "playOnce" checked on that particular speech,
			// it will not play, because it's already played once:
			dialogueController.MarkHasPlayed(triggerSpeechUniqueID);
		}
		

		// player speech audio, if any:
		AudioClip clip = dialogueController.GetSpeechAudioByID(triggerSpeechUniqueID);
		if (clip != null){
			GetComponent<AudioSource>().clip = clip;
			GetComponent<AudioSource>().Play();
		}
		

		// get associated player responses:
		playerResponses = dialogueController.GetPlayerResponsesByID(triggerSpeechUniqueID);

		// PRINT TO UI:
			// print NPC's speech:
			txtNPCDialogue.text = npcSays;

			string tempResponseCollection = "";	// put all player replies into a temporary string
			
			// loop through and print player replies:
			if (playerResponses != null && playerResponses.Length != 0){
				for (int x=0; x<playerResponses.Length; x++){
					if (x == 0){
						// first item:
						tempResponseCollection = "1) " + playerResponses[0].reply;
					} else {
						// further items:
						tempResponseCollection = tempResponseCollection + "\n" + (x+1) + ") " + playerResponses[x].reply;
					}
				} 
			}
			
			txtPlayerChoices.text = tempResponseCollection;

		// end of convo?
		if (playerResponses == null || playerResponses.Length == 0){
			
			// end convo after 7 seconds
			Invoke("EndConversation", 7);


		} else {

			// create an integer array to hold GOTO IDs for each player response
			playerReplyGoToID = new int[playerResponses.Length];

			// get the response unique ID for each player response, and put it into the
			// int array, playerReplyGoToID:
			for(int i=0; i<playerResponses.Length; i++){
				playerReplyGoToID[i] = playerResponses[i].gotoID;
			}
		}
	}



	void EndConversation(){
		dialogueController.EndConvo();
		Debug.Log("CONVERSATION ENDED");

		isInConversation = false;
		//npcBrain.Unfreeze();	// unfreeze the AI
		npcBrain.UnfreezeAIOnly();	// unfreeze the AI

		firstTime = false;
		triggerSpeechUniqueID = 0;

		// show dialogue window:
		dialogueWindow.SetActive(false);			

	}


}
