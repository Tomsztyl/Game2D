using Attack;
using Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties Locomotion Character")]
    [Tooltip("Running locomotion character")]
    [SerializeField]private float locomotionRunningSpeed = 10f;
    [Tooltip("Jumping power character")]
    [SerializeField] private float locomotionJumpingPower = 1000f; 

    [Header("Variable Check Ground")]
    [Tooltip("LayerMaks Ground raycast check if ray hit object with layer mask")]
    [SerializeField]private LayerMask layerMaskGround;
    [Tooltip("Distance from the ground")]
    [SerializeField]private float distanceGround = .41f;
    [Tooltip("Calculate distance falling treshold")]
    [SerializeField]private float fallingTreshold = 0f;

    InputActionPlayer _inputActions = null;                                      //input system player
    Locomotion2D _locomotion2D = null;                                           //using locomotion2D with mechanisms character:[running][jumpingUp][jumpingDown]
    LocomotionInput _locomotionInput = null;                                     //input system player get locomotion
    AttackController _attackController = null;

    Rigidbody2D rigidbody2DCharacter = null;                                     //component rigidbody in character        
    Animator animatorCharacter = null;                                           //component animator in character


    private void Awake()
    {
        #region Locomotion Object System
        //input system locomotion
        _inputActions = new InputActionPlayer();
        //get locomtoion object
        _locomotionInput = new LocomotionInput();
        //locomotion using with mechanisms 2d
        _locomotion2D = new Locomotion2D();
        //execiute method LocomotionPlayer who Get value Vector2 from input system
        _locomotionInput.LocomotionPlayer(_inputActions);
        #endregion

        _attackController = new AttackController();

    }

    private void Start()
    {
        rigidbody2DCharacter = GetComponent<Rigidbody2D>();
        animatorCharacter = GetComponent<Animator>();

        AttackCharacter();
    }

    private void FixedUpdate()
    {
        if (_locomotionInput != null)
        {
            LocomotionCharacterRunning();
            LocomotionCharacterJumpingUp();
            LocomotionCharacterJumpingDown();
        }
    }
    private void LocomotionCharacterRunning()
    {
        LocomotionRunning locomotionRunning = new LocomotionRunning(_locomotionInput.LocomotionVector(), locomotionRunningSpeed);
        locomotionRunning.LocomotionRotateMechanism(this.gameObject.transform);
        locomotionRunning.LocomotionRunningAnimation(animatorCharacter, "Runing");
        locomotionRunning.LocomotionRunningMechanism(this.gameObject.transform);
    }
    private void LocomotionCharacterJumpingUp()
    {
        if (_locomotion2D.IsGrounded(this.gameObject.transform, layerMaskGround, distanceGround))
        {
            LocomotionJumpingUp locomotionJumpingUp = new LocomotionJumpingUp(_locomotionInput.LocomotionVector(), locomotionJumpingPower);
            locomotionJumpingUp.LocomotionJumpingUpAnimation(animatorCharacter, "isJumpUp", _locomotion2D.IsGrounded(this.gameObject.transform, layerMaskGround, distanceGround));
            if (animatorCharacter.GetBool("isBeforeJumpingUp"))
            {
                locomotionJumpingUp.LocomotionJumpingUpMechanism(this.gameObject.transform, rigidbody2DCharacter);
                animatorCharacter.SetBool("isBeforeJumpingUp", false);
            }

        }
    }
    private void LocomotionCharacterJumpingDown()
    {
        LocomotionJumpingDown locomotionJumpingDown = new LocomotionJumpingDown();
        locomotionJumpingDown.LocomotionJumpingDownAnimation(animatorCharacter, "IsJumpDown", _locomotion2D.IsJumpingDown(rigidbody2DCharacter,fallingTreshold));
    }
    private void AttackCharacter()
    {
        if (_attackController!=null)
        {
            _attackController.AttackInputCharacter(_inputActions,animatorCharacter, "IsAttack");
        }
    }

    #region Switch Input System
    private void OnEnable()
    {
        //enable Player Locomotion Input system
        _inputActions.PlayerLocomotion.Enable();

        //enable Player Attack Input System
        _inputActions.PlayerAttack.Enable();
    }
    private void OnDisable()
    {
        //disable Player Locomotion Input system
        _inputActions.PlayerLocomotion.Disable();

        //disable Player Attack Input System
        _inputActions.PlayerAttack.Disable();
    }
    #endregion

}
