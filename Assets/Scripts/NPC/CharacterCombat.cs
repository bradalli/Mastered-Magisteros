using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.NPC;

public class CharacterCombat : MonoBehaviour
{
    [Header("Combat - Attack Information")]
    public bool attemptAttack;
    public bool isAttacking;
    public Character combatTarget;
    public float timeLastGivenAttack;
    public Character charLastGivenAttack;
    public float timeLastReceivedAttack;
    public Character charLastReceivedAttack;

    [Header("Combat - Block Information")]
    public bool attemptBlock;
    public bool isBlocking;

    public void AttackTarget(Character target)
    {
        isAttacking = true;
    }

    public void Block()
    {
        isBlocking = true;
    }
}
