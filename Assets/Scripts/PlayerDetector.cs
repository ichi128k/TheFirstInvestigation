using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

	public GameObject sendTargetObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			sendTargetObject.SendMessage("OnPlayerDetected",other.gameObject.transform.position);
	}

	void OnPlayerDetected()
	{
		Debug.Log("Detected.");
	}
}
