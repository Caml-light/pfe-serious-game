using UnityEngine;
using System.Collections.Generic;

public class Continent : MonoBehaviour {

    public float posX;
    public float posY; // Coorodonées de la caméra zoomée, modifiable depuis l'interface de Unity (pour chaque continent)
    public float posZoom;

    public Dictionary<string, Indicator> indicators = new Dictionary<string, Indicator>();
    //public static Dictionary<string, Technologie> technologies = new Dictionary<string, Technologie>();

    public string _Name;

    private Animator surbrillance;

    public Continent(string name, Indicator pop, Indicator foodNeed,Indicator foodProd, Indicator airQuality, Indicator earthQuality, Indicator seaQuality, Indicator biodiversity)
    {
        indicators.Add("pop", pop);
        indicators.Add("foodNeed", foodNeed);
        indicators.Add("foodProd", foodProd);
        indicators.Add("airQuality", airQuality);
        indicators.Add("earthQuality", earthQuality);
        indicators.Add("seaQuality", seaQuality);
        indicators.Add("biodiversity", biodiversity);
        _Name = name;
    }

    public void AddTechnologie(string indicatorName, double modifier){

        Debug.Log("Continent.AddTechnologie");
        Indicator bufferIndicator;
        if (indicators.TryGetValue("foodProd", out bufferIndicator))
        {
            bufferIndicator.Modifier += modifier;
        }

        Debug.LogFormat("test : {0}, {1}", indicators[indicatorName].Modifier, modifier);

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
            GameManager.instance.isZoomFinished = false; // On indique que l'nnimation commence


            //INSTUCTIONS lors d'un clic sur le continent ici....

        }
        

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


    public void nextTurn()
    {

    }
}
