using UnityEngine;

public class Master : MonoBehaviour
{
	//Instance and DontDestroyOnLoad for Managementscripts
	LevelManager levelManager;
	public LevelManager LevelManager { get { return levelManager; } }

	MenuManager menuManager;
	public MenuManager MenuManager { get { return menuManager; } }

	AudioManager audioManager;
	public AudioManager AudioManager { get { return audioManager; } }

	//
	static Master instance;
	public static Master Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<Master>();
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
