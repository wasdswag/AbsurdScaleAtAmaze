using UnityEngine;
using System.Collections;

public class drunkMode : MonoBehaviour {

	public GameObject Arm1;
	public Renderer drunk;
	float distort;
	public float drunkScore = 60f;
	public AudioSource tada;
	Ray ray;
	private RaycastHit hit;
//	private bool isCheck = true;
//
//	public float rate = 0.2f;
//
//
//	//private bool isActive = false;
//
//
//
//
//	void Awake(){
//	StartCoroutine(CheckArm());
//	}
//
//	IEnumerator CheckArm(){
//	while (isCheck){
//
//	yield return new WaitForSeconds (rate);

void Update(){
	distort = drunk.material.GetFloat("_BumpAmt");

	ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
	if (Physics.Raycast(ray, out hit, 5f) && hit.collider.tag == "alco") {
	Debug.Log (distort + hit.collider.gameObject.GetComponent<drunkMode>().drunkScore); 

	Arm1.SetActive(true);
	if(Input.GetMouseButtonDown(0)) {
	tada.Play();
	drunk.material.SetFloat("_BumpAmt", distort + hit.collider.gameObject.GetComponent<drunkMode>().drunkScore); 
	//isDestoyed = true;
	Destroy(hit.collider.gameObject); 
	Arm1.SetActive(false); 
	}}
	else {
	Arm1.SetActive(false);
	}

	}}






	

