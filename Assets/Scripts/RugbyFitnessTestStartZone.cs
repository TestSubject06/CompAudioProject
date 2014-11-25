using UnityEngine;
using System.Collections;

public class RugbyFitnessTestStartZone : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		SendMessageUpwards("startFitnessTest");
	}
}
