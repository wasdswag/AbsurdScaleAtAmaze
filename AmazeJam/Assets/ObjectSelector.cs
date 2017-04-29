using UnityEngine;
using System.Collections;
using TMPro;


public class ObjectSelector : MonoBehaviour {

		private TMP_Text m_TextComponent;
     
    	public int CurrentPage = 1;
        private TMP_Text pageComponent;
   		GameObject FPCMask;


	




		void Awake()
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
            pageComponent = gameObject.GetComponent<TextMeshProUGUI>();
			

        }

	
	// Update is called once per frame
	void Update() {

	pageComponent.pageToDisplay = CurrentPage;
	if(Input.GetAxis("Mouse ScrollWheel") > 0f){
	CurrentPage += 1;

	}
	else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
	CurrentPage -=1;
	}
	if (CurrentPage > 6){
	CurrentPage = 1;

	}
	if (CurrentPage < 1){
	CurrentPage = 6;

	}




	}
}


