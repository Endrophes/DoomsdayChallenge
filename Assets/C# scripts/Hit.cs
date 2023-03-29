using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

    public AudioClip[] hitSounds;
    public AudioSource speaker;
    public string[] objectsThatCanHit;

    private int numSounds;

	// Use this for initialization
	void Start () {
       numSounds = hitSounds.Length;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision Collision) 
    {
        string removeClone = Collision.gameObject.name.Replace("(Clone)", "");

        foreach (string var in objectsThatCanHit)
        {
            if (var.Equals(removeClone))
            {
                int select = Random.Range(0, numSounds);
                speaker.audio.PlayOneShot(hitSounds[select]);
                break;
            }
        }
    }
}
