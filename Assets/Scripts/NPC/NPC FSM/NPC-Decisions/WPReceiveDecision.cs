using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;

[CreateAssetMenu(menuName = "FSM/Decisions/WPReceiveDecision")]
public class WPReceiveDecision : Decision
{
    public KeyCode debugAdvanceKey;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        var characterInfo = stateMachine.GetComponent<CharacterInfo>();
        decision = characterInfo.AreWaypointsRemaining() && !characterInfo.IsATaskBeingPerformed();
        return decision;
    }
}