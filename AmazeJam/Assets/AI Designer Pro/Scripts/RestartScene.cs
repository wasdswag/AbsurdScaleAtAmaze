using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart(){
		//Application.LoadLevel(Application.loadedLevel);	// old api
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 5.3+ api
	}
}
