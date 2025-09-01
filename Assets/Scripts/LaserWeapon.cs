using UnityEngine;
using System.Collections;

public class LaserWeapon : MonoBehaviour {

	public LineRenderer laserObject;
	public float weaponReachLength = 64;
	public Health planeHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		
		Debug.DrawRay(transform.position,Vector3.forward,Color.red,weaponReachLength);

		if(Input.GetButton("Fire"))
		{
			if(Physics.Raycast(transform.position,Vector3.forward,out hit))
			{

				if(hit.collider.tag == "Enemy")
				{
					hit.collider.gameObject.SendMessage("OnDamage",50);
					planeHealth.Charge(10);
				}
			}

			laserObject.enabled = true;
		}
		else
		{
			laserObject.enabled = false;
		}
	}
}
