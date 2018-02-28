﻿namespace HZBot
{
    public class CharacterStat
    {
        #region Constructors

        public CharacterStat(double Gewichtung)
        {
            this.Gewichtung = Gewichtung;
        }

        #endregion Constructors

        #region Properties

        public StatType StatType { get; set; }
        public int BaseValue { get; set; }
        public int BoughtValue { get; set; }
        public int TotalValue { get; set; }
        public int TrainingValue { get; set; }
        public int TrainingMaxValue { get; set; }
        public int MaxValue { get; set; }
        public double Gewichtung { get; }

        #endregion Properties
    }
}