  using UnityEngine;
using System.Collections;

public class LoveAttack : MonoBehaviour {

Transform player;
public float rotspeed = 150f;
float speed;
public float walkSpeed = 3.6f; 
public float normSpeed;

GameObject[] otherLovers;
public float loversDistance = 10f;
//private bool[] col;




void Start(){
	 player = GameObject.Find ("FPSController").transform;
	 otherLovers = GameObject.FindGameObjectsWithTag("Respawn"); 

}


	// Update is called once per frame
void Update () {

	///// скорость вращения
    float step = rotspeed * Time.deltaTime;

    ///// скорость ходьбы 
	float wSpeed = walkSpeed * Time.deltaTime;


	//// check lovers between lovers and fpc
	float dist = Vector3.Distance(transform.position, player.transform.position);

	///////////////////
//	for (int i = 0; i < otherLovers.Length ; i++ ) { 
//
//	float loversDist = Vector3.Distance(transform.position, otherLovers[i].transform.position);
//	if (loversDist <= 20f){ 
//
//	transform.position = Vector3.MoveTowards(transform.position, otherLovers[i].transform.position,  -1); 
//	if (loversDist >= 20f){ 
//	transform.position =  new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);} 


	//transform.rotation = Quaternion.RotateTowards(transform.rotation, otherLovers[i].transform.rotation, -step);



//	for (int i = 0; i < otherLovers.Length ; i++ ) { 
//	if (Vector3.Distance(transform.position, otherLovers[i].transform.position) < loversDistance
//	&& transform.position.x > otherLovers[i].transform.position.x) {
//	transform.position +=  Vector3.right * (0.02f * Time.deltaTime) ; 
//	}
//	else if (Vector3.Distance(transform.position, otherLovers[i].transform.position) < loversDistance
//	&& transform.position.x < otherLovers[i].transform.position.x) {
//	transform.position +=  Vector3.left * (0.02f * Time.deltaTime); 
//	}
//	// play some     sad sound
//	else if (Vector3.Distance(transform.position, otherLovers[i].transform.position) > loversDistance) {


	transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, 
	transform.position.y, player.transform.position.z), wSpeed);
	transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, step);


	if (dist < 11f){
    walkSpeed = 0f;
    }
    else { walkSpeed = normSpeed; 
    }
    }}



   

	





