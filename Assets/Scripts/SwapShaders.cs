using UnityEngine;
using System.Collections;

public class SwapShaders : MonoBehaviour {

	public Shader showThroughDoorway;
	public Shader cullThroughDoorway;
	public Shader portal;
	public Shader portalZ;
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

			if(a.renderer != null && a.renderer.material.shader == portal){
				a.renderer.material.shader = portalZ;
			}else if(a.renderer != null && a.renderer.material.shader == portalZ){
				a.renderer.material.shader = portal;
			}
		}
		allChildren = Zone2.GetComponentsInChildren<Transform>();
		foreach(Transform a in allChildren){
			if(a.renderer != null && a.renderer.material.shader == showThroughDoorway){
				a.renderer.material.shader = cullThroughDoorway;
			}else if(a.renderer != null && a.renderer.material.shader == cullThroughDoorway){
				a.renderer.material.shader = showThroughDoorway;
			}

			if(a.renderer != null && a.renderer.material.shader == portal){
				a.renderer.material.shader = portalZ;
			}else if(a.renderer != null && a.renderer.material.shader == portalZ){
				a.renderer.material.shader = portal;
			}
		}
		Debug.Log("Highest Level Reached");
	}
}
