using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
	[SerializeField] GameObject drops;
	[SerializeField] GameObject player;
	[SerializeField] PosProcessor pPMaterial;
	[SerializeField] Material posProcessing;
	[SerializeField] Shader farbfront;

	private string rDrop = "_RedDrops";
	private string gDrop = "_GreenDrops";
	private string bDrop = "_BlueDrops";

	void Start()
	{
	}

	void Update()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		float redDropAmount = posProcessing.GetFloat(rDrop);
		float greenDropAmount = posProcessing.GetFloat(gDrop);
		float blueDropAmount = posProcessing.GetFloat(bDrop);

		if (other.CompareTag("red")) { posProcessing.SetFloat(rDrop, redDropAmount + 0.2f); }
		if (other.CompareTag("green")) { posProcessing.SetFloat(gDrop, greenDropAmount + 0.2f); }
		if (other.CompareTag("blue")) { posProcessing.SetFloat(bDrop, blueDropAmount + 0.2f); }

		//if (!other.CompareTag("red")) { return; }
		//posProcessing.SetFloat("_BlueDrops", 1f);
	}

	private void OnDisable()
	{
		posProcessing.SetFloat(rDrop, 0f);
		posProcessing.SetFloat(gDrop, 0f);
		posProcessing.SetFloat(bDrop, 0f);
	}
}
