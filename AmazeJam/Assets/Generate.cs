using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

public Transform player;
Vector3 pos;

GameObject currentObject;
bool isgenerated;
public GameObject [] creations;


	// Use this for initialization
	void Start () {
//	InvokeRepeating("LaunchGen", 0f, f);
	StartCoroutine (GenerateObj());

	}

	private Vector3 RandomVector (float range)
	{
		return new Vector3(Random.Range(-range,range),Random.Range(-range,range),Random.Range(-range,range));
	}

	IEnumerator GenerateObj(){
	while(true){
	yield return new WaitForSeconds(4f);
			pos = player.position + player.forward * 200f;

	currentObject = Instantiate(creations[Random.Range(0, creations.Length)], pos, Quaternion.identity) as GameObject;
	currentObject.transform.parent = transform;
			StartCoroutine(Grow(currentObject.transform));

	if (currentObject.GetComponent<Rigidbody>() == null) {
		currentObject.AddComponent<BoxCollider>();
				currentObject.AddComponent<Rigidbody>();
				currentObject.GetComponent<Rigidbody>().AddTorque(RandomVector(10f),ForceMode.Impulse);
				currentObject.GetComponent<Rigidbody>().AddForce(RandomVector(10f),ForceMode.Impulse);
	}

	Renderer[] rendererArray = currentObject.GetComponentsInChildren<Renderer>();
	for (int i = 0; i < rendererArray.Length; ++i) {
		Renderer renderer = rendererArray[i];
		Material[] materials = renderer.materials;
		Material[] mats = new Material[materials.Length];
		for (int m = 0; m < materials.Length; ++m) {
			Material old = materials[m];
					mats[m] = new Material(Shader.Find("Unlit/ShaderStuff"));
			mats[m].color = old.color;
			if (old.mainTexture != null) {
				mats[m].mainTexture = old.mainTexture;
				mats[m].SetFloat("_ColorNormal", 0f);
			} else {
				mats[m].SetFloat("_ColorNormal", 1f);
			}
		}
		renderer.materials = mats;
	}

		}
	}

	IEnumerator Grow (Transform t){
	float ratio = 0f;
	while (ratio <= 1f) {
		t.localScale = Vector3.one * ratio;
		ratio += Time.deltaTime;
			yield return null;
	}

	}

}
