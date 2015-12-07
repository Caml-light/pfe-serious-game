using UnityEngine;
using System.Collections;

public class TourSuivant : MonoBehaviour {

    public GameManager gm;

     void OnMouseEnter()
    {
        Vector3 temp = new Vector3(0, 0, -2);
        transform.position += temp;
    }

    void OnMouseExit()
    {
        Vector3 temp = new Vector3(0, 0, 2);
        transform.position += temp;
    }


    void OnMouseDown()
    {
        gm.nextTurn();
    }
	// Use this for initialization
	void Start () {
        Debug.Log("Button Start");
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
