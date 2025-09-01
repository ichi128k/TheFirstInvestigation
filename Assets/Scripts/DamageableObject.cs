using UnityEngine;
using System.Collections;

public class DamageableObject : MonoBehaviour {

	public GameObject aeroplaneObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.tag == "Player")
		{
			aeroplaneObject.GetComponent<Health>().SendMessage("OnDamage",3.5f);
		}
	}
}
