using UnityEngine;
using System.Collections;

public class RugbyFitnessTest : MonoBehaviour {

	public GameObject triggerStartZone;
	public GameObject noisePlayer;
	public AudioClip noiseSound;
	public AudioClip Warning;
	public AudioClip BeginLevel;
	public AudioClip OkayLevel;
	public AudioClip RunOver;

	public bool isStarted;
	private bool btriggerZone1;
	private bool btriggerZone2;
	public int something1;
	public int something2;
	public bool lookAtTriggerZone1;

	protected float timer;
	protected float[] levelTimes = new float[]{9.0f, 8.0f, 7.58f, 7.20f, 6.86f, 6.55f, 6.26f, 6.55f, 6.26f, 6.0f, 5.76f, 5.54f, 5.33f, 5.14f, 4.97f, 4.80f, 4.65f, 4.50f, 4.36f, 4.24f, 4.11f, 4.00f, 3.89f};
	protected int level = 0;
	protected int currentShuttle;
	protected int[] levelShuttles = new int[]{7, 8, 8, 9, 9, 10, 10, 11, 11, 11, 12, 12, 13, 13, 13, 14, 14, 15, 15, 16, 16};
	public float silentTime = 0.6f;
	public Vector2 volumeEnvelope = new Vector2(-0.3f, 0.8f);
	public Vector2 pitchEnvelope = new Vector2(0.8f, 1.8f);
	float wait = 0.0f;
	int warnings = 0;
	// Use this for initialization
	void Start () {
		isStarted = false;
		btriggerZone1 = false;
		btriggerZone2 = false;
		lookAtTriggerZone1 = false;
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(isStarted && wait <= 0.0f){
			timer += Time.deltaTime;
			//Modify pitch and volume of tension sound
			float percent = timer / (levelTimes[level] - silentTime);
			if(percent < 1){
				noisePlayer.audio.pitch = Mathf.Lerp(pitchEnvelope.x, pitchEnvelope.y, Mathf.Max(percent, 0));
				noisePlayer.audio.volume = Mathf.Lerp(volumeEnvelope.x, volumeEnvelope.y, Mathf.Max(percent, 0));
			}else{
				noisePlayer.audio.volume -= 0.10f;
			}

			//Increment the shuttle and level.
			//TODO: Find a place for the beep sound to trigger.
			if(timer > levelTimes[level]){
				currentShuttle++;
				noisePlayer.audio.Stop();
				noisePlayer.audio.clip = noiseSound;
				noisePlayer.audio.loop = true;
				noisePlayer.audio.Play();
				if(currentShuttle > levelShuttles[level]){
					currentShuttle = 0;
					level++;
				}
				//Normally we want to subtract by the step amount to prevent wasted miliseconds
				// but in this case we really do want to reset the timer.
				timer = 0;

				//Check to see if the player made it through the gate in time
				if(lookAtTriggerZone1 && btriggerZone1){
					audio.clip = OkayLevel;
					audio.Play();
					lookAtTriggerZone1 = false;
					btriggerZone1 = false;
					btriggerZone2 = false;
				}else if(!lookAtTriggerZone1 && btriggerZone2){
					audio.clip = OkayLevel;
					audio.Play();
					lookAtTriggerZone1 = true;
					btriggerZone1 = false;
					btriggerZone2 = false;
				}else{
					//Player was not fast enough. Play warning sound and continue.
					warnings++;
					if(warnings >= 3){
						audio.clip = RunOver;
						audio.Play();
						isStarted = false;
					}else{
						audio.clip = Warning;
						audio.Play();
					}
				}
			}
		}else{
			wait -= Time.deltaTime;
		}
	}

	public void startFitnessTest(){
		if(!isStarted){
			isStarted = true;
			noisePlayer.GetComponent<VoiceAssembler>().playSentence("You're doing the rugby fitness test, level one begin");
			btriggerZone1 = false;
			btriggerZone2 = false;
			lookAtTriggerZone1 = false;
			level = 0;
			currentShuttle = 0;
			wait = 5.0f;
			audio.clip = BeginLevel;
			audio.PlayDelayed(5.0f);
		}
	}

	public void hitTriggerZone(int triggerZone){
		if(triggerZone == 1){
			Debug.Log("TRIGGER1");
			this.btriggerZone1 = true;
			this.something1++;
			Debug.Log(btriggerZone1);
		}
		if(triggerZone == 2){
			Debug.Log("TRIGGER2");
			this.something2++;
			this.btriggerZone2 = true;
		}
	}
}
