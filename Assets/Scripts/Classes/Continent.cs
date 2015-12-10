﻿using UnityEngine;
using System.Collections;

public class Continent : MonoBehaviour {

    public Indicator pop;
    public Indicator foodNeed;
    public Indicator foodProd;
    public Indicator airQuality;
    public Indicator earthQuality;
    public Indicator seaQuality;
    public Indicator biodiversity;
    public string _Name;

   

    // Use this for initialization
    void Start () {
        Debug.Log(Name +" start");
        pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Global.instance.continents.Add(Name,this);
        Debug.Log( Name + " finished");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

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
        foodProd.UpdateValue();
        GameManager.instance.nextTurn();
    }




    public string Name
    {
        get
        {
            return _Name;
        }

        set
        {
            _Name = value;
        }
    }
}
