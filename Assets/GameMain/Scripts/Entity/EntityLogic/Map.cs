using UnityGameFramework.Runtime;
using Entity = StarForce.Entity;

namespace SG1
{
    public class Map : Entity
    {
        private MapData m_MapData;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_MapData = (MapData) userData;

            if (m_MapData == null)
            {
                Log.Error("Map IS Devlid");
                return;
            }

            CachedTransform.localScale = m_MapData.Scale;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
    }
}

