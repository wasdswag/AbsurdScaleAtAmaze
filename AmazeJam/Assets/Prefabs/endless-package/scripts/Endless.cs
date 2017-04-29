/*
 * @author SoftRare - www.softrare.eu
 * @version 1.0
 * @date somewhere in 2010
 * @license Published under GPL v.3
 * 
 * We ask you to include some sort of attribution if you include code from this class in one of your personal/commercial projects.
 * Please note that we don't provide official support for this code anymore.
 * 
 * Usage: 
 * Put Endless-prefab in your scene (the scene must include a Unity3d terrain). Drag and drop your player gameObject on the "playerObject" variable of the prefab script.
 * Adjust updatingInterval (standard value is 0.0005), targetFrameRate (standard value is 30), and cameraFarClipPlane (standard is 700).
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Endless : MonoBehaviour
{
    // Fields
	public float cameraFarClipPlane;
	public int targetFrameRate;
	public GameObject playerObject;
    private static Endless ms_Singleton;
    private Terrain tOrg;
    private float xlength;
    private float zlength;
	
	public float updatingInterval;
	private static float timeelapsed = 0.0f;
	private static bool continueCallingUpdate = true;
	
	private Terrain terrainRight = null;
	private Terrain terrainLeft = null;
	private Terrain terrainBottom = null;
    private Terrain terrainTop = null;
	private Terrain terrainBottomRight = null;
	private Terrain terrainTopRight = null;
	private Terrain terrainBottomLeft = null;
	private Terrain terrainTopLeft = null;

	
	//necessary dummy, don't remove
	public static void instantiateSingleton() {
		
	}	
	
    // Methods
    private void Start()
    {

        ms_Singleton = this;
		if (tOrg == null)
        	this.tOrg = Terrain.activeTerrain;
        this.xlength = this.tOrg.terrainData.size.x;
        this.zlength = this.tOrg.terrainData.size.z;

        for (int i = 0; i < 8; i++)
        {
            Vector3 position = this.tOrg.transform.position;
            switch (i)
            {
                case 0:
                    position.x += this.xlength;
                    position.z += this.zlength;
                    break;

                case 1:
                    position.x += this.xlength;
                    position.z += 0f;
                    break;

                case 2:
                    position.x += this.xlength;
                    position.z -= this.zlength;
                    break;

                case 3:
                    position.x += 0f;
                    position.z -= this.zlength;
                    break;

                case 4:
                    position.x -= this.xlength;
                    position.z -= this.zlength;
                    break;

                case 5:
                    position.x -= this.xlength;
                    position.z += 0f;
                    break;

                case 6:
                    position.x -= this.xlength;
                    position.z += this.zlength;
                    break;

                case 7:
                    position.x += 0f;
                    position.z += this.zlength;
                    break;
            }
			
			
			
			GameObject go =Terrain.CreateTerrainGameObject((TerrainData)GameObject.Instantiate(this.tOrg.terrainData));
			Terrain terrainClone = go.GetComponent<Terrain>();
			terrainClone.transform.position = position;
            switch (i)
            {
                case 0:
                    terrainTopRight = terrainClone;
                    break;

                case 1:
                    terrainRight = terrainClone;
                    break;

                case 2:
                    terrainBottomRight = terrainClone;
                    break;

                case 3:
                    terrainBottom = terrainClone;
                    break;

                case 4:
                    terrainBottomLeft = terrainClone;
                    break;

                case 5:
                    terrainLeft = terrainClone;
                    break;

                case 6:
                    terrainTopLeft = terrainClone;
                    break;

                case 7:
                    terrainTop = terrainClone;
                    break;
            }
        }
		//(left : Terrain, top : Terrain, right : Terrain, terrain, Bottom : Terrain
        terrainTopRight.SetNeighbors(terrainTop, null, null, terrainRight);
        terrainBottomRight.SetNeighbors(terrainBottom, terrainRight, null, null);
		terrainBottomLeft.SetNeighbors(null, terrainLeft, terrainBottom, null);
		terrainTopLeft.SetNeighbors(null, null, terrainTop, terrainLeft);        
		
		terrainRight.SetNeighbors(tOrg, terrainTopRight, null,terrainBottomRight);
		terrainLeft.SetNeighbors(null, terrainTopLeft, tOrg, terrainBottomLeft);
		terrainTop.SetNeighbors(terrainTopLeft, null, terrainTopRight, tOrg);
		terrainBottom.SetNeighbors(terrainBottomLeft, tOrg, terrainBottomRight, null);
		
		this.tOrg.SetNeighbors(terrainLeft, terrainTop, terrainRight, terrainBottom);		
		
		adjustTerrainHeights(terrainRight,"right");
		adjustTerrainHeights(terrainTopRight,"right");
		adjustTerrainHeights(terrainBottomRight,"right");
		adjustTerrainHeights(terrainLeft,"left");
		adjustTerrainHeights(terrainTopLeft,"left");
		adjustTerrainHeights(terrainBottomLeft,"left");
		adjustTerrainHeights(terrainTop,"top");
		adjustTerrainHeights(terrainTopRight,"top");
		adjustTerrainHeights(terrainTopLeft,"top");
		adjustTerrainHeights(terrainBottom,"bottom");		
		adjustTerrainHeights(terrainBottomRight,"bottom");
		adjustTerrainHeights(terrainBottomLeft,"bottom");
        
		if (targetFrameRate != 0)
	    	Application.targetFrameRate = targetFrameRate;
		
		if (cameraFarClipPlane != 0f)
			Camera.main.farClipPlane = cameraFarClipPlane;	
		
		checkUpdate();
    }
	
    // Methods
	private void execAction() {
		ArrayList newPosStruct = Endless.getNewPositionStruct(playerObject.transform.position);
		
		if ((bool)newPosStruct[0] == true) {
			playerObject.transform.position = (Vector3)newPosStruct[1];
		}	
	}
	
	//update recording/replaying position and start timer to next update
	private void checkUpdate() {
		float updateStartingTime = Time.realtimeSinceStartup;
		bool mayBeNull = true;
		
		float interval = updatingInterval;		
							
		//execute current recorder action
		execAction();
		
		float updateEndingTime = Time.realtimeSinceStartup;

		StartCoroutine(waitForNewUpdate(interval,timeelapsed));
			


	}	
	
	//there is an interval to wait for before the update will be done
	private IEnumerator waitForNewUpdate(float delay, float timeelapsed) {
		yield return new WaitForSeconds(delay);

		if (continueCallingUpdate)
			checkUpdate();

	}
	
	public void adjustTerrainHeights(Terrain terrain,string locationToChange)
	{
        int xMax = (int)terrain.terrainData.heightmapWidth;
        int yMax= (int)terrain.terrainData.heightmapHeight;

		float[,] heights = terrain.terrainData.GetHeights(0, 0, xMax, yMax);
		
		//terrain top:
		if (locationToChange == "top") {
			for (int y=0;y<yMax;y++) {
				heights[0,y] = heights[xMax-1,y];
			}
		
		//terrain right:
		} else if (locationToChange == "right") {
			for (int x=0;x<xMax;x++) {
				heights[x,0] = heights[x,yMax-1];
			}	
		
		//terrain bottom:
		} else if (locationToChange == "bottom")
			for (int y=0;y<yMax;y++) {
			heights[xMax-1,y] = heights[0,y];
			
		//terrain left:
		} else if (locationToChange == "left") {	
			for (int x=0;x<xMax;x++) {
				heights[x,yMax-1] = heights[x,0];
			}			
		}
	
		terrain.terrainData.SetHeights(0, 0, heights);
	}
	
	public static ArrayList getNewPositionStruct(Vector3 position) {
        
		float correction = 0f;
		ArrayList ret = new ArrayList();
		ret.Insert(0,false);
        if (position.x >= singleton.xlength)
        {
            //Debug.Log("x > length");
            correction = position.x - singleton.xlength;
            position.x = 0f + correction;
			ret.Insert(0,true);
			ret.Insert(1,position);
        }
        else if (position.z >= singleton.zlength)
        {
            //Debug.Log("z > length");
            correction = position.z - singleton.zlength;
            position.z = 0f + correction;
			ret.Insert(0,true);
			ret.Insert(1,position);
        }
        else if (position.x <= 0f)
        {
            //Debug.Log("x < 0");
            correction = position.x;
            position.x = singleton.xlength - correction;
			ret.Insert(0,true);
			ret.Insert(1,position);
        }
        else if (position.z <= 0f)
        {
            //Debug.Log("z < 0");
            correction = position.z;
            position.z = singleton.zlength - correction;
			ret.Insert(0,true);
			ret.Insert(1,position);
        }	
		
		return ret;
	}

    // Properties
    private static Endless singleton
    {
        get
        {
            if (ms_Singleton == null)
            {
             //   Type[] components = new Type[] { typeof(ZoneLoaderG) };
                GameObject obj2 = new GameObject("Endless", typeof(Endless) );
                ms_Singleton = obj2.GetComponent(typeof(Endless)) as Endless;
            }
            return ms_Singleton;
        }
    }
}
