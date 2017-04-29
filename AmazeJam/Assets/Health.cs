using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public GameObject Arm1;
	public Renderer drunk;
	float distort;
	public float foodScore = 60f;
	public AudioSource tada;
	Ray ray;
	private RaycastHit hit;

//	private bool isCheckH = true;
//
//	public float rate = 0.2f;


	//private bool isActive = false;




//	void Awake(){
//	StartCoroutine(CheckHarm());
//	}
//
//	IEnumerator CheckHarm(){
//	while (isCheckH){
//
//	yield return new WaitForSeconds (rate);

void Update(){
	distort = drunk.material.GetFloat("_BumpAmt");

	ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
	if (Physics.Raycast(ray, out hit, 6f) && hit.collider.tag == "food") {
	Arm1.SetActive(true);
	if(Input.GetMouseButtonDown(0)) {
	tada.Play();
	Destroy(hit.collider.gameObject); 
	Arm1.SetActive(false);
	drunk.material.SetFloat("_BumpAmt", distort - foodScore);  
	}}
	else {
	Arm1.SetActive(false);
	}
	}}