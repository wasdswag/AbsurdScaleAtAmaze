using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyShader : MonoBehaviour {

	public Shader shader;

	void Start () {
		Renderer[] rendererArray = GetComponentsInChildren<Renderer>();
		for (int i = 0; i < rendererArray.Length; ++i) {
			Renderer renderer = rendererArray[i];
			Material[] materials = renderer.materials;
			Material[] mats = new Material[materials.Length];
			for (int m = 0; m < materials.Length; ++m) {
				Material old = materials[m];
				mats[m] = new Material(shader);
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
	
	void Update () {
		
	}
}
