using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Life : MonoBehaviour {

	public int amount;
	public GameObject explosion;
	public Dictionary<string, int> test = new Dictionary<string, int> ();

	// Use this for initialization
	void Start () {

		test.Add ("PhaserBeam", 1);
		test.Add ("Torpedo", 50);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision Collision)
	{
		string removeClone = Collision.gameObject.name.Replace ("(Clone)", "");

		amount -= (test.ContainsKey (removeClone) ? test[removeClone] : 0);

		if(amount <= 0)
		{
			(Instantiate(explosion, transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleEmitter>();
            HighScoreManager.reportChange(100);
            Destroy (gameObject);
		}

	}
}