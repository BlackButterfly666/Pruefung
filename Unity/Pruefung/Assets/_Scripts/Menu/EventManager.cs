using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	MenuManager menuManager;
	public UnityEvent StartPlaying = new UnityEvent();
	public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();
	public UnityEvent<float> ChangeVolume = new FloatEvent();
	//public UnityEvent "name" = new UnityEvent();

	#region Singleton
	static EventManager instance;
	public static EventManager Instance
	{
		get { if (instance == null) { instance = GameObject.FindObjectOfType<EventManager>(); } return instance; }
		private set { instance = value; }
	}
	#endregion

	private void Awake()
	{
		if (Instance != null && Instance != this) { Destroy(gameObject); }
		else { Instance = this; }
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) //{ Application.Quit(); } //PauseMenu und dann Quit
		{
			ChangeMenu.Invoke(ActiveMenu.PauseMenu);
			menuManager.PauseMenu.SetActive(true);
		}
	}

	#region Button Invoke

	//Menu changing
	public void ToMainMenuButton() { ChangeMenu.Invoke(ActiveMenu.MainMenu); }
	public void ToSettingsButton() { ChangeMenu.Invoke(ActiveMenu.Settings); }
	public void ToCreditsButton() { ChangeMenu.Invoke(ActiveMenu.Credits); }
	public void StartPlayingButton() { ChangeMenu.Invoke(ActiveMenu.Opener); }
	public void SkipIntroButton() { StartPlaying.Invoke(); }

	public void QuitGame() { Application.Quit(); }
	//public void ClosePanel(GameObject go) { go.SetActive(false); }

	//Settings
	public void SoundVolSlider(float soundVol) { ChangeVolume.Invoke(soundVol); }
	public void MusicVolSlider(float musicVol) { ChangeVolume.Invoke(musicVol); }


	#endregion
}

public enum ActiveMenu { Startscreen, MainMenu, Opener, Settings, Credits, PauseMenu }

[System.Serializable] public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }