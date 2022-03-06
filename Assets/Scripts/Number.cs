using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour, Init<Number>
{
    private int number;
    public Text text;

    void Start()
    {

    }

    public Number Init()
    {
        this.text = GetComponent<Text>();
        this.SetNumber(0);
        
        return this;
    }

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int number)
    {
        this.number = number;
        this.text.text = number.ToString();
    }

    public static Number operator ++(Number a)
    {
        a.SetNumber(a.number + 1);
        return a;
    }

    public static bool operator ==(Number a, Number b)
    {
        return a.number == b.number;
    }

    public static bool operator !=(Number a, Number b)
    {
        return a.number != b.number;
    }

    public static bool operator <(Number a, Number b)
    {
        return a.number < b.number;
    }

    public static bool operator >(Number a, Number b)
    {
        return a.number > b.number;
    }

    public static bool operator <=(Number a, Number b)
    {
        return a.number <= b.number;
    }

    public static bool operator >=(Number a, Number b)
    {
        return a.number >= b.number;
    }

    public override bool Equals(object obj)
    {
        return obj is Number number &&
               base.Equals(obj) &&
               this.number == number.number;
    }

    public override int GetHashCode()
    {
        int hashCode = 1091060534;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + number.GetHashCode();
        return hashCode;
    }
}
