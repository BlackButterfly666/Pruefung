using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public RectTransform startscreen;
	public RectTransform opener;
	public RectTransform mainMenu;
	public RectTransform settings;
	public RectTransform gameMenu;
	public RectTransform findGame;
	public RectTransform audioMenu;
	public RectTransform graphicsMenu;

	MenuEvents menuEvents;

	private void OnEnable()
	{
		menuEvents = GetComponent<MenuEvents>();
		menuEvents.ChangeMenu.AddListener(SetActiveMenu);
	}

	private void OnDisable()
	{
		menuEvents.ChangeMenu.RemoveListener(SetActiveMenu);
	}

	public void SetActiveMenu(ActiveMenu activeMenu)
	{
		switch (activeMenu)
		{
			case ActiveMenu.Startscreen:
				startscreen.SetAsLastSibling();
				break;
			case ActiveMenu.Opener:
				opener.SetAsLastSibling();
				break;
			case ActiveMenu.MainMenu:
				mainMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Settings:
				settings.SetAsLastSibling();
				break;
			case ActiveMenu.GameMenu:
				gameMenu.SetAsLastSibling();
				break;
			case ActiveMenu.FindGame:
				findGame.SetAsLastSibling();
				break;
			case ActiveMenu.AudioMenu:
				audioMenu.SetAsLastSibling();
				break;
			case ActiveMenu.GraphicsMenu:
				graphicsMenu.SetAsLastSibling();
				break;

			default:
				break;
		}
	}
}
