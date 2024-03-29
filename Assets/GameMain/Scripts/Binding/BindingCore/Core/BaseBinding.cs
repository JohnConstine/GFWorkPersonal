using UnityEngine;

namespace SG1
{
    public abstract class BaseBinding : UICustomBehaviour, IBaseBinding
    {
        [SerializeField] private ModelView m_ModelView;

        public ModelView ModelView
        {
            get { return m_ModelView != null ? m_ModelView : m_ModelView = GetComponentInParent<ModelView>(); }
            set { m_ModelView = value; }
        }

        private bool m_Binded;

        private bool m_IgnoreChanges;

        protected abstract bool Bind();

        protected abstract void Unbind();

        public bool Binded
        {
            get { return m_Binded; }
        }

        public bool IgnoreChanges
        {
            get { return m_IgnoreChanges; }
            protected set { m_IgnoreChanges = value; }
        }

        public void OnContextChange()
        {
            UpdateBinding();
        }

        internal void UpdateBinding()
        {
            Unbind();
            m_Binded = Bind();
            OnChange();
        }

        protected override void Start()
        {
            if (!m_Binded)
            {
                UpdateBinding();
            }
            else
            {
                OnChange();
            }
        }

        protected override void OnDestroy()
        {
            Unbind();
        }

        protected abstract void OnChange();

        public string GetTextValue(Property property)
        {
            if (property == null)
            {
                return string.Empty;
            }
            else if (property is Property<string>)
            {
                return ((Property<string>) property).GetValue();
            }
            else if (property is Property<int>)
            {
                return ((Property<int>) property).GetValue().ToString();
            }
            else if (property is Property<float>)
            {
                return ((Property<float>) property).GetValue().ToString("R");
            }
            else if (property is Property<double>)
            {
                return ((Property<double>) property).GetValue().ToString("R");
            }
//            else if (property is Property<long>)
//            {
//                return ((Property<long>) property).GetValue();
//            }
//            else if (property is Property<short>)
//            {
//                return ((Property<short>) property).GetValue();
//            }
//            else if (property is Property<byte>)
//            {
//                return ((Property<byte>) property).GetValue();
//            }
            else
            {
                return string.Empty;
            }
        }

        public void SetTextValue(Property property, string value)
        {
            if (property is Property<string>)
            {
                ((Property<string>) property).SetValue(value);
            }
            else if (property is Property<int>)
            {
                int v;
                if (int.TryParse(value, out v))
                {
                    ((Property<int>) property).SetValue(v);
                }
            }
            else if (property is Property<float>)
            {
                float v;
                if (float.TryParse(value, out v))
                {
                    ((Property<float>) property).SetValue(v);
                }
            }
            else if (property is Property<double>)
            {
                double v;
                if (double.TryParse(value, out v))
                {
                    ((Property<double>) property).SetValue(v);
                }
            }

//            else if (property is Property<long>)
//            {
//                if (long.TryParse(value, out var v))
//                {
//                    ((Property<long>) property).SetValue(v);
//                }
//            }
//            else if (property is Property<short>)
//            {
//                if (short.TryParse(value, out var v))
//                {
//                    ((Property<short>) property).SetValue(v);
//                }
//            }
//            else if (property is Property<byte>)
//            {
//                if (byte.TryParse(value, out var v))
//                {
//                    ((Property<byte>) property).SetValue(v);
//                }
//            }
        }

        public double GetNumericValue(Property property)
        {
            if (property == null)
            {
                return 0;
            }
            else if (property is Property<int>)
            {
                return ((Property<int>) property).GetValue();
            }
            else if (property is Property<float>)
            {
                return ((Property<float>) property).GetValue();
            }
            else if (property is Property<double>)
            {
                return ((Property<double>) property).GetValue();
            }

//            else if (property is Property<long>)
//            {
//                return ((Property<long>) property).GetValue();
//            }
//            else if (property is Property<short>)
//            {
//                return ((Property<short>) property).GetValue();
//            }
//            else if (property is Property<byte>)
//            {
//                return ((Property<byte>) property).GetValue();
//            }
            return 0;
        }

        public void SetNumericValue(Property property, double val)
        {
            if (property is Property<int>)
            {
                ((Property<int>) property).SetValue((int) val);
            }
            else if (property is Property<float>)
            {
                ((Property<float>) property).SetValue((float) val);
            }
            else if (property is Property<double>)
            {
                ((Property<double>) property).SetValue(val);
            }

//            else if (property is Property<long> _)
//            {
//                ((Property<long>) property).SetValue((long) val);
//            }
//            else if (property is Property<short> _)
//            {
//                ((Property<short>) property).SetValue((short) val);
//            }
//            else if (property is Property<byte> _)
//            {
//                ((Property<byte>) property).SetValue((byte) val);
//            }
        }

        public object GetRowValue(Property property)
        {
            if (property == null)
            {
                return (object) null;
            }

            return property.GetRowValue();
        }

        public Color GetColorValue(Property property)
        {
            if (property == null)
            {
                return Color.white;
            }
            else if (property is Property<Color>)
            {
                return (property as Property<Color>).GetValue();
            }
            else if (property is Property<Color32>)
            {
                return (property as Property<Color32>).GetValue();
            }

            return Color.white;
        }
    }
}