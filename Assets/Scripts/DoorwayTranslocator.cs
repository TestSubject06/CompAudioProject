using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorwayTranslocator : MonoBehaviour {

	public GameObject entryDoorwayQuad;
	public GameObject exitDoorwayQuad;
	public GameObject secondCamera;
	private List<GameObject> trackingObjects;
	[HideInInspector]
	public bool swapMaterials;

	// Use this for initialization
	void Start () {
		trackingObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject a in trackingObjects){
			//When the dot was positive, and is now negative or equal to 0, we were in the trigger and then passed through to the other side, so teleport us.
			if(Vector3.Dot(Vector3.Project(entryDoorwayQuad.transform.position - a.transform.position, entryDoorwayQuad.transform.forward), entryDoorwayQuad.transform.forward) <= 0){
				a.transform.position = exitDoorwayQuad.transform.position + (a.transform.position - entryDoorwayQuad.transform.position);
				trackingObjects.Remove(a);
				if(a.gameObject.name.Equals("First Person Controller")){
					swapMaterials = true;
					Shader temp = exitDoorwayQuad.renderer.material.shader;
					exitDoorwayQuad.renderer.material.shader = entryDoorwayQuad.renderer.material.shader;
					entryDoorwayQuad.renderer.material.shader = temp;
					SendMessageUpwards("HighestLevel");
					entryDoorwayQuad.transform.Rotate(new Vector3(0, 1, 0), 180.0f);
					exitDoorwayQuad.transform.Rotate(new Vector3(0, 1, 0), 180.0f);
					secondCamera.SendMessage("SwapCameras");
				}
				break;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(Vector3.Dot(Vector3.Project(entryDoorwayQuad.transform.position - other.gameObject.transform.position, entryDoorwayQuad.transform.forward), entryDoorwayQuad.transform.forward) > 0){
			trackingObjects.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		trackingObjects.Remove(other.gameObject);
	}
}
