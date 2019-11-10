using System.Collections;
using System.Collections.Generic;
using StarForce;
using UnityEngine;

namespace SG1
{
    public class MapData : EntityData
    {
        private Vector2 m_Scale;

        public Vector2 Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        public MapData(int entityId, int typeId) : base(entityId, typeId)
        {
            
        }
    }
}

