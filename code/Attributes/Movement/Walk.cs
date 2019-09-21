using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace attributeSystem.rts.twod
{
    public class Walk : IAttribute<WalkData>
    {

        public void UpdateLogic(WalkData data)
        {
            Debug.Log("Update logic of Attribute Walk");
        }
    }

    public struct WalkData
    {
        int Test;
    }
}