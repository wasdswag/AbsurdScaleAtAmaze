using UnityEngine;
using System.Collections;

public class GenerationX : MonoBehaviour {


	public GameObject[] objects;
    int index;
    GameObject currentObject;
	private Ray ray;
	private RaycastHit hit;
	public bool hover;
	GameObject thisMan;


     void Start(){
    hover = false;
    index = Random.Range(0, objects.Length);
	currentObject = Instantiate(objects[index], transform.position, Quaternion.identity) as GameObject;
	currentObject.transform.parent = transform;
	thisMan = GameObject.FindGameObjectWithTag("Respawn");  



     }

  

 
     void  Update (){

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 150f) && hit.transform.tag == "Respawn" && Input.GetMouseButtonDown(0)) {
		currentObject = hit.transform.gameObject;
		hover = true;
		index++;
		if (index >= objects.Length){ index = 0;} 

        if(hover && currentObject != null) Destroy(hit.collider.gameObject);
        currentObject = Instantiate(objects[index], transform.position, Quaternion.identity) as GameObject;
		currentObject.transform.parent = transform;
		}

		}
     }


