using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arbre_tech : MonoBehaviour
{

    private bool isDisplayed = false;
    private GameObject arbre_tech;

    // Use this for initialization
    void Start()
    {
        arbre_tech = GameObject.Find("arbre_tech");
        arbre_tech.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void display()
    {
        if (isDisplayed)
        {
            isDisplayed = false;
            arbre_tech.SetActive(false);
        }
        else
        {
            isDisplayed = true;
            arbre_tech.SetActive(true);
        }
    }

    public void addChasse()
    {
        if (Global.instance.globalIndicators["money"].Value >= 22 && Global.instance.globalIndicators["research"].Value >= 8)
        {
            Global.instance.globalIndicators["money"].Value -= 22;
            Global.instance.globalIndicators["research"].Value -= 8;
            Text moneyText = GameObject.Find("globalTextMoney").GetComponent<Text>();
            moneyText.text = Global.instance.globalIndicators["money"].Value.ToString();
            Text researchText = GameObject.Find("globalTextResearch").GetComponent<Text>();
            researchText.text = Global.instance.globalIndicators["research"].Value.ToString();

            foreach (Continent c in Global.instance.continents.Values)
            {
                c.Technologies.Add("Chasse", 0);
            }

            Global.instance.unlockedTechnologies.Add("Chasse", new Technologie("Chasse", 1, 1, "Sprites/chasse", "foodProd", 0, 10000));
        }
    }

}
