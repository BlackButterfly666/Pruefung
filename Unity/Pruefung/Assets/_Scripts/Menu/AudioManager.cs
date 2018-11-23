using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AnimationCurve volCurve;
	[SerializeField] AudioMixer mainMixer;
	[SerializeField] AudioClip[] sounds;

	AudioSource musicSource;
	int maxMusicIndex;
	int musicIndex;
	bool musicIsPlaying;
}
