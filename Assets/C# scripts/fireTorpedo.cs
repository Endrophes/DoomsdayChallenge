using UnityEngine;
using System.Collections;

public class fireTorpedo : MonoBehaviour {

	public ProjectileLauncher torpedoLauncher;

    public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnClick()
	{
        audio.PlayOneShot(sound);
		torpedoLauncher.launch ();
	}

}
