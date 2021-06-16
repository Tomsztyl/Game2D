// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputActionPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActionPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionPlayer"",
    ""maps"": [
        {
            ""name"": ""PlayerLocomotion"",
            ""id"": ""a4331e46-150a-486d-9dbe-7aa5e8c181b0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aa7a3104-b940-4707-af17-78cf7333bd84"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2DWASD"",
                    ""id"": ""7bafb54d-5adf-4694-b2eb-6f6ee9f4eb27"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""28842df7-8dda-4112-af53-07f5f57a48f4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ab2cf6d0-857a-4737-bfa5-bdb3f4633f55"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9a29cc8d-01b2-499d-99d0-9525df767b03"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""793a6290-8a27-45ee-837d-080db4aa18d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2DArrow"",
                    ""id"": ""eed6f892-c911-4be1-a95c-91742c233ab7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""729007df-3fd5-4371-a74d-e3371ff16860"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f35f7c0c-6663-45da-8762-24575b061cc2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1e495736-e8d3-466d-bd99-4ea04050074f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6466bd75-2171-41d9-ae26-bd892d0bf3c7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerAttack"",
            ""id"": ""17fda280-c904-4f7b-9b44-b70aa5a08b38"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3e71752b-c2b1-4caa-a260-bf163251555e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2226f525-31a5-4ac0-9ba8-991098f967fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
        // PlayerLocomotion
        m_PlayerLocomotion = asset.FindActionMap("PlayerLocomotion", throwIfNotFound: true);
        m_PlayerLocomotion_Move = m_PlayerLocomotion.FindAction("Move", throwIfNotFound: true);
        // PlayerAttack
        m_PlayerAttack = asset.FindActionMap("PlayerAttack", throwIfNotFound: true);
        m_PlayerAttack_Attack = m_PlayerAttack.FindAction("Attack", throwIfNotFound: true);
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

    // PlayerLocomotion
    private readonly InputActionMap m_PlayerLocomotion;
    private IPlayerLocomotionActions m_PlayerLocomotionActionsCallbackInterface;
    private readonly InputAction m_PlayerLocomotion_Move;
    public struct PlayerLocomotionActions
    {
        private @InputActionPlayer m_Wrapper;
        public PlayerLocomotionActions(@InputActionPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerLocomotion_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerLocomotion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerLocomotionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerLocomotionActions instance)
        {
            if (m_Wrapper.m_PlayerLocomotionActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerLocomotionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerLocomotionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerLocomotionActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerLocomotionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerLocomotionActions @PlayerLocomotion => new PlayerLocomotionActions(this);

    // PlayerAttack
    private readonly InputActionMap m_PlayerAttack;
    private IPlayerAttackActions m_PlayerAttackActionsCallbackInterface;
    private readonly InputAction m_PlayerAttack_Attack;
    public struct PlayerAttackActions
    {
        private @InputActionPlayer m_Wrapper;
        public PlayerAttackActions(@InputActionPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_PlayerAttack_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAttack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAttackActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerAttackActions instance)
        {
            if (m_Wrapper.m_PlayerAttackActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerAttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerAttackActions @PlayerAttack => new PlayerAttackActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerLocomotionActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IPlayerAttackActions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
}
