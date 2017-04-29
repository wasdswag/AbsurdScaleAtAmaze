using UnityEngine;
using System.Collections;

public class MakeItSmaller : MonoBehaviour {

Transform fps;
Renderer grids;

	public float startDistance = 50f;
	public float endDistance = 20f;
	float diffDistance;



	// Use this for initialization
	void Start () {
	fps = GameObject.Find("FPSController").transform;
	diffDistance = startDistance - endDistance;
	grids = GameObject.Find("Plane").GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
	float dist = Vector3.Distance (transform.position, fps.position);


		float d = Mathf.Lerp(0f, 1f,  (dist-endDistance)/diffDistance);

		transform.localScale = new Vector3 (Mathf.Lerp(0f, 5f, (dist-endDistance)/diffDistance), Mathf.Lerp(0f, 5f, (dist-endDistance)/diffDistance), Mathf.Lerp (0f, 5f, (dist-endDistance)/diffDistance));
		grids.material.SetTextureScale("_MainTex", new Vector2 ( Mathf.Lerp(5f, 1f, (dist-endDistance)/diffDistance), Mathf.Lerp(5f, 1f, (dist-endDistance)/diffDistance)));
		 

	}
	

}
