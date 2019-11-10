using GameFramework;

namespace SG1
{
    public class VarUser : Variable<VarUser>
    {
        private int m_Score;

        private int m_HighScore;

        public int HighScore
        {
            get { return m_HighScore; }
            set { m_HighScore = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
    }

}

