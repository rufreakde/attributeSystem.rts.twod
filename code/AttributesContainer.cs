using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using manager.ioc;

namespace attributeSystem.rts.twod
{
    [System.Serializable]
    public class AttributesDictionary : CustomDict<string, IamAttribute>
    {
        public AttributesDictionary() : base()
        {
        }
    }

    public class AttributesContainer : MonoBehaviour
    {
        public AttributesDictionary Attributes;

        public List<IamAttribute> testList;

        public IamAttribute field;
    }
}