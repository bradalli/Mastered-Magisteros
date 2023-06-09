using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.NPC;

[CreateAssetMenu(menuName = "FSM/Decisions/AggravatedDecision")]
public class AggravatedDecision : Decision
{
    public KeyCode debugAdvanceKey;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        // var characterInSight = stateMachine.GetComponent<CharacterSight>();
        // decision = characterInSight.Ping() && characterInSight.IsEnemyInSight();
        var character = stateMachine.GetComponent<CharacterCore>();
        decision = character.IsInCombat();
        return decision;
    }
}
