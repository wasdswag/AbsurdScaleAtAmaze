using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AIDesigner{


public class EmotionDemo : MonoBehaviour {

	

	// used by emotion side:
	public GameObject aiAgent;
	private AIDesigner.EmotionController emotions;

	// for dialogue handling:
	private Transform targetNPC;
	public GameObject dialogueWindow;
	public Text txtNPCDialogue;
	public Text txtPlayerChoices;
	public Text txtPlayerName;

	// for special effects:
	public Transform effectSpawnPt;
	public GameObject positiveEmotionEffect;
	public GameObject negativeEmotionEffect;

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

	public AIDesigner.DialogueController.PlayerResponse[] playerResponses;
	public int[] playerReplyGoToID;
	private bool firstTime = true;	
	private bool isInConversation = false;
	private SphereCollider sphereColl;	


	// Use this for initialization
	void Start () {
		emotions = aiAgent.GetComponent<AIDesigner.EmotionController>();

		// create new memory with our attached Identity / charName on human player:
		// usage: emotionController.CreateNewMemoryEntry("name", int type) 
		// 'type' can be 0, 1, or 2:  0 = use charName, 1 = faction, 2 = gameobject TAG
		emotions.CreateNewMemoryEntry(GetComponent<AIDesigner.Identity>().charName, 0);

		if (txtPlayerName.text == ""){
			txtPlayerName.text = "Alex";
		}

		targetNPC = aiAgent.transform;

	}
	




     public void StartConversation() {
    	if (!isInConversation){
		

			dialogueController = targetNPC.gameObject.GetComponent<AIDesigner.DialogueController>();



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
					npcBrain = targetNPC.gameObject.GetComponent<AIDesigner.Brain>();
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




	void DoSpeech(){
		// tell the AI our player name:
		dialogueController.SetPlayerName(txtPlayerName.text);


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
			
			// end convo after 4 seconds
			Invoke("EndConversation", 4);


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



	public void EndConversation(){
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



	void SpawnEffectPositive(){
		if (effectSpawnPt != null && positiveEmotionEffect != null){
			Instantiate(positiveEmotionEffect, effectSpawnPt.position, Quaternion.identity);
		}
	}

	void SpawnEffectNegative(){
		if (effectSpawnPt != null && negativeEmotionEffect != null){
			Instantiate(negativeEmotionEffect, effectSpawnPt.position, Quaternion.identity);
		}
	}


	// example game actions:
	public void GiveGold(){
		// increase friendliness by 5:
		// syntax:  emotion.IncreaseFriend(the human player's Identity charName faction or gameobject tag, amount to increase, type)
		// type can be "charname", "faction", or "tag"
		// again, "charname" is the same "Char Name" found on the human player's Identity component
		// this syntax is the same for the next functions such as IncreaseHappy() and IncreaseFear()
		emotions.IncreaseFriend(GetComponent<AIDesigner.Identity>().charName, 5, "charname");

		// increase happiness from seeing this person by 5:
		emotions.IncreaseHappy(GetComponent<AIDesigner.Identity>().charName, 5, "charname");

		SpawnEffectPositive(); // spawn optional effects
	}

	public void StealGold(){

		// decrease friendliness by 15:
		// negative emotions should have greater weight so we do 20 instead of 5 for the positive emotions
		emotions.IncreaseFriend(GetComponent<AIDesigner.Identity>().charName, -20, "charname");


		// decrease happiness from seeing this person by 15:
		emotions.IncreaseHappy(GetComponent<AIDesigner.Identity>().charName, -20, "charname");

		SpawnEffectNegative(); // spawn optional effects
	}

	public void GiveCompliment(){
		// increase happiness from seeing this person by 5:
		emotions.IncreaseHappy(GetComponent<AIDesigner.Identity>().charName, 5, "charname");

		SpawnEffectPositive(); // spawn optional effects
	}

	public void Insult(){
		// decrease happiness from seeing this person by 10:
		// insults hurt, but not as much as getting gold stolen
		emotions.IncreaseHappy(GetComponent<AIDesigner.Identity>().charName, -10, "charname");

		SpawnEffectNegative(); // spawn optional effects
	}



	public void Soothe(){
		// decrease fear of this person by 5:
		emotions.IncreaseFear(GetComponent<AIDesigner.Identity>().charName, -5, "charname");

		SpawnEffectPositive(); // spawn optional effects
	}


	public void Threaten(){
		// increase fear of this person by 15:
		emotions.IncreaseFear(GetComponent<AIDesigner.Identity>().charName, 15, "charname");

		SpawnEffectNegative(); // spawn optional effects
	}



}


}