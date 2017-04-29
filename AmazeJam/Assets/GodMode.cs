using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {

public GameObject[] grass;
public GameObject[] trees;
public GameObject[] mountains;
public GameObject[] animals;
public GameObject adam;
public GameObject eve;

GameObject adam1;


int index1;
int index2;
int index3;
int index4;

GameObject currentObject;
public Ray ray;
public RaycastHit hit;
public bool hover;
public float offset = 1f;
Transform player;
public GameObject cursor;
public GameObject skyText;


GameObject [] pixels;
public Camera cam;
GameObject textSelector;

ObjectSelector objSelector;
int currentGroup;
GameObject sky;
bool skyEnable;
public bool itIsAnimal;

public Vector3 pos;
public Vector3 targetPos;

	


void Awake(){

	hover = false;
	skyEnable = false;
	itIsAnimal = false;
	index1 = Random.Range(0, grass.Length);
	index2 = Random.Range(0, trees.Length);
	index3 = Random.Range(0, mountains.Length);
	index4 = Random.Range(0, animals.Length);

	pixels = GameObject.FindGameObjectsWithTag("Cube");
	textSelector = GameObject.Find("Selector/text");
	objSelector = textSelector.GetComponent<ObjectSelector>();
	sky = GameObject.Find("Sphere/SpaceSphere");



//	player = GameObject.Find ("FPSController").transform;
//	currentObject = Instantiate(npc[index], transform.position, Quaternion.LookRotation(player.position - transform.position)) as GameObject;
//	currentObjectLyric = Instantiate(dialoue[index], transform.position, Quaternion.identity) as GameObject;
//
//	//currentObject.transform.parent = transform;
//

}

void  Update (){

	adam1 = GameObject.FindGameObjectWithTag("Adam");

	currentGroup = objSelector.CurrentPage;
//	Debug.Log(currentGroup);

	ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
	int layer_mask = LayerMask.GetMask("pixel");


	if (Input.GetKeyDown("z")){
	sky.GetComponent<MeshRenderer>().enabled = true;

	}
	if (sky.GetComponent<MeshRenderer>().enabled == true && Input.GetKeyDown("x")){
	sky.GetComponent<MeshRenderer>().enabled = false;

	}
	if (Input.GetKey("escape")){
     Application.Quit();
      }



	if (Physics.Raycast(ray, out hit, 300f, layer_mask) && hit.collider.tag == "Cube") {

	hover = true;

	cursor.SetActive(true);

	}


	else {
	hover = false;

	if(!hover){
	cursor.SetActive(false);

	}}

	//// Highlight Area
	if (Physics.Raycast(ray, out hit, 300f, layer_mask)){
	for(int i = 0; i< pixels.Length; i++){
	if (hit.collider.gameObject == pixels[i].gameObject && hit.collider != null){
	pixels[i].GetComponent<MeshRenderer>().enabled = true;
	}
	else { 
	pixels[i].GetComponent<MeshRenderer>().enabled = false; }
	}}


	if(hover && Input.GetMouseButtonDown(0)) { 
	pos = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 40f, hit.collider.transform.position.z);
	targetPos = new Vector3 (hit.collider.transform.position.x, this.adam.transform.position.y, hit.collider.transform.position.z);

	if (currentGroup == 1){
	currentObject = Instantiate(grass[index1], pos, Quaternion.identity) as GameObject;
	index1++;
	if (index1 >= grass.Length){ index1 = 0;}
	} 

	if (currentGroup == 2){
	currentObject = Instantiate(trees[index2], pos, Quaternion.identity) as GameObject;
	index2++;
	if (index2 >= trees.Length){ index2 = 0;}
	} 

	if (currentGroup == 3){
	currentObject = Instantiate(mountains[index3], pos, Quaternion.identity) as GameObject;
	index3++;
	if (index3 >= mountains.Length){ index3 = 0;} 
	}

	if (currentGroup == 4){

	currentObject = Instantiate(animals[index4], pos, Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0))) as GameObject;
	itIsAnimal = true;
	index4++;
	if (index4 >= animals.Length){ index4 = 0;} 
	}

	if (currentGroup == 5){
	currentObject = Instantiate(adam, pos, Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0))) as GameObject;


	}
	if (currentGroup == 6){
	currentObject = Instantiate(eve, pos, Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0))) as GameObject;


	}




	hover = false;
	//itIsAnimal = false;

}}


}
