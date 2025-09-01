using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public TextMesh levelText;
	public TextMesh energyText;
	public GameObject gameOverTextObject;

	public Health playerHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(!GameManager.gameOver)
		{
			levelText.text = "LEVEL : " + GameManager.level;
			energyText.text = "ENERGY : " + Mathf.Floor(playerHealth.health);
		}
		else
		{
			levelText.text = "";
			energyText.text = "";
			gameOverTextObject.SetActive(true);
		}
	}

}
