using System.Threading.Tasks;

namespace Assets.Scripts.Objects.Entities.Stats {
    internal sealed class Buff : Stat {
        /// <summary>
        /// <list type="bullet">
        /// <item> (add, subtract, multiply, divide) � Math operation </item>
        /// <item> custom � Use a custom <see cref="Task"/>&lt;<see cref="bool"/>&gt; </item>
        /// </list>
        /// </summary>
        internal enum BuffTask {
            add, subtract, multiply, divide,
            custom
        }


        #region Helper

        internal bool toggle(bool enable = default) {
            if (enable == default) this.isEnabled = !this.isEnabled;
            this.isEnabled = enable;
            return this.isEnabled;
        }

        #endregion


        internal override StatName statName { get; }
        internal bool isEnabled { get; set; }
        internal System.Type statType { get; set; }
        internal float amount { get; set; }
        internal BuffTask buffTask { get; set; }

        internal Buff(
                System.Type statType,
                float amount,
                BuffTask buffTask,
                bool enableNow = true) {
            if (!statType.IsAssignableFrom(typeof(Stat)))
                throw new System.ArgumentException("statType must be assignable from the type Stat");
            this.statName = StatName.Buff;
            this.statType = statType;
            this.amount = amount;
            this.buffTask = buffTask;
            this.isEnabled = enableNow;
        }
    }
}
