using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public RectTransform inventar;
	public RectTransform gatheringPanel;
	public RectTransform productionPanel;

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
			case ActiveMenu.Main:
				break;
			case ActiveMenu.Settings:
				break;
			case ActiveMenu.Gathering:
				break;
			case ActiveMenu.Production:
				break;
			case ActiveMenu.Game:
				break;
			default:
				break;
		}
	}
}
