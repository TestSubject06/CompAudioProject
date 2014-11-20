using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SpeechVoices{
	One,
	Two,
	Three,
	Four,
	Five,
	Six,
	Seven,
	Eight,
	Nine,
	Ten,
	YoureDoing,
	Squats,
	Situps,
	Pullups,
	Pushups,
	Rep,
	Reps,
	Set,
	Sets,
	Workout
}

[RequireComponent (typeof(AudioSource))]
public class VoiceAssembler : MonoBehaviour {

	public AudioClip[] voiceClips;
	private List<SpeechVoices> voiceClipQueue;


	// Use this for initialization
	void Start () {
		voiceClipQueue = new List<SpeechVoices> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (audio.clip != null) {
			if (audio.time >= audio.clip.length && voiceClipQueue.Count > 0) {
				audio.Stop ();
				audio.clip = voiceClips [(int)voiceClipQueue [0]];
				voiceClipQueue.RemoveAt (0);
				audio.Play ();
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			Debug.Log("Yeah.");
			playSentence(new SpeechVoices[]{SpeechVoices.Workout, SpeechVoices.Two, SpeechVoices.YoureDoing, SpeechVoices.Pullups, SpeechVoices.Eight, SpeechVoices.Sets, SpeechVoices.Five, SpeechVoices.Reps});
		}
	}

	void playSentence(SpeechVoices[] sentence){
		voiceClipQueue.Clear ();
		for(int i = 0; i < sentence.Length; i++){
			QueueVoiceClip(sentence[i]);
		}
		audio.Stop ();
		audio.clip = voiceClips [(int)voiceClipQueue [0]];
		voiceClipQueue.RemoveAt (0);
		audio.Play ();
	}

	private void QueueVoiceClip(SpeechVoices voiceClip){
		voiceClipQueue.Add (voiceClip);
	}
}
