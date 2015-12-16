using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public static Global instance = null;

    public Dictionary<string,Continent> continents = new Dictionary<string,Continent>();
    public Dictionary<string, double> globalIndicators = new Dictionary<string, double>();

    void Awake()
    {
        Debug.Log("Global start");
        if (instance == null)
        {
            instance = this;
            globalIndicators.Add("pop", 0);
            globalIndicators.Add("foodNeed", 0);
            globalIndicators.Add("foodProd", 0);
            globalIndicators.Add("airQuality", 0);
            globalIndicators.Add("earthQuality", 0);
            globalIndicators.Add("seaQuality", 0);
            globalIndicators.Add("biodiversity", 0);
        }            
        else if (instance != this)
        {
            Destroy(gameObject);
        }
            

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
        
    }

    public void UpdateGlobalIndicators()
    {
        double indicatorValueBuffer;
        Indicator indicatorBuffer;
        bool success = false;

        foreach (string indicatorName in globalIndicators.Keys)
        {
            indicatorValueBuffer = 0;

            foreach (Continent c in continents.Values)
            {
                success = c.indicators.TryGetValue(indicatorName, out indicatorBuffer);
                if (success)
                {
                    indicatorValueBuffer += indicatorBuffer.Value;
                }

            }

            globalIndicators[indicatorName] = indicatorValueBuffer;
        }
    }
}
