using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.ObjectModel;

public class GameManager : MonoBehaviour {

    //public Continent europe, afrique, ameriqueNord, ameriqueSud, oceanie, asie;

    public static GameManager instance = null;

    Camera cam = Camera.main;
    public bool isZoomed = false;
    public bool isZoomFinished = true; // l'annimation est-elle terminée ?

    public float LockedZoom = 8596.979f;
    public float LockedX = 0f;
    public float LockedY = 0f;

    private float delta = 0;
    public float smooth = 2;

    private Continent continentSelected;


    private Text foodUS;
    private Text foodEU;
    private Text foodGlobal;

    public Continent ContinentSelected
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
        foodUS = GameObject.Find("FoodUS").GetComponent<Text>();
        foodUS.enabled = false;
        foodEU = GameObject.Find("FoodEurope").GetComponent<Text>();
        foodEU.enabled = false;
        foodGlobal = GameObject.Find("FoodGlobal").GetComponent<Text>();

    }

     public void nextTurn()
    {
        Global.instance.nextTurn();

        foodUS.text = "US : " + Global.instance.continents["Amérique du Nord"].foodProd.Value;
        foodEU.text = "Europe : " + Global.instance.continents["Europe"].foodProd.Value;
        foodGlobal.text = "Global : " + Global.instance.foodProd;

      
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape) && isZoomFinished && isZoomed)
        {
            isZoomed = !isZoomed;
            isZoomFinished = false;
            HideContinentIndicators();
            continentSelected = null;
        }

        if (isZoomed && !isZoomFinished)
        {
            ZoomInContinent();

        }
        else if (!isZoomed && !isZoomFinished)
        {
            ZoomOutContinent();
        }
    }

       

    void ZoomInContinent() // description de la fonction demandé.
    {
        //est - ce qu'il est possible de ne faire qu'un seul appelle à cette fonction, parce que la, c'est quand mme 31 appelles, c'est beaucoup.
        Debug.Log("ZoomInContinent()");
        delta += smooth * Time.deltaTime;
        DisplayContinentIndicators();


        //Cam size
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, continentSelected.posZoom, delta);

        //Cam pos

        float targetX;
        float targetY;
        targetX = Mathf.Lerp(cam.transform.position.x, continentSelected.posX, delta);
        targetY = Mathf.Lerp(cam.transform.position.y, continentSelected.posY, delta);
        cam.transform.position = new Vector3(targetX, targetY, cam.transform.position.z);


        if (cam.orthographicSize == continentSelected.posZoom && cam.transform.position.x == continentSelected.posX && cam.transform.position.y == continentSelected.posY)
        {
            isZoomFinished = true;
            delta = 0;
        }

    }



    void ZoomOutContinent()
    {// est-ce qu'il est possible de ne faire qu'un seul appelle à cette fonction, parce que la, c'est quand mme 31 appelles, c'est beaucoup.
        Debug.Log("ZoomOutContinent()");
        delta += smooth * Time.deltaTime;

        //Cam size
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, LockedZoom, delta);

        //Cam pos

        float targetX;
        float targetY;
        targetX = Mathf.Lerp(cam.transform.position.x, LockedX, delta);
        targetY = Mathf.Lerp(cam.transform.position.y, LockedY, delta);
        cam.transform.position = new Vector3(targetX, targetY, cam.transform.position.z);


        if (cam.orthographicSize == LockedZoom && cam.transform.position.x == LockedX && cam.transform.position.y == LockedY)
        {
            isZoomFinished = true;
            delta = 0;
        }

    }

    void DisplayContinentIndicators() // call when clicking on a continent, display indicators for the continent clicked
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

    void HideContinentIndicators() // call when exiting a continent, hide indicators of the current zoomed continent.
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
