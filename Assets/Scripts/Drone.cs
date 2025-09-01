using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Drone : MonoBehaviour {

	public GameObject beamObject;
	public GameObject explotionParticleObject;
	public Health targetPlayerHealth;

	private bool isBeamLaunched = false;
	
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () 
	{
		//Set minimum position for spawn
		Random.seed = (int)System.DateTime.Now.Ticks;

		RaycastHit hit;
		float minimumYPos = -50;
		float maximumYPos = 50;
		Vector3 currentPos = new Vector3(Random.Range(-150,150),180,transform.position.z);

		if(Physics.Raycast(currentPos,Vector3.down,out hit))
		{
			minimumYPos = hit.point.y + 30;
			maximumYPos = 160;
		}

		currentPos = new Vector3(currentPos.x,Random.Range(minimumYPos,maximumYPos),transform.position.z);

		transform.position = currentPos;

		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnDamage()
	{

	}

	void OnDead()
	{
		GameManager.exp += 100;

		GameObject particle = GameObject.Instantiate(explotionParticleObject);
		particle.transform.position = transform.position;

		targetPlayerHealth.Charge(15);

		particle.SetActive(true);
		gameObject.SetActive(false);
		//GameObject.Destroy(gameObject);
	}

	void OnPlayerDetected(Vector3 targetPosition)
	{
		if(!isBeamLaunched)
		{
			GameObject beamClone = GameObject.Instantiate(beamObject);
			beamClone.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - 10f);
			beamClone.transform.LookAt(targetPosition);
			beamClone.SetActive(true);
		}
		isBeamLaunched = true;
	}
}
