using UnityEngine;
using System.Collections;

public class Arbre_tech : MonoBehaviour {

    private bool isDisplayed = false;
    private GameObject arbre_tech; 

	// Use this for initialization
	void Start () {
        arbre_tech = GameObject.Find("arbre_tech");
        arbre_tech.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void display()
    {
        if(isDisplayed)
        {
            isDisplayed = false;
            arbre_tech.SetActive(false);
        }
        else
        {
            isDisplayed = true;
            arbre_tech.SetActive(true);
        }
    }

}
