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


   


    void Start()
    {
        Debug.Log("Global start");
        if (instance == null)
        {
            instance = this;
            globalIndicators.Add("pop", new Info("Population", 0));
            globalIndicators.Add("foodNeed", new Info("Besoin en nourriture", 0));
            globalIndicators.Add("foodProd", new Info("Production de nourriture", 0));
            globalIndicators.Add("earthHealth", new Info("Santé de la planete", 0));
            globalIndicators.Add("biodiversity", new Info("Biodiversité", 0));
            globalIndicators.Add("research", new Info("Recherche", 0));
            globalIndicators.Add("energy", new Info("Energie", 0));
            globalIndicators.Add("sickness", new Info("Maladie", 0));
            globalIndicators.Add("money", new Info("Argent", 0));



            ContinentInit("Europe");
            ContinentInit("Asie");
            ContinentInit("Amérique du Nord");
            ContinentInit("Amérique du Sud");
            ContinentInit("Océanie");
            ContinentInit("Afrique");

          
            foreach (KeyValuePair<string, Continent> entry in continents) // ajout des technologies de bases à chaque continent
            {
                entry.Value.Technologies.Add("Feu", 0);
                entry.Value.Technologies.Add("Chasse", 0);
                entry.Value.Technologies.Add("Cueillette", 0);
                entry.Value.Technologies.Add("Ecole", 0);
                entry.Value.Technologies.Add("Banque", 0);
                entry.Value.Technologies.Add("Cabane", 0);
                entry.Value.Technologies.Add("Charbon", 0);
                entry.Value.Technologies.Add("Pesticide", 0);
                entry.Value.Technologies.Add("Peche profonde", 0);
                entry.Value.Technologies.Add("Scierie", 0);
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
            unlockedTechnologies.Add("Feu", new Technologie("Feu", 1, 1, "Sprites/feu", "energy", 0, 5));
            unlockedTechnologies.Add("Chasse", new Technologie("Chasse", 1, 1, "Sprites/chasse", "foodProd", 0, 10));
            unlockedTechnologies.Add("Pêche", new Technologie("Pêche", 1, 1, "Sprites/pêche", "foodProd", 0, 15));
            unlockedTechnologies.Add("Cueillette", new Technologie("Cueillette", 1, 1, "Sprites/cueillette", "foodProd", 0, 5));
            unlockedTechnologies.Add("Ecole", new Technologie("Ecole", 1, 1, "Sprites/ecole", "research", 0, 5));
            unlockedTechnologies.Add("Banque", new Technologie("Banque", 1, 1, "Sprites/banque", "money", 0, 5));
            unlockedTechnologies.Add("Cabane", new Technologie("Cabane", 1, 1, "Sprites/cabane", "pop", 0, 5));
            unlockedTechnologies.Add("Charbon", new Technologie("Charbon", 1, 1, "Sprites/charbon", "airQuality", 0, -5));
            unlockedTechnologies.Add("Pesticide", new Technologie("Pesticide", 1, 1, "Sprites/pesticide", "earthQuality", 0, -5));
            unlockedTechnologies.Add("Peche profonde", new Technologie("Peche profonde", 1, 1, "Sprites/peche", "seaQuality", 0, -5));
            unlockedTechnologies.Add("Scierie", new Technologie("Scierie", 1, 1, "Sprites/scierie", "biodiversity", 0, 5));
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
            if (indicatorName.Equals("earthHealth"))
            {
                Debug.Log("C EST RIGOLO DE TUER LA PLANETEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                double result = 0;
                double moyTerre = 0;
                double moyAir = 0;
                double moyMer = 0;


                foreach (Continent c in continents.Values)
                {
                    moyTerre += c.Indicators["earthQuality"].Value;
                    moyAir += c.Indicators["airQuality"].Value;
                    moyMer += c.Indicators["seaQuality"].Value;
                }
                moyTerre = moyTerre / 6;
                moyMer = moyMer / 6;
                moyAir = moyAir / 6;

                result = (moyAir + moyMer + moyTerre) / 3;

               
                globalIndicators["earthHealth"].Value = result;
                Debug.Log(globalIndicators["earthHealth"].Value);
            }
            else
            {
                foreach (Continent c in continents.Values)
                {
                    Debug.LogFormat("{0}", c.Nom);
                    success = c.Indicators.TryGetValue(indicatorName, out indicatorBuffer);
                    if (success)
                    {
                        indicatorValueBuffer += indicatorBuffer.Value;
                    }
                }
            }

            globalIndicators[indicatorName].Value = indicatorValueBuffer;
        }

        

  

        foreach (Info i in globalIndicators.Values)
        {
            switch (i.Name)
            {
                case "Population":
                    popText.text = i.Value.ToString();
                    break;
                case "Production de nourriture":
                    foodText.text = i.Value.ToString();
                    break;
                case "Energie":
                    energyText.text = i.Value.ToString();
                    break;
                case "Maladie":
                    sickText.text = i.Value.ToString();
                    break;
                case "Recherche":
                    researchText.text = i.Value.ToString();
                    break;
                case "Santé de la planete":
                    earthText.text = i.Value.ToString();
                    break;
                case "Argent":
                    moneyText.text = i.Value.ToString();
                    break;
            }
        }
        Debug.Log("UpdateGlobalIndicators end");
    }

    private void ContinentInit(string name)
    {
        Debug.Log("Initialization of " + name + " continent start");

        Indicator pop = new Indicator("Population", 100.0, "Sprites/pop_totale");
        Indicator foodNeed = new Indicator("Besoin en nourriture", 100.0, "Sprites/nourriture");
        Indicator foodProd = new Indicator("Production de nourriture", 100.0, "Sprites/nourriture");
        Indicator airQuality = new Indicator("Qualité de l'air", 100.0, "Sprites/sante_planete");
        Indicator earthQuality = new Indicator("Qualité de la terre", 100.0, "Sprites/sante_planete");
        Indicator seaQuality = new Indicator("Qualité de la mer", 100.0, "Sprites/sante_planete");
        Indicator biodiversity = new Indicator("Biodiversité", 10000000, "Sprites/sante_planete");
        Indicator research = new Indicator("Recherche", 0, "Sprites/recherche");
        Indicator energy = new Indicator("Energie", 0,"Sprites/energie");
        Indicator sickness = new Indicator("Maladie", 1, "Sprites/pop_malade");
        Indicator money = new Indicator("Argent", 20, "Sprites/argent");
        Indicator happiness = new Indicator("Bonheur", 0, "Sprites/bonheur");


        Continent continent = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity,research,energy,sickness,money,happiness);

        Global.instance.continents.Add(name, continent);
        Debug.Log("Initialization of " + name + " continent end");
    }
}
