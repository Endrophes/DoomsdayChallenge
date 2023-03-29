using UnityEngine;
using System.Collections;

public class LightDimmer : MonoBehaviour {

    public float startingIntensity;
    public float rateOfDecrease;

    private Light thiySelf;

	// Use this for initialization
	void Start () {
        thiySelf = gameObject.GetComponent<Light>();
        thiySelf.intensity = startingIntensity;
	}
	
	// Update is called once per frame
	void Update () {
        float timepassed = Time.deltaTime * rateOfDecrease;
        thiySelf.intensity -= timepassed;
	}
}
