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
	[SerializeField] public GameObject PauseMenu;

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
				MainMenu.gameObject.SetActive(true);
				Startscreen.gameObject.SetActive(false);
				MainMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Opener:
				Opener.gameObject.SetActive(true);
				MainMenu.gameObject.SetActive(false);
				Opener.SetAsLastSibling();
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
