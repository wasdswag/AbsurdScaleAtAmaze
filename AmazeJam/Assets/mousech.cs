using UnityEngine;
using System.Collections;


public class mousech : MonoBehaviour 
{
	private Ray ray;
	private RaycastHit hit;
	Collider coll;
	public bool hover;


    void Start () 
    {
	coll = GetComponentInChildren<Collider>();
	hover = false;
    }

    // Update is called once per frame
    void Update () 
    {
	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
	if (Physics.Raycast(ray, out hit, 100f)) {
			if (hit.collider.gameObject.tag == "Respawn" && Input.GetMouseButtonDown(0) ) {
	Debug.Log("YOU MAKE ME CRY");


	hover = true;
	}
	else { hover = false;
	}
	//print(coll.name); 


     }
     }
   
     }


    


