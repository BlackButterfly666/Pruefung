using UnityEngine;

public class MenuTurn : MonoBehaviour
{
	[SerializeField] RectTransform MainMenu;
	[SerializeField] RectTransform Settings;
	[SerializeField] RectTransform Credits;
	[SerializeField] GameObject Cube;
	[SerializeField] Camera cam;
	//[SerializeField] Transform camRight;
	//[SerializeField] Transform camLeft;
	//[SerializeField] Transform camCenter;

	Quaternion center;
	Quaternion right;
	Quaternion left;

	Vector3 centerPos;
	Vector3 rightPos;
	Vector3 leftPos;

	void Start()
	{
		center = Quaternion.Euler(0, 0, 0);
		right = Quaternion.Euler(0, -90, 0);
		left = Quaternion.Euler(0, 90, 0);

		centerPos.Set(0f, 1f, -10f);
		rightPos.Set(200f, 1f, 192f);
		leftPos.Set(-202f, 1f, 193f);
	}

	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.L)) { TurnLeft(); }
		//else if (Input.GetKeyDown(KeyCode.R)) { TurnRight(); }
		//else if (Input.GetKeyDown(KeyCode.C)) { TurnCenter(); }
		//else { Debug.Log("Please push R for right turn, L for left turn or space for center turn"); }
	}

	public void TurnRight()
	{
		cam.transform.SetPositionAndRotation(rightPos, right);
		//cam.transform.CamMovement(camRight, 10f);
	}

	public void TurnLeft()
	{
		cam.transform.SetPositionAndRotation(leftPos, left);
		//cam.transform.CamMovement(camLeft, 10f);
	}

	public void TurnCenter()
	{
		cam.transform.SetPositionAndRotation(centerPos, center);
		//cam.transform.CamMovement(camCenter, 10f);
	}
}
