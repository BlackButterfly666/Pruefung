using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public const string level01 = "Level01";
	public const string level02 = "Level02";

	private void OnEnable()
	{
		MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
	}

	private void OnDisable()
	{
		if (MenuEvents.Instance != null)
		{ MenuEvents.Instance.StartPlaying.RemoveListener(ChangeScene); }
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(level01);
		StartCoroutine(ResubListener());
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene(level02);
		StartCoroutine(ResubListener());
	}

	//public void ChangeScene(string sceneName) { }

	IEnumerator ResubListener()
	{
		int frameCounter = 2;
		while (frameCounter > 0)
		{
			frameCounter--;
			yield return null;
		}

		MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
	}
}
