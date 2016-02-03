using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Grille : MonoBehaviour
{

    public GameObject technoprefabricated;
    public GameObject indicatorprefabricated;
    GameObject newTechno;
    GameObject newIndic;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clearGrille()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.name != "Technologie" && child.name != "Indicateur")
            {
                children.Add(child.gameObject);
            }
        }
        children.ForEach(child => Destroy(child));
    }

    public void panelIndicInitialization()
    {

        Text indicstring;
        Image indicicon;

        clearGrille();

        indicatorprefabricated.SetActive(true);

        Continent continentSelected = Global.instance.continents[GameManager.instance.ContinentSelected.transform.name];

        foreach (KeyValuePair<string, Indicator> entry in continentSelected.Indicators)
        {
            // utiliser entry.Value et entry.Key

            newIndic = (GameObject)Instantiate(indicatorprefabricated, indicatorprefabricated.transform.position, Quaternion.identity);
            newIndic.name = entry.Key;

            indicicon = newIndic.transform.Find("IndicIcon").GetComponent<Image>();
            indicicon.sprite = Resources.Load<Sprite>(continentSelected.Indicators[entry.Key].IconPath);

            indicstring = newIndic.transform.Find("IndicName").GetComponent<Text>();
            indicstring.text = entry.Value.Name;

            indicstring = newIndic.transform.Find("IndicQuantity").GetComponent<Text>();
            indicstring.text = entry.Value.Value.ToString();

            newIndic.transform.SetParent(transform); // équivaut à newIndic.transform.SetParent(this.transform); 
            newIndic.transform.localScale = indicatorprefabricated.transform.localScale;
        }
        indicatorprefabricated.SetActive(false);
    }

    public void planelTechInitialization()
    {

        Text techstring;
        Image techicon;

        clearGrille();

        technoprefabricated.SetActive(true);

        Continent continentSelected = Global.instance.continents[GameManager.instance.ContinentSelected.transform.name];

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

            newTechno.transform.SetParent(transform); // équivaut newTechno.transform.SetParent(this.transform);
            newTechno.transform.localScale = technoprefabricated.transform.localScale;

        }
        technoprefabricated.SetActive(false);
    }
}
