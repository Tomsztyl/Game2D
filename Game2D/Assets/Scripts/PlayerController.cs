using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActionPlayer _inputActions = null;

    LocomotionInput locomotionInput = null;

    private void Awake()
    {
        _inputActions = new InputActionPlayer();

        #region Locomotion Object System
        //get locomtoion object
        locomotionInput = new LocomotionInput();
        //execiute method LocomotionPlayer who Get value Vector2 from input system
        locomotionInput.LocomotionPlayer(_inputActions);
        #endregion

    }
    private void FixedUpdate()
    {
        if (locomotionInput != null)
        {
            LocomotionRunning locomotionRunning = new LocomotionRunning(locomotionInput.LocomotionVector(),10f);
            locomotionRunning.LocomotionRotateMechanism(this.gameObject.transform);
            locomotionRunning.LocomotionRunningAnimation(GetComponent<Animator>(), "Runing");
            locomotionRunning.LocomotionRunningMechanism(this.gameObject.transform);
        }
            //Debug.Log(locomotionInput.LocomotionVector());
    }

    #region Switch Input System
    private void OnEnable()
    {
        //enable Player Locomotion Input system
        _inputActions.PlayerLocomotion.Enable();
    }
    private void OnDisable()
    {
        //disable Player Locomotion Input system
        _inputActions.PlayerLocomotion.Disable();
    }
    #endregion

    #region Locomotion System Input
    /// <summary>
    /// Class Who Get Value From System Input
    /// </summary>
    class LocomotionInput
    {
        private Vector2 locomotion;     //locomotion speed get from input system

        /// <summary>
        /// Get From Input System Speed Vector2d
        /// </summary>
        /// <param name="inputActions">Input System Define Action Vector2D</param>
        public void LocomotionPlayer(InputActionPlayer inputActions)
        {
            if (inputActions != null)
            {
                //is Input System

                //set locomotion value Vector2 is it calculated
                inputActions.PlayerLocomotion.Move.performed += cntxt => locomotion = cntxt.ReadValue<Vector2>();
                //set locomotion value Vector2 if interaction is canceled set default value Vector2 zero
                inputActions.PlayerLocomotion.Move.canceled += cntxt => locomotion = Vector2.zero;
            }
            else
                //no define input system Debug [Error]
                Debug.LogError("Input System Locomotion is not define");
        }
        /// <summary>
        /// Get Vector Locomtoion From Input system
        /// </summary>
        /// <returns>Vector2 Calculate Input System</returns>
        public Vector2 LocomotionVector()
        {
            //get locomotion speed Vector from Input system
            return locomotion;
        }
    }
    #endregion

    #region Locomotion Character
    /// <summary>
    /// Class Who Have Mechanism Running
    /// </summary>
    class LocomotionRunning
    {
        private Vector2 locomotion;         //define locomotion from input system for the character
        private float speedRuning;          //define speed character running declarate from constructor

        /// <summary>
        /// Constructor who assigns properties to Mechanism Running Character
        /// </summary>
        /// <param name="locomotion">Locomotion from input system</param>
        /// <param name="speedRuning">Set speed character running</param>
        public LocomotionRunning(Vector2 locomotion, float speedRuning)
        {
            //assigns variable LocomotionRunning class
            this.locomotion = locomotion;
            this.speedRuning = speedRuning;
        }
        /// <summary>
        /// Method Trnaslate Character
        /// </summary>
        /// <param name="transformObject">Transform character to Translate</param>
        public void LocomotionRunningMechanism(Transform transformObject)
        {
            //calculate and set translate character
            float translation = locomotion.x * speedRuning * Time.deltaTime;
            transformObject.transform.Translate(translation, 0, 0);
        }
        /// <summary>
        /// Method Switch Animation Character
        /// </summary>
        /// <param name="animator">Component Animator to Controll and switch animation</param>
        /// <param name="textParameter">Name paramets to change</param>
        public void LocomotionRunningAnimation(Animator animator, string textParameter)
        {
            //calculate speed character
            var locomotionCalculate = locomotion.x;
            if (locomotion.x<0)
            {
                locomotionCalculate *= -1;
            }   
            //swtich value variable to speed character
            animator.SetFloat(textParameter, locomotionCalculate);
        }
        /// <summary>
        /// Mathod Rotate Character To Move
        /// </summary>
        /// <param name="transformObject">Transoform object to rotate character to corrcet direction</param>
        public void LocomotionRotateMechanism(Transform transformObject)
        {
            if (locomotion.x<0)
            {
                //switch direction character to left
                speedRuning *= -1;
                transformObject.eulerAngles = new Vector2(transformObject.eulerAngles.x, -180);
            }
            else if (locomotion.x>0)
            {
                //switch direction character to right
                speedRuning *= 1;
                transformObject.eulerAngles = new Vector2(transformObject.eulerAngles.x, 0);
            }
        }
    }
    /// <summary>
    /// Class Who Define Mechanism Jumping Up
    /// </summary>
    class LocomotionJumpingUp
    {
        //float translationjump = locomotion.y * 10f * Time.deltaTime;
    }
    /// <summary>
    /// Class Who Define Mechanism Jumping Down
    /// </summary>
    class LocomotionJumpingDown
    {

    }
    #endregion
}
