using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Continent : MonoBehaviour
{

    public float posX;
    public float posY; // Coorodonées de la caméra zoomée, modifiable depuis l'interface de Unity (pour chaque continent)
    public float posZoom;

    private Dictionary<string, Indicator> _indicators = new Dictionary<string, Indicator>();
    private Dictionary<string, int> _technologies = new Dictionary<string, int>();
    private string _nom;

    private Animator surbrillance;

    public Continent(string sname, Indicator pop, Indicator foodNeed, Indicator foodProd, Indicator airQuality, Indicator earthQuality, Indicator seaQuality, Indicator biodiversity)
    {

        Debug.Log("contruction du continent : " + sname);

        Indicators.Add("pop", pop);
        Indicators.Add("foodNeed", foodNeed);
        Indicators.Add("foodProd", foodProd);
        Indicators.Add("airQuality", airQuality);
        Indicators.Add("earthQuality", earthQuality);
        Indicators.Add("seaQuality", seaQuality);
        Indicators.Add("biodiversity", biodiversity);

        Nom = sname;
    }

    public void AddTechnologie(string indicatorName, double modifier)
    {

        Debug.Log("Continent.AddTechnologie");
        Indicator bufferIndicator;
        if (Indicators.TryGetValue("foodProd", out bufferIndicator))
        {
            bufferIndicator.Modifier += modifier;
        }

        Debug.LogFormat("test : {0}, {1}", Indicators[indicatorName].Modifier, modifier);

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



            // ZONE à CORRIGER //

            //INSTUCTIONS lors d'un clic sur le continent ici....
            GameObject.Find("PanelContinent").transform.Find("TechButton").GetComponent<Button>().onClick.Invoke(); // Simulation du click sur le bouton Technologie du panel (afin d'afficher les technologies asociées au continent)
                                                                                                                    // Ne fonctionne pas... je ne sais pas pourquoi. 
                                                                                                                    //Null reference exception.....
                                                                                                                    //utiliser la methode onClick.Invoke()

            // ZONE à CORRIGER //



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
