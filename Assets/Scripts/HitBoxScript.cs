using UnityEngine;
using System.Collections;

public class HitBoxScript : MonoBehaviour {
	public Parent obj1;
	public Parent obj2;
	// Use this for initialization
	void Start () {
	
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	void OnTriggerEnter(Collider other) {
		obj1.enterAction(other);
		obj2.enterAction(other);
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
	void OnTriggerStay(Collider other) {
		obj1.stayAction (other);
		obj2.stayAction (other);
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
	void OnTriggerExit(Collider other) {
		obj1.leaveAction (other);
		obj2.leaveAction (other);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
