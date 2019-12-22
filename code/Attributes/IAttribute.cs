using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace attributeSystem.rts.twod
{
    public enum AttributeState
    {
        InProgress,
        Done,
        Loop
    }

    [System.Serializable]
    public abstract class IamAttribute : ScriptableObject
    {
        public bool isActivelyUsed = true;
        public abstract AttributeState UpdateLogic(AttributesContainer _State);
    }
}