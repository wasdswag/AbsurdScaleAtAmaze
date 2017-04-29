using UnityEngine;
using System.Collections;

namespace AIDesigner{

public class SceneTimeScale : MonoBehaviour {

	public float gameTimeScale = 1.5f;

	// Use this for initialization
	void Start () {
		Time.timeScale = gameTimeScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}