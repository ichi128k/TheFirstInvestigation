using UnityEngine;
using System.Collections;
using TFI.Terrain;

public class LaserBeam : MonoBehaviour {

	public float laserSpeed = 600;
	public float laserDuration = 3;
	public float damageAmount = 20;
	public bool chargeHealth = false;
	public bool isLaserSpeedVariable = false;
	public bool playerHitOnly = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float lSpeed = laserSpeed;

		if(isLaserSpeedVariable)
		{
			lSpeed += TerrainScroller.scrollSpeed;
		}

		transform.Translate(new Vector3(0,0,lSpeed * Time.deltaTime));

		laserDuration -= Time.deltaTime;

		if(laserDuration < 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.layer != 8)
		{
			if(playerHitOnly && other.gameObject.tag != "Player")
				return;

			if(other.gameObject.GetComponent<Health>())
			{
				other.gameObject.SendMessage("OnDamage",damageAmount);
			}

			Destroy(gameObject);
		}
	}
}
