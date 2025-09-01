using UnityEngine;
using System.Collections;
using TFI.Terrain;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Scroll Obstacle
		transform.Translate(new Vector3(TerrainScroller.scrollSpeed * Time.deltaTime,0,0));

		//Delete Obstacle
		if(transform.position.z < TerrainScroller.terrainSwapOffsetZ * -1)
		{
			GameObject.Destroy(gameObject);
		}

	}
}
