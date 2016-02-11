using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Continent : MonoBehaviour
{

    public float posX;
    public float posY; // Coordonnées de la caméra zoomée, modifiable depuis l'interface de Unity (pour chaque continent)
    public float posZoom;

    private Dictionary<string, Indicator> _indicators = new Dictionary<string, Indicator>();
    private Dictionary<string, int> _technologies = new Dictionary<string, int>();
    private string _nom;

    private Animator surbrillance;

    public Continent(string sname)
    {

        Debug.Log("contruction du continent : " + sname);


        Indicator pop = new Indicator("Population", 100000.0, "Sprites/pop_totale");
        Indicator sickness = new Indicator("Population Malade (%)", 1, "Sprites/pop_malade");

        Indicator lifeQuality = new Indicator("Niveau de Vie", 1, "Sprites/niveau_vie");
        Indicator knowledge = new Indicator("Savoir", 1, "Sprites/savoir");
        Indicator happiness = new Indicator("Bonheur", 0, "Sprites/bonheur");

        Indicator foodNeed = new Indicator("Besoin en nourriture", 100.0, "Sprites/besoin_nourriture");
        Indicator foodProd = new Indicator("Production de nourriture", 100.0, "Sprites/nourriture+");

        Indicator money = new Indicator("Argent", 20, "Sprites/argent");
        Indicator moneyProd = new Indicator("Revenus", 20, "Sprites/argent+");
        Indicator moneyNeed = new Indicator("Besoin économique", 20, "Sprites/besoin_eco");

        Indicator energyProd = new Indicator("Production d'énergie", 0, "Sprites/energie"); //nergie+
        Indicator energyNeed = new Indicator("Besoin énergetique", 0, "Sprites/besoin_energie"); 

        Indicator researchProd = new Indicator("Recherche", 0, "Sprites/recherche+");

        Indicator airQuality = new Indicator("Qualité de l'air (%)", 100.0, "Sprites/qualité_air");
        Indicator earthQuality = new Indicator("Qualité de la terre (%)", 100.0, "Sprites/qualité_terre");
        Indicator seaQuality = new Indicator("Qualité de la mer (%)", 100.0, "Sprites/qualité_mer");

        Indicator forest = new Indicator("Biodiversité végétale", 100000.0, "Sprites/foret");
        Indicator animals = new Indicator("Biodiversité terrestre", 10000.0, "Sprites/faune_terrestre");
        Indicator submarines = new Indicator("Biodiversité marine", 10000.0, "Sprites/faune_marine");

        Indicators.Add("pop", pop);
        Indicators.Add("sickness", sickness);

        Indicators.Add("lifeQuality", lifeQuality);
        Indicators.Add("knowledge", knowledge);
        Indicators.Add("happiness", happiness);

        Indicators.Add("foodNeed", foodNeed);
        Indicators.Add("foodProd", foodProd);

        Indicators.Add("money", money);
        Indicators.Add("moneyProd", moneyProd);
        Indicators.Add("moneyNeed", moneyNeed);

        Indicators.Add("energyProd", energyProd);
        Indicators.Add("energyNeed", energyNeed);

        Indicators.Add("researchProd", researchProd);

        Indicators.Add("airQuality", airQuality);
        Indicators.Add("earthQuality", earthQuality);
        Indicators.Add("seaQuality", seaQuality);

        Indicators.Add("forest", forest);
        Indicators.Add("animals", animals);
        Indicators.Add("submarines", submarines);

        Nom = sname;
    }

    public void AddTechnologie(string indicatorName, double modifier, double constant)
    {
        Debug.Log("Continent.AddTechnologie");
        Indicator bufferIndicator;
        if (Indicators.TryGetValue(indicatorName, out bufferIndicator))
        {
            if(indicatorName.Equals("money"))
            {
                bufferIndicator.Modifier += modifier;
                bufferIndicator.Constant += constant;
            }
            else
            {
                bufferIndicator.Value += constant;
            }
           
        }

        Debug.LogFormat("test : {0}, {1}, {2}", Indicators[indicatorName].Modifier, modifier,constant);

    }

    public void SupprTechnologie(string indicatorName, double modifier, double constant)
    {
        Debug.Log("Continent.SupprTechnologie");
        Indicator bufferIndicator;
        if (Indicators.TryGetValue(indicatorName, out bufferIndicator))
        {
            if (indicatorName.Equals("money"))
            {
                bufferIndicator.Modifier -= modifier;
                bufferIndicator.Constant -= constant;
            }
            else
            {
                bufferIndicator.Value -= constant;
            }

        }

        Debug.LogFormat("test : {0}, {1}, {2}", Indicators[indicatorName].Modifier, modifier, constant);

    }








    void Start()
    {
        surbrillance = GetComponent<Animator>(); // permet de gérer la surbrillance (on lui attribu l'animator)
    }

    void OnMouseEnter() // Lorsque l'on passe la souris sur le continent
    {
        if (GameManager.instance.isZoomed == false && GameManager.instance.isZoomFinished) // On vérifie que l'on est en vue globale (et non en vue zoomée), et que l'on n'est pas en pleine annimation de zoom
        {
            surbrillance.SetBool("isMouseOn", true);
        }
    }

    void OnMouseExit() // Lorsque la souris sort de la zone cliqueble du continent
    {
        if (GameManager.instance.isZoomed == false && GameManager.instance.isZoomFinished) // On vérifie que l'on est en vue zoomé, et que l'on n'est pas en pleine annimation de zoom
        {
            surbrillance.SetBool("isMouseOn", false);
        }
    }

    void OnMouseDown() // Lorsque l'on clique sur un continent
    {

        if (GameManager.instance.isZoomFinished && !GameManager.instance.isZoomed) // Si on n'est pas en pleine annimation et que on est en vue globale
        {
            surbrillance.SetBool("isMouseOn", false);

            GameManager.instance.ContinentSelected = this; // On attribu au GameManager le continent sélectionné 
            GameManager.instance.isZoomed = !GameManager.instance.isZoomed; // On annonce que on passe en vue zoomée
            GameManager.instance.isZoomFinished = false; // On indique que l'annimation commence

            GameManager.instance.panelContinent.SetActive(true);
            GameObject.Find("IndicatorsButton").GetComponent<Button>().onClick.Invoke();

        }


    }

    public string Nom
    {
        get
        {
            return _nom;
        }

        set
        {
            _nom = value;
        }
    }

    public Dictionary<string, int> Technologies
    {
        get
        {
            return _technologies;
        }

        set
        {
            _technologies = value;
        }
    }

    public Dictionary<string, Indicator> Indicators
    {
        get
        {
            return _indicators;
        }

        set
        {
            _indicators = value;
        }
    }

    public void nextTurn()
    {

    }
}
