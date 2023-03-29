using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float amountToWait;
	public float TotalEnemies;
	public GameObject spawnObject;

	//private vars
	private float NextSpawn;
	private float TotalSpawn;

	// Update is called once per frame
	void Start()
	{
	}

	void Update()
	{
		if(TotalSpawn >= TotalEnemies) return;
		if(Time.time > NextSpawn)
		{
			//set next spawn time.
			NextSpawn = Time.time + amountToWait;
			//Create a random enemy at this location
			Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);	//add to total spawn.
			TotalSpawn++;
		}
	}
	
	private IEnumerator spawn()
	{
		(Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject).GetComponent<TrackTarget>();
		yield return new WaitForSeconds(amountToWait);
	}

	private void spawner()
	{
		float delay = amountToWait;
		while(true)
		{
			if(delay > 1)
			{
				delay--;
			}
			else
			{
				delay = amountToWait;
				(Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject).GetComponent<TrackTarget>();
				///yield  WaitForSeconds(amountToWait);
			}
		}
	}


}
