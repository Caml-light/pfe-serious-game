using UnityEngine;
using System.Collections;

public class NextTurnButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {  
	
	}

    public void NextTurn()
    {
        GameManager.instance.nextTurn();

    }

}
