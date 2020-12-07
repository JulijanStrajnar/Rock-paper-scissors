// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""8c82da82-795e-4f03-861b-f8baa40ce02b"",
            ""actions"": [
                {
                    ""name"": ""SelectCard"",
                    ""type"": ""Button"",
                    ""id"": ""9269eafa-8f1b-4fa4-a774-6cb61411a3fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectLane"",
                    ""type"": ""Button"",
                    ""id"": ""64459225-c86e-4c75-811a-e1fa618da23a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TryToBuy"",
                    ""type"": ""Button"",
                    ""id"": ""255b0651-c1ef-49ce-ae27-ad0d126ba35c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""SelectCard"",
                    ""id"": ""a4083887-768b-4ab6-932f-691e5ae74ed9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8e838e02-f996-4c74-965b-2ece33d5a611"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bad38f01-02c3-4f69-8c7d-795361e585ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""SelectLane"",
                    ""id"": ""762abc9d-a058-4a05-a4e6-14ef26cd47aa"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f405abc3-13bb-4d07-b5ed-d92ad7072fbe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""972086e6-eb04-4a1f-a97d-8b7ef770522b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e3b8c519-7f35-4106-b328-4f4c2ea20090"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""TryToBuy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""7d1f4e6c-2798-4864-850e-6e26c2dfd64d"",
            ""actions"": [
                {
                    ""name"": ""SelectCard"",
                    ""type"": ""Button"",
                    ""id"": ""0e5db56d-4b50-48c6-bd54-44f3ad63765c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectLane"",
                    ""type"": ""Button"",
                    ""id"": ""386bc467-d53f-4871-8f3d-ef62b97d901e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TryToBuy"",
                    ""type"": ""Button"",
                    ""id"": ""f34f4005-2716-42c4-a35a-a2df6926ac1a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""SelectCard"",
                    ""id"": ""6bec1ad4-bf2e-4869-ab52-bbe6973896d2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5db7c009-9f41-4477-96a4-7644d0e6c908"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""816b0e0e-5ddc-4365-bfb6-099cf27c9e33"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""SelectLane"",
                    ""id"": ""fda1bcd8-9843-4ea2-9b1a-d289a0999fd3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""20d43517-a5f5-4d33-b230-3a3926af406b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""15840384-b714-48d3-b060-aa7ba59a7403"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectLane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7893dc3-831f-4d8b-b8dd-2f0742748d5f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""TryToBuy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""General"",
            ""id"": ""4f81342a-5a21-4bab-9078-cf9cf295005e"",
            ""actions"": [
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""be5ea2d6-4023-4280-bf51-22ad9282ebcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8bd2175a-9ae0-4ce7-90d9-0b7a075e1125"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_SelectCard = m_Player1.FindAction("SelectCard", throwIfNotFound: true);
        m_Player1_SelectLane = m_Player1.FindAction("SelectLane", throwIfNotFound: true);
        m_Player1_TryToBuy = m_Player1.FindAction("TryToBuy", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_SelectCard = m_Player2.FindAction("SelectCard", throwIfNotFound: true);
        m_Player2_SelectLane = m_Player2.FindAction("SelectLane", throwIfNotFound: true);
        m_Player2_TryToBuy = m_Player2.FindAction("TryToBuy", throwIfNotFound: true);
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Esc = m_General.FindAction("Esc", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_SelectCard;
    private readonly InputAction m_Player1_SelectLane;
    private readonly InputAction m_Player1_TryToBuy;
    public struct Player1Actions
    {
        private @InputMaster m_Wrapper;
        public Player1Actions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectCard => m_Wrapper.m_Player1_SelectCard;
        public InputAction @SelectLane => m_Wrapper.m_Player1_SelectLane;
        public InputAction @TryToBuy => m_Wrapper.m_Player1_TryToBuy;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @SelectCard.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectCard;
                @SelectCard.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectCard;
                @SelectCard.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectCard;
                @SelectLane.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectLane;
                @SelectLane.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectLane;
                @SelectLane.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectLane;
                @TryToBuy.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTryToBuy;
                @TryToBuy.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTryToBuy;
                @TryToBuy.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTryToBuy;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectCard.started += instance.OnSelectCard;
                @SelectCard.performed += instance.OnSelectCard;
                @SelectCard.canceled += instance.OnSelectCard;
                @SelectLane.started += instance.OnSelectLane;
                @SelectLane.performed += instance.OnSelectLane;
                @SelectLane.canceled += instance.OnSelectLane;
                @TryToBuy.started += instance.OnTryToBuy;
                @TryToBuy.performed += instance.OnTryToBuy;
                @TryToBuy.canceled += instance.OnTryToBuy;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_SelectCard;
    private readonly InputAction m_Player2_SelectLane;
    private readonly InputAction m_Player2_TryToBuy;
    public struct Player2Actions
    {
        private @InputMaster m_Wrapper;
        public Player2Actions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectCard => m_Wrapper.m_Player2_SelectCard;
        public InputAction @SelectLane => m_Wrapper.m_Player2_SelectLane;
        public InputAction @TryToBuy => m_Wrapper.m_Player2_TryToBuy;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @SelectCard.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectCard;
                @SelectCard.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectCard;
                @SelectCard.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectCard;
                @SelectLane.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectLane;
                @SelectLane.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectLane;
                @SelectLane.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSelectLane;
                @TryToBuy.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnTryToBuy;
                @TryToBuy.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnTryToBuy;
                @TryToBuy.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnTryToBuy;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectCard.started += instance.OnSelectCard;
                @SelectCard.performed += instance.OnSelectCard;
                @SelectCard.canceled += instance.OnSelectCard;
                @SelectLane.started += instance.OnSelectLane;
                @SelectLane.performed += instance.OnSelectLane;
                @SelectLane.canceled += instance.OnSelectLane;
                @TryToBuy.started += instance.OnTryToBuy;
                @TryToBuy.performed += instance.OnTryToBuy;
                @TryToBuy.canceled += instance.OnTryToBuy;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Esc;
    public struct GeneralActions
    {
        private @InputMaster m_Wrapper;
        public GeneralActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Esc => m_Wrapper.m_General_Esc;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Esc.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnSelectCard(InputAction.CallbackContext context);
        void OnSelectLane(InputAction.CallbackContext context);
        void OnTryToBuy(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnSelectCard(InputAction.CallbackContext context);
        void OnSelectLane(InputAction.CallbackContext context);
        void OnTryToBuy(InputAction.CallbackContext context);
    }
    public interface IGeneralActions
    {
        void OnEsc(InputAction.CallbackContext context);
    }
}
