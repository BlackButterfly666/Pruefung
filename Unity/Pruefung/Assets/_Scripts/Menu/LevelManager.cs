using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public const string level01 = "Level01";

	private void OnEnable()
	{
		EventManager.Instance.StartPlaying.AddListener(LoadLevel);
	}

	private void OnDisable()
	{
		if (EventManager.Instance != null)
		{ EventManager.Instance.StartPlaying.RemoveListener(LoadLevel); }
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(level01);
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

		EventManager.Instance.StartPlaying.AddListener(LoadLevel);
	}
}
