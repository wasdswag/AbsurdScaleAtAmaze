using UnityEngine;
using System.Collections;

public class LookAtMe : MonoBehaviour {

	Transform target;
	public float delta;
	public float xAng;
	public float yAng;
	public float zAng;

	void Start(){
	target = GameObject.Find ("Camera").transform;
	}



    	// Update is called once per frame
	void LateUpdate () {

	Vector3 relativePos = target.position - transform.position;

	Quaternion CLAMP = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation(relativePos), delta);
	transform.rotation = new Quaternion(Mathf.Clamp(CLAMP.x,-xAng ,xAng), Mathf.Clamp(CLAMP.y,-yAng ,yAng), zAng, CLAMP.w);






//	Vector3 relativePos = target.position - transform.position;
//    Quaternion rotation = Quaternion.LookRotation(relativePos); 
//    transform.rotation = rotation;








	//transform.LookAt(target);



//		Vector3 targetDir = target.position - transform.position;
//        float step = speed * Time.deltaTime;
//        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
//        Debug.DrawRay(transform.position, newDir, Color.red);
//        transform.rotation = Quaternion.LookRotation(newDir);
//		//transform.localEulerAngles.x = 0;
//  		//transform.localEulerAngles.z = 0;
// 
	}

}
