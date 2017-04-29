using UnityEngine;
using System.Collections;

public class TearsCrump : MonoBehaviour {

	//public int quality = 50;
		public float scale= 1.0f;
		public float speed= 1.0f;
		public bool recalculateNormals= false;
		
		private Vector3[] baseVertices;
		private Perlin noise;
		
		void  Start (){
			noise = new Perlin ();
		}
		
		void  Update (){
			Mesh mesh = GetComponent<MeshFilter>().mesh;
			
		
		
			
			if (baseVertices == null)
				baseVertices = mesh.vertices;
			
		var vertices = new Vector3[baseVertices.Length];
			
		float timey= Time.time * speed + 1.21688f  ;

			for (int i = 0; i < vertices.Length;i++)
		{	
				Vector3 vertex= baseVertices[i];

			vertex.y += noise.Noise(timey + vertex.x, timey + vertex.y, timey + vertex.z) * scale ;
				
				vertices[i] = vertex;
			}
			
			mesh.vertices = vertices;
			
			if (recalculateNormals)	
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}
	}