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

	private void Awake()
	{
		//musicSource = GetComponentInChildren<Tag_MusicSource>().GetComponent<AudioSource>();
	}

	private void OnEnable()
	{

	}

	private void Start()
	{

	}

	//void MusicChange()
	//{
	//	musicSource.Stop();
	//	musicSource.clip = sounds[musicIndex];
	//	musicSource.Play();
	//}

	void StartMusic(ActiveMenu activeMenu)
	{
		if (!musicIsPlaying /* && activeMenu == ActiveMenu.Startscreen/Opener/MainMenu*/)
		{
			musicIsPlaying = true;
			musicSource.Play();
		}

	}

	void OnChangeVolume(float val)
	{
		float volume = Mathf.Lerp(-80, 0, val);
		//"musicVol" exposen - MenuSound
		//mainMixer.SetFloat("musicVol", volume);
	}
}

//	void PrintUnitValFromVolume()
//	{
//		float vol = 0;
//		mainMixer.GetFloat("musicVol", out vol);
//		vol = Utils.Map(vol, -80f, 0f, 0f, 1f);
//	}
//}

//public static class Utils
//{
//	public static float Map(float oldVal, float oldMin, float oldMax, float newMin, float newMax)
//	{
//		float oldRange = oldMax - oldMin;
//		float newRange = newMax - newMin;
//		float newVal = (((oldVal - oldMin) / oldRange) * newRange) + newMin;
//		return newVal;
//	}
//}

