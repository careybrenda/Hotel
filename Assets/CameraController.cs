using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera maincam;

	private float zoomspeed = 8.0f;
	private float movespeed = 7.0f;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey (KeyCode.Q))
		{
			if(maincam.orthographicSize < 18)
			{
				maincam.orthographicSize += zoomspeed* Time.deltaTime;
			}
		}
		if(Input.GetKey (KeyCode.E))
		{
			if(maincam.orthographicSize > 4)
			{
				maincam.orthographicSize -= zoomspeed* Time.deltaTime;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(movespeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-movespeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-movespeed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,movespeed * Time.deltaTime,0));
		}

	}
}
