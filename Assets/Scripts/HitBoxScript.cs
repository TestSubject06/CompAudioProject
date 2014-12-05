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
		if (other.name == "biggymtrigger") {
			other.name = "You are next to upperbody machine.";
		} else if (other.name == "GymBenchTrigger") {
			other.name = "Here you can do bench press";
		} else if (other.name == "GymBikeTrigger") {
			other.name = "Here you can ride the bike for cardio";
		} else if (other.name == "PullupBarTrigger") {
			other.name = "You can do pull ups here";
		} else if (other.name == "DumbbellTrigger") {
			other.name = "Perform dumbbell workouts here";
		} else {

		}
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
