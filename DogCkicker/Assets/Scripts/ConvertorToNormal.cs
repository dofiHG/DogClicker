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

        return value.ToString("#.##") + postfics[i];
    }
}
