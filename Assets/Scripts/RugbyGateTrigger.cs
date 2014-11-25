using UnityEngine;
using System.Collections;

public class RugbyGateTrigger : MonoBehaviour {
	public int triggerNumber;
	void OnTriggerEnter(Collider other){
		SendMessageUpwards("hitTriggerZone", triggerNumber);
	}
}
