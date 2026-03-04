using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class DTSMiddleman : MonoBehaviour
{
    public Slider trustSlider;
    public int Day = 0;
    public float cassieTrust = 0;
    public float bebeTrust = 0;
    public float nancyTrust = 0;
    public float emikoTrust = 0;
    public float takikoTrust = 0;
    public float sashaTrust = 0;
    public float trust = 0;

    public void UpdateUI()
    {
        trustSlider.value = trust;
    }

    [YarnCommand("Save")]
    public void SaveGame()
    {
        SaveInfo data = new SaveInfo
        {
            Day = Day,
            cassieTrust = (float)cassieTrust,
            bebeTrust = (float)bebeTrust,
            nancyTrust = (float)nancyTrust,
            emikoTrust = (float)emikoTrust,
            takikoTrust = (float)takikoTrust,
            sashaTrust = (float)sashaTrust,
        };

        SaveFunction.Save(data);
    }

    [YarnCommand("NextDay")]
    public void NextDay()
    {
        Day++;
        Debug.Log("day increased to " + Day);
    }

    public void ctUP()
    {
        cassieTrust = cassieTrust + 12.5f;
        trustSlider.value = cassieTrust;
    }
    public void ctDW()
    {
        cassieTrust = cassieTrust - 12.5f;
        trustSlider.value = cassieTrust;
    }

    public void btUP()
    {
        bebeTrust = bebeTrust + 12.5f;
        trustSlider.value = bebeTrust;
    }
    public void btDW()
    {
        bebeTrust = bebeTrust - 12.5f;
        trustSlider.value = bebeTrust;
    }

    public void ntUP()
    {
        nancyTrust = nancyTrust + 12.5f;
        trustSlider.value = nancyTrust;
    }
    public void ntDW()
    {
        nancyTrust = nancyTrust - 12.5f;
        trustSlider.value = nancyTrust;
    }

    public void etUP()
    {
        emikoTrust = emikoTrust + 12.5f;
        trustSlider.value = emikoTrust;
    }
    public void etDW()
    {
        emikoTrust = emikoTrust - 12.5f;
        trustSlider.value = emikoTrust;
    }

    public void ttUP()
    {
        takikoTrust = takikoTrust + 12.5f;
        trustSlider.value = takikoTrust;
    }
    public void ttDW()
    {
        takikoTrust = takikoTrust - 12.5f;
        trustSlider.value = takikoTrust;
    }

    public void stUP()
    {
        sashaTrust = sashaTrust + 12.5f;
        trustSlider.value = sashaTrust;
    }
    public void stDW()
    {
        sashaTrust = sashaTrust - 12.5f;
        trustSlider.value = sashaTrust;
    }
}
