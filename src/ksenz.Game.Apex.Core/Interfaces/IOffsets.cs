namespace ksenz.Game.Apex.Core.Interfaces
{
    public interface IOffsets
    {
        #region Properties

        uint ButtonInAttack { get; }
        uint ButtonInWalk { get; }
        uint ButtonInZoom { get; }
        uint ButtonInForward { get; }
        uint ButtonInForwardState { get; }
        uint CoreEntityList { get; }
        uint CoreLevelName { get; }
        uint CoreLocalPlayer { get; }
        uint EntityLastVisibleTime { get; }
        uint EntityLocalOrigin { get; }
        uint EntitySignifierName { get; }
        uint PlayerBleedoutState { get; }
        uint PlayerDuckState { get; }
        uint PlayerGlowEnable { get; }
        uint PlayerGlowThroughWall { get; }
        uint PlayerLifeState { get; }
        uint PlayerName { get; }
        uint PlayerTeamNum { get; }
        uint PlayerVecPunchWeaponAngle { get; }
        uint PlayerViewAngle { get; }
        uint PlayerFlags { get; }
        uint PlayerGlowColor { get; }
        uint PlayerShield { get; }

        #endregion
    }
}
