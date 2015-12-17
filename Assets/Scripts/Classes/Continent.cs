using UnityEngine;
using System.Collections.Generic;

public class Continent : MonoBehaviour {

    public float posX;
    public float posY; // Coorodonées de la caméra zoomée, modifiable depuis l'interface de Unity (pour chaque continent)
    public float posZoom;

    public Dictionary<string, Indicator> indicators = new Dictionary<string, Indicator>();

    public string _Name;

    public Continent(string Name, Indicator pop, Indicator foodNeed,Indicator foodProd, Indicator airQuality, Indicator earthQuality, Indicator seaQuality, Indicator biodiversity)
    {
        indicators.Add("pop", pop);
        indicators.Add("foodNeed", foodNeed);
        indicators.Add("foodProd", foodProd);
        indicators.Add("airQuality", airQuality);
        indicators.Add("earthQuality", earthQuality);
        indicators.Add("seaQuality", seaQuality);
        indicators.Add("biodiversity", biodiversity);
        _Name = Name;
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

            GameManager.instance.EnableContinentIndicators(); // On affiche les indicateurs

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
