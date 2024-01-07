using UnityEngine;
using System.Collections;

public class MenuRoad : MonoBehaviour {
	public GameObject road;
	public float speed;

	void Start () {
		
	}
	
	void Update () {
		road.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (road.transform.localPosition.x <= -96f)
        {
            road.transform.localPosition = new Vector3(-76.6f, 2.6f, -19.1f);
        }

    }
}
