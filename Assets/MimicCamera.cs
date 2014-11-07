using UnityEngine;
using System.Collections;

public class MimicCamera : MonoBehaviour {
	public GameObject cameraToMimic;
	public Camera mimicCamera;

	// Use this for initialization
	void Start () {
		mimicCamera = cameraToMimic.GetComponent<Camera> ();	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.localEulerAngles = cameraToMimic.transform.localEulerAngles;
		transform.rotation = cameraToMimic.transform.rotation;
	}
}
