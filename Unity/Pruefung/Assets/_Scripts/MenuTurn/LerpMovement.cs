using UnityEngine;

public static class LerpMovement
{
	//t1 moves to t2 in time t -> for camera around cube movement -> saved for later version
	public static void CamMovement(this Transform t1, Transform t2, float t)
	{
		t1.position = Vector3.Lerp(t1.position, t2.position, t);
		t1.rotation = Quaternion.Lerp(t1.rotation, t2.rotation, t);
		t1.localScale = Vector3.Lerp(t1.localScale, t2.localScale, t);
	}
}
