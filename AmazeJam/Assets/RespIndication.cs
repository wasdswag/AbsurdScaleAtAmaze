using UnityEngine;
using System.Collections;

public class RespIndication : MonoBehaviour {

	public Texture2D test;

	public GUIStyle gooey;
	public float iconSize = 50f;
	float scaleRes = Screen.width / 500;

	float xl;
	float yl;


	// Use this for initialization
	void Start () {
		xl = Screen.width - (scaleRes * iconSize);
	yl = Screen.height - (scaleRes * iconSize);




	gooey.normal.textColor = new Vector4 (0, 0, 0, 0);

	}


     void OnGUI() {

		GUI.Box (new Rect (0, 0, scaleRes * iconSize, scaleRes * iconSize), test, gooey);   
   		GUI.Box (new Rect (0, yl, scaleRes * iconSize, scaleRes * iconSize), test, gooey);
		GUI.Box (new Rect (xl, 0, scaleRes * iconSize, scaleRes * iconSize), test, gooey);
		GUI.Box (new Rect (xl, yl, scaleRes * iconSize, scaleRes * iconSize), test, gooey);
	

               }
               }