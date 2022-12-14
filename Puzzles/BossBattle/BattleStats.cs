using System;

namespace Puzzle.BossBattle
{
    [Serializable]
    public struct BattleStats : IComparable<BattleStats>
    {
        public int Health;
        public int Defence;
        public int UpEnergy;
        public int DownEnergy;
        public int Speed;
        public int AttackCount;

        public int CompareTo(BattleStats other)
        {
            return Health.CompareTo(other.Health);
        }
    }
}
