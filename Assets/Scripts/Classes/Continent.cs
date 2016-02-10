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

    public Continent(string sname, Indicator pop, Indicator foodNeed, Indicator foodProd, Indicator airQuality, Indicator earthQuality, Indicator seaQuality, Indicator biodiversity,Indicator reseach,Indicator energy, Indicator sickness, Indicator money, Indicator happiness)
    {

        Debug.Log("contruction du continent : " + sname);

        Indicators.Add("pop", pop);
        Indicators.Add("foodNeed", foodNeed);
        Indicators.Add("foodProd", foodProd);
        Indicators.Add("airQuality", airQuality);
        Indicators.Add("earthQuality", earthQuality);
        Indicators.Add("seaQuality", seaQuality);
        Indicators.Add("biodiversity", biodiversity);
        Indicators.Add("research", reseach);
        Indicators.Add("energy", energy);
        Indicators.Add("sickness", sickness);
        Indicators.Add("money", money);
        Indicators.Add("happiness", happiness);

        Nom = sname;
    }

    public void AddTechnologie(string indicatorName, double modifier, double constant)
    {
        Debug.Log("Continent.AddTechnologie");
        Indicator bufferIndicator;
        if (Indicators.TryGetValue(indicatorName, out bufferIndicator))
        {
            if(indicatorName.Equals("money") || indicatorName.Equals("research"))
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
            bufferIndicator.Modifier -= modifier;
            bufferIndicator.Constant -= constant;
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
