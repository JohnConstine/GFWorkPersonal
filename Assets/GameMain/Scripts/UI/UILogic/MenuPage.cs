using DG.Tweening;
using StarForce;
using UnityEngine;

namespace SG1
{
    public class MenuPageModel : UGuiFormModel<MenuPage, MenuPageModel>
    {
        public void ControlVoice()
        {
        }

        
        public void StartGame()
        {
            Page.StartGame();
        }
    }

    public class MenuPage : UGuiFormPage<MenuPage, MenuPageModel>
    {
        [SerializeField] private RectTransform m_Star = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            
            m_Star.localPosition = Vector3.zero;
            m_Star.DOLocalJump(new Vector3(0, 30), 1, 1, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        public void StartGame()
        {
            
            Close();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            GameEntry.UI.OpenUIForm(UIFormId.BattlePage, this);
            m_Star.DOKill();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}