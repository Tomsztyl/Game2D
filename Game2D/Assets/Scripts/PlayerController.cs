using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActionPlayer _inputActions = null;

    Locomotion locomotion = null;

    private void Awake()
    {
        _inputActions = new InputActionPlayer();


        #region Locomotion Object System
        //get locomtoion object
        locomotion = new Locomotion();
        //execiute method LocomotionPlayer who Get value Vector2 from input system
        locomotion.LocomotionPlayer(_inputActions);
        #endregion
    }
    private void Update()
    {
        if (locomotion != null)
            Debug.Log(locomotion.LocomotionVector());
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

    #region Locomotion System
    class Locomotion
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

}
