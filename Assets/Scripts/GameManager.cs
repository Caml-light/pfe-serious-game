﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    //public Continent europe, afrique, ameriqueNord, ameriqueSud, oceanie, asie;

    public static GameManager instance = null;

    Camera cam = Camera.main;
    public bool isZoomed = false; // Sommes-nous en vue globale ou en vue zoomée sur un continent ?
    public bool isZoomFinished = true; // l'annimation est-elle terminée ?

    public float LockedZoom = 8596.979f;
    public float LockedX = 0f;            /* Les coordonées de la caméra en vue globale */
    public float LockedY = 0f;

    private float delta = 0; // Permet de faire une transition
    public float smooth = 2; // Permet de géré la rapidité du zoom, modifiable via l'interface de Unity

    private Continent continentSelected; // Le continent séléctionné par le joueur. Null quand on est en vue globale

    public Dictionary<string, Technologie> allTechnologies = new Dictionary<string, Technologie>();


    public GameObject panelContinent;
    public GameObject panelEvents;
    private GameObject barreIcones;

    private GameObject europe;
    private GameObject asie;
    private GameObject amerique_nord;
    private GameObject amerique_sud;
    private GameObject afrique;
    private GameObject oceanie;
    private GameObject next_turn_button;

    private Text foodText;
    private Text energyText;
    private Text researchText;
    private Text popText;
    private Text sickText;
    private Text earthText;
    private Text moneyText;

    private GameObject foodIcon;
    private GameObject energyIcon;
    private GameObject researchIcon;
    private GameObject popIcon;
    private GameObject sickIcon;
    private GameObject earthIcon;
    private GameObject moneyIcon;


    public Continent ContinentSelected // Propriétés du continent séléctionné
    {
        get
        {
            return continentSelected;
        }

        set
        {
            continentSelected = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {

        Debug.Log("GM start");


        amerique_nord = GameObject.Find("Amérique du Nord");
        amerique_sud = GameObject.Find("Amérique du Sud");
        asie = GameObject.Find("Asie");
        europe = GameObject.Find("Europe");
        oceanie = GameObject.Find("Océanie");
        afrique = GameObject.Find("Afrique");
        next_turn_button = GameObject.Find("NextTurn_Button");

        foodText = GameObject.Find("globalTextFood").GetComponent<Text>();
        moneyText = GameObject.Find("globalTextMoney").GetComponent<Text>();
        energyText = GameObject.Find("globalTextEnergy").GetComponent<Text>();
        popText = GameObject.Find("globalTextPop").GetComponent<Text>();
        sickText = GameObject.Find("globalTextSickness").GetComponent<Text>();
        earthText = GameObject.Find("globalTextEarth").GetComponent<Text>();
        researchText = GameObject.Find("globalTextResearch").GetComponent<Text>();

        foodIcon = GameObject.Find("globalFood");
        energyIcon = GameObject.Find("globalEnergy");
        researchIcon = GameObject.Find("globalResearch");
        popIcon = GameObject.Find("globalPop");
        sickIcon = GameObject.Find("globalSickness");
        earthIcon = GameObject.Find("globalEarth");
        moneyIcon = GameObject.Find("globalMoney");

        barreIcones = GameObject.Find("BarreHaut");
        panelContinent = GameObject.Find("PanelContinent");
        panelContinent.SetActive(false);
        panelEvents = GameObject.Find("PanelEvents");
        panelEvents.SetActive(false);

    }

    public void nextTurn()
    {
        Debug.Log("nextTurn GM");
        Global.instance.nextTurn();
        panelEvents.SetActive(true);

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Continent"))
        {
            obj.SetActive(false);
        }

        GameObject.Find("ActualisationEventsButton").GetComponent<Button>().onClick.Invoke();
    }

    public void closeEventPanel()
    {
        panelEvents.SetActive(false);
        amerique_nord.SetActive(true);
        amerique_sud.SetActive(true);
        asie.SetActive(true);
        europe.SetActive(true);
        oceanie.SetActive(true);
        afrique.SetActive(true);
        next_turn_button.SetActive(true);
    }

    public void AddTechnologie(string techName)
    {
        Debug.Log("AddTechnologie(" + techName +") sur l'" + ContinentSelected.name + " [GameManager]");

        string indicator = Global.instance.unlockedTechnologies[techName].Indicator;
        double modifier = Global.instance.unlockedTechnologies[techName].Modifier;
        double constant = Global.instance.unlockedTechnologies[techName].Constant;
        string continentName = ContinentSelected.name;

        Global.instance.continents[continentName].Technologies[techName]++;
        Global.instance.continents[continentName].AddTechnologie(indicator, modifier,constant);
    }


    public void SupprTechnologie(string techName)
    {
        Debug.Log("SupprTechnologie(" + techName + ") sur l'" + ContinentSelected.name + " [GameManager]");

        string indicator = Global.instance.unlockedTechnologies[techName].Indicator;
        double modifier = Global.instance.unlockedTechnologies[techName].Modifier;
        double constant = Global.instance.unlockedTechnologies[techName].Constant;
        string continentName = ContinentSelected.name;

        Global.instance.continents[continentName].Technologies[techName]--;
        Global.instance.continents[continentName].SupprTechnologie(indicator, modifier, constant);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape) && isZoomFinished && isZoomed) // Si l'on appuie sur la touche "Echap", que nous ne sommes pas en pleine annimation et en vue zoomée
        {
            isZoomed = !isZoomed; // On annonce qu'on passe en vue globale
            isZoomFinished = false; // Que l'annimation commence
            ContinentSelected = null; // On désélectionne le continent
        }

        if (isZoomed && !isZoomFinished) // Si on est en en vue zoomée mais que l'annimation n'est pas fini (donc qu'on est en transition vers une vue zoomée)
        {
            ZoomInContinent(); // Permet de s'approcher de la position zoomée (appelé environ 33 fois pour une transition)

            //RIN A FAIRE ICI... CETTE FONCTION EST APPELÉE 33 FOIS LORS D'UN ZOOM !!!!!
            // GROS PORC DE THOMAS LEFRANC

            foodIcon.SetActive(false);
            popIcon.SetActive(false);
            earthIcon.SetActive(false);
            sickIcon.SetActive(false);
            energyIcon.SetActive(false);
            foodText.gameObject.SetActive(false);
            earthText.gameObject.SetActive(false);
            popText.gameObject.SetActive(false);
            sickText.gameObject.SetActive(false);
            energyText.gameObject.SetActive(false);

        }
        else if (!isZoomed && !isZoomFinished) // Sinon, si on est en transition vers la vue globale
        {
            ZoomOutContinent(); // Permet de s'approcher de la position dézoomée (appelé environ 33 fois pour une transition)
            panelContinent.SetActive(false);
            foodIcon.SetActive(true);
            popIcon.SetActive(true);
            earthIcon.SetActive(true);
            sickIcon.SetActive(true);
            energyIcon.SetActive(true);
            foodText.gameObject.SetActive(true);
            earthText.gameObject.SetActive(true);
            popText.gameObject.SetActive(true);
            sickText.gameObject.SetActive(true);
            energyText.gameObject.SetActive(true);
        }
    }



    void ZoomInContinent() // A chaqeu appel, va modifier la position de la caméra pour s'approcher de la position zoomée
    {
        delta += smooth * Time.deltaTime; //Défini la distance parcouru

        //Zoom de la caméra
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, continentSelected.posZoom, delta); // On zoom un peu plus en augmentant l'orthographicSize 

        //Position de la caméra
        float targetX;
        float targetY;
        targetX = Mathf.Lerp(cam.transform.position.x, continentSelected.posX, delta); // On défini la position X de la caméra à un temps donné
        targetY = Mathf.Lerp(cam.transform.position.y, continentSelected.posY, delta); // de même pour Y
        cam.transform.position = new Vector3(targetX, targetY, cam.transform.position.z); // On créé un vecteur de translation avec les cordonées X et Y (on ne touche pas au z, car on est en 2D)


        if (cam.orthographicSize == continentSelected.posZoom && cam.transform.position.x == continentSelected.posX && cam.transform.position.y == continentSelected.posY) // Si la caméra est a la position définie par le continent
        {
            isZoomFinished = true; // On annonce que le zoom est fini
            delta = 0; // On remet l'indicateur de distance parcouru à 0 (pour d'autres transitions)
        }

    }



    void ZoomOutContinent() // A chaqeu appel, va modifier la position de la caméra pour s'approcher de la position désoomée
    {
        delta += smooth * Time.deltaTime;

        //Zoom de la caméra
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, LockedZoom, delta);

        //Position de la caméra
        float targetX;
        float targetY;
        targetX = Mathf.Lerp(cam.transform.position.x, LockedX, delta); /*Idem que ZoomInContinent, sauf qu'ici on se raproche des coordonées de la vue globale */
        targetY = Mathf.Lerp(cam.transform.position.y, LockedY, delta);
        cam.transform.position = new Vector3(targetX, targetY, cam.transform.position.z);


        if (cam.orthographicSize == LockedZoom && cam.transform.position.x == LockedX && cam.transform.position.y == LockedY)
        {
            isZoomFinished = true;
            delta = 0;
        }

    }
}