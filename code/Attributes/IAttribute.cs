﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace attributeSystem.rts.twod
{
    public interface IAttribute<T>
    {
        void UpdateLogic(T data);
    }

}