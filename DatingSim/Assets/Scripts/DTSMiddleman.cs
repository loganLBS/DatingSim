using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

public class DTSMiddleman : MonoBehaviour
{
    public static DTSMiddleman Instance;
    // Reference to your Yarn Dialogue Runner
    [SerializeField] private DialogueRunner dialogueRunner;
    public Slider trustSlider;

    public int Day = 0;
    public float cassieTrust = 0;
    public float bebeTrust = 0;
    public float nancyTrust = 0;
    public float emikoTrust = 0;
    public float takikoTrust = 0;
    public float sashaTrust = 0;
    public float trust = 0;

   

    private void Start()
    {
        if (dialogueRunner != null)
        {
            // This makes <<LoadNextScene>> call the LoadNextScene() method
            dialogueRunner.AddCommandHandler("CassieTrustUp", ctUP);
            dialogueRunner.AddCommandHandler("CassieTrustDown", ctDW);
            dialogueRunner.AddCommandHandler("BebeTrustUp", btUP);
            dialogueRunner.AddCommandHandler("NancyTrustUp", ntUP);
            dialogueRunner.AddCommandHandler("EmikoTrustUp", etUP);
            dialogueRunner.AddCommandHandler("TakikoTrustUp", ttUP);
            dialogueRunner.AddCommandHandler("SashaTrustUp", stUP);
            dialogueRunner.AddCommandHandler("BebeTrustDown", btDW);
            dialogueRunner.AddCommandHandler("NancyTrustDown", ntDW);
            dialogueRunner.AddCommandHandler("EmikoTrustDown", etDW);
            dialogueRunner.AddCommandHandler("TakikoTrustDown", ttDW);
            dialogueRunner.AddCommandHandler("SashaTrustDown", stDW);

            UnityEngine.Debug.Log("Yarn command 'Character Trust Commands' registered successfully");
        }
        else
        {
            UnityEngine.Debug.LogError("DialogueRunner reference not set in SceneLoader!");
        }
    }
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

    //[YarnCommand("NextDay")]
    public void NextDay()
    {
        Day++;
        UnityEngine.Debug.Log("day increased to " + Day);
        
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
