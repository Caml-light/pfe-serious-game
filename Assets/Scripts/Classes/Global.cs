using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public static Global instance = null;

    public double pop;
    public double foodNeed;
    public double foodProd;
    public double airQuality;
    public double earthQuality;
    public double seaQuality;
    public double biodiversity;

    public Dictionary<string,Continent> continents = new Dictionary<string,Continent>();

    void Awake()
    {
        Debug.Log("Global start");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Debug.Log("Global finished");
    }



    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextTurn()
    {
        foodProd = 0;
        foreach (Continent c in Global.instance.continents.Values)
        {
            foodProd += c.foodProd.Value;
        }
    }
}
