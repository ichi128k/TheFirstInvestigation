using UnityEngine;
using System.Collections;

public class RayCastPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if(Physics.Raycast (transform.position,transform.forward,out hit))
		{
			if(hit.collider.gameObject.tag == "Button")
			{
				hit.collider.gameObject.SendMessage("OnHovering");
				if(Input.GetKeyDown(KeyCode.Return))
				{
					hit.collider.gameObject.SendMessage("OnPressReturn");
				}
			}
		}
	}
}
