using System;

namespace Jing.Feature.InfomationManager
{
    public interface IPlayerInfoManager
    {
        #region ::: Action :::
        Action<int> Action_Affection { get; set; }
        Action<int> Action_Money { get; set; }
        Action<int> Action_Strength { get; set; }
        #endregion

        int Money { get; set; }
        int Strength { get; set; }
        int Affection { get; set; }


        void UpdateAffection(int count);
        void UpdateMoney(int count);
        void UpdateStrength(int count);
    }
}