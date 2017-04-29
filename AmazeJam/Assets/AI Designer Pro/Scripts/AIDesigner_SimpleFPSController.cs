using UnityEngine;
using System.Collections;

namespace AIDesigner{

public class AIDesigner_SimpleFPSController : MonoBehaviour {

		public float moveSpeed = 1.5f;
		private float originalMoveSpeed = 1.5f;

    public bool delayStart = true;  // allow everything to finish loading first
                                  // otherwise, initial player movement can be laggy
    public float delayTime = 2;
    private bool canMove = false;

		// The cameraTransform we are following
		[SerializeField]
		private Transform cameraTransform;

		private Transform fpsChar;	// cache our main Transform for performance

	// SMOOTH MOUSE:
	    Vector3 m_TargetAngles;
	    private Vector3 m_FollowAngles;
	    private Vector3 m_FollowVelocity;		
        private Vector2 rotationRange = new Vector3(180, 360);
        private Quaternion originalRot;

		// Use this for initialization
		void Start() {
			originalRot = cameraTransform.localRotation;
			originalMoveSpeed = moveSpeed;
			fpsChar = GetComponent<Transform>();
      Invoke("CanStart", delayTime);

		}


    void CanStart(){
      canMove = true;
    }

		void FixedUpdate(){
      if (canMove){

              cameraTransform.localRotation = originalRot;

              // get and process user input:
              float inputH2 = Input.GetAxis("Horizontal");
              float inputV2 = Input.GetAxis("Vertical");
              float inputH = Input.GetAxis("Mouse X");;
              float inputV = Input.GetAxis("Mouse Y");;
              m_TargetAngles.y += inputH*0.8f;
              m_TargetAngles.x += inputV*0.8f;

              m_TargetAngles.y = Mathf.Clamp(m_TargetAngles.y, -rotationRange.y*0.5f, rotationRange.y*0.5f);
              m_TargetAngles.x = Mathf.Clamp(m_TargetAngles.x, -rotationRange.x*0.5f, rotationRange.x*0.5f);

              m_FollowAngles = Vector3.SmoothDamp(m_FollowAngles, m_TargetAngles, ref m_FollowVelocity, 0.2f);
             	cameraTransform.localRotation = originalRot*Quaternion.Euler(-m_FollowAngles.x, m_FollowAngles.y, 0);		
             	fpsChar.localRotation = new Quaternion(fpsChar.localRotation.x, cameraTransform.localRotation.y, fpsChar.localRotation.z, fpsChar.localRotation.w);


             	// run:
             	if (Input.GetKey(KeyCode.LeftShift)){
             		moveSpeed = originalMoveSpeed * 4;
             	} else {
             		moveSpeed = originalMoveSpeed;
             	}


             	// forward back and strafe:
              fpsChar.Translate(fpsChar.forward * moveSpeed * inputV2 * Time.fixedDeltaTime);
              fpsChar.Translate(fpsChar.right * moveSpeed * inputH2 * Time.fixedDeltaTime);

    }

	}





	} 

}
