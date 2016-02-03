using UnityEngine;
using Assets.Scripts.Classes;
using System.Collections.Generic;
using UnityEngine.UI;

public class Global : MonoBehaviour
{

    public static Global instance = null;

    public Dictionary<string, Continent> continents = new Dictionary<string, Continent>();
    public Dictionary<string, Info> globalIndicators = new Dictionary<string, Info>();
    public Dictionary<string, Technologie> unlockedTechnologies = new Dictionary<string, Technologie>();

    private Text foodText;
    private Text energyText;
    private Text researchText;
    private Text popText;
    private Text sickText;
    private Text earthText;
    private Text moneyText;



    Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0, "Sprites/pop_totale");
    Indicator foodNeed = new Indicator("Besoin en nourriture", 100.0, 0.99, 50.0, 1.0, "Sprites/nourriture");
    Indicator foodProd = new Indicator("Production de nourriture", 100.0, 0.99, 50.0, 1.0, "Sprites/nourriture");
    Indicator airQuality = new Indicator("Qualité de l'air", 100.0, 0.99, 50.0, 1.0, "Sprites/sante_planete");
    Indicator earthQuality = new Indicator("Qualité de la terre", 100.0, 0.99, 50.0, 1.0, "Sprites/sante_planete");
    Indicator seaQuality = new Indicator("Qualité de la mer", 100.0, 0.99, 50.0, 1.0, "Sprites/sante_planete");
    Indicator biodiversity = new Indicator("Biodiversité", 10000000, 0.99, 10000000, 1.0, "Sprites/sante_planete");


    void Start()
    {
        Debug.Log("Global start");
        if (instance == null)
        {
            instance = this;
            globalIndicators.Add("pop", new Info("Population", 0));
            globalIndicators.Add("foodNeed", new Info("Besoin en nourriture", 0));
            globalIndicators.Add("foodProd", new Info("Production de nourriture", 0));
            globalIndicators.Add("airQuality", new Info("Qualité de l'air", 0));
            globalIndicators.Add("earthQuality", new Info("Qualité de la terre", 0));
            globalIndicators.Add("seaQuality", new Info("Qualité de la mer", 0));
            globalIndicators.Add("biodiversity", new Info("Biodiversité", 0));

            EuropeInitilization();
            AsiaInitilization();
            AfricaInitilization();
            NorthAmericaInitilization();
            SouthhAmericaInitilization();
            AustraliaInitilization();

            foreach (KeyValuePair<string, Continent> entry in continents) // ajout des technologies de bases à chaque continent
            {
                entry.Value.Technologies.Add("Feu", 0);
                entry.Value.Technologies.Add("Chasse", 0);
                entry.Value.Technologies.Add("Cueillette", 0);
                entry.Value.Technologies.Add("Pêche", 0);
            }

            foodText = GameObject.Find("globalTextFood").GetComponent<Text>();
            moneyText = GameObject.Find("globalTextMoney").GetComponent<Text>();
            energyText = GameObject.Find("globalTextEnergy").GetComponent<Text>();
            popText = GameObject.Find("globalTextPop").GetComponent<Text>();
            sickText = GameObject.Find("globalTextSickness").GetComponent<Text>();
            earthText = GameObject.Find("globalTextEarth").GetComponent<Text>();
            researchText = GameObject.Find("globalTextResearch").GetComponent<Text>();

            UpdateGlobalIndicators();

            //definition des technologies
            unlockedTechnologies.Add("Feu", new Technologie("Feu", 1, 1, "Sprites/feu", "foodProd", 0.015));
            unlockedTechnologies.Add("Chasse", new Technologie("Chasse", 1, 1, "Sprites/chasse", "foodProd", 0.017));
            unlockedTechnologies.Add("Pêche", new Technologie("Pêche", 1, 1, "Sprites/pêche", "foodProd", 0.015));
            unlockedTechnologies.Add("Cueillette", new Technologie("Cueillette", 1, 1, "Sprites/cueillette", "foodProd", 0.010));

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        Debug.Log("Global finished");
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextTurn()
    {
        Debug.Log("NextTurn Global.cs");
        foreach (Continent c in continents.Values)
        {
            foreach (Indicator i in c.Indicators.Values)
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
                Debug.LogFormat("{0}", c.Nom);
                success = c.Indicators.TryGetValue(indicatorName, out indicatorBuffer);
                if (success)
                {
                    indicatorValueBuffer += indicatorBuffer.Value;
                }
            }

            globalIndicators[indicatorName].Value = indicatorValueBuffer;
        }

        foreach (Info i in globalIndicators.Values)
        {
            switch (i.Name)
            {
                case "pop":
                    popText.text = i.Value.ToString();
                    break;

                case "foodProd":
                    foodText.text = i.Value.ToString();
                    break;
            }
        }
        Debug.Log("UpdateGlobalIndicators end");
    }

    private void EuropeInitilization()
    {
        Debug.Log("Initialization of Europe continent start");

        string name = "Europe";

        Continent continentEurope = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentEurope);
        Debug.Log("Initialization of Europe continent end");
    }

    private void AsiaInitilization()
    {

        string name = "Asie";
        Debug.Log("Initialization of Asia continent start");

        Continent continentAsia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAsia);
        Debug.Log("Initialization of Asia continent end");
    }

    private void NorthAmericaInitilization()
    {

        string name = "Amérique du Nord";
        Debug.Log("Initialization of North America continent start");

        Continent continentNA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentNA);
        Debug.Log("Initialization of North America continent end");
    }

    private void SouthhAmericaInitilization()
    {

        string name = "Amérique du Sud";
        Debug.Log("Initialization of South America continent start");

        Continent continentSA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentSA);
        Debug.Log("Initialization of South America continent end");
    }

    private void AfricaInitilization()
    {

        string name = "Afrique";
        Debug.Log("Initialization of Africa continent start");

        Continent continentAfrica = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAfrica);
        Debug.Log("Initialization of Africa continent end");
    }

    private void AustraliaInitilization()
    {

        string name = "Océanie";
        Debug.Log("Initialization of Australia continent start");

        Continent continentAustralia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAustralia);
        Debug.Log("Initialization of Australia continent end");
    }
}
