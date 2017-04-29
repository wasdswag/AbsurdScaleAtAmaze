using UnityEngine;
using System.Collections;

public class testGen : MonoBehaviour {

public GameObject[] npc;
public GameObject[] dialoue;
int index;
GameObject currentObject;
GameObject currentObjectLyric;
Ray ray;
private RaycastHit hit;
public bool hover;
public float offset = 1f;
Transform player;

	


void Awake(){

	hover = true;
	index = Random.Range(0, npc.Length);
	player = GameObject.Find ("FPSController").transform;
	currentObject = Instantiate(npc[index], transform.position, Quaternion.LookRotation(player.position - transform.position)) as GameObject;
	currentObjectLyric = Instantiate(dialoue[index], transform.position, Quaternion.identity) as GameObject;

	//currentObject.transform.parent = transform;


}

void  Update (){

	ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

	if (Physics.Raycast(ray, out hit, 300f)) {
	if ( 
	hit.transform.position.x >= currentObject.transform.position.x + offset  || 
	hit.transform.position.x <= currentObject.transform.position.x - offset  || 
	hit.transform.position.z >= currentObject.transform.position.z + offset  || 
	hit.transform.position.z <= currentObject.transform.position.z - offset 
	&&  hit.collider.tag == "Respawn" && hit.collider != null) {
	hover = false;

	}
	else { hover = true; }
	index++;

	if (index >= npc.Length){ index = 0;} 


	if(hover && Input.GetMouseButtonDown(0) && currentObject != null) { 
	Destroy(hit.transform.gameObject);
	Destroy(currentObjectLyric);  
	//Vector3 relativePos = player.position - transform.position;
	currentObject = Instantiate(npc[index], hit.transform.position, Quaternion.LookRotation(player.position - hit.transform.position)) as GameObject;
	//currentObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, -200 * Time.deltaTime);
	//currentObject.transform.LookAt(player);
	//currentObject.transform.rotation = Quaternion.LookRotation(transform.position - player.position);

	currentObjectLyric = Instantiate(dialoue[index], transform.position, Quaternion.identity) as GameObject;


			//currentObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,this.transform.position.z );
	//currentObject.transform.parent = transform;
	//currentObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, 100f * Time.deltaTime);

	hover = false;

}}}}
//	Vector3 targetDir = player.position - currentObject.transform.position;
//	Vector3 newDir = Vector3.RotateTowards(transform.up, targetDir, 200 * Time.deltaTime, 0.0F);
//	currentObject.transform.rotation = Quaternion.LookRotation(newDir);