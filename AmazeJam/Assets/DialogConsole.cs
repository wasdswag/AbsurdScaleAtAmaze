using UnityEngine;
using System.Collections;

namespace TMPro.Examples
{

public class DialogConsole : MonoBehaviour {

	
        private TMP_Text m_TextComponent;
        private bool hasTextChanged;
        public int CurrentPage = 1;
        private TMP_Text pageComponent;
        private bool pause;
        public float breakPause = 2f;
        private bool skip;
		int visibleCount = 0;
		int totalVisibleCharacters;
		public string NPC_Name;
		GameObject FPCMask;

		int countChecker;
		int pageChecker;


		public bool visible;
		GameObject [] serge;
		Transform player;




        void Awake()
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
            pageComponent = gameObject.GetComponent<TextMeshProUGUI>();

        }


        void Start()
        {
			serge = GameObject.FindGameObjectsWithTag(NPC_Name);	
			player = GameObject.Find("FPSController").transform;
			FPCMask = GameObject.Find("FPSController/Camera/Mask");
            StartCoroutine(CheckDist());
			StartCoroutine(RevealCharacters(m_TextComponent));
		}


	IEnumerator CheckDist(){
	while(true){
	yield return new WaitForSeconds(0.1f);
	serge = GameObject.FindGameObjectsWithTag(NPC_Name);
	for (int i = 0; i < serge.Length; i++){
	float dist = Vector3.Distance(player.position, serge[i].transform.position);

	if (dist >= 25f || FPCMask.activeInHierarchy == false){
	visible = false;


	}

	else if (dist < 25f){
	visible = true;


	}

	}}}




        IEnumerator RevealCharacters(TMP_Text textComponent)
        {
           
            while (true)
            {	

           
			textComponent.ForceMeshUpdate();
            TMP_TextInfo textInfo = textComponent.textInfo;
			totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
            //visibleCount = 0;
            int allPages = textInfo.pageCount;

            pause = false;
            skip = false;

            	
				textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
				pageComponent.pageToDisplay = CurrentPage;
				int maxPage = m_TextComponent.textInfo.pageCount;
				//CurrentPage = Mathf.Clamp(CurrentPage, 0, maxPage + 1);

				if(!pause && visible){
				visibleCount += 1;
				}

				if(!visible){
				textComponent.maxVisibleCharacters = 0;
			
				pageComponent.pageToDisplay = pageChecker;
				visibleCount = m_TextComponent.textInfo.pageInfo[CurrentPage - 1].firstCharacterIndex + 1;
				}

				yield return new WaitForSeconds(0.0f);

				if (visibleCount >= m_TextComponent.textInfo.pageInfo[CurrentPage - 1].lastCharacterIndex + 1)
                {	
                	pause = true;

					if (Input.GetKeyDown("g")){
				 	breakPause = 0f;
					
					}

                	yield return new WaitForSeconds(breakPause);
                    CurrentPage += 1;
					pause = false;
					yield return new WaitForSeconds(breakPause);
					breakPause = 1f;
				}


                if (visibleCount > totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(1.0f);
                    visibleCount = 0;
                    CurrentPage = 1;

                   
                }


                countChecker = visibleCount;
                pageChecker = CurrentPage;
                Debug.Log(pageChecker);

              }
        }





	}}



        /// <summary>
        /// Method revealing the text one word at a time.
        /// </summary>
        /// <returns></returns>
//        IEnumerator RevealWords(TMP_Text textComponent)
//        {
//            textComponent.ForceMeshUpdate();
//
//            int totalWordCount = textComponent.textInfo.wordCount;
//            int totalVisibleCharacters = textComponent.textInfo.characterCount; // Get # of Visible Character in text object
//            int counter = 0;
//            int currentWord = 0;
//            int visibleCount = 0;
//
//            while (true)
//            {
//                currentWord = counter % (totalWordCount + 1);
//
//                // Get last character index for the current word.
//                if (currentWord == 0) // Display no words.
//                    visibleCount = 0;
//                else if (currentWord < totalWordCount) // Display all other words with the exception of the last one.
//                    visibleCount = textComponent.textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
//                else if (currentWord == totalWordCount) // Display last word and all remaining characters.
//                    visibleCount = totalVisibleCharacters;
//
//                textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
//
//                // Once the last character has been revealed, wait 1.0 second and start over.
//                if (visibleCount >= totalVisibleCharacters)
//                {
//                    yield return new WaitForSeconds(1.0f);
//                }
//
//                counter += 1;
//
//                yield return new WaitForSeconds(0.1f);
//            }
//        }

 