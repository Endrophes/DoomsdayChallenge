using UnityEngine;
using System.Collections;

public class autoFireWeapon : MonoBehaviour {

    public float amountToWait;
    public ProjectileLauncher[] weapon;

    //private vars
    private float NextSpawn;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > NextSpawn)
        {
            //set next spawn time.
            NextSpawn = Time.time + amountToWait;
            //Create a random enemy at this location
            foreach(ProjectileLauncher var in weapon)
            {
                var.launch();
            }
        }
	}
}
