using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TFI.Terrain
{
	public class TerrainScroller : MonoBehaviour {

		public GameObject terrainObject;

		private GameObject[] terrainClones;

		public GameObject[] terrainObstacleObjects;

		public GameObject enemyObject;

		//private GameObject[] terrainObstacleClones;
		private List<GameObject> terrainObstacleClones;

		public Health playerHealth;

		public static float scrollSpeed = 300;

		public static float terrainSwapOffsetZ = 3000;

		public float terrainOffsetZ = 0;

		public int terrainCount = 3;

		public int maxObstacleCount = 5;

		public float minObstacleGenerationTime = 5; 

		public float maxObstacleGenerationTime = 5;

		//public float lastGenerationTime = 0;

		public Vector3 obstacleGenerationPosition;
		
		// Use this for initialization
		void Start () {

			terrainClones = new GameObject[terrainCount];
			//terrainObstacleClones = new GameObject[maxObstacleCount];
			terrainObstacleClones = new List<GameObject>();

			//Create terrain clone
			for(int i = 0;i < terrainCount;i++)
			{
				terrainClones[i] = GameObject.Instantiate(terrainObject);
				terrainClones[i].transform.parent = this.transform;

				terrainClones[i].transform.position = new Vector3(terrainClones[i].transform.position.x,terrainClones[i].transform.position.y,terrainOffsetZ * i * -1);
				terrainClones[i].SetActive(true);
			}

			InvokeRepeating("GenerateObstacle",minObstacleGenerationTime,minObstacleGenerationTime);
			InvokeRepeating("SpawnEnemy",5,5);
			//StartCoroutine("GenerateObstacle");
			/*
			 * To cancel repeating , Insert "CancelInvoke(Function());".
			 */
		}
		
		// Update is called once per frame
		void Update () {
			/*
			terrainObject.transform.Translate(new Vector3(0,0,scrollSpeed * -1));
			terrainClones.transform.Translate(new Vector3(0,0,scrollSpeed * -1));

			if(terrainClones.transform.position.z < terrainSwapOffsetZ * -1)
			{
				terrainClones.transform.position = new Vector3(terrainClones.transform.position.x,
				                                              terrainClones.transform.position.y,
				                                              terrainObject.transform.position.z + terrainOffsetZ);
			}

			if(terrainObject.transform.position.z < terrainSwapOffsetZ * -1)
			{
				terrainObject.transform.position = new Vector3(terrainObject.transform.position.x,
				                                               terrainObject.transform.position.y,
				                                               terrainClones.transform.position.z + terrainOffsetZ);
			}
			*/
			//Set current speed
			if(!GameManager.gameOver)
			{
				scrollSpeed = 150 + (GameManager.level * 150);
			}
			else
			{
				scrollSpeed = 0;
			}
			//Scroll terrain
			for(int i = 0;i < terrainCount;i++)
			{
				terrainClones[i].transform.Translate(new Vector3(0,0,scrollSpeed * -1 * Time.deltaTime));
			}

			//Swap terrain
			for(int i = 0;i < terrainCount;i++)
			{
				if(terrainClones[i].transform.position.z < terrainSwapOffsetZ * -1)
				{
					int nextCloneIndex = i >= terrainCount - 1 ? 0 : i + 1;

					terrainClones[i].transform.position = new Vector3(terrainClones[i].transform.position.x,
					                                                 terrainClones[i].transform.position.y,
					                                                 terrainClones[nextCloneIndex].transform.position.z + terrainOffsetZ);
				}
			}

			/*
			//Scroll obstacles
			for(int i = 0;i < terrainObstacleClones.Count;i++)
			{
				if(terrainObstacleClones[i])
					terrainObstacleClones[i].transform.Translate(new Vector3(scrollSpeed * Time.deltaTime,0,0));
			}

			//Destroy obstacle
			for(int i = 0;i < terrainObstacleClones.Count;i++)
			{
				if(terrainObstacleClones[i].transform.position.z < terrainSwapOffsetZ * -1)
				{
					GameObject.Destroy(terrainObstacleClones[i]);
				}
			}
			*/

		}

		void PopObstacleCloneList()
		{

		}

		void GenerateObstacle()
		{
			/*
			terrainObstacleClones.Add(GameObject.Instantiate(terrainObstacleObjects[0]));
			int currentNum = terrainObstacleClones.Count - 1;

			terrainObstacleClones[currentNum].transform.parent = this.transform;
			terrainObstacleClones[currentNum].transform.position = obstacleGenerationPosition;
			terrainObstacleClones[currentNum].SetActive(true);
			*/

			Random.seed = (int)System.DateTime.Now.Ticks;

			int idx = Random.Range(0,terrainObstacleObjects.Length);
			idx = idx >= terrainObstacleObjects.Length ? terrainObstacleObjects.Length - 1 : idx;

			//If player's health is low , Set index number to drone.
			if(playerHealth.health < 50)
			{

			}

			GameObject generatedObstacle = GameObject.Instantiate(terrainObstacleObjects[idx]);

			generatedObstacle.transform.parent = this.transform;
			//generatedObstacle.transform.position = obstacleGenerationPosition;
			generatedObstacle.transform.position = new Vector3(obstacleGenerationPosition.x,generatedObstacle.transform.position.y,obstacleGenerationPosition.z);
			generatedObstacle.SetActive(true);

			float obstacleGenTime = minObstacleGenerationTime + Random.Range(0.0f,maxObstacleGenerationTime);

			CancelInvoke("GenerateObstacle");
			InvokeRepeating("GenerateObstacle",obstacleGenTime,obstacleGenTime);
		}

		void SpawnEnemy()
		{
			GameObject generatedObstacle = GameObject.Instantiate(enemyObject);
			
			generatedObstacle.transform.parent = this.transform;
			//generatedObstacle.transform.position = obstacleGenerationPosition;
			generatedObstacle.transform.position = new Vector3(obstacleGenerationPosition.x,generatedObstacle.transform.position.y,obstacleGenerationPosition.z);
			generatedObstacle.SetActive(true);
			
			float obstacleGenTime = minObstacleGenerationTime + Random.Range(0.0f,maxObstacleGenerationTime);
		}
	}

}

