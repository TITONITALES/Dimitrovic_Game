﻿using UnityEngine;

namespace FSM_Behaviors
{
    public class AreaAttackBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private bool attackStarted;
        private float currentTimer;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            attackStarted = false;
            currentTimer = aiData.areaAttackDelay;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (!attackStarted && currentTimer <= 0)
            {
                aiData.areaAttackCollider.enabled = true;
                attackStarted = true;
                currentTimer = aiData.areaAttackTime;
            }
            if (attackStarted && currentTimer <= 0)
            {
                aiData.areaAttackCollider.enabled = false;
            }
            currentTimer -= Time.deltaTime;
        }
    }
}