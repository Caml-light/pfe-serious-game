using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;

public class Technologie : MonoBehaviour {
    private string _name;
    private int _cost; // money the technologie cost
    private int _value; // research point the technologie cost
    private string _iconPath;
    private string _indicator;
    private double _modifier;


    public Technologie(string name, int cost, int value, string iconPath, string indi, double modifier)
    {
        _name = name;
        _cost = cost;
        _value = value;
        _iconPath = iconPath;
        _indicator = indi;
        _modifier = modifier;

        Debug.Log("technologie created");
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

    public int Cost
    {
        get
        {
            return _cost;
        }

        set
        {
            _cost = value;
        }
    }

    public int Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }

    public string Indicator
    {
        get
        {
            return _indicator;
        }

        set
        {
            _indicator = value;
        }
    }

    public double Modifier
    {
        get
        {
            return _modifier;
        }

        set
        {
            _modifier = value;
        }
    }
}
