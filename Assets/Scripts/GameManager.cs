using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.ObjectModel;

public class GameManager : MonoBehaviour {

    //public Continent europe, afrique, ameriqueNord, ameriqueSud, oceanie, asie;

    public static GameManager instance = null; 
     
  
    private Text foodUS;
    private Text foodEU;
    private Text foodGlobal;
    



    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

        void Start () {
        foodUS = GameObject.Find("FoodUS").GetComponent<Text>();
        foodEU = GameObject.Find("FoodEurope").GetComponent<Text>();
        foodGlobal = GameObject.Find("FoodGlobal").GetComponent<Text>();

        foodUS.text = "US : " + Global.instance.continents["Amérique du Nord"].foodProd.Value;
        foodEU.text = "Europe: " + Global.instance.continents["Europe"].foodProd.Value;
        foodGlobal.text = "Global : " + Global.instance.foodProd;

    }

     public void nextTurn()
    {
        Global.instance.nextTurn();

        foodUS.text = "US : " + Global.instance.continents["Amérique du Nord"].foodProd.Value;
        foodEU.text = "Europe : " + Global.instance.continents["Europe"].foodProd.Value;
        foodGlobal.text = "Global : " + Global.instance.foodProd;

      
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxisRaw("Horizontal") != 0)
            {
            Debug.Log("CLAVIER DETECTE");
            Debug.Log(Global.instance.foodNeed);

            foreach(Continent c in Global.instance.continents.Values)
            {
                Debug.Log(c.Name + " : " + c.foodProd.Name + " = " + c.foodProd.Value);
            }
        }
    }
}
