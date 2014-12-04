using UnityEngine;
using System.Collections;

public class PullUps : MonoBehaviour {
	
	public Color triggerExitColor = Color.green;
	public Color triggerEnterColor = Color.red;
	public GameObject planeIndicator;
	public AudioClip[] clips = new AudioClip[10];
	//public AudioClip[] setClips = new AudioClip[4];
	//public AudioSource workout;
	public AudioSource finished;

	public int set = 4;
	public int reps = 8;
	int counter = 0;
	int setCounter = 0;
	
	// Use this for initialization
	void Start () {


		renderer.material.color = triggerExitColor;

	}
	
	// Update is called once per frame
	void Update () {


		
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	void OnTriggerEnter(Collider other) {
		
		//ways to check to see if a specific object has entered the trigger:
		
		//Presence of a Component:
		//checking to see if the object we collided with has a CharacterController
		
		CharacterController controller = other.gameObject.GetComponent<CharacterController>();
		if (controller != null) //only change color when character controller found
		{
			renderer.material.color = triggerEnterColor;
			if (planeIndicator != null)
				planeIndicator.renderer.material.color = triggerEnterColor;
			other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("You're doing pullups four sets eight reps");
			
			Debug.Log (gameObject.name + ": entered trigger with name " + other.transform.name);
		}

		//Tags:
		//Checking to see if the object that entered the trigger has a specific trigger:
		if (other.gameObject.tag == "Player") 
			//you can also check for tags 
			//(change the tag for your first-person controller to "Player" to make this work)
		{
			
		}
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
	void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown("z"))
		{
			if ( counter < reps){
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence(new SpeechVoices[]{(SpeechVoices)counter});
				//audio.clip = clips[counter];
				//audio.clip = setClips[setCounter]; 
				//audio.Play ();
				counter++;
			}
			if( counter == reps){
				finished.Play();
				counter = 0;
				setCounter++;
				if (setCounter == set){
					setCounter = 0;
				}
			}
		}
		
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
	void OnTriggerExit(Collider other) {
		//note that we are not checking tags or components here
		
		renderer.material.color = triggerExitColor;
		if (planeIndicator != null)
			planeIndicator.renderer.material.color = triggerExitColor;
		//workout.Stop();
		counter = 0;
		Debug.Log (gameObject.name + ": exited trigger with name " + other.transform.name);
	}
	
}

