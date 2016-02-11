using UnityEngine;
using System.Collections;

public abstract class CustomEvent : MonoBehaviour {
    private string _name;
    private string _textEvent;
    private string _imagePath;
    protected static readonly System.Random getRandom = new System.Random(); 


    public CustomEvent(string name, string textEvent, string imagepath)
    {
        Name = name;
        TextEvent = textEvent;
        ImagePath = imagepath;
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string TextEvent
    {
        get
        {
            return _textEvent;
        }

        set
        {
            _textEvent = value;
        }
    }

    public string ImagePath
    {
        get
        {
            return _imagePath;
        }

        set
        {
            _imagePath = value;
        }
    }

    public abstract void nextTurn();
}
