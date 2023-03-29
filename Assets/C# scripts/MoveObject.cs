using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	//public GameObject target;
	public float low;
	public float heigh;
	public bool freezeX;
    public int z;

	void Start()
	{
		//target = 
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown (0) || Input.touchCount >= 1)) 
		{
			if (Input.GetMouseButtonDown (0)) {
				moveObject(Input.mousePosition);
			}
			else if (Input.touches [0].phase == TouchPhase.Moved) 
			{
				moveObject(Input.touches [0].position);
			}
		}
	}

	private void moveObject(Vector3 position)
	{
		if (position.y > 130.0f) 
		{
			//Debug.Log ("Past in: " + position);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, z));

            Vector3 fixOrentation = new Vector3(touchPosition.z, touchPosition.y, touchPosition.x);

			float temp = fixOrentation.x;
			fixOrentation.x = fixOrentation.z;
			fixOrentation.z = temp;

			if (freezeX) {
					fixOrentation.x *= 0;
			}
			//fixOrentation.z *= -1;

			//if(fixOrentation.z < 4)
			//{
			Vector3 original = transform.position;
			fixOrentation.x = original.x;

			if (fixOrentation.z >= low && fixOrentation.z <= heigh) {
                fixOrentation.y = transform.position.y;	
                transform.position = fixOrentation;
                Debug.Log("Results: " + fixOrentation);
			}
			//}

			//target.transform.position = newPosition;
			//fixOrentation.y = 0;
			//fixOrentation.x = 0;
			//fixOrentation.z =(fixOrentation.z / 8);
		}
	}
}
