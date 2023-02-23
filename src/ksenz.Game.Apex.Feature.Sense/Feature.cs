using ksenz.Game.Apex.Core;
using ksenz.Game.Apex.Core.Interfaces;
using ksenz.Game.Apex.Core.Models;
using ksenz.Core.Models;

namespace ksenz.Game.Apex.Feature.Sense
{
    public class Feature : IFeature
    {
        private readonly Config _config;

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
                        if (localPlayer.LocalOrigin.Distance2(player.LocalOrigin) * Constants.UnitToMeter < _config.Distance)
                        {
                            player.GlowEnable = (byte)(1);
                            player.GlowThroughWalls = (byte)(player.Visible ? 2 : 2);
                            if (player.Visible)
                            {
                                player.GlowColor = new Vector(0.0f, 2.0f, 0.0f);
                            }
                            else if (player.Shield >= 120)
                            {
                                player.GlowColor = new Vector(2.0f, 0.0f, 0.0f);
                            }
                            else if (player.Shield >= 100)
                            {
                                player.GlowColor = new Vector(1.5f, 0.0f, 1.5f);
                            }
                            else if (player.Shield >= 75)
                            {
                                player.GlowColor = new Vector(0.0f, 1.0f, 2.0f);
                            }
                            else
                            {
                                player.GlowColor = new Vector (1.0f, 1.0f, 1.0f);
                                //player.GlowColor = (player.Visible? new Vector(10.0f, 0.0f, 0.0f) : new Vector(0.0f, 11.0f, 15.0f));
                            }
                            /*if (_config.Distance != 333)
                            {
                                player.GlowThroughWalls = (byte)(player.Visible ? 1 : 2);
                            }*/
                        }
                        else if (player.GlowEnable is 5 or 7)
                        {
                            player.GlowEnable = 2;
                            player.GlowThroughWalls = 5;
                            /*if (_config.Distance != 333)
                            {
                                player.GlowThroughWalls = 5;
                            }*/
                        }
                    }
                }
            }
        }

        #endregion
    }
}
