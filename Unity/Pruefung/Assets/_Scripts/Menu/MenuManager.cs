using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	[SerializeField] public RectTransform Startscreen;
	[SerializeField] public RectTransform MainMenu;
	[SerializeField] public RectTransform Opener;
	[SerializeField] public RectTransform Settings;
	[SerializeField] public RectTransform Credits;
	[SerializeField] public RectTransform PauseMenu;

	EventManager eventManager;

	private void OnEnable()
	{
		eventManager = GetComponent<EventManager>();
		eventManager.ChangeMenu.AddListener(SetActiveMenu);
	}

	private void OnDisable()
	{
		eventManager.ChangeMenu.RemoveListener(SetActiveMenu);
	}

	public void SetActiveMenu(ActiveMenu activeMenu)
	{
		switch (activeMenu)
		{
			case ActiveMenu.Startscreen:
				break;
			case ActiveMenu.MainMenu:
				break;
			case ActiveMenu.Opener:
				break;
			case ActiveMenu.Settings:
				break;
			case ActiveMenu.Credits:
				break;
			case ActiveMenu.PauseMenu:
				break;
			default:
				break;
		}
	}
}
