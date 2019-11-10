using System.Collections;
using System.Collections.Generic;
using GameFramework;
using StarForce;
using UnityEngine;

namespace SG1
{
    public class BattlePageModel : UGuiFormModel<BattlePage, BattlePageModel>
    {
        #region ScoreProperty

        private readonly Property<string> _privateScoreProperty = new Property<string>();

        public Property<string> ScoreProperty
        {
            get { return _privateScoreProperty; }
        }

        public string Score
        {
            get { return _privateScoreProperty.GetValue(); }
            set { _privateScoreProperty.SetValue(value); }
        }

        #endregion

        #region HighScoreProperty

        private readonly Property<string> _privateHighScoreProperty = new Property<string>();

        public Property<string> HighScoreProperty
        {
            get { return _privateHighScoreProperty; }
        }

        public string HighScore
        {
            get { return _privateHighScoreProperty.GetValue(); }
            set { _privateHighScoreProperty.SetValue(value); }
        }

        #endregion
    }

    public class BattlePage : UGuiFormPage<BattlePage, BattlePageModel>
    {
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //var user = GameEntry.DataNode.GetData<VarUser>(Constant.ProcedureData.UserData);
            
            Model.Score = Utility.Text.Format("分数:{0}",0);
            Model.HighScore = Utility.Text.Format("最高分数:{0}", 0);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }
    }

}

