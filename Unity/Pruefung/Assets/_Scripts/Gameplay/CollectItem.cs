using UnityEngine;

public class CollectItem : MonoBehaviour
{
	[SerializeField] GameObject drops;
	[SerializeField] GameObject player;
	[SerializeField] PosProcessor pPMaterial;
	[SerializeField] Material posProcessing;
	[SerializeField] Shader farbfront;

	private string rDrop = "_RedDrops";
	public int rDropCount = 0;
	private string gDrop = "_GreenDrops";
	public int gDropCount = 0;
	private string bDrop = "_BlueDrops";
	public int bDropCount = 0;

	float tRed = 0f;
	float tGreen = 0f;
	float tBlue = 0f;


	private void Update()
	{
		WinCheck();

		tRed += 0.5f * Time.deltaTime;
		tGreen += 0.5f * Time.deltaTime;
		tBlue += 0.5f * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		float redDropAmount = posProcessing.GetFloat(rDrop);
		float greenDropAmount = posProcessing.GetFloat(gDrop);
		float blueDropAmount = posProcessing.GetFloat(bDrop);

		if (other.CompareTag("red"))
		{
			float lerpColor = Mathf.Lerp(redDropAmount, redDropAmount + 0.2f, tRed);
			posProcessing.SetFloat(rDrop, lerpColor);
			other.gameObject.SetActive(false);
			rDropCount++;
		}

		if (other.CompareTag("green"))
		{
			float lerpColor = Mathf.Lerp(greenDropAmount, greenDropAmount + 0.2f, tGreen);
			posProcessing.SetFloat(gDrop, lerpColor);
			other.gameObject.SetActive(false);
			gDropCount++;
		}

		if (other.CompareTag("blue"))
		{
			float lerpColor = Mathf.Lerp(blueDropAmount, blueDropAmount + 0.2f, tBlue);
			posProcessing.SetFloat(bDrop, lerpColor);
			other.gameObject.SetActive(false);
			bDropCount++;
		}
	}

	private void OnDisable()
	{
		posProcessing.SetFloat(rDrop, 0f);
		posProcessing.SetFloat(gDrop, 0f);
		posProcessing.SetFloat(bDrop, 0f);
	}
	void WinCheck()
	{
		if ((rDropCount == 5) && (gDropCount == 5) && (bDropCount == 5))
		{
			EventManager.Instance.ChangeMenu.Invoke(ActiveMenu.PauseMenu);
			print("You collect every Colordrop. Now Wagner ist coloured :D \nYou win this game \nPress 'Quit Game' to leave the game.");
			//texture change to white Wagner color
		}
	}
}
