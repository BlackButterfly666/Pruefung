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

	int i;
	float t = 3f;

	void Start()
	{
	}

	private void Update()
	{
		if (opener.activeSelf == true)
		{
			StartCoroutine(FadeOut(t, text));
			OpenerText();
		}
	}

	public void OpenerText() //Textdump
	{
		openerText[0] = "Hallo"; //textContainer.text01;
								 //openerText[1] = textContainer.text02;
								 //openerText[2] = textContainer.text03;
								 //openerText[3] = textContainer.text04;
								 //openerText[4] = textContainer.text05;
								 //openerText[5] = textContainer.text06;
								 //openerText[6] = textContainer.text07;
								 //openerText[7] = ;
								 //openerText[8] = ;
								 //openerText[9] = ;
	}

	public IEnumerator FadeIn(float t, Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a < 1.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
			yield return null;
		}

		if (i <= 6) { StartCoroutine(FadeOut(t, text)); }
		else { continueButton.SetActive(true); }
	}

	public IEnumerator FadeOut(float t, Text text)
	{
		Debug.Log("FadeOut");
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
		while (text.color.a > 0.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
			yield return null;
		}

		if (i <= 6)
		{
			StartCoroutine(FadeIn(t, text));
			this.text.text = openerText[i];

			i++;

			//if (i == 7)
			//{
			//	Debug.Log("7" + i);
			//	this.text.fontSize = 70;
			//	t = 2f;
			//}
			//if (i == 8)
			//{
			//	Debug.Log("8" + i);
			//	this.text.fontSize = 90;
			//}
			//if (i == 9)
			//{
			//	Debug.Log("9" + i);
			//	this.text.fontSize = 120;
			//	t = 1f;
			//}
		}
	}
}
