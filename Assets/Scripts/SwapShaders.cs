using UnityEngine;
using System.Collections;

public class SwapShaders : MonoBehaviour {

	public Shader showThroughDoorway;
	public Shader cullThroughDoorway;
	public GameObject Zone1;
	public GameObject Zone2;

	public void HighestLevel(){
		Transform[] allChildren = Zone1.GetComponentsInChildren<Transform>();
		foreach(Transform a in allChildren){
			if(a.renderer != null && a.renderer.material.shader == cullThroughDoorway){
				a.renderer.material.shader = showThroughDoorway;
			}else if(a.renderer != null && a.renderer.material.shader == showThroughDoorway){
				a.renderer.material.shader = cullThroughDoorway;
			}
		}
		allChildren = Zone2.GetComponentsInChildren<Transform>();
		foreach(Transform a in allChildren){
			if(a.renderer != null && a.renderer.material.shader == showThroughDoorway){
				a.renderer.material.shader = cullThroughDoorway;
			}else if(a.renderer != null && a.renderer.material.shader == cullThroughDoorway){
				a.renderer.material.shader = showThroughDoorway;
			}
		}
		Debug.Log("Highest Level Reached");
	}
}
