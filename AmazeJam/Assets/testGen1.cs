using UnityEngine;
using System.Collections;

public class testGen1 : MonoBehaviour {

	public GameObject[] bred;

    int number;
    GameObject cur;
	private Ray buba;
	private RaycastHit h;
	public bool cover;


    void Start(){

    cover = false;
    number = Random.Range(0, bred.Length);
  	cur = Instantiate(bred[number], transform.position, Quaternion.identity) as GameObject;
	cur.transform.parent = transform;

     }

     void  Update (){

		buba = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(buba, out h, 150f) && h.transform.tag == "Finish" && Input.GetMouseButtonDown(0)) {
		number++;
		if (number >= bred.Length){ number = 0;} 
		cover = true;


 		if(cover && cur != null) Destroy(h.transform.gameObject);
        cur = Instantiate(bred[number], transform.position, Quaternion.identity) as GameObject;
		cur.transform.parent = transform;
        cover = false;
		
		}}
     }


