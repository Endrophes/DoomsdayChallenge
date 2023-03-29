using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
	
	public float angleOfRotation;
	public float moveBay;
	public string axis;
	public bool rotate;
	public int lifeTime;

    public Dictionary<string, int> test = new Dictionary<string, int>();
	
	// Use this for initialization
	void Start () {
		//audio.PlayOneShot (sound);
        test.Add("KBCD7 3", 1);
        test.Add("Astroid", 50);
        test.Add("DoomsDay", 50);
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime > 0) 
		{
			lifeTime--;
			moveObject ();
		} 
		else 
		{
			Destroy (gameObject);
		}
	}
	
	void moveObject()
	{
		if (rotate) {
			transform.Rotate (0, angleOfRotation * Time.deltaTime, 0);
		}
		
		Vector3 position = transform.position;
		
		if (axis != null) {
			if (axis == "x" || axis == "X")
			{
				position.x += moveBay;
			}
			else if (axis == "y" || axis == "Y")
			{
				position.y += moveBay;
			}
			else if (axis == "z" || axis == "Z")
			{
				position.z += moveBay;
			}
		}
		
		transform.position = position;
	}

	void OnCollisionStay(Collision Collision)
	{
		//(Instantiate(explosion, transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleEmitter>();
        string removeClone = Collision.gameObject.name.Replace("(Clone)", "");

        if (test.ContainsKey(removeClone))
        {
            Destroy(gameObject);
        }
    }
	
}
