using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireOnTarget: MonoBehaviour {

	public float maxRange;
	public string[] LookingFor;
	private List<GameObject> trackTargets;

	public PhaserBank phaserBank;
	public AudioClip firePhaser;

    GameObject closest;
    Vector3 closestPosition;
	
	private int ID;
	private bool inRange;
	private bool fire;
    private bool autoFire;

	// Use this for initialization
	void Start () 
	{
		ID = GetInstanceID ();
		trackTargets = new List<GameObject>();
		Quaternion idenity = Quaternion.identity;
        closestPosition = new Vector3(0, 0, 0);
        closest = null;
		inRange = false;
		fire = false;
        autoFire = false;
	}

    public void toggleFire()
    {
        if(autoFire)
        {
            autoFire = false;
            trackTargets.Clear();
            closest = null;
            closestPosition = new Vector3(0, 0, 0);
        }
        else
        {
            autoFire = true;
        }
    }
	
    public void fireMainBank()
    {
        if (closest != null)
        {
            //check range
            Vector3 diffrence = transform.position - closest.transform.position;
            
            if (diffrence.magnitude < maxRange)
            {
                //Fire on that one
                if (!fire)
                {
                    PlayAudioloop(firePhaser);
                    fire = true;
                }
                inRange = true;
                phaserBank.fire(transform.position, closest.transform.position);
                trackTargets.Clear();
            }
            else
            {
                stopAudio();
                fire = false;
            }
        }
    }

	//// Update is called once per frame
	void Update () 
	{
		findTargets ();
		if (trackTargets.Count != 0 || inRange) 
		{
			findClosest ();

            if (autoFire)
            {
                fireMainBank();
            }
		} 

		if(!inRange)
		{
			phaserBank.transform.position = new Vector3(0.0f,0.0f,10.0f);
            stopAudio();
            fire = false;
            trackTargets.Clear();
            closest = null;
            closestPosition = new Vector3(0, 0, 0);
		}
	}

	private void PlayAudioloop(AudioClip sound)
	{
		audio.loop = true;
		audio.clip = (sound);
		audio.Play();
	}

	private void stopAudio()
	{
		audio.Stop ();
	}

	private void PlayAudioOnce(AudioClip sound)
	{
		audio.PlayOneShot (sound);
	}

	void findClosest ()
	{
		//Search through trackTargets
		foreach (GameObject var in trackTargets) 
		{
			////find the closest
			Vector3 distance = transform.position - var.transform.position;

			if(closest == null || closestPosition.magnitude > distance.magnitude)
			{
				closest = var;
				closestPosition = distance;
			}
		}
	}

	void findTargets()
	{
		foreach(string var in LookingFor)
		{
			//Search list
			GameObject[] newTargets = GameObject.FindGameObjectsWithTag(var);
			//Add to trackTargets
			if(newTargets.Length != 0 && newTargets.Length != trackTargets.Count)
			{
				foreach (GameObject target in newTargets) 
				{
					trackTargets.Add(target);
				}
			}
			else
			{
				trackTargets.Clear();
				inRange = false;
			}
		}
	}
}
