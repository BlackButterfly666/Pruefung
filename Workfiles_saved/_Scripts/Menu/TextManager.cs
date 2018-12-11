using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
	public Text text;
	int i;
	float t = 3f;
	[SerializeField] GameObject startButton;

	string[] openerText = new string[10];

	void Start()
	{
		OpenerText();
		//Text txt = GetComponent<Text>();
		//Debug.Log(txt == null);
		StartCoroutine(FadeOut(t, text));
	}

	public void OpenerText()
	{
		openerText[0] = "Kriege wurden schon immer geführt.";
		openerText[1] = "Wer fragt schon nach dem Warum?";
		openerText[2] = "Der Feind dringt in Dein Land ein.";
		openerText[3] = "Dringt in dein Haus ein.";
		openerText[4] = "Tötet Deine Familie.";
		openerText[5] = "Zerstört alles was du liebst.";
		openerText[6] = "Alles was zählt, sind:";
		openerText[7] = "Freunde";
		openerText[8] = "Familie";
		openerText[9] = "<b>Brüder</b>";
	}

	public IEnumerator FadeIn(float t, Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a < 1.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
			yield return null;
		}

		if (i <= 9)
		{
			StartCoroutine(FadeOut(t, text));
		}
		else
		{
			startButton.SetActive(true);
		}
	}

	public IEnumerator FadeOut(float t, Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
		while (text.color.a > 0.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
			yield return null;
		}

		if (i <= 9)
		{
			StartCoroutine(FadeIn(t, text));
			this.text.text = openerText[i];

			if (i == 7)
			{
				Debug.Log("7" + i);
				this.text.fontSize = 70;
				t = 2f;
			}
			if (i == 8)
			{
				Debug.Log("8" + i);
				this.text.fontSize = 90;
			}
			if (i == 9)
			{
				Debug.Log("9" + i);
				this.text.fontSize = 120;
				t = 1f;
			}

			i++;
		}
	}
}