using UnityEngine;
using System.Collections;

public class GenerateNPC : MonoBehaviour {

	public GameObject[] npc; 
	private Ray ray;
	private RaycastHit hit;
	Collider coll;
	public bool hover;
	int ammount;

	public float checkInterval = 0.4f;


	private bool isCreated;

	private bool reCreated;
	private bool shoot;

	void Start () {

	hover = false;
	isCreated = false;
	reCreated = false;
	shoot = false;
	ammount = npc.Length; 
	Delay();

	}

////////////////////////

	void Delay(){
	StartCoroutine ( AppearTime() );
	}

	IEnumerator AppearTime() {
	yield return new WaitForSeconds (checkInterval);
	//for (int i = 0; i < npc.Length; i++){

	//for (int j = 0; j < ammount ; j++){
	int s = Random.Range(0, ammount); 
	if (!isCreated){

	GameObject npcCreated = (GameObject) Instantiate(npc[s], transform.position, Quaternion.identity);
	//npcCreated.transform.parent = transform;
	isCreated = true; 
	Debug.Log(npcCreated + "is created"); 
	}}

	void Update(){

	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit, 150f)) {
	if (hit.collider.gameObject.tag == "Respawn" && Input.GetMouseButtonDown(0) ) {
	Debug.Log("YOU MAKE ME CRY");
	Destroy(hit.transform.gameObject);
	Delay();
	reCreated = true;
	if (reCreated){
	int r = Random.Range(0, ammount); 
	GameObject npcCreated = (GameObject) Instantiate(npc[r], transform.position, Quaternion.identity);
	reCreated = false;

	}

	}}}}


