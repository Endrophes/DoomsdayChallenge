using UnityEngine;
using System.Collections;

public class ParticleMangier : MonoBehaviour {

	public GameObject particelSystem;

	//public GameObject locationPoint;

	//public AudioClip PhaserSound;

	private ParticleSystem currentSystem;

	//private bool blockInput = false;

	// Use this for initialization
	void Start () {
	
	}

	private void PlayAudio(AudioClip sound)
	{
		audio.PlayOneShot (sound);
	}

	// Update is called once per frame
	void Update () {

		if ((Input.GetMouseButtonDown (0) || Input.touchCount >= 1)) 
		{
			if (Input.GetMouseButtonDown (0)) {
				createParticelEffect(Input.mousePosition);
			}
			else if (Input.touches [0].phase == TouchPhase.Began) {
				createParticelEffect(Input.touches [0].position);
			}
		}

	}

	private void createParticelEffect(Vector3 position)
	{
		//Vector3 fixedHeight = position;

		position.z = 5;

		Vector3 moniteredPosition = Camera.main.ScreenToWorldPoint (position);

		Quaternion rotation = new Quaternion ();
		//rotation.x = -90.0f;
		//rotation.y = 90.0f;
		//rotation.z = -90.0f;

		float angel = -90.0f;
		Vector3 axis = new Vector3 (1.0f, 0.0f, 0.0f);

		rotation = Quaternion.AngleAxis(angel, axis);

		(Instantiate(particelSystem, moniteredPosition, rotation) as GameObject).GetComponent<ParticleSystem>();
	}
}
