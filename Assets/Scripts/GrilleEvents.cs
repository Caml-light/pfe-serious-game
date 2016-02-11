using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GrilleEvents : MonoBehaviour
{

    public static GrilleEvents instance = null;
    public GameObject eventprefabricated;
    GameObject newEvent;

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
            if (child.name != "Evènement")
            {
                children.Add(child.gameObject);
            }
        }
        children.ForEach(child => Destroy(child));
    }

    public void panelEventInitialization()
    {

        Text eventstring;
        Image eventicon;
        int cpt = 0;

        clearGrille();


        if (Global.instance.eventsOccurringList.Count > 0)
        {
            eventprefabricated.SetActive(true);
            foreach (CustomEvent eventoccurring in Global.instance.eventsOccurringList)
            {
                cpt++;
                newEvent = (GameObject)Instantiate(eventprefabricated, eventprefabricated.transform.position, Quaternion.identity);
                newEvent.name = eventoccurring.Name + cpt;

                eventicon = newEvent.transform.Find("EventIcon").GetComponent<Image>();
                eventicon.sprite = Resources.Load<Sprite>(eventoccurring.ImagePath);

                eventstring = newEvent.transform.Find("EventName").GetComponent<Text>();
                eventstring.text = eventoccurring.Name;

                eventstring = newEvent.transform.Find("EventText").GetComponent<Text>();
                eventstring.text = eventoccurring.TextEvent;

                newEvent.transform.SetParent(transform); // équivaut à newEvent.transform.SetParent(this.transform); 
                newEvent.transform.localScale = eventprefabricated.transform.localScale;
            }
            eventprefabricated.SetActive(false);
        }
        else
        {
            closePanel();
        }
    }

    public void closePanel()
    {
        GameManager.instance.closeEventPanel();
    }
}
