using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public const string menu = "menu";
	private const string level = "level";

	private void OnEnable()
	{
		EventManager.Instance.StartPlaying.AddListener(LoadLevel);
		//EventManager.Instance.BackToMenu.AddListener(LoadMenu);
	}

	private void OnDisable()
	{
		if (EventManager.Instance != null)
		{ EventManager.Instance.StartPlaying.RemoveListener(LoadLevel); }
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene("Level01");
		StartCoroutine(ResubListener(level));
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
		StartCoroutine(ResubListener(menu));
	}

	/// <summary>
	/// Resub listener to scene with two frames delay.
	/// string scene is: menu for menu scenes/ level for level scenes
	/// </summary>
	IEnumerator ResubListener(string scene)
	{
		int frameCounter = 2;
		while (frameCounter > 0)
		{
			frameCounter--;
			yield return null;
		}

		if (scene == level) { EventManager.Instance.StartPlaying.AddListener(LoadLevel); }
		//else if (scene == menu) { EventManager.Instance.BackToMenu.AddListener(LoadMenu); }
	}
}
