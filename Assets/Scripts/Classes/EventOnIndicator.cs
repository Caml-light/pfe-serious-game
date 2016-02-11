using UnityEngine;
using System.Collections;
using System;
public class EventOnIndicator : CustomEvent
{
    private string _indicatorName;
    private int _proba;
    private int _threshold;
    private bool _eventOnThresholdSup;

    public EventOnIndicator(string name, string textEvent, string imagepath, string indicator, int proba, int threshold, bool isSupp) : base(name, textEvent, imagepath)
    {
        _indicatorName = indicator;
        _proba = proba;
        _threshold = threshold;
        _eventOnThresholdSup = isSupp;

        Debug.LogFormat("EventOnIndicator {0} created for {1}", name, indicator);
    }

    public override void nextTurn()
    {
        Debug.Log("__________________________________________________________\n\n\n");

        bool EventCouldOccur = false;
        string texteventtemp = TextEvent;
        foreach (Continent continent in Global.instance.continents.Values)
        {
            Indicator buffer;

            if(continent.Indicators.TryGetValue(this.IndicatorName, out buffer))
            {
                if (EventOnThresholdSup)
                {
                    EventCouldOccur = Threshold >= buffer.Value;
                }
                else
                {
                    EventCouldOccur = Threshold <= buffer.Value;
                }

                if (EventCouldOccur)
                {
                    int rnd = getRandom.Next(0, 100);
                    if(Proba >= rnd)
                    {
                        TextEvent += continent.Nom;
                        Global.instance.eventsOccurringList.Add((EventOnIndicator)MemberwiseClone());
                        TextEvent = texteventtemp;
                        Debug.LogFormat( "Event {0} : {1} Continent : {2}", Name, TextEvent, continent.Nom);
                    }
                    else
                    {
                        Debug.LogFormat("Event {0} didn't happened : {1} :", Name, rnd);
                    }
                }


            }
            
        }
    }

    public string IndicatorName
    {
        get
        {
            return _indicatorName;
        }

        set
        {
            _indicatorName = value;
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
