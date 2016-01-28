using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddTechnoOnClick : MonoBehaviour {
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Add technologie OnMouseDown");
        Text valeur = GameObject.Find(transform.parent.name).transform.Find("TechQuantity").GetComponent<Text>();
        int i = int.Parse(valeur.text);
        i++;
        valeur.text = i.ToString();
        GameManager.instance.AddTechnologie("fire");
    }
}
