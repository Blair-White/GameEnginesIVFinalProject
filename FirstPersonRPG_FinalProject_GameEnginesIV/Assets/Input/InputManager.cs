using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    private GameplayControls gameplayControls;
    public static InputManager Instance { get { return _instance; } }
    private GameObject sword;
    private void Awake()
    {
        sword = GameObject.Find("MagicSword_Ice");
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        gameplayControls = new GameplayControls();
        Cursor.visible = false;
      
    }

    private void OnEnable()
    {
        gameplayControls.Enable();
    }

    public Vector2 GetPlayerMovement()
    {
        return gameplayControls.MainGameplayControls.Movement.ReadValue<Vector2>();        
    }

    public Vector2 GetMouseDelta()
    {
        return gameplayControls.MainGameplayControls.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return gameplayControls.MainGameplayControls.Jump.triggered;
    }

    public bool PressedMouse0()
    {
        return gameplayControls.MainGameplayControls.Attack.triggered;
    }

    public bool PressedAbilityOne()
    {
        return gameplayControls.MainGameplayControls.AbilityOne.triggered;
    }

    public bool PressedAbilityTwo()
    {
        return gameplayControls.MainGameplayControls.AbilityTwo.triggered;
    }

}
