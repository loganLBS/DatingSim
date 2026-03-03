using UnityEngine;
using Yarn.Unity;

public class DTSMiddleman : MonoBehaviour
{
    public int Day = 0;
    public float cassieTrust = 0;
    public float bebeTrust = 0;
    public float nancyTrust = 0;
    public float emikoTrust = 0;
    public float takikoTrust = 0;
    public float sashaTrust = 0;
    
    [YarnCommand("NextDay")]
    public void NextDay()
    {
        Day++;
        Debug.Log("day increased to " + Day);
    }

    public void ctUP()
    {
        cassieTrust = cassieTrust + 12.5f;
    }
    public void ctDW()
    {
        cassieTrust = cassieTrust - 12.5f;
    }

    public void btUP()
    {
        bebeTrust = bebeTrust + 12.5f;
    }
    public void btDW()
    {
        bebeTrust = bebeTrust - 12.5f;
    }

    public void ntUP()
    {
        nancyTrust = nancyTrust + 12.5f;
    }
    public void ntDW()
    {
        nancyTrust = nancyTrust - 12.5f;
    }

    public void etUP()
    {
        emikoTrust = emikoTrust + 12.5f;
    }
    public void etDW()
    {
        emikoTrust = emikoTrust - 12.5f;
    }

    public void ttUP()
    {
        takikoTrust = takikoTrust + 12.5f;
    }
    public void ttDW()
    {
        takikoTrust = takikoTrust - 12.5f;
    }

    public void stUP()
    {
        sashaTrust = sashaTrust + 12.5f;
    }
    public void stDW()
    {
        sashaTrust = sashaTrust - 12.5f;
    }
}
