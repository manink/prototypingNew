using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {

    public GameObject charCamera = null;
    public GameObject overheadCamera = null;

    public float snappiness = 1.0f;
    public GameObject positionTarget = null;
    public GameObject lookTarget = null;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    charCamera.transform.position = Vector3.Lerp(charCamera.transform.position, positionTarget.transform.position, Time.deltaTime);
        charCamera.transform.LookAt(lookTarget.transform);
    }
}
