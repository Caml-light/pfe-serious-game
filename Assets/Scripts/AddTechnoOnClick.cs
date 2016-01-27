using UnityEngine;
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
        GameManager.instance.AddTechnologie("fire");
    }
}
