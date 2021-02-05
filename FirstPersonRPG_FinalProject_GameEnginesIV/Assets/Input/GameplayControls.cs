// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameplayControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameplayControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayControls"",
    ""maps"": [
        {
            ""name"": ""MainGameplayControls"",
            ""id"": ""2797dc6e-0c7a-4858-94f0-4d135c1b7db7"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9e4dc790-1f11-45b3-bb56-defa0f60638d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""79721917-505b-4d26-bc74-3312fe42e168"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ade990fe-136e-4471-9fce-ded6cb12aeb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b558cfb6-533c-4825-8d34-629e55a43ad6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e467d465-4f66-42c3-98f3-480dfb91d90e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f54c72c1-b7b3-4eb3-b856-4ea3b19fa89c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f80f1afd-91bb-4dab-a7a8-0518883d5c88"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d898c090-6900-4541-8a87-5e38ca198384"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66a188ee-164d-4cbe-90f8-eeeb4b11ca01"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""542fd15b-5e10-454d-aae4-2a6d895bc540"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c32fa7eb-4652-4b04-9545-780ef859f1e3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c2a34a4-884d-420c-a680-e3a588f9e014"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainGameplayControls
        m_MainGameplayControls = asset.FindActionMap("MainGameplayControls", throwIfNotFound: true);
        m_MainGameplayControls_Movement = m_MainGameplayControls.FindAction("Movement", throwIfNotFound: true);
        m_MainGameplayControls_Look = m_MainGameplayControls.FindAction("Look", throwIfNotFound: true);
        m_MainGameplayControls_Jump = m_MainGameplayControls.FindAction("Jump", throwIfNotFound: true);
        m_MainGameplayControls_Attack = m_MainGameplayControls.FindAction("Attack", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MainGameplayControls
    private readonly InputActionMap m_MainGameplayControls;
    private IMainGameplayControlsActions m_MainGameplayControlsActionsCallbackInterface;
    private readonly InputAction m_MainGameplayControls_Movement;
    private readonly InputAction m_MainGameplayControls_Look;
    private readonly InputAction m_MainGameplayControls_Jump;
    private readonly InputAction m_MainGameplayControls_Attack;
    public struct MainGameplayControlsActions
    {
        private @GameplayControls m_Wrapper;
        public MainGameplayControlsActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MainGameplayControls_Movement;
        public InputAction @Look => m_Wrapper.m_MainGameplayControls_Look;
        public InputAction @Jump => m_Wrapper.m_MainGameplayControls_Jump;
        public InputAction @Attack => m_Wrapper.m_MainGameplayControls_Attack;
        public InputActionMap Get() { return m_Wrapper.m_MainGameplayControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainGameplayControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMainGameplayControlsActions instance)
        {
            if (m_Wrapper.m_MainGameplayControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainGameplayControlsActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_MainGameplayControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public MainGameplayControlsActions @MainGameplayControls => new MainGameplayControlsActions(this);
    public interface IMainGameplayControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
