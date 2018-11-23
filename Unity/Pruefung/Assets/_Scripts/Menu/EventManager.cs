using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
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
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

	#region Button Invoke

	//Menu changing

	//public void "Methodenname"() {ChangeMenu.Invoke(ActiveMenu.Opener);} 
	//public void ClosePanel(GameObject go) { go.SetActive(false); }

	#endregion
}

public enum ActiveMenu { Startscreen, MainMenu, Opener, Settings, Credits, PauseMenu }

[System.Serializable] public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }