using ksenz.Game.Apex.Core;
using ksenz.Game.Apex.Core.Models;
using ksenz.Game.Apex.Feature.Aim.Enums;
using ksenz.Game.Apex.Feature.Aim.Interfaces;
using ksenz.Game.Apex.Feature.Aim.Models;

namespace ksenz.Game.Apex.Feature.Aim.Extensions
{
    public static class StateExtensions
    {
        #region Statics

        public static TargetType GetTargetType(this State state, Player localPlayer)
        {
            if (localPlayer.BleedoutState != 0)
            {
                return TargetType.None;
            }

            if (state.Buttons.InAttack != 0 && (state.Buttons.InZoom != 0 || localPlayer.VecPunchWeaponAngle.X != 0 || localPlayer.VecPunchWeaponAngle.Y != 0))
            {
                return state.Buttons.InWalk != 0 ? TargetType.All : TargetType.Enemy;
            }

            if (state.Buttons.InZoom != 0)
            {
                return TargetType.Enemy;
            }

            return TargetType.None;
        }

        public static IEnumerable<ITarget> IterateTargets(this State state)
        {
            foreach (var (_, npc) in state.Npcs)
            {
                yield return new NpcTarget(npc);
            }

            foreach (var (_, player) in state.Players)
            {
                yield return new PlayerTarget(player);
            }
        }

        #endregion
    }
}
