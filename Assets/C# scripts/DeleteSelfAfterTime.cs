using UnityEngine;
using System.Collections;

public class DeleteSelfAfterTime : MonoBehaviour {

    public float amountOfTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (amountOfTime <= 0)
        {
            //delete
            Destroy(gameObject);
        }
        else
        {
            amountOfTime -= Time.deltaTime;
        }
	}
}
