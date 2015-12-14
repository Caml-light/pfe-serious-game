using UnityEngine;
using System.Collections;

public class Continent : MonoBehaviour {

    public float posX;
    public float posY; // Coorodonées de la caméra zoomée, modifiable depuis l'interface de Unity (pour chaque continent)
    public float posZoom;
        
    public Indicator pop;
    public Indicator foodNeed;
    public Indicator foodProd;
    public Indicator airQuality;
    public Indicator earthQuality;
    public Indicator seaQuality;
    public Indicator biodiversity;
    public string _Name;

   

    // Use this for initialization
    void Start () {
        Debug.Log(Name +" start");
        pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Global.instance.continents.Add(Name,this);
        Debug.Log( Name + " finished");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseEnter() // Lorsque l'on passe la souris sur le continent
    {
        if (GameManager.instance.isZoomed == false && GameManager.instance.isZoomFinished) // On vérifie que l'on est en vue globale (et non en vue zoomée), et que l'on n'est pas en pleine annimation de zoom
        {
            Vector3 temp = new Vector3(0, 0, -120); // On créé un vecteur de translation pour faire avancer l'image du continent au premier plan (devant celle du planisphère)
            transform.position += temp; // On l'applique à l'objet
            /* ça sera supprimé lors de l'ajout des vraies annimaions */
        }
    }

    void OnMouseExit() // Lorsque la souris sort de la zone cliqueble du continent
    {
        if (GameManager.instance.isZoomed == false && GameManager.instance.isZoomFinished) // On vérifie que l'on est en vue zoomé, et que l'on n'est pas en pleine annimation de zoom
        {
            Vector3 temp = new Vector3(0, 0, 120); // On créé un veteur de translation pour le faire passer derière le planisphère
            transform.position += temp;
            /* ça sera supprimé lors de l'ajout des vraies annimaions */
        }
    }

    void OnMouseDown() // Lorsque l'on clique sur un continent
    {
        Debug.LogFormat("OnMouseDown on {0}", Name); // Affichage de débug à virer
        foodProd.UpdateValue(); // On incrémente la variable de nourriture // Rien à faire ici
        GameManager.instance.nextTurn(); // On passe au tour suivant // RIEN à faire ici


        if (GameManager.instance.isZoomFinished && !GameManager.instance.isZoomed) // Si on n'est pas en pleine annimation et que on est en vue globale
        {
            GameManager.instance.ContinentSelected = this; // On attribu au GameManager le continent sélectionné 
            GameManager.instance.isZoomed = !GameManager.instance.isZoomed; // On annonce que on passe en vue zoomée
            GameManager.instance.isZoomFinished = false; // On indique que l'nnimation commence

            if (transform.position.z < 2) // correction d'un bug
            { 
                Vector3 temp = new Vector3(0, 0, 120); // ça sera supprimé lors de l'ajout des vraies annimaions
                transform.position += temp;
            }

            GameManager.instance.DisplayContinentIndicators(); // On affiche les indicateurs

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
}
