using ksenz.Game.Apex.Core;
using ksenz.Game.Apex.Core.Interfaces;

namespace ksenz.Game.Apex.Feature.Sense
{
    public class Feature : IFeature
    {
        private readonly Config _config;
        private uint previousState;

        #region Constructors

        public Feature(Config config)
        {
            _config = config;
        }

        #endregion

        #region Implementation of IFeature

        public void Tick(DateTime frameTime, State state)
        {
            if (state.Players.TryGetValue(state.LocalPlayer, out var localPlayer))
            {
                foreach (var (_, player) in state.Players)
                {
                    if (player.IsValid() && !player.IsSameTeam(localPlayer))
                    {
                        if (localPlayer.LocalOrigin.Distance2(player.LocalOrigin) * Constants.UnitToMeter < _config.Distance && (state.Buttons.InForwardDown1 ==0 && state.Buttons.InForwardDown2 == 0))
                        {
                            player.GlowEnable = (byte)(player.Visible ? 5 : 7);
                            if (_config.Distance != 333)
                            {
                                player.GlowThroughWalls = (byte)(player.Visible ? 1 : 2);
                            }
                        }
                        else if (player.GlowEnable is 5 or 7)
                        {
                            player.GlowEnable = 2;
                            if (_config.Distance != 333)
                            {
                                player.GlowThroughWalls = 5;
                            }
                        }
                    }
                }
                if (localPlayer.IsGrounded())
                {
                    if (state.Buttons.InForwardState == 0)
                    {
                        state.Buttons.InForwardState = 5;
                    }
                    else
                    {
                        state.Buttons.InForwardState = 0;
                    }
                    /*if (state.Buttons.InForwardDown1 == 0 && state.Buttons.InForwardDown2 == 0)
                    {
                        if (state.Buttons.InForwardState == 0)
                        {
                            state.Buttons.InForwardState = 5;
                        }
                        else
                        {
                            state.Buttons.InForwardState = 4;
                        }
                    }*/
                }
                    /*if (state.Buttons.InForwardDown1 == 0 && state.Buttons.InForwardDown2 == 0)
                    {
                        if (previousState != 5)
                        {
                            state.Buttons.InForwardState = 5;
                            previousState = 5;
                        }
                        else
                        {
                            state.Buttons.InForwardState = 4;
                            previousState = 4;
                        }
                    }*/
            }
        }

        #endregion
    }
}
