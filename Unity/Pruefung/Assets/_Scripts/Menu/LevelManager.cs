using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const string menu = "menu";
    private const string level = "level";

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        EventManager.Instance.StartPlaying.AddListener(LoadLevel);
    }

    struct ColorPot
    {
        public ColorPot(Color color, string tag)
        {
            this.color = color;
            this.tag = tag;
        }
        public Color color;
        public string tag;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg)
    {
        if (!scene.name.Contains("Level"))
            return;

        var dropRoot = scene.GetRootGameObjects().FirstOrDefault(x => x.name == "Drops");
        int dropCount = dropRoot.transform.childCount;

        int redCount, greenCount, blueCount;
        redCount = greenCount = blueCount = dropCount / 3;

        List<ColorPot> colorPot = new List<ColorPot>();
        for (int i = 0; i < redCount; i++)
            colorPot.Add(new ColorPot(Color.red, "red"));
        for (int i = 0; i < greenCount; i++)
            colorPot.Add(new ColorPot(Color.green, "green"));
        for (int i = 0; i < blueCount; i++)
            colorPot.Add(new ColorPot(Color.blue, "blue"));

        var randomizer = new System.Random();

        var randomDropcolor = colorPot.OrderBy(x => randomizer.NextDouble()).GetEnumerator();

        foreach (Transform d in dropRoot.transform)
        {
            if (randomDropcolor.MoveNext())
            {
                var color = randomDropcolor.Current;
                var material = d.GetComponent<MeshRenderer>().material;
                material.SetColor("_EmissionColor", color.color);
                material.color = color.color;
                
                d.tag = color.tag;
            }
        }
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
    }
}
