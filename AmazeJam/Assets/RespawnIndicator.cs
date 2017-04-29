using UnityEngine;
using System.Collections;

public class RespawnIndicator : MonoBehaviour {

	 GameObject [] enemy;
	 public Texture2D icon;

	Vector2 indRange;
	float scaleRes = Screen.width / 500;
	Camera cam;
	public GUIStyle gooey;
	public float iconSize = 50f;
	  


	// Use this for initialization
	void Start () {
	enemy = GameObject.FindGameObjectsWithTag("Respawn");
	cam = Camera.main;


	indRange.x = Screen.width - (Screen.width / 16);
    indRange.y = Screen.height - (Screen.height / 9);
    indRange /= 2f;

	gooey.normal.textColor = new Vector4 (0, 0, 0, 0); //Makes the box around the icon invisible.



	}
	
	// Update is called once per frame
	void OnGUI () {
	for (int i = 0; i < enemy.Length; i++){
	Debug.Log ("Enemy" + enemy[i] + "detected"); 

		Vector3 dir = enemy[i].transform.position - cam.transform.position;
        dir = Vector3.Normalize (dir);
        dir.y *= -1f;

        Vector2 indPos = new Vector2 (indRange.x * dir.x, indRange.y * dir.y);
       indPos = new Vector2 ((Screen.width / 2) + indPos.x, (Screen.height / 2) + indPos.y);

        Vector3 pdir = enemy[i].transform.position - cam.ScreenToWorldPoint(new Vector3(indPos.x, indPos.y, transform.position.z));
        pdir = Vector3.Normalize(pdir);

        float angle = Mathf.Atan2(pdir.x, pdir.y) * Mathf.Rad2Deg;

        GUIUtility.RotateAroundPivot(angle, indPos); //Rotates the GUI. Only rotates GUI drawn after the rotate is called, not before.

        GUI.Box (new Rect (indPos.x, indPos.y, scaleRes * iconSize, scaleRes * iconSize), icon,gooey);

        GUIUtility.RotateAroundPivot(0, indPos); //Rotates GUI back to the default so that GUI drawn after is not rotated.

	} 


	
	}
}
