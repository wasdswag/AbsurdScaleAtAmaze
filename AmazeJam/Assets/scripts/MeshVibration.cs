using UnityEngine;
using System.Collections;

public class MeshVibration : MonoBehaviour {

	    
	private AudioListener listener;
		
		//public int quality = 50;
		public float scale= 1.0f;
		public float speed= 1.0f;
		public bool recalculateNormals= false;
		
		private Vector3[] baseVertices;
		private Perlin noise;
		
		void  Start (){
		  	listener = Camera.main.GetComponent<AudioListener>();
			noise = new Perlin ();
		}
		
		void  Update (){
			Mesh mesh = GetComponent<MeshFilter>().mesh;
			
		
		
			
			if (baseVertices == null)
				baseVertices = mesh.vertices;
			
		var vertices = new Vector3[baseVertices.Length];
		float [] soundBit = new float[vertices.Length];
			
		//float timex= Time.time * speed + 0.1365143f ;
		float timey= Time.time * speed + 1.21688f  ;
		//float timez= Time.time * speed + 2.5564f;
		
			for (int i = 0; i < vertices.Length;i++)
		{	
				AudioListener.GetOutputData(soundBit, 0);
				//Debug.Log ("soundbeat is" + soundBit) ;
				Vector3 vertex= baseVertices[i];
				//scale = scale + 2*soundBit[i]; 
				
		//	vertex.x += noise.Noise(timex + vertex.x, timex + vertex.y, timex + vertex.z) * scale ;
			vertex.y += noise.Noise(timey + vertex.x, timey + vertex.y, timey + vertex.z) * scale ;
		//	vertex.z += noise.Noise(timez + vertex.x, timez + vertex.y, timez + vertex.z) * scale ;
				
				vertices[i] = vertex;
			}
			
			mesh.vertices = vertices;
			
			if (recalculateNormals)	
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}
	}