using UnityEngine;
using System.Collections;

public class PhaserBank : MonoBehaviour {
	private bool fireing;

	/// <Debugging>
	//public GameObject Target;
	//public GameObject shipFireing;
	//public Vector3 positionOffset;
	//public float scaleBack;
	//public float zFix;
	/// </Debugging>

	/// <Real>
	private Vector3 positionOffset;
	private float scaleBack;
	private float zFix;
	/// </Debugging>

	// Use this for initialization
	void Start () {
		fireing = false;
		positionOffset = new Vector3 (-1.0f, 0.5f, 0);
		scaleBack = 1.0f;
		zFix = 1;
	}
	
	// Update is called once per frame
	void Update () {
		fireing = false;
	}

	public void fire(Vector3 positionStart, Vector3 positionEnd)
	{
		Vector3 startToEnd = (positionStart - positionEnd);
		Vector3 currentScale = transform.localScale;

		Vector3 newPosition = positionStart;
		newPosition.z /= zFix;
		transform.position = (newPosition + positionOffset);

		float distace = startToEnd.magnitude;
		float newScale = distace;
		currentScale.z = newScale - scaleBack;
		transform.localScale = currentScale;

		Vector3 normalized = startToEnd.normalized;
		Quaternion lookAtDirection = Quaternion.LookRotation (normalized);
		transform.rotation = lookAtDirection;

		fireing = true;
	}
}
