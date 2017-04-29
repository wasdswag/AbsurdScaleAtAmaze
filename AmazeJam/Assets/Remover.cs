//using UnityEngine;
//using System.Collections;
//
//public class Remover : MonoBehaviour {
//
//
//	private Ray ray;
//	private RaycastHit hit;
//	private bool notKilled;
//	private bool isCreated;
//
//
//	public GameObject[] npc; 
//
//	// Use this for initialization
//	void Start () {
//	notKilled = true;
//	isCreated = true;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    if (Physics.Raycast(ray, out hit, 150f)) {
//	if (hit.collider.gameObject.tag == "Respawn" && Input.GetMouseButtonDown(0) ) {
//	notKilled = false;
//	isCreated = false;
//	Destroy(hit.collider.gameObject);
//	}
//	}
//
//	if(!notKilled){
//	for (int i = 0; i < npc.Length; i++){
//	for (int j =0; j < npc.Length; j++){
//	j = Random.Range(0, npc.Length ); 
//	if (!isCreated){
//	GameObject npcCreated = (GameObject) Instantiate(npc[j], transform.position, Quaternion.identity);
//	npcCreated.transform.parent = transform;
//	isCreated = true; 
//	notKilled = true;
//
//	}
//
//
//
//
//	}
//}
//}
//}
//}
