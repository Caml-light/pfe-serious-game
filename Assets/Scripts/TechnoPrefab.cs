using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TechnoPrefab : MonoBehaviour
{

    public GameObject technoprefabricated;
    GameObject newTechno;

    Text techstring;
    Image techicon;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void planelInitialization()
    {

        var children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.name != "Technologie")
            {
                children.Add(child.gameObject);
            }
        }
        children.ForEach(child => Destroy(child));

        technoprefabricated.SetActive(true);
        technoprefabricated.name = "Technologie";
        techstring = technoprefabricated.transform.Find("TechName").GetComponent<Text>(); // initialiser le premier 
        techstring.text = "Technologie de base";


        Continent continentSelected = Global.instance.continents[GameManager.instance.ContinentSelected.transform.name];
        Debug.Log("planelInitialization() : Continent séléctionné : " + continentSelected.Nom);


        foreach (KeyValuePair<string, int> entry in continentSelected.Technologies)
        {
            // utiliser entry.Value et entry.Key

            
                newTechno = (GameObject)Instantiate(technoprefabricated, technoprefabricated.transform.position, Quaternion.identity);
                newTechno.name = entry.Key;
                techicon = newTechno.transform.Find("TechIcon").GetComponent<Image>();

                techicon.sprite = Resources.Load<Sprite>(Global.instance.unlockedTechnologies[entry.Key].IconPath);

                techstring = newTechno.transform.Find("TechName").GetComponent<Text>();
                techstring.text = entry.Key;

                techstring = newTechno.transform.Find("TechQuantity").GetComponent<Text>();
                techstring.text = entry.Value.ToString();

                newTechno.transform.SetParent(this.transform);
                newTechno.transform.localScale = technoprefabricated.transform.localScale;
            

        }
        technoprefabricated.SetActive(false);
    }
}
