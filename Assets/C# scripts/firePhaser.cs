using UnityEngine;
using System.Collections;

public class firePhaser : MonoBehaviour {

    public FireOnTarget mainBank;

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
        mainBank.toggleFire();
	}
}
