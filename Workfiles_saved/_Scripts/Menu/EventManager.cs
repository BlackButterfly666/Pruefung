using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	//ToDo => Button Invoke
	//Ingredient += amountPerClick

	public UnityEvent Click = new UnityEvent();
	public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();

	static EventManager instance;
	public static EventManager Instance
	{
		get
		{
			if (instance == null) { instance = GameObject.FindObjectOfType<EventManager>(); }
			return instance;
		}
		private set { instance = value; }
	}

	void Awake()
	{
		if (Instance != null && Instance != this) { Destroy(gameObject); }
		else { Instance = this; }
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); } }
	}

	//public void ButtonInvoke(){ Button.Invoke(); }
}

public enum ActiveMenu { Main, Settings, Gathering, Production, Game }
public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }