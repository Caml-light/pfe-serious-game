using UnityEngine;
using System.Collections;
using Assets.Scripts.Classes;
using System;

public class Indicator : Info
{
    /// <summary>
    ///     An indicator is defined by its name, its current value, a constant of variation which tends to the equilibrium
    ///     Name, Value, Modifier, Equilibrium
    /// </summary>

    private string _iconPath;

    private double _Constant;
    private double _Equilibrium;
    private double _Modifier;

    public Indicator(string Name, double Value, double Constant, double Equilibrium, double Modifier, string spath) : base (Name, Value)
    {

        //_Constant = Constant;
        _Constant  = 0.99; // Default value to try. This this the equivalent of 1% of modification / turn
        _Equilibrium = Equilibrium;
        _Modifier = Modifier;
        _iconPath = spath;

        Debug.LogFormat("Indicator (Name, Value, Constant, Equilibrium, Modifier) created :{0}, {1}, {2}, {3}, {4}, {5}", _Name, _Value, _Constant, _Equilibrium, _Modifier, _iconPath);
    }

    public string IconPath
    {
        get
        {
            return _iconPath;
        }

        set
        {
            _iconPath = value;
        }
    }

    public double Modifier
    {
        get
        {
            return _Modifier;
        }

        set
        {
            _Modifier = value;
        }
    }

    public double Equilibrium
    {
        get
        {
            return _Equilibrium;
        }

        //The equilibrium should not change. I don't see why it should.
        //set
        //{
        //    _Equilibrium = value;
        //}
    }

    public double Constant
    {
        get
        {
            return _Constant;
        }

        set
        {
            _Constant = value;
        }
    }

    public void UpdateValue()
    {
        Value = Math.Truncate(Value * Constant * Modifier);

        Debug.LogFormat("{0} value is now {1}", _Name, _Value);
    }





    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
