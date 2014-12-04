using UnityEngine;
using System.Collections;

public class Squats : MonoBehaviour {
	public Color triggerExitColor = Color.green;
	public Color triggerEnterColor = Color.red;
	public GameObject planeIndicator;
	public AudioClip[] clips = new AudioClip[10];
	//public AudioSource workout;
	public AudioSource finished;
	public AudioSource badForm;
	public int set = 4;
	public int reps = 8;
	public double pitchCount = 1.0;

	private bool inThere = false;
	int counter = 0;

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
			//workout.Play();
			inThere = true;
			other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence("You're doing squats four sets eight reps");
			//badForm.Play();

			
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
		badForm.Play();
		if (Input.GetKeyDown("c"))
		{
			if ( counter <= reps){
				other.gameObject.GetComponentInChildren<VoiceAssembler>().playSentence(new SpeechVoices[]{(SpeechVoices)counter});
				/*audio.clip = clips[counter];
				audio.Play ();*/
				counter++;
				
			}
			if( counter == reps){
				finished.Play();
				counter = 0;
			}


			
			
		}
		if (Input.GetKey (KeyCode.C)) {
			//other.transform.forward.y
			Vector3 characterForward = new Vector3(other.transform.forward.x, 0, other.transform.forward.z);
			characterForward.Normalize();

			Debug.Log (Camera.main.transform.forward);

			float percentOff = 1 - Mathf.Clamp01(Vector3.Dot(characterForward, Camera.main.transform.forward));

			Vector3 characterDown = Vector3.Cross(characterForward, other.transform.right);
			bool up = Vector3.Dot(characterDown, Camera.main.transform.forward)>=0;

			//TODO: volume = Mathf.pow(percentOff, 4); pitch = 1 + ((.8 * percentOff)*(up?1:-1));
			float volume = Mathf.Pow(percentOff, 4);
			float pitch = (1f + ((.8f * percentOff)*(up?1:-1)));

			badForm.volume = volume + .1f;
			badForm.pitch = pitch + .1f;

		}
		
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
	void OnTriggerExit(Collider other) {
		//note that we are not checking tags or components here
		
		renderer.material.color = triggerExitColor;
		if (planeIndicator != null)
			planeIndicator.renderer.material.color = triggerExitColor;
		//workout.Stop();
		inThere = false;
		counter = 0;
		Debug.Log (gameObject.name + ": exited trigger with name " + other.transform.name);
	}
	
}



