using UnityEngine;
using System.Collections;

public class applicationControl : MonoBehaviour {

    public bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HighScoreManager.saveOut();
            Application.LoadLevel("MainMenu");
        }
	}

    void OnGUI()
    {
        if (paused)
        {
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
            if(GUI.Button (new Rect(5,55,200,20), "Resume"))
            {
                SetPause(false);
            }
        }

    }

    void SetPause(bool newValue)
    {
        paused = newValue;

        if (newValue)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

   // void OnApplicationFocus(bool focusStatus)
   // {
   //     SetPause(focusStatus);
   // }

    void OnApplicationPause(bool pauseStatus)
    {
        SetPause(pauseStatus);
    }

    void OnApplicationQuit()
    {
        HighScoreManager.saveOut();
    }
}
