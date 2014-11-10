using UnityEngine;
using System.Collections;

public class StrangeCameraScript : MonoBehaviour {
	public GameObject doorway1;
	public GameObject doorway2;
	public GameObject playerCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 relativePosition = playerCamera.transform.position - doorway1.transform.position;
		transform.position = doorway2.transform.position + relativePosition;
	}

	public void SwapCameras(){
		GameObject temp = doorway1;
		doorway1 = doorway2;
		doorway2 = temp;
		Debug.Log("Swapped");
	}
}
