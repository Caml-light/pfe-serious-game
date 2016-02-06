using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechnologiesManager : MonoBehaviour
{


    public void AddTechno()
    {
        Debug.Log("Ajout de la technologie " + GameObject.Find(transform.parent.name).name);
        Text valeur = GameObject.Find(transform.parent.name).transform.Find("TechQuantity").GetComponent<Text>();
         int i = int.Parse(valeur.text);
         i++;
         valeur.text = i.ToString();
        
        GameManager.instance.AddTechnologie(GameObject.Find(transform.parent.name).name);
    }

    public void RemoveTechno()
    {
        Debug.Log("Suppression de la technologie " + GameObject.Find(transform.parent.name).name);
        Text valeur = GameObject.Find(transform.parent.name).transform.Find("TechQuantity").GetComponent<Text>();
        int i = int.Parse(valeur.text);
        if(i>0)
        {
            i--;
        }
        
        valeur.text = i.ToString();
        GameManager.instance.SupprTechnologie(GameObject.Find(transform.parent.name).name);
    }
}
