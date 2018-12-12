using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenerManager : MonoBehaviour
{
	[SerializeField] GameObject opener;
	[SerializeField] GameObject continueButton;

	[SerializeField] Text text;
	string[] openerText = new string[6];

	[SerializeField] Image Image;
	Image[] images = new Image[6];

	[SerializeField] TextContainer textContainer;

	EventManager eventManager;

	int i;
	float t = 3f;

	private void OnEnable()
	{
		eventManager = GetComponent<EventManager>();
		eventManager.ChangeMenu.AddListener(BeginTransition);
		eventManager.StartPlaying.AddListener(SkipTransition);
	}

	private void OnDisable()
	{
		eventManager.ChangeMenu.RemoveListener(BeginTransition);
		eventManager.StartPlaying.RemoveListener(SkipTransition);
	}

	void BeginTransition(ActiveMenu activeMenu)
	{
		if(activeMenu != ActiveMenu.Opener) { return; }
		StartCoroutine(FadeOut(t, text));
		OpenerText();
	}

	void SkipTransition()
	{
		StopAllCoroutines();
	}

	public void OpenerText() //Textdump
	{
		openerText[0] = textContainer.text01;
		openerText[1] = textContainer.text02;
		openerText[2] = textContainer.text03;
		openerText[3] = textContainer.text04;
		openerText[4] = textContainer.text05;
		openerText[5] = textContainer.text06;
	}

	public IEnumerator FadeIn(float t, Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a < 1.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
			yield return null;
		}

		if (i <= 5) { StartCoroutine(FadeOut(t, text)); }
		else { continueButton.gameObject.SetActive(true); }
	}

	public IEnumerator FadeOut(float t, Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
		while (text.color.a > 0.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
			yield return null;
		}

		if (i < 6)
		{
			StartCoroutine(FadeIn(t, text));
			this.text.text = openerText[i];

			i++;
		}
	}
}
