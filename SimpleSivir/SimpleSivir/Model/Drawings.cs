﻿using System;
using System.Drawing;
using EloBuddy;
using SimpleSivir.Helpers;

namespace SimpleSivir.Model
{
    internal class Drawings : Model
    {
        static Drawings()
        {
            Drawing.OnDraw += DrawingOnOnDraw;
        }

        private static void DrawingOnOnDraw(EventArgs args)
        {
            try
            {
                DamageIndicator.HealthbarEnabled = Config.Drawings.IndicatorHealthbar;
                DamageIndicator.PercentEnabled = Config.Drawings.IndicatorPercent;
                if (Config.Drawings.DrawQ)
                    Drawing.DrawCircle(_Player.Position, Q.Range, Q.IsReady() ? Color.Aqua : Color.Red);
                if (Config.Drawings.DrawR)
                {
                    foreach (var buff in _Player.Buffs)
                    {
                        if (buff.Name.ToLower() == "sivirr")
                        {
                            var mypos = Drawing.WorldToScreen(_Player.Position);
                            var timer = buff.EndTime - Game.Time;
                            var fancy = string.Format("{0:0}", timer);
                            Drawing.DrawText(mypos[0] - 10, mypos[1] - 140, Color.Gold, "" + fancy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        public static void Initiliaze()
        {
        }
    }
}