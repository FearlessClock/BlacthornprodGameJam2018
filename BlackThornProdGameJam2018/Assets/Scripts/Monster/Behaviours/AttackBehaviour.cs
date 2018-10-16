﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {

    private GameObject player;
    private MonsterController monster;

    private bool spawnOne = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        monster = animator.transform.gameObject.GetComponent<MonsterController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float disToPlayer = Vector3.Distance(player.transform.position, animator.transform.position);
        //Debug.Log("Attack: " + disToPlayer);
        if (disToPlayer > 2)
        {
            animator.SetTrigger("WalkTo");
        }
        else if (disToPlayer < monster.attackRange)
        {
            if (!spawnOne)
            {
                GameObject spellObj = Instantiate<GameObject>(monster.spellGenerator);

                spellObj.transform.parent = monster.Spells;

                SpellGenerator spellScript = spellObj.GetComponent<SpellGenerator>();
                spellScript.spellSettings = monster.spellSettings;
                spellScript.GenerateSpell(monster.transform);
                spawnOne = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}