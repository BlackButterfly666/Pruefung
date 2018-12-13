using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	MenuManager menuManager;
	LevelManager levelManager;
	MenuTurn menuTurn;

	public UnityEvent StartPlaying = new UnityEvent();
	public UnityEvent BackToMenu = new UnityEvent();
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
		levelManager = GetComponent<LevelManager>();
		menuTurn = GetComponentInParent<MenuTurn>();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }
    }

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) //{ Application.Quit(); } //PauseMenu und dann Quit
		{
			ChangeMenu.Invoke(ActiveMenu.PauseMenu);
			Cursor.lockState = CursorLockMode.None;
		}
	}

	#region Button Invoke

	//Menu changing
	public void ToMainMenuButton() { ChangeMenu.Invoke(ActiveMenu.MainMenu); } //menuTurn.TurnCenter(); }
	public void ToSettingsButton() { ChangeMenu.Invoke(ActiveMenu.Settings); } //menuTurn.TurnRight(); }
	public void ToCreditsButton() { ChangeMenu.Invoke(ActiveMenu.Credits); } //menuTurn.TurnLeft(); }
	public void StartPlayingButton() { ChangeMenu.Invoke(ActiveMenu.Opener); }

	public void SkipIntroButton() { StartPlaying.Invoke(); ChangeMenu.Invoke(ActiveMenu.None); }//ClosePanel(menuManager.MainMenu.gameObject); }
	public void BackToMainMenu()
	{
		BackToMenu.Invoke();
		levelManager.LoadMenu();
		//ChangeMenu.Invoke(ActiveMenu.MainMenu);
	}

	public void ClosePanel(GameObject go) { go.SetActive(false); }
	public void QuitGame() { Application.Quit(); }

	//Settings
	public void SoundVolSlider(float soundVol) { ChangeVolume.Invoke(soundVol); }
	public void MusicVolSlider(float musicVol) { ChangeVolume.Invoke(musicVol); }

	//public void BUTTONTEST() { Debug.Log("BUTTONTEST"); }

	#endregion
}

public enum ActiveMenu { None, Startscreen, MainMenu, Opener, Settings, Credits, PauseMenu }

[System.Serializable] public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }