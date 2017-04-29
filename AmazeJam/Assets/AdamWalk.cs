using UnityEngine;
using System.Collections;

public class AdamWalk : MonoBehaviour {



Transform player;
public float rotspeed = 150f;
float speed;
public float walkSpeed = 3.6f; 
public float normSpeed;
float dist;

GameObject[] animals;
public float loversDistance = 10f;
public int randomAnimal;
int thisAnimal = 0;
Animator animator;


public float checkInterval = 0.2f; // как часто проверять расстояние
public bool isCheckDistance = true; // провеklkрять ли вообще
public bool isWalking = false;
bool stop = true;

//
//GameObject textSelector;
//ObjectSelector objSelector;

GodMode godMode;
Vector3 AnimalPos;
GameObject creator;

public bool AnisActive;

Ray ray;
RaycastHit hit;


void Start(){
	animals = GameObject.FindGameObjectsWithTag("Respawn"); 
	animator = GetComponentInChildren<Animator>();

//	textSelector = GameObject.Find("Selector/text");
//	objSelector = textSelector.GetComponent<ObjectSelector>();
	creator = GameObject.Find("Create");
	AnimalPos = creator.GetComponent<GodMode>().pos;
	AnisActive = creator.GetComponent<GodMode>().itIsAnimal;
	StartCoroutine ( SlowDistanceCheck() );


	}


	IEnumerator SlowDistanceCheck(){
	while(true){
	yield return new WaitForSeconds (0.1f);

	if (!isWalking && (Vector3.Distance (transform.position, GameObject.Find("Create").GetComponent<GodMode>().pos) > 45f)) {
	animator.SetTrigger ("Walk");
	isWalking = true;
	}
	else if (isWalking && (Vector3.Distance (transform.position, GameObject.Find("Create").GetComponent<GodMode>().pos) < 45f)){
	animator.SetTrigger ("Idle");
	isWalking = false;

	}

	}
	} 



	// Update is called once per frame
	void Update () { 



	///// скорость вращения
    float step = rotspeed * Time.deltaTime;
    ///// скорость ходьбы 
	float wSpeed = walkSpeed * Time.deltaTime;
	//// check lovers between lovers and fpc







	float dist = Vector3.Distance(transform.position, GameObject.Find("Create").GetComponent<GodMode>().pos);

	if(GameObject.Find("Create").GetComponent<GodMode>().itIsAnimal && dist > 45f){
	isWalking = false;
	walkSpeed = normSpeed;
	transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Create").GetComponent<GodMode>().pos, wSpeed);
	this.transform.LookAt(GameObject.Find("Create").GetComponent<GodMode>().targetPos);
	}

	else if (dist < 45f){
	isWalking = true;
    walkSpeed = 0f;
    }
    else { walkSpeed = normSpeed; 
    }
	




	}
	}

	



    



   

	








   

	





