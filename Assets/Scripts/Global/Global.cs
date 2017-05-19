using UnityEngine;
using System.Collections;


public class Global
{
    static public string GetSeparatedNumber(int _num)
    {
        string strNum = _num.ToString();
        if (strNum.Length > 3)
        {
            for (int i = strNum.Length - 1; i >= 0; i -= 3)
            {
                //insert ',' and increment i by 1 because adding ',' will move indexes by 1
                if (i != strNum.Length - 1)
                {
                    strNum = strNum.Insert(i+1, ",");
                }
                //check if there is 3 more digits -> and exit
                if (i - 3 < 0)
                    break;
            }
        }
        return strNum;
    }
}
