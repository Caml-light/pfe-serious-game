using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameLaunch(string name)
    {
        if (name.Equals("new"))
        {
            Application.LoadLevel(1);
        }
        else if (name.Equals("exit"))
        {
            Application.Quit();
        }
    }
}
