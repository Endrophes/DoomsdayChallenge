using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetFireOn : MonoBehaviour {

	public float maxRange;
	public string[] LookingFor;
	private List<GameObject> trackTargets;

	public PhaserBank phaserBank;
	public AudioClip firePhaser;

    GameObject closest;
	
	private int ID;
	private bool inRange;
	private bool fire;

	// Use this for initialization
	void Start () 
	{
		ID = GetInstanceID ();
		trackTargets = new List<GameObject>();
		Quaternion idenity = Quaternion.identity;
        closest = null;
		inRange = false;
		fire = false;
	}
	
    void fireMainBank()
    {
        if (closest != null)
        {
            //check range
            Vector3 diffrence = transform.position - closest.transform.position;
            ////float range = diffrence.magnitude;
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
		} 

		if(!inRange)
		{
			phaserBank.transform.position = new Vector3(0.0f,0.0f,10.0f);
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
		Vector3 closestPosition = new Vector3 (0,0,0);

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
					//if(!trackTargets.Contains(target))
					//{
						trackTargets.Add(target);
					//}
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
