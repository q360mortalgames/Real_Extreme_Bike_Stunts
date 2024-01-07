using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheelScript : MonoBehaviour {

	public Vector3 rot;
	void Start () {
		
	}
	

	void Update () 
	{
		this.transform.Rotate (rot.x, rot.y, rot.z);
	}
}
