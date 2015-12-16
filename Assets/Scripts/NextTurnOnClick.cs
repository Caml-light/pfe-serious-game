using UnityEngine;
using System.Collections;

public class NextTurnOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {  
	
	}

    void OnMouseDown()
    {
        Debug.Log("Je te clique dans la geule");
        GameManager.instance.nextTurn();
    }

}
