using System;
using System.Globalization;
using UnityEngine;

public class ConvertorToNormal : MonoBehaviour
{
    public string Convertor(double value)
    {
        string[] postfics = { "", "K", "M", "B", "T", "Q", "Qn", "S" };

        if (value < 1000) { return value.ToString(); }
        int i = 0;
        while (i < postfics.Length && value >= 1000) 
        {
            value/=1000;
            i++;
        }

        return value.ToString("##.##") + postfics[i];
    }

    public string Convertor(string value)
    {
        long doubleValue = Convert.ToInt64(value);
        return Convertor(doubleValue);
    }

    public double ReversConvertor(string value)
    {
        CultureInfo culture = new CultureInfo("fr-FR");
        char prefix = value[0];
        string numberPart = "";

        if (prefix != '+') { numberPart = value[0..^1]; }
        else { numberPart = value[1..^1]; }

        string suffix = value[^1].ToString().ToUpper();
        if (numberPart.Length == 0) { numberPart = suffix; }
        double number = double.Parse(numberPart, culture);

        switch (suffix)
        {
            case "K":
                number *= 1000;
                break;
            case "M":
                number *= 1000000;
                break;
            case "B":
                number *= 1000000000;
                break;
            case "T":
                number *= 1000000000000;
                break;
            default:
                return Convert.ToInt64(value);
        }

        return number;
    }
}
