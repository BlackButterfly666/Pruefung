using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuEvents : MonoBehaviour
{
	public UnityEvent StartPlaying = new UnityEvent();
	public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();
	public UnityEvent<float> ChangeVolume = new FloatEvent();
	//public UnityEvent "name" = new UnityEvent();

	#region Singleton
	static MenuEvents instance;
	public static MenuEvents Instance
	{
		get { if (instance == null) { instance = GameObject.FindObjectOfType<MenuEvents>(); } return instance; }
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

public enum ActiveMenu
{
	Startscreen = 0,
	Opener = 1,
	MainMenu = 2,
	Settings = 3,
	GameMenu = 4,
	FindGame = 5,
	AudioMenu = 6,
	GraphicsMenu = 7
}

[System.Serializable] public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }