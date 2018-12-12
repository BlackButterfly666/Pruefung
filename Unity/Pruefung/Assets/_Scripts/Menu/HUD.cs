using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

	//[SerializeField] TextContainer textContainer;
	[SerializeField] Text redCount;
	[SerializeField] Text greenCount;
	[SerializeField] Text blueCount;

	public string text08; //red Drop count
	public string text09; //green Drop count
	public string text10; //blue Drop count

	CollectItem colItem;

	public void Awake()
	{
		colItem = GameObject.Find("Player").GetComponent<CollectItem>();
		redCount.text = colItem.rDropCount.ToString() + "/5";
		greenCount.text = colItem.gDropCount.ToString() + "/5";
		blueCount.text = colItem.bDropCount.ToString() + "/5";
	}
}
