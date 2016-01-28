using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechnoPrefab : MonoBehaviour {

    public GameObject technoprefabricated;
    GameObject newTechno;

    Text techname;

	// Use this for initialization
	void Start () {

        for (int i = 2; i < 18; i ++ ) {
            newTechno = (GameObject)Instantiate(technoprefabricated, technoprefabricated.transform.position, Quaternion.identity);
            newTechno.name = "Technologie " + i;
            techname = newTechno.transform.Find("TechName").GetComponent<Text>();
            techname.text = "Technologie " + i;
            newTechno.transform.parent = this.transform;
            newTechno.transform.localScale = technoprefabricated.transform.localScale;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
