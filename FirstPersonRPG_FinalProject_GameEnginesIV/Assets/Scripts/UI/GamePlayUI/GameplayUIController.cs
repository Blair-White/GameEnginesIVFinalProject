using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameplayUIController : MonoBehaviour
{
    public GameObject mPlayer, AbilityCooldownPanel_1, AbilityCooldownPanel_2, AbilityFlashPanel_1, AbilityFlashPanel_2;
    private bool AbilityOneAvailable, AbilityTwoAvailable, CoolingOne, CoolingTwo, FlashingAbilityOne, FlashingAbilityTwo;
    private RectTransform imgAbilityOneCooldown, imgAbilityTwoCooldown;
    private int flickerCount;
    private float coolDownOne, coolDownTwo, CdRate1, CdRate2;
    void Start()
    {
        mPlayer = GameObject.Find("Player");
        imgAbilityOneCooldown = AbilityCooldownPanel_1.GetComponent<RectTransform>();
        imgAbilityTwoCooldown = AbilityCooldownPanel_2.GetComponent<RectTransform>();
        coolDownOne = 1; coolDownTwo = 1; CdRate1 = 0.0003f; CdRate2 = 0.0001f;
        AbilityOneAvailable = true;
        AbilityTwoAvailable = true;
    }

    void Update()
    {
        if(!AbilityOneAvailable && CoolingOne) 
        {
            coolDownOne -= CdRate1;
            if (coolDownOne <= 0.0f) { FinishedCoolingDownAbilityOne(); return; }
            imgAbilityOneCooldown.localScale = new Vector3(1, coolDownOne, 1);
        }

        if (!AbilityTwoAvailable && CoolingTwo)
        {
            coolDownTwo -= CdRate2;
            if (coolDownTwo <= 0.0f) { FinishedCoolingDownAbilityTwo();  return; }
            imgAbilityTwoCooldown.localScale = new Vector3(1, coolDownTwo, 1);
        }

        if(AbilityOneAvailable)  { if (InputManager.Instance.PressedAbilityOne()) { ActivateAbilityOne(); }  }

        if(AbilityTwoAvailable)  { if (InputManager.Instance.PressedAbilityTwo()) { ActivateAbilityTwo(); }  }

    }

    void ActivateAbilityOne()
    {
        imgAbilityOneCooldown.localScale = new Vector3(1, 1, 1);
        coolDownOne = 1;
        AbilityOneAvailable = false;
        mPlayer.SendMessage("Empower");
    }

    void ActivateAbilityTwo()
    {
        imgAbilityTwoCooldown.localScale = new Vector3(1, 1, 1);
        coolDownTwo = 1;
        AbilityTwoAvailable = false;
        mPlayer.SendMessage("ShieldMe");
    }

    void FinishedCoolingDownAbilityOne()
    {
        AbilityOneAvailable = true;
        imgAbilityOneCooldown.localScale = new Vector3(1, 0, 1);
        CoolingOne = false;
    }

    void FinishedCoolingDownAbilityTwo()
    {
        AbilityTwoAvailable = true;
        imgAbilityTwoCooldown.localScale = new Vector3(1, 0, 1);
        CoolingTwo = false;
    }

    void ShieldEnded() { CoolingTwo = true; imgAbilityTwoCooldown.localScale = new Vector3(1, 1, 1); }
    void EmpowerEnded() { CoolingOne = true; imgAbilityOneCooldown.localScale = new Vector3(1, 1, 1); }
}
