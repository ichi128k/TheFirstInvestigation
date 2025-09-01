using UnityEngine;
using System.Collections;

public class Aeroplane : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDead()
	{
		GameManager.gameOver = true;
	}

}
