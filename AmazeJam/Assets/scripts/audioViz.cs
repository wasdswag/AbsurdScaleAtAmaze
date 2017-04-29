using UnityEngine;
using System.Collections;

public class audioViz : MonoBehaviour
{
	public LineRenderer lineRend;
	private AudioListener listener;
	public int quality = 50;
//	public float len = 0;
	public float amplitude = 20;
	
	public float xradius;
	public float yradius;
	public float scale = 0.00001f;
	
	float x;
	float y;
	float z = 0f;
	
	float angle = 20f;
	
	void Start(){
	lineRend.useWorldSpace = false;
 	listener = Camera.main.GetComponent<AudioListener>();
	}
	
	void Update () 
	{
		float[] soundBit = new float[quality];
		lineRend.SetVertexCount(quality);
		
		
		
		
//		if (audio.isPlaying)
//		{
			for (int i = -quality / 2; i < quality / 2; i++) 		
			{	
				
				AudioListener.GetOutputData(soundBit, 0);
				x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius + soundBit[i + quality / 2] * amplitude;
				y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius - soundBit[i + quality / 2] * amplitude;
				angle += (360f / quality);
				
				lineRend.SetPosition(i + quality / 2, new Vector3(x, y , z));
				transform.localScale += new Vector3(0 +  scale, 0 + scale, 1 + scale)* Time.deltaTime;
				
			
//			}
		}
	}
}