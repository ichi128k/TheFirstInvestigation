using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public TextMesh textMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.color = Color.white;
	}
	
	void OnHovering()
	{
		textMesh.color = Color.red;
	}
	
	void OnPressReturn()
	{
		Application.Quit();
	}
}
