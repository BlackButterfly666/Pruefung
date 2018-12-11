using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//Instance and DontDestroyOnLoad for Manager
	LevelManager levelManager;
	public LevelManager LevelManager { get { return levelManager; } }

	MenuManager menuManager;
	public MenuManager MenuManager { get { return menuManager; } }

	AudioManager audioManager;
	public AudioManager AudioManager { get { return audioManager; } }

	//
	static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<GameManager>();
				Instance.levelManager = Instance.GetComponentInChildren<LevelManager>();
				Instance.menuManager = Instance.GetComponentInChildren<MenuManager>();
				Instance.audioManager = Instance.GetComponentInChildren<AudioManager>();

				DontDestroyOnLoad(instance.gameObject);
			}

			return instance;
		}

		private set { instance = value; }
	}

	void Awake()
	{
		levelManager = GetComponentInChildren<LevelManager>();
		menuManager = GetComponentInChildren<MenuManager>();
		audioManager = GetComponentInChildren<AudioManager>();
		
		if (Instance != null && Instance != this) { Destroy(gameObject); }
		else { Instance = this; DontDestroyOnLoad(gameObject); }
	}
}
