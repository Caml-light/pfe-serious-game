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
    public Dictionary<string, CustomEvent> eventsList = new Dictionary<string, CustomEvent>();
    public List<CustomEvent> eventsOccurringList = new List<CustomEvent>();

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
               // entry.Value.Technologies.Add("Chasse", 0);
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
            unlockedTechnologies.Add("Feu", new Technologie("Feu", 1, 1, "Sprites/feu", "energyProd", 0, 5));
          //  unlockedTechnologies.Add("Chasse", new Technologie("Chasse", 1, 1, "Sprites/chasse", "foodProd", 0, 10000));
            unlockedTechnologies.Add("Pêche", new Technologie("Pêche", 1, 1, "Sprites/pêche", "foodProd", 0, 15));
            unlockedTechnologies.Add("Cueillette", new Technologie("Cueillette", 1, 1, "Sprites/cueillette", "foodProd", 0, 5));
            unlockedTechnologies.Add("Ecole", new Technologie("Ecole", 1, 1, "Sprites/école", "researchProd", 0, 5));
            unlockedTechnologies.Add("Banque", new Technologie("Banque", 1, 1, "Sprites/banque", "moneyProd", 0, 5));
            unlockedTechnologies.Add("Cabane", new Technologie("Cabane", 1, 1, "Sprites/cabane", "pop", 0, 5));
            unlockedTechnologies.Add("Charbon", new Technologie("Charbon", 1, 1, "Sprites/charbon", "airQuality", 0, -5));
            unlockedTechnologies.Add("Pesticide", new Technologie("Pesticide", 1, 1, "Sprites/pesticides", "earthQuality", 0, -5));
            unlockedTechnologies.Add("Peche profonde", new Technologie("Peche profonde", 1, 1, "Sprites/pêche_profonde", "seaQuality", 0, -5));
            unlockedTechnologies.Add("Scierie", new Technologie("Scierie", 1, 1, "Sprites/scierie", "forest", 0, 5));


            //definition of the events.
            // Nom - description - path de l'image - indicateur trigger - proba - seuil - seuil à atteidre pour déclencher (vrai nou faux) - indacateur influencé - pourcentage à appliquer
            eventsList.Add("Famine", new EventOnIndicator("Famine", "La famine sévit en ", "Sprites/famine", "foodProd", 100, 50000, true, "pop", 0.8f));
            eventsList.Add("Tsunami", new EventOnIndicator("Tsunami", "Un Tsunami ravage\nles côtes d'", "Sprites/tsunami", "pop", 5, 100, false, "pop", 0.95f));
            eventsList.Add("Extinction du Mammouth", new EventOnTech("Extinction du Mammouth", "Le Mammouth s'éteint en ", "Sprites/mammouth", "Chasse", 100, 10, false, "animals", 0.999f));
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
            c.Indicators["money"].Value = c.Indicators["money"].Value + c.Indicators["moneyProd"].Value - c.Indicators["moneyNeed"].Value;
        }

        eventsOccurringList.Clear();
        foreach (CustomEvent e in eventsList.Values)
        {
            e.nextTurn();
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
            indicatorValueBuffer = 0;

            if (indicatorName.Equals("research"))
            {
                foreach (Continent c in continents.Values)
                {
                    globalIndicators[indicatorName].Value += c.Indicators["researchProd"].Value;
                }
            }

            if (indicatorName.Equals("earthHealth"))
            {
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
            }
            else
            {
                foreach (Continent c in continents.Values)
                {
                    success = c.Indicators.TryGetValue(indicatorName, out indicatorBuffer);
                    if (success)
                    {
                        indicatorValueBuffer += indicatorBuffer.Value;
                    }
                    else if(indicatorName.Equals("research"))
                    {
                        indicatorValueBuffer = globalIndicators["research"].Value;
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

        Continent continent = new Continent(name);

        Global.instance.continents.Add(name, continent);
        Debug.Log("Initialization of " + name + " continent end");
    }
}
