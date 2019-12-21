using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace attributeSystem.rts.twod
{
    [System.Serializable]
    public abstract class IamAttribute : ScriptableObject
    {
        public int testParent = 1;
        public abstract void UpdateLogic();
    }

}