using UnityEngine;
using System.Collections;

public class HitBoxScript : MonoBehaviour {
	public Parent obj;

	// Use this for initialization
	void Start () {
	
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	void OnTriggerEnter(Collider other) {
		obj.enterAction(other);
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
	void OnTriggerStay(Collider other) {
		obj.stayAction (other);
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
	void OnTriggerExit(Collider other) {
		obj.leaveAction (other);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
