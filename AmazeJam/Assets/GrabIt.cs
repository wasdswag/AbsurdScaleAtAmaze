using UnityEngine;
using System.Collections;

public class GrabIt : MonoBehaviour {

	public float delay = 5f;
	
	public GameObject FPC;
	public GameObject text;
	private bool isClicked;
	public GameObject trophey;

	public AudioSource tada;
	public GameObject[] awards;
	private int awardNumb;
	
	public float distance = 12f;


	public GameObject[] tropheys;
	private int tropheyNumb;
	
	void Start(){
	isClicked = false;
	text.SetActive(false);



	for (int i = 0; i < awards.Length; i++){
	awards[i].SetActive(false); 
	}
	}

	void Update () {

	if (Vector3.Distance (transform.position, FPC.transform.position) < distance){
	text.SetActive(true);
	}
	if (!isClicked && Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, FPC.transform.position) < distance){
	tada.Play();
	text.SetActive(false); 	
	trophey.SetActive(false);
	isClicked = true;


	awardNumb = Random.Range (0,awards.Length);
	tropheyNumb = Random.Range (0,tropheys.Length);
	for (int i = 0; i < awards.Length; i++){
	for (int j = 0; j < tropheys.Length; j++){
	
	
				
	awards[i].SetActive(false); 
	awards[awardNumb].SetActive(true);
	
	
	
	tropheys[j].SetActive(false);
	tropheys[tropheyNumb].SetActive(true); 
	
	
	Trophey(); 
	Prize();
	}

	}
	}
	else if (Vector3.Distance (transform.position, FPC.transform.position) > distance){
	awards[awardNumb].SetActive(false); 
	
	//tropheys[tropheyNumb].SetActive(false); 
				
	text.SetActive(false);
	}
		
	}

void Trophey(){

		StartCoroutine (TimeToGo() );
	}

	
		IEnumerator TimeToGo() {
		yield return new WaitForSeconds (delay);
		trophey.SetActive(true); 
		tropheys[tropheyNumb].SetActive(false);
		//tropheys[tropheyNumb].SetActive(true);
		text.SetActive(false); 
		isClicked = false;
}
void Prize(){

		StartCoroutine (PrizeAppear() );
	}
		IEnumerator PrizeAppear() {
		yield return new WaitForSeconds (delay);
		awards[awardNumb].SetActive(false);

	

	} 

}

