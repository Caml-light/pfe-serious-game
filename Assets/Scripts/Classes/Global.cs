using UnityEngine;
using Assets.Scripts.Classes;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public static Global instance = null;

    public Dictionary<string,Continent> continents = new Dictionary<string,Continent>();
    public Dictionary<string, Info> globalIndicators = new Dictionary<string, Info>();
    public Dictionary<string, Technologie> allTechnologies = new Dictionary<string, Technologie>();

    void Start()
    {
        Debug.Log("Global start");
        if (instance == null)
        {
            instance = this;
            globalIndicators.Add("pop", new Info("pop", 0));
            globalIndicators.Add("foodNeed", new Info("foodNeed", 0));
            globalIndicators.Add("foodProd", new Info("foodProd", 0));
            globalIndicators.Add("airQuality", new Info("airQuality", 0));
            globalIndicators.Add("earthQuality", new Info("earthQuality", 0));
            globalIndicators.Add("seaQuality", new Info("seaQuality", 0));
            globalIndicators.Add("biodiversity", new Info("biodiversity", 0));

            EuropeInitilization();
            AsiaInitilization();
            AfricaInitilization();
            NorthAmericaInitilization();
            SouthhAmericaInitilization();
            AustraliaInitilization();

            UpdateGlobalIndicators();

            //definition des technologies
            allTechnologies.Add("fire", new Technologie("fire", 1, 1, "fire", "foodProd", 0.015));

        }            
        else if (instance != this)
        {
            Destroy(gameObject);
        }
            

        Debug.Log("Global finished");
    }    

	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextTurn()
    {
        Debug.Log("NextTurn Global.cs");
        foreach (Continent c in continents.Values)
        {
            foreach (Indicator i in c.indicators.Values)
            {
                i.UpdateValue();
            }
        }
        UpdateGlobalIndicators();
    }

    public void UpdateGlobalIndicators()
    {

        Debug.Log("UpdateGlobalIndicators start");


        double indicatorValueBuffer;
        Indicator indicatorBuffer;
        bool success = false;

        foreach (string indicatorName in globalIndicators.Keys)
        {
            Debug.LogFormat("{0}", indicatorName);
            indicatorValueBuffer = 0;


            foreach (Continent c in continents.Values)
            {
                Debug.LogFormat("{0}", c.Name);
                success = c.indicators.TryGetValue(indicatorName, out indicatorBuffer);
                if (success)
                {
                    indicatorValueBuffer += indicatorBuffer.Value;
                }
            }

            globalIndicators[indicatorName].Value = indicatorValueBuffer;
        }
        Debug.Log("UpdateGlobalIndicators end");
    }

    private void EuropeInitilization()
    {
        Debug.Log("Initialization of Europe continent start");

        string name = "Europe";
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentEurope = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentEurope);
        Debug.Log("Initialization of Europe continent end");
    }

    private void AsiaInitilization()
    {

        string name = "Asie";
        Debug.Log("Initialization of Asia continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAsia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAsia);
        Debug.Log("Initialization of Asia continent end");
    }

    private void NorthAmericaInitilization()
    {

        string name = "Amérique du Nord";
        Debug.Log("Initialization of North America continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentNA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentNA);
        Debug.Log("Initialization of North America continent end");
    }

    private void SouthhAmericaInitilization()
    {

        string name = "Amérique du Sud";
        Debug.Log("Initialization of South America continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentSA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentSA);
        Debug.Log("Initialization of South America continent end");
    }

    private void AfricaInitilization()
    {

        string name = "Afrique";
        Debug.Log("Initialization of Africa continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAfrica = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAfrica);
        Debug.Log("Initialization of Africa continent end");
    }

    private void AustraliaInitilization()
    {

        string name = "Australie";
        Debug.Log("Initialization of Australia continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAustralia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAustralia);
        Debug.Log("Initialization of Australia continent end");
    }
}
