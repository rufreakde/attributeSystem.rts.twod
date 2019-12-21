using manager.ioc;
using UnityEngine;

namespace attributeSystem.rts.twod
{
    [CreateAssetMenu(fileName = "WalkAttributeData", menuName = "ScriptableObjects/Attribut/Walk", order = 1)]
    public class Walk : IamAttribute, IJsonSerialize<Walk>, IJsonDeserialize<Walk>
    {
        public string testChild = "works";

        public bool deserializationFinished { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool deserializationCheck()
        {
            if(!deserializationFinished)
            {
                Debug.LogError("Error Deserialization failed!", this);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Deserialize(Walk _Data)
        {
            this.Deserialize(this);
            this.deserializationFinished = true;
        }

        public void Serialize(Walk _Data)
        {
            this.Serialize(this);
        }

        public override void UpdateLogic()
        {
            Debug.Log("Update logic of Attribute Walk");
        }
    }
}