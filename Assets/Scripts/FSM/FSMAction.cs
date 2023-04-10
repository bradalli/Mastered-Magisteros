using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.Brad
{
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine stateMachine);
    }
}

