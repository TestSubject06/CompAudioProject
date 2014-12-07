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
	Workout, 
	Begin,
	Level, 
	TheRugbyFitnessTest,
	//Count,
	Bench,
	Dumbbells,
	Bikes,
	Pullupbar,
	Upperbody
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
				audio.loop = false;
				audio.pitch = 1.0f;
				audio.volume = 1.0f;
				GetComponentInParent<MusicPlayerController>().LowerVolume(audio.clip.length);
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			playSentence(new SpeechVoices[]{SpeechVoices.Workout, SpeechVoices.Two, SpeechVoices.YoureDoing, SpeechVoices.Pullups, SpeechVoices.Eight, SpeechVoices.Sets, SpeechVoices.Five, SpeechVoices.Reps});
		}
	}

	//Attempts to parse an english sentence into a SpeechVoices array, and then plays that
	public void playSentence(string sentence){
		string[] words = sentence.ToLower().Split(' ');
		List<SpeechVoices> voices = new List<SpeechVoices>();
		foreach(string word in words){
			//Oh my old 2340 teacher would kill me.
			switch(word){
			case "one":
				voices.Add(SpeechVoices.One);
				break;
			case "two":
				voices.Add(SpeechVoices.Two);
				break;
			case "three":
				voices.Add(SpeechVoices.Three);
				break;
			case "four":
				voices.Add(SpeechVoices.Four);
				break;
			case "five":
				voices.Add(SpeechVoices.Five);
				break;
			case "six":
				voices.Add(SpeechVoices.Six);
				break;
			case "seven":
				voices.Add(SpeechVoices.Seven);
				break;
			case "eight":
				voices.Add(SpeechVoices.Eight);
				break;
			case "nine":
				voices.Add(SpeechVoices.Nine);
				break;
			case "ten":
				voices.Add(SpeechVoices.Ten);
				break;
			case "you're":
				voices.Add(SpeechVoices.YoureDoing);
				break;
			case "youre":
				voices.Add(SpeechVoices.YoureDoing);
				break;
			case "squats":
				voices.Add(SpeechVoices.Squats);
				break;
			case "situps":
				voices.Add(SpeechVoices.Situps);
				break;
			case "sit-ups":
				voices.Add(SpeechVoices.Situps);
				break;
			case "pullups":
				voices.Add(SpeechVoices.Pullups);
				break;
			case "pull-ups":
				voices.Add(SpeechVoices.Pullups);
				break;
			case "pushups":
				voices.Add(SpeechVoices.Pushups);
				break;
			case "push-ups":
				voices.Add(SpeechVoices.Pushups);
				break;
			case "rep":
				voices.Add(SpeechVoices.Rep);
				break;
			case "reps":
				voices.Add(SpeechVoices.Reps);
				break;
			case "set":
				voices.Add(SpeechVoices.Set);
				break;
			case "sets":
				voices.Add(SpeechVoices.Sets);
				break;
			case "workout": 
				voices.Add(SpeechVoices.Workout);
				break;
			case "begin":
				voices.Add(SpeechVoices.Begin);
				break;
			case "level": 
				voices.Add(SpeechVoices.Level);
				break;
			case "the":
				voices.Add(SpeechVoices.TheRugbyFitnessTest);
				break;
			case "benchnearby":
				voices.Add(SpeechVoices.Bench);
				break;
			case "bikesnearby":
				voices.Add(SpeechVoices.Bikes);
				break;
			case "dumbbellnearby":
				voices.Add(SpeechVoices.Dumbbells);
				break;
			case "pullupnearby":
				voices.Add(SpeechVoices.Pullupbar);
				break;
			case "upperbodynearby":
				voices.Add(SpeechVoices.Upperbody);
				break;
			}
		}
		playSentence(voices.ToArray());
	}

	public void playSentence(SpeechVoices[] sentence){
		voiceClipQueue.Clear ();
		for(int i = 0; i < sentence.Length; i++){
			QueueVoiceClip(sentence[i]);
		}
		audio.Stop ();
		audio.clip = voiceClips [(int)voiceClipQueue [0]];
		voiceClipQueue.RemoveAt (0);
		audio.Play ();
		audio.loop = false;
		audio.pitch = 1.0f;
		audio.volume = 1.0f;
		GetComponentInParent<MusicPlayerController>().LowerVolume(audio.clip.length);
	}

	private void QueueVoiceClip(SpeechVoices voiceClip){
		voiceClipQueue.Add (voiceClip);
	}
}
