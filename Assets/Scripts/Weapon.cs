using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float weaponReachLength = 64;
	public GameObject beamObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {

		if(!GameManager.gameOver)
		{
			if(Input.GetButtonDown("Fire"))
			{
				GameObject beamClone = GameObject.Instantiate(beamObject);
				beamClone.transform.position = transform.position;
				beamClone.transform.rotation = transform.rotation;
				beamClone.SetActive(true);
			}
		}
	}
}
