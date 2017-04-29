using UnityEngine;
using System.Collections;

public class IndicatorInCircle : MonoBehaviour {

Camera cam;
public Texture2D [] icon;

public GUIStyle gooey;
public float iconSize = 50f;
float scaleRes = Screen.width / 500;
public string targetTag;

GameObject [] enemy;

float xradius = Screen.width/2;
float yradius = Screen.height/2;

// segments is equal to ammount of "enemies" to indicate
int segments;


// pictogram 
int ico;

//define border offset
public float offset;
public bool isActive;
// define rounded corner off indication area
[Range(1.42f, 3.3f)]
public float rounded;
float radians;
private Color guiColor;

public float alphaStart = 300f;
public float alphaEnd = 60f;
float alphaDif;

/// <summary>
/// ///////////////////////////////////////
/// </summary>


void Start () {

alphaDif = alphaStart - alphaEnd;
guiColor = Color.black;
cam = Camera.main;
gooey.normal.textColor = new Vector4 (0, 0, 0, 0);

// find target
enemy = GameObject.FindGameObjectsWithTag(targetTag);
// define target ammount
segments = enemy.Length;
radians = segments*90f; 
ico = Random.Range(0, icon.Length); 

isActive = true;

}

void OnGUI () {

	float x;
	float y;

// for each founded target
	for (int i = 0; i < segments; i++){	

	GUI.color = guiColor;
	enemy = GameObject.FindGameObjectsWithTag(targetTag);

	ico = i;

	// translate target X,Z coordinates to Camera X,Y coordinates
	Vector3 relative = transform.InverseTransformPoint(enemy[i].transform.position);
	//relative = Vector3.Normalize(relative);

	// translate and define angle of target position
	float angle = Mathf.Atan2(-relative.x, -relative.z) * Mathf.Rad2Deg;
	angle += (radians / segments);

	// difine x,y to draw an ellipse map with target position 
	x = Mathf.Cos (Mathf.Deg2Rad * angle) * Screen.width/rounded + xradius;
	y = Mathf.Sin (Mathf.Deg2Rad * angle) * Screen.height/rounded + yradius;


// convert ellipse map to rect, snapped to the edges of the screen with adjustable angles rounded
	float xm = Mathf.Clamp(x, offset, Screen.width - (scaleRes * iconSize)-offset);
	float ym = Mathf.Clamp(y, offset, Screen.height - (scaleRes * iconSize)-offset);

	float dis = Vector3.Distance(enemy[i].transform.position, transform.position); 
	guiColor.a = Mathf.Lerp(1.0f, 0.01f, (dis-alphaEnd)/alphaDif);

	if ( dis > 40f ) { 
// draw icons
	GUI.Box (new Rect (xm, ym, scaleRes * iconSize, scaleRes * iconSize), icon[ico], gooey);	
	}	

	}}}


