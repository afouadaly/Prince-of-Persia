using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime : MonoBehaviour {

	public Vector3 position;
	public Quaternion rotation;

	public PointInTime (Vector3 pos, Quaternion rot)
	{
		position = pos;
		rotation = rot;
	}
}
