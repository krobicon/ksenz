using ksenz.Game.Apex.Core;
using ksenz.Game.Apex.Core.Interfaces;

namespace ksenz.Game.Apex.Feature.Sense
{
    public class Feature : IFeature
    {
        private readonly Config _config;
        private bool status;
        private bool press;
        private bool release;
        private bool force;

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
                        if (localPlayer.LocalOrigin.Distance2(player.LocalOrigin) * Constants.UnitToMeter < _config.Distance && (state.Buttons.InForwardState == 33))
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
                //status = (state.Buttons.InForwardState & 1) != 0;
                if (!localPlayer.IsGrounded())
                {
                    force = true;
                    if (!release)
                    {
                        press = false;
                        release = true;
                    }
                    else
                    {
                        release = false;
                        press = true;
                    }
                }
                else
                {
                    if (release && state.Buttons.InForwardDown1 != 0)
                    {
                        release = false;
                        press = true;
                    }
                    else if (press && state.Buttons.InForwardDown1 != 0) 
                    {
                        force = false;
                    }
                    else if (press && state.Buttons.InForwardDown1 == 0) 
                    {
                        release = true;
                        press = false;
                    }
                    else if(release && state.Buttons.InForwardDown1 == 0) 
                    {
                        force = false;
                    }
                }
                if (force)
                {
                    int st;
                    if (press && !release) 
                    {
			            st = 5;
		            }
                    else if (!press && release) 
                    {
			            st = 0;
		            }
                    else 
                    {
		    	if (state.Buttons.InForwardDown1 == 0 && state.Buttons.InForwardDown2 == 0)
			{
				st = 0;
			}
			else 
			{
				st = 5;
			}
		    }
                    if (state.Buttons.InForwardState != st) 
                    {
			            state.Buttons.InForwardState = (byte)st;
		            }
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
