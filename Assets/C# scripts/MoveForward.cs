using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float moveBay;
	public string axis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		if (axis != null) {
			if (axis == "x" || axis == "X")
			{
                newPosition.x += moveBay;
			}
			else if (axis == "y" || axis == "Y")
			{
                newPosition.y += moveBay;
			}
			else if (axis == "z" || axis == "Z")
			{
                newPosition.z += moveBay;
			}
		}
		transform.position = newPosition;
	}
}
