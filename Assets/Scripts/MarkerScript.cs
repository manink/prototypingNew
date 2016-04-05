using UnityEngine;
using System.Collections;

public class MarkerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseUp()
    {
        //this is where we mark our environment
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
    }
}
