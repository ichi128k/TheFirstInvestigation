using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float healthAmount = 100;
	public float health;

	public float exhaustingHealthAmount = 1f;
	public bool isHealthExhaustGradually = false;

	// Use this for initialization
	void Start () {
		RechargeHealth();
	}
	
	// Update is called once per frame
	void Update () {

		if(isHealthExhaustGradually)
			health -= exhaustingHealthAmount * Time.deltaTime;

		if(health <= 0)
		{
			gameObject.SendMessage("OnDead");
			this.enabled = false;
		}

		//Debug.Log("Fuel : " + health);
	}

	public void RechargeHealth()
	{
		health = healthAmount;
	}

	public void Charge(float amount)
	{
		health += amount;

		if(health > healthAmount)
		{
			health = healthAmount;
		}
	}

	void OnDamage(int damageValue)
	{
		health -= damageValue;

		if(health < 0)
		{
			health = 0;
		}
	}

	void OnDead()
	{
		//gameObject.SetActive(false);
	}
}
