using UnityEngine;
using System.Collections;

public abstract class CustomEvent {
    private string _name;
    private string _textEvent;
    private string _imagePath;
    private string _influenced_indic;
    private float _percentage;
    protected static readonly System.Random getRandom = new System.Random(); 


    public CustomEvent(string name, string textEvent, string imagepath, string indic, float percent)
    {
        Name = name;
        TextEvent = textEvent;
        ImagePath = imagepath;
        Influenced_indic = indic;
        Percentage = percent;
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

    public string Influenced_indic
    {
        get
        {
            return _influenced_indic;
        }

        set
        {
            _influenced_indic = value;
        }
    }

    public float Percentage
    {
        get
        {
            return _percentage;
        }

        set
        {
            _percentage = value;
        }
    }

    public abstract void nextTurn();
}
