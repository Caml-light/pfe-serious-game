using UnityEngine;
using System.Collections;
public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject global;

    void Awake()
    {
        Debug.Log("Loader start");

            
        if (Global.instance == null)
        {
            Instantiate(global);
        }
            

        EuropeInitilization();
        AsiaInitilization();
        AfricaInitilization();
        NorthAmericaInitilization();
        SouthhAmericaInitilization();
        AustraliaInitilization();

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        Debug.Log("Loader finished");
    }


    private void EuropeInitilization()
    {
        Debug.Log("Initialization of Europe continent start");

        string name = "Europe";
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentEurope = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentEurope);
        Debug.Log("Initialization of Europe continent end");
    }

    private void AsiaInitilization()
    {

        string name = "Asie";
        Debug.Log("Initialization of Europe continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAsia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAsia);
        Debug.Log("Initialization of Asia continent end");
    }

    private void NorthAmericaInitilization()
    {

        string name = "Amérique du Nord";
        Debug.Log("Initialization of North America continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentNA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentNA);
        Debug.Log("Initialization of North America continent end");
    }

    private void SouthhAmericaInitilization()
    {

        string name = "Amérique du Sud";
        Debug.Log("Initialization of North America continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentSA = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentSA);
        Debug.Log("Initialization of South America continent end");
    }

    private void AfricaInitilization()
    {

        string name = "Afrique";
        Debug.Log("Initialization of Africa continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAfrica = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAfrica);
        Debug.Log("Initialization of Africa continent end");
    }

    private void AustraliaInitilization()
    {

        string name = "Australie";
        Debug.Log("Initialization of Australia continent start");
        Indicator pop = new Indicator("Population", 100.0, 0.99, 50.0, 1.0);
        Indicator foodNeed = new Indicator("Hunger", 100.0, 0.99, 50.0, 1.0);
        Indicator foodProd = new Indicator("Food", 100.0, 0.99, 50.0, 1.0);
        Indicator airQuality = new Indicator("Air", 100.0, 0.99, 50.0, 1.0);
        Indicator earthQuality = new Indicator("Earth", 100.0, 0.99, 50.0, 1.0);
        Indicator seaQuality = new Indicator("Sea", 100.0, 0.99, 50.0, 1.0);
        Indicator biodiversity = new Indicator("Biodiversity", 10000000, 0.99, 10000000, 1.0);

        Continent continentAustralia = new Continent(name, pop, foodNeed, foodProd, airQuality, earthQuality, seaQuality, biodiversity);

        Global.instance.continents.Add(name, continentAustralia);
        Debug.Log("Initialization of Australia continent end");
    }
}