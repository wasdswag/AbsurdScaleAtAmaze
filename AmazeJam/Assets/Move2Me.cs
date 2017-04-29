using UnityEngine;
using System.Collections;

public class Move2Me : MonoBehaviour {

    public float speed;
	public GameObject player;


    void Start() {
	

    }

    void Update() {
        float step = speed * Time.deltaTime;
		float dist = Vector3.Distance(transform.position, player.transform.position);

		transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, 
		transform.position.y, player.transform.position.z), step);

        if (dist < 11f){
        speed = 0f;
        }
        else { speed = 3.6f; }
    }
}