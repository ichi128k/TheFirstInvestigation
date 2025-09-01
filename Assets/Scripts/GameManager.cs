using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int level = 1;
	public static float distance = 0;
	public static bool gameOver = false;
	public static float exp = 0;

	// Use this for initialization
	void Start () {
		gameOver = false;
		level = 1;
		distance = 0;
		exp = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(exp > level * 500)
		{
			level++;

			if(level > 5)
			{
				level = 5;
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(0);
		}
	}
}