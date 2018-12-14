using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	/* 
	 * The commented code-parts are not used at moment, but will used in future, if there are more than one soundfile
	 */

	[SerializeField] AnimationCurve volCurve;
	[SerializeField] AudioMixer mainMixer;
	[SerializeField] AudioClip[] soundFiles;

	AudioSource musicSource;
	//int maxMusicIndex;
	//int musicIndex = 0;
	bool musicIsPlaying;

	private void Awake()
	{
		musicSource = GetComponentInChildren<Tag_MusicSource>().GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		EventManager.Instance.ChangeVolume.AddListener(OnChangeVolume);
		EventManager.Instance.ChangeMenu.AddListener(StartMusic);
	}

	void Start()
	{
		//maxMusicIndex = soundFiles.Length - 1;
		//musicSource.clip = soundFiles[musicIndex];
			musicSource.Play();
	}

	void StartMusic(ActiveMenu activeMenu)
	{
		if (!musicIsPlaying && activeMenu == ActiveMenu.Startscreen)
		{
			musicIsPlaying = true;
		}
	}

	public void OnChangeVolume(float val)
	{
		float volume = Mathf.Lerp(-80, 0, val);
		mainMixer.SetFloat("soundVol", volume);
	}

	public void PrintUnitValFromVolume()
	{
		float vol = 0;
		mainMixer.GetFloat("musicVol", out vol);
		vol = Utils.Map(vol, -80f, 0f, 0f, 1f);
	}
}

public static class Utils
{
	public static float Map(float oldVal, float oldMin, float oldMax, float newMin, float newMax)
	{
		float oldRange = oldMax - oldMin;
		float newRange = newMax - newMin;
		float newVal = (((oldVal - oldMin) / oldRange) * newRange) + newMin;
		return newVal;
	}
}
