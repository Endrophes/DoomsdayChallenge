using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

    private static int score;

    public static UILabel label;

    /// lable to change

	// Use this for initialization
	void Start () {
	    //load file
        GameObject[] newTargets = GameObject.FindGameObjectsWithTag("scoreLabel");
        if (newTargets != null)
        {
            label = newTargets[0].GetComponent<UILabel>();
        }
        score = PlayerPrefs.GetInt("currentScore",0);
        label.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    //check score and put to label
        PlayerPrefs.Save();
        label.text = score.ToString();
	}

    public static void reportChange(int update)
    {
        score += update;
        label.text = score.ToString();
        PlayerPrefs.SetInt("currentScore", score);
    }
    
    public static void saveOut()
    {
        PlayerPrefs.Save();
        string[] lines = { "Look At My Data", "score" + score };
        System.IO.File.WriteAllLines(Application.persistentDataPath + "\\SampleFile.txt", lines);
    }

    void OnApplicationQuit()
    {
        saveOut();
    }

}
