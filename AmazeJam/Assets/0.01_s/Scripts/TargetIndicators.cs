using UnityEngine;
using System.Collections;

public class TargetIndicators : MonoBehaviour {

[System.Serializable]
public class TargetSettings {

///// Tag Selector 
[SerializeField]
[Header("Type your target tag here:")]
public string targetTag;
public Color targetColor;
public Texture2D icon;
// enable rotation for each icon
public bool iconRotation;
[Header("Display Name")]
public bool enableName;
public string typeNameHere;
[Range(-100f, 100f)]
public float xOffset = 0f;
[Range(-100f, 100f)]
public float yOffset = 0f;


[HideInInspector]
public GameObject[] target;
[HideInInspector]
public Color[] guiColor;


}

[System.Serializable]
public class ShowDistance  {
[Header("check it to draw distance in numbers")]
public bool showDistance;
[Header("pick up Font, Normal Color Size here")]
public GUIStyle numbstyle;



				}

/// Setup 
[HideInInspector]
public Camera cam;
[HideInInspector]
public GUIStyle style;
[Header("SELECT TARGET")]
public TargetSettings [] MyTargets;

[Header("GENERAL SETUP")]
public Transform player;

[Range(5f, 300f)]	public float iconSize = 50f;
// overall scale
[Range(2f, 10f)]	public float scale = 2f;

[Header("Alignment")]
// adjust position on screen

[Range(0f, 1f)]	public float positionX;
[Range(0f, 1f)]	public float positionY;


// margins
[Range(0f, 400f)]	public float offset = 0f;
// corner rounding

[Header("Corner rounding")]
[Range(1.42f, 10f)]	public float rounding = 1.6f;

// fade in/fade out by dist
[Header("Fade In / Fade Out distance")]
public bool FadeInEnabled;
public float alphaStart = 100f; 
public float alphaEnd = 10f;

[Header("Increasing icon size by dist")]
public bool IncreaseEnabled;
[Range(1.01f, 3.2f)]
public float MaxIncrease = 1.01f;
float Amplifier = 1f;
public float IncreaseStart = 100f;
public float IncreaseEnd = 10f;

[Header("Minimal distance to draw icon")]
public float minDistanse = 7f;

float scaleRes = Screen.width / 2000f;
int segments;  

float alphaDif, increaseDif, icSize, radians;
float xradius, yradius, baseScale, aspect, keepAspectX, xAspect;
float moveX, moveY;
private Vector2 pivotPoint;
private Vector2 pivotPointArrow;

[Header("Display only on top edge")]
public bool OnlyTop;
[Range(0,2000f)]
public float line2Arc;


[Header("Rect -> Quad / Ellipse -> Circle")]
public bool keepAspect;

[Header("Show Distance in Numbers")]
public ShowDistance DistInNumbers;







void Start(){
// Define all targets in groups of tags
cam = Camera.main;
style.normal.textColor = new Vector4 (0, 0, 0, 0);
for (int i = 0; i < MyTargets.Length; i++){
MyTargets[i].target = GameObject.FindGameObjectsWithTag(MyTargets[i].targetTag);
segments = MyTargets[i].target.Length;

}
}

void OnGUI () {

float x, y;
float icSize = scaleRes * iconSize;
alphaDif = alphaStart - alphaEnd;
increaseDif = IncreaseStart - IncreaseEnd;
xradius = Screen.width/scale -  icSize/2;
yradius = Screen.height/scale - icSize/2;
baseScale = scale/2;

aspect = Screen.width - Screen.height;
keepAspectX = aspect/2;

// 
for (int j = 0; j < MyTargets.Length; j++){	
for (int i = 0; i < segments; i++){	
MyTargets[j].target = GameObject.FindGameObjectsWithTag(MyTargets[j].targetTag);
MyTargets[j].guiColor = new Color[segments];

segments = MyTargets[j].target.Length;
radians = segments*90f; 


// check distance
float dis = Vector3.Distance(MyTargets[j].target[i].transform.position, player.position);

/// Asign RGB values from selected target color to each icons in Target Tags Group, 
//  Color Alpha values is not asigned, which allows to use guiColor[i].a  to set fade IN/OUT effects
MyTargets[j].guiColor[i].r = MyTargets[j].targetColor.r; 
MyTargets[j].guiColor[i].g = MyTargets[j].targetColor.g; 
MyTargets[j].guiColor[i].b = MyTargets[j].targetColor.b;

// set transparency
if (FadeInEnabled){
MyTargets[j].guiColor[i].a = Mathf.Lerp(1.0f, 0.01f, (dis-alphaEnd)/alphaDif);
}
else { MyTargets[j].guiColor[i].a = 1; }
GUI.color = MyTargets[j].guiColor[i];

// global icons increasing by dist 
if (IncreaseEnabled){
Amplifier = Mathf.Lerp(MaxIncrease, 1, (dis-IncreaseEnd)/increaseDif);
}
else { Amplifier = 1f; 
}

// translate target X,Z coordinates to Camera X,Y coordinates
Vector3 relative = player.InverseTransformPoint(MyTargets[j].target[i].transform.position);


// translate and define angle of target position
float angle = Mathf.Atan2(-relative.x, -relative.z) *  Mathf.Rad2Deg;
angle += (radians / segments);

float xmax = Screen.width / baseScale;
float ymax = Screen.height / baseScale;



//////////////////////////
////// Align Position ///
if (keepAspect){
xradius = yradius;
xmax = ymax;
moveX = keepAspectX;
}


moveX = Mathf.Lerp(0f, Screen.width - xmax, positionX);
moveY =	Mathf.Lerp(0f, Screen.height - ymax, positionY);

float newRounding = rounding + line2Arc/500;



// difine x,y to draw an ellipse map with target position 
x = moveX + Mathf.Cos (Mathf.Deg2Rad * angle) * xmax / newRounding + xradius; 
y = moveY + Mathf.Sin (Mathf.Deg2Rad * angle) * ymax / newRounding + yradius;  

// convert ellipse map to rect, snapped to the edges of the screen with adjustable corners rounding
float xm = Mathf.Clamp(x, offset+moveX, xmax - icSize * Amplifier - offset+moveX);
float ym = Mathf.Clamp(y, offset+moveY, ymax - icSize * Amplifier - offset+moveY);


Vector3 rotateRelative = player.InverseTransformPoint(MyTargets[j].target[i].transform.position);
float icAngle = Mathf.Atan2(rotateRelative.x, rotateRelative.y) * Mathf.Rad2Deg;

float Yscale = Screen.height/baseScale;
float DifYscale = Yscale * baseScale;
float ddY = Screen.height - DifYscale;

float limit = Screen.height;

// if enable will display only on top
if(OnlyTop){
limit = ddY+moveY+offset+line2Arc;
}

if ( dis > minDistanse && ym <= limit + 1) { 



// draws icons if rotation is enabled
if(MyTargets[j].iconRotation){
pivotPoint = new Vector2(xm + (icSize * Amplifier)/2, ym + (icSize * Amplifier)/2);
Matrix4x4 matrixBackup = GUI.matrix;
GUIUtility.RotateAroundPivot(icAngle, pivotPoint); 
GUI.Box (new Rect (xm, ym, icSize*Amplifier, icSize*Amplifier), MyTargets[j].icon, style);
GUI.matrix = matrixBackup;
}


// draws icons by default
if(!MyTargets[j].iconRotation){
GUI.Box (new Rect (xm, ym, icSize*Amplifier, icSize*Amplifier), MyTargets[j].icon, style);



}
if(DistInNumbers.showDistance == true){
string ShowDistance = string.Format("{0:0}", dis);
GUI.color = Color.white;
GUI.Box (new Rect (xm, ym, icSize*Amplifier, icSize*Amplifier), ShowDistance, DistInNumbers.numbstyle);
}
if(MyTargets[j].enableName == true){
GUI.color = Color.white;
GUI.Box (new Rect (xm+MyTargets[j].xOffset, ym+MyTargets[j].yOffset+icSize*Amplifier, icSize, icSize), 
MyTargets[j].typeNameHere, DistInNumbers.numbstyle);
}

}
}}}}























