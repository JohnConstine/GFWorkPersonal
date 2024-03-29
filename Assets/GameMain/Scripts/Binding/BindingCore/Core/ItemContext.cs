using System;

namespace SG1
{
    public class ItemContext : Context
    {
        private Action<ItemContext> m_OnItemClick;

        public event Action<ItemContext> OnItemClick
        {
            add
            {
                m_OnItemClick -= value; 
                m_OnItemClick += value;
            }
            remove { m_OnItemClick -= value; }
        }

        private int m_Index;

        public int Index
        {
            get { return m_Index; }
            internal set { m_Index = value; }
        }

        public virtual void Click()
        {
            if (m_OnItemClick != null)
            {
                m_OnItemClick.Invoke(this);
            }
        }
    }
}