using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.NPC;

[CreateAssetMenu(menuName = "FSM/Decisions/WPReceiveDecision")]
public class WPReceiveDecision : Decision
{
    public KeyCode debugAdvanceKey;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        var characterInfo = stateMachine.GetComponent<NPCharacter>();
        decision = characterInfo.AreWaypointsRemaining() && !characterInfo.IsAnActionBeingPerfomed();
        return decision;
    }
}
