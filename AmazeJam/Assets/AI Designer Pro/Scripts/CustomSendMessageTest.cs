// attach this to AI
// fill in the function name into one of the custom events on the AI
// this is a demo script only to test Unity SendMessage() with.
// not to be added to AI in production game.

// This uses Unity's SendMessage() implementation that is used by some AI Designer components.
// NOTE: SendMessage() is usually worse performance than calling a function directly, so 
// use sparingly. The performance hit using SendMessage() is very small if you only have a few AI, but
// it may be noticible on a large battle scene with 50 - 100s of AI active at once.

// USAGE:
// Check the function names below, like "IGotHit"
// Now, go to any AI Designer component with a Custom Events drop down.
// Example, go to the Health Controller.
// Open up Custom Script Events.
// Find where it says "Function On Hit"
// Type in "IGotHit"
// Thats it.  Now, when the AI / Health Controller is hit, it will trigger the function down below.
		// Note: For this particular function call, the Health Controller will fire the function
		// even if the damage was absorbed (by armor or shielding)...it's the initial raw damage


using UnityEngine;
using System.Collections;

public class CustomSendMessageTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	void IGotHit(float damageSent){
		Debug.Log(gameObject.name + ": I'm hit! " + damageSent + " damage!");
	}

	public void IAmRegeneratingHealth(){
		// triggered every interval of regen rage
		Debug.Log(gameObject.name + ": I'm regen health!");
	}
}
