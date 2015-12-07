using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public Continent europe, afrique, ameriqueNord, ameriqueSud, oceanie, asie;

    private Indicator inFood;
    public Text foodText;
	// Use this for initialization
	void Start () {
        Debug.Log("Application start");
        Debug.Log("GameManager start");

        inFood = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        foodText.text = "Nourriture : " + inFood.Value;
        Debug.Log("GameManager start finish");
    }

     public void nextTurn()
    {
        inFood.UpdateValue();
        foodText.text = "Nourriture : " + inFood.Value;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
