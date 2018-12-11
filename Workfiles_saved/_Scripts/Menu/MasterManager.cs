using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
	EventManager eventManager;
	public EventManager EventManager { get { return eventManager; } }

	static MasterManager instance;
	public static MasterManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<MasterManager>();
				Instance.eventManager = Instance.GetComponentInChildren<EventManager>();

				DontDestroyOnLoad(instance.gameObject);
			}
			return instance;
		}
		private set { instance = value; }
	}

	private void Awake()
	{
		eventManager = GetComponentInChildren<EventManager>();

		if (Instance != null && Instance != this) { Destroy(gameObject); }
		else { Instance = this; DontDestroyOnLoad(gameObject); }
	}
}
