using UnityEngine;
using System;

public class EventOnTech : CustomEvent
{

    private string _techName;
    private int _proba;
    private int _threshold;
    private bool _eventOnThresholdSup;

    public EventOnTech(string name, string textEvent, string imagepath, string techno, int proba, int threshold, bool isSupp, string influenced, float percent) : base(name, textEvent, imagepath, influenced, percent)
    {
        _techName = techno;
        _proba = proba;
        _threshold = threshold;
        _eventOnThresholdSup = isSupp;

        Debug.LogFormat("EventOnTech {0} created for {1}", name, techno);
    }

    public override void nextTurn()
    {
        Debug.Log("__________________________________________________________\n\n\n");

        bool EventCouldOccur = false;
        string texteventtemp = TextEvent;
        foreach (Continent continent in Global.instance.continents.Values)
        {

            int buffer;

            if (continent.Technologies.TryGetValue(TechName, out buffer))
            {
                if (EventOnThresholdSup)
                {
                    EventCouldOccur = Threshold >= buffer;
                }
                else
                {
                    EventCouldOccur = Threshold <= buffer;
                }

                if (EventCouldOccur)
                {
                    int rnd = getRandom.Next(0, 100);
                    if (Proba >= rnd)
                    {
                        continent.Indicators[Influenced_indic].Value = Math.Truncate(continent.Indicators[Influenced_indic].Value * Percentage);

                        TextEvent += continent.Nom;
                        Global.instance.eventsOccurringList.Add((EventOnTech)MemberwiseClone());
                        TextEvent = texteventtemp;
                        Debug.LogFormat("Event {0} : {1} Continent : {2}", Name, TextEvent, continent.Nom);
                    }
                    else
                    {
                        Debug.LogFormat("Event {0} didn't happened : {1} :", Name, rnd);
                    }
                }
            }
        }
    }

    public string TechName
    {
        get
        {
            return _techName;
        }

        set
        {
            _techName = value;
        }
    }

    public int Proba
    {
        get
        {
            return _proba;
        }

        set
        {
            _proba = value;
        }
    }

    public int Threshold
    {
        get
        {
            return _threshold;
        }

        set
        {
            _threshold = value;
        }
    }

    public bool EventOnThresholdSup
    {
        get
        {
            return _eventOnThresholdSup;
        }

        set
        {
            _eventOnThresholdSup = value;
        }
    }
}
