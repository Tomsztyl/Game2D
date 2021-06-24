using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locomotion
{
    public class Locomotion2D
    {
        /// <summary>
        /// Method Check if character is grounded through mechanism RayCastHit2D and draw Gizmos Line
        /// </summary>
        /// <param name="feetGroundCharacter">Transform character where raycast hit down</param>
        /// <param name="layerGround">Layer where raycast separe hit</param>
        /// <param name="feetGroundLenght">Lenght raycast </param>
        /// <returns>Variable bool [true=is grounded] || [false=is not grounded] </returns>
        public bool IsGrounded(Transform feetGroundCharacter,LayerMask layerGround,float feetGroundLenght)
        {
            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(feetGroundCharacter.position, -Vector2.up,feetGroundLenght,layerGround);

            if (hit.collider != null)
            {
                Debug.DrawRay(feetGroundCharacter.position, -Vector2.up * hit.distance, Color.blue);
                return true;
            }
            else
            {
                Debug.DrawRay(feetGroundCharacter.position, -Vector2.up * hit.distance, Color.green);
                return false;
            }           
        }
        /// <summary>
        /// Method who check if character falling down
        /// </summary>
        /// <param name="rigidbody2D">Rigidbody 2D character</param>
        /// <param name="fallingThreshold">Calculate distance falling treshold</param>
        /// <returns>Variable bool [true=is falling] [false=is not falling]</returns>
        public bool IsJumpingDown(Rigidbody2D rigidbody2D, float fallingThreshold)
        {
            //checking falling treshold character
            if (rigidbody2D.velocity.y < fallingThreshold)
            {
                //is falling
                return true;
            }
            else
            {
                //is not falling
                return false;
            }
        }
    }

    #region Locomotion System Input
    /// <summary>
    /// Class Who Get Value From System Input
    /// </summary>
    public class LocomotionInput
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
    public class LocomotionRunning
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
            if (locomotion.x < 0)
            {
                locomotionCalculate *= -1;
            }
            //swtich value variable to speed character
            animator.SetFloat(textParameter, locomotionCalculate);
        }
        /// <summary>
        /// Method Rotate Character To Move
        /// </summary>
        /// <param name="transformObject">Transoform object to rotate character to corrcet direction</param>
        public void LocomotionRotateMechanism(Transform transformObject)
        {
            if (locomotion.x < 0)
            {
                //switch direction character to left
                speedRuning *= -1;
                transformObject.eulerAngles = new Vector2(transformObject.eulerAngles.x, -180);
            }
            else if (locomotion.x > 0)
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
    public class LocomotionJumpingUp
    {
        private Vector2 locomotion;
        private float jumpPower;

        public LocomotionJumpingUp(Vector2 locomotion, float jumpPower)
        {
            this.locomotion = locomotion;
            this.jumpPower = jumpPower;
        }
        public void LocomotionJumpingUpMechanism(Transform transformObject, Rigidbody2D rigidbody2D)
        {
            //calculate and jumping power character
            if (locomotion.y>0)
            {
                float jumpingPower = locomotion.y * jumpPower;
                rigidbody2D.AddForce(transformObject.up * jumpingPower);
            }
        }
        public void LocomotionJumpingUpAnimation(Animator animator,string textParameter,bool isGround)
        {
            if (isGround && !animator.GetBool(textParameter))
            {
                if (locomotion.y > 0)
                {
                    //jump up
                    animator.SetBool(textParameter, true);
                }
            }           
            else
            {
                //end jumping up
                animator.SetBool(textParameter, false);
            }
        }
    }
    /// <summary>
    /// Class Who Define Mechanism Jumping Down
    /// </summary>
    public class LocomotionJumpingDown
    {
        /// <summary>
        /// Method who Set Animation Jumping Down / Falling Character
        /// </summary>
        /// <param name="animator">Component Animator Character to change variable parameter</param>
        /// <param name="textParameter">String name varible in Animator (Parameter)</param>
        /// <param name="isFalling">Vairable To define is character falling or not</param>
        public void LocomotionJumpingDownAnimation(Animator animator,string textParameter,bool isFalling)
        {
            if (isFalling)
            {
                //character falling 
                animator.SetBool(textParameter, isFalling);
            }
            else
            {
                //character not falling
                animator.SetBool(textParameter, isFalling);
            }
        }
    }
    #endregion
}
