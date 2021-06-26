using UnityEngine;

namespace Attack
{
    public class AttackController
    {
        public void AttackInputCharacter(InputActionPlayer inputActions, Animator animatorCharacter, string parametrsAttack)
        {
            if (inputActions != null)
            {
                //is Input System
                inputActions.PlayerAttack.Attack.started += ctxbtn => Attack(animatorCharacter, parametrsAttack, true);
                inputActions.PlayerAttack.Attack.canceled += ctxbtn => Attack(animatorCharacter, parametrsAttack, false);

            }
            else
                //no define input system Debug [Error]
                Debug.LogError("Input System Attack is not define");
        }
        public void Attack(Animator animatorCharacter, string parametrsAttack, bool isAttack)
        {
            AttackAnimationSwitch(animatorCharacter, parametrsAttack, isAttack);
        }
        private void AttackAnimationSwitch(Animator animatorAttack, string parametrsAttack, bool isAttack)
        {
            if (animatorAttack != null)
                animatorAttack.SetBool(parametrsAttack, isAttack);
        }
    }
}
