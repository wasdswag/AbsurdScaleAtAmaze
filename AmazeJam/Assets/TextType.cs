using UnityEngine;
using System.Collections;

public class TextType : MonoBehaviour {

     
   public GUIStyle font;
     string message;
	 Color textColor = Color.white;
  
     void Start () 
     {
 
		message = "DISCO/DISCOMFORT VER.2.0 \nby WASDSWAG 2017\nSTATUS: DISCONNECTED\n\n\nPRESS [ENTER] TO QUIT\n_____________________________________________\n\n|||||||||||||||| USED RESOURSES:||||||||||||||\nSOUNDS & MUSIC: \ndublab.com/heidi-lawden-magic-roundabout-01-27-16 \nfreesound.org/people/truflabart/sounds/125875/ \nMODELS:\n3dwarehouse.sketchup.com\nmixamo fuse software\nMADE WITH UNITY3D\nTHANKS TO @KIV_HERE FOR HELPING\n\nWASDSWAG.COM";
         			
       
       
     }
  
     

     void OnGUI()
     {
		GUI.color = textColor;
		GUI.Label(new Rect(0, 0, 256, 1024), message, font);    
     }
     
     void Update()
     {
         if(Input.GetKeyDown (KeyCode.Return))
         {
			Application.Quit();
         }
     }
 }