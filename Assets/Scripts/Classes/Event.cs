using UnityEngine;
using System.Collections;

public abstract class CustomEvent : MonoBehaviour {
    private string _name;
    private string _textEvent;
    protected static readonly System.Random getRandom = new System.Random(); 


    public CustomEvent(string name, string textEvent)
    {
        Name = name;
        TextEvent = textEvent;
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

    public abstract void nextTurn();
}
