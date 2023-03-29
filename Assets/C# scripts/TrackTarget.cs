using UnityEngine;
using System.Collections;

public class TrackTarget : MonoBehaviour {

	public GameObject target;

	public float amountTouchMove;
	public float strength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 startingPosition = this.transform.position;
		Vector3 targetPosition = target.transform.position;
		Vector3 newPostion = lerpFormOneToAnother (startingPosition, targetPosition);
		transform.position = newPostion;
		changeLookingDirection (targetPosition);
	}

	Vector3 lerpFormOneToAnother(Vector3 startingPosition, Vector3 targetPosition)
	{
		Vector3 newPosition = Vector3.Lerp(startingPosition, targetPosition, amountTouchMove);
		return (newPosition);
	}

	void changeLookingDirection(Vector3 targetPosition)
	{
		Vector3 lookForward = targetPosition - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (lookForward);
		float str = Mathf.Min (strength * Time.deltaTime, 1.0f);
		Quaternion result = Quaternion.Lerp (transform.rotation, targetRotation, str);
		transform.rotation = result;
	}
}
