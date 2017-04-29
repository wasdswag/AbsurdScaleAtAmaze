using UnityEngine;
using System.Collections;

public class BodyRot : MonoBehaviour {

	Transform player;
	public float speed =150f;
	public float distance;

	void Start(){
		 player = GameObject.Find ("FPSController").transform;
	}


    	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (transform.position, player.position) < distance) {
        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, step);



        }
    }
}
