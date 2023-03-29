using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {

	public GameObject spawnObject;

    public AudioClip weaponSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void launch()
	{
        if (weaponSound != null)
        {
            audio.PlayOneShot(weaponSound);
        }
		Instantiate (spawnObject, transform.position, spawnObject.transform.rotation);
	}
}
