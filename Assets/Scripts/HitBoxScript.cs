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
		obj1.enterAction(other); //sound controller
		if (other != null) {
			if (this.gameObject.name == "biggymtrigger") {
				other.name = "You are next to upperbody machine.";
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("upperbodynearby");
			} else if (this.gameObject.name == "GymBenchTrigger") {
				other.name = "Here you can do bench press";
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("benchnearby");
			} else if (this.gameObject.name == "GymBikeTrigger") {
				other.name = "Here you can ride the bike for cardio";
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("bikesnearby");
			} else if (this.gameObject.name == "PullupBarTrigger") {
				other.name = "You can do pull ups here";
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("pullupnearby");
			} else if (this.gameObject.name == "Dumbbelltrigger") {
				other.name = "Perform dumbbell workouts here";
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("dumbbellnearby");
			} else {

			}
		obj2.enterAction(other); //google glass display
		}
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
