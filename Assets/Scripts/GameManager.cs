using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.ObjectModel;

public class GameManager : MonoBehaviour {

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


    private Text foodUS;
    private Text foodEU;
    private Text foodGlobal;

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

        void Start () {

        Debug.Log("GM start");
        foodUS = GameObject.Find("FoodUS").GetComponent<Text>();
        foodUS.enabled = false;
        foodEU = GameObject.Find("FoodEurope").GetComponent<Text>();
        foodEU.enabled = false;
        foodGlobal = GameObject.Find("FoodGlobal").GetComponent<Text>();
        UpdateDisplay();

    }

     public void nextTurn()
    {
        Debug.Log("nextTurn GM");
        Global.instance.nextTurn();
        UpdateDisplay();

      
    }


    public void UpdateDisplay()
    {
        Debug.Log("UpdateDisplay GM");        
        foodEU.text = "Europe : "  + Global.instance.continents["Europe"].indicators["foodProd"].Value.ToString();
        foodUS.text = "NA : " + Global.instance.continents["Amérique du Nord"].indicators["foodProd"].Value.ToString();
        foodGlobal.text = "Global : " + Global.instance.globalIndicators["foodProd"].Value.ToString();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.Escape) && isZoomFinished && isZoomed) // Si l'o appuie sur la touche "Echap", que nous ne sommes pas en pleine annimation et en vue zoomée
        {
            isZoomed = !isZoomed; // On annonce qu'on passe en vue globale
            isZoomFinished = false; // Que l'annimation commence
            DesabledContinentIndicators(); // On cache les indicateurs du contient séléctionné
            continentSelected = null; // On désélectionne le continent
        }

        if (isZoomed && !isZoomFinished) // Si on est en en vue zoomée mais que l'annimation n'est pas fini (donc qu'on est en transition vers une vue zoomée)
        {
            ZoomInContinent(); // Permet de s'approcher de la position zoomée (appelé environ 33 fois pour une transition)

        }
        else if (!isZoomed && !isZoomFinished) // Sinon, si on est en transition vers la vue globale
        {
            ZoomOutContinent(); // Permet de s'approcher de la position dézoomée (appelé environ 33 fois pour une transition)
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

    public void EnableContinentIndicators() // call when clicking on a continent, display indicators for the continent clicked
    {
        Debug.LogFormat("DisplayContinentIndicators : Display indicators for {0}", ContinentSelected.Name);

        switch (ContinentSelected.Name)
        {
            case "Europe":
                foodEU.enabled = true;
                break;

            case "Amérique du Nord":
                foodUS.enabled = true;
                break;

            default:
                foodGlobal.enabled = true;

                break;
        }
    }

    void DesabledContinentIndicators() // call when exiting a continent, hide indicators of the current zoomed continent.
    {

        Debug.LogFormat("HideContinentIndicators : Hide indicators for {0}", ContinentSelected.Name);
        switch (ContinentSelected.Name)
        {
            case "Europe":
                foodEU.enabled = false;

                break;

            case "Amérique du Nord":
                foodUS.enabled = false;
                break;

            default:

                break;
        }
    }
}
