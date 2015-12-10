using UnityEngine;
using System.Collections;
public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject global;

    void Awake()
    {
        Debug.Log("Loader start");
        if (GameManager.instance == null)
            Instantiate(gameManager);

        if (Global.instance == null)
            Instantiate(global);
        Debug.Log("Loader finished");
    }
}