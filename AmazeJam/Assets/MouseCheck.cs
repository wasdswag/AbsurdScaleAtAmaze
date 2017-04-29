using UnityEngine;
using System.Collections;

public class TestHover : MonoBehaviour 
{
    // Use this for initialization
    void Start () 
    {

    }

    // Update is called once per frame
    void Update () 
    {

    }

    void OnMouseEnter()
    {
        Debug.Log("Entering");
    }

    void OnMouseExit()
    {
        Debug.Log("Exiting");
    }
}