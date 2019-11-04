using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synergy.Model.Baseball;

namespace Synergy.Data.Baseball.Calculators
{
    public class ZoneCalculator : IZoneCalculator
    {
        /// <summary>
        /// Sets pitch zone number based on the drawing at https://i.ibb.co/B6gzjMW/Pitch-Zones.jpg
        /// </summary>
        /// <param name="pitch"></param>
        public void PerformCalculation(PitchEvent pitch)
        {
            pitch.Zone = CalculateZone(pitch);
        }

        private int CalculateZone(PitchEvent pitch)
        {
            if (pitch.SzTop == 0.0 || pitch.SzBot == 0.0)
            {
                return 0; // return 0 if SzTop and SzBot is 0 (business requirement)
            }

            double zoneHeight = pitch.SzTop - pitch.SzBot; //feet
            double zoneWidth = (double)17 / 12; //Baseball standard numbers. In feets.
            double halfZoneWidth = zoneWidth / 2; //feet
            double ballDiameter = 2.94 / 12; //Baseball standard numbers. In feets.

            // zone 2, 5, 8, 12, 23
            if (Math.Abs(pitch.Px) <= zoneWidth / 6)
            {
                // zone 2
                if (pitch.Pz <= pitch.SzTop && pitch.Pz > (pitch.SzTop - zoneHeight / 3))
                {
                    return 2;
                }

                // zone 5
                if (pitch.Pz <= (pitch.SzTop - zoneHeight / 3) && pitch.Pz >= (pitch.SzBot + zoneHeight / 3))
                {
                    return 5;
                }

                // zone 8
                if (pitch.Pz >= pitch.SzBot && pitch.Pz < (pitch.SzBot + zoneHeight / 3))
                {
                    return 8;
                }

                // zone 12
                if (pitch.Pz > pitch.SzTop && pitch.Pz <= (pitch.SzTop + ballDiameter))
                {
                    return 12;
                }

                // zone 23
                if (pitch.Pz < pitch.SzBot && pitch.Pz >= (pitch.SzBot - ballDiameter))
                {
                    return 23;
                }
            }

            // zone 1, 4, 7, 11, 22
            if (pitch.Px >= (halfZoneWidth * -1) && pitch.Px < (zoneWidth / -6))
            {
                // zone 1
                if (pitch.Pz <= pitch.SzTop && pitch.Pz > (pitch.SzTop - zoneHeight / 3))
                {
                    return 1;
                }

                // zone 4
                if (pitch.Pz <= (pitch.SzTop - zoneHeight / 3) && pitch.Pz >= (pitch.SzBot + zoneHeight / 3))
                {
                    return 4;
                }

                // zone 7
                if (pitch.Pz >= pitch.SzBot && pitch.Pz < (pitch.SzBot + zoneHeight / 3))
                {
                    return 7;
                }

                // zone 11
                if (pitch.Pz > pitch.SzTop && pitch.Pz <= (pitch.SzTop + ballDiameter))
                {
                    return 11;
                }

                // zone 22
                if (pitch.Pz < pitch.SzBot && pitch.Pz >= (pitch.SzBot - ballDiameter))
                {
                    return 22;
                }
            }

            // zone 3, 6, 9, 13, 24
            if (pitch.Px > (zoneWidth / 6) && pitch.Px <= halfZoneWidth)
            {
                // zone 3
                if (pitch.Pz <= pitch.SzTop && pitch.Pz > (pitch.SzTop - zoneHeight / 3))
                {
                    return 3;
                }

                // zone 6
                if (pitch.Pz <= (pitch.SzTop - zoneHeight / 3) && pitch.Pz >= (pitch.SzBot + zoneHeight / 3))
                {
                    return 6;
                }

                // zone 9
                if (pitch.Pz >= pitch.SzBot && pitch.Pz < (pitch.SzBot + zoneHeight / 3))
                {
                    return 9;
                }

                // zone 13
                if (pitch.Pz > pitch.SzTop && pitch.Pz <= (pitch.SzTop + ballDiameter))
                {
                    return 13;
                }

                // zone 24
                if (pitch.Pz < pitch.SzBot && pitch.Pz >= (pitch.SzBot - ballDiameter))
                {
                    return 24;
                }
            }

            // zone 10, 15, 17, 19, 21
            if (pitch.Px >= ((halfZoneWidth + ballDiameter) * -1) && pitch.Px < (halfZoneWidth * -1))
            {
                // zone 10
                if (pitch.Pz > pitch.SzTop && pitch.Pz <= (pitch.SzTop + ballDiameter))
                {
                    return 10;
                }

                // zone 15
                if (pitch.Pz <= pitch.SzTop && pitch.Pz > (pitch.SzTop - zoneHeight / 3))
                {
                    return 15;
                }

                // zone 17
                if (pitch.Pz <= (pitch.SzTop - zoneHeight / 3) && pitch.Pz >= (pitch.SzBot + zoneHeight / 3))
                {
                    return 17;
                }

                // zone 19
                if (pitch.Pz >= pitch.SzBot && pitch.Pz < (pitch.SzBot + zoneHeight / 3))
                {
                    return 19;
                }

                // zone 21
                if (pitch.Pz < pitch.SzBot && pitch.Pz >= (pitch.SzBot - ballDiameter))
                {
                    return 21;
                }
            }

            // zone 14, 16, 18, 20, 25
            if (pitch.Px <= (halfZoneWidth + ballDiameter) && pitch.Px > halfZoneWidth)
            {
                // zone 14
                if (pitch.Pz > pitch.SzTop && pitch.Pz <= (pitch.SzTop + ballDiameter))
                {
                    return 14;
                }

                // zone 16
                if (pitch.Pz <= pitch.SzTop && pitch.Pz > (pitch.SzTop - zoneHeight / 3))
                {
                    return 16;
                }

                // zone 18
                if (pitch.Pz <= (pitch.SzTop - zoneHeight / 3) && pitch.Pz >= (pitch.SzBot + zoneHeight / 3))
                {
                    return 18;
                }

                // zone 20
                if (pitch.Pz >= pitch.SzBot && pitch.Pz < (pitch.SzBot + zoneHeight / 3))
                {
                    return 20;
                }

                // zone 25
                if (pitch.Pz < pitch.SzBot && pitch.Pz >= (pitch.SzBot - ballDiameter))
                {
                    return 25;
                }
            }

            // zone 27, 32
            if (Math.Abs(pitch.Px) <= halfZoneWidth)
            {
                // zone 27
                if (pitch.Pz > (pitch.SzTop + ballDiameter))
                {
                    return 27;
                }

                // zone 32
                if (pitch.Pz < (pitch.SzBot - ballDiameter))
                {
                    return 32;
                }
            }

            // zone 29, 30
            if (pitch.Pz >= pitch.SzBot && pitch.Pz <= pitch.SzTop)
            {
                // zone 29
                if (pitch.Px < ((halfZoneWidth + ballDiameter) * -1))
                {
                    return 29;
                }

                // zone 30
                if (pitch.Px > (halfZoneWidth + ballDiameter))
                {
                    return 30;
                }
            }

            // zone 26
            if (pitch.Pz > pitch.SzTop && pitch.Px < (halfZoneWidth * -1))
            {
                // exclude zone 10
                if (pitch.Pz <= (pitch.SzTop + ballDiameter) && pitch.Px >= ((halfZoneWidth + ballDiameter) * -1))
                {
                    return 10;
                }

                return 26;
            }

            // zone 28
            if (pitch.Pz > pitch.SzTop && pitch.Px > halfZoneWidth)
            {
                // exclude zone 14
                if (pitch.Pz <= (pitch.SzTop + ballDiameter) && pitch.Px <= (halfZoneWidth + ballDiameter))
                {
                    return 14;
                }

                return 28;
            }

            // zone 31
            if (pitch.Pz < pitch.SzBot && pitch.Px < (halfZoneWidth * -1))
            {
                // exclude zone 21
                if (pitch.Pz >= (pitch.SzBot - ballDiameter) && pitch.Px >= ((halfZoneWidth + ballDiameter) * -1))
                {
                    return 21;
                }

                return 31;
            }

            // zone 33
            if (pitch.Pz < pitch.SzBot && pitch.Px > halfZoneWidth)
            {
                // exclude zone 25
                if (pitch.Pz >= (pitch.SzBot - ballDiameter) && pitch.Px <= (halfZoneWidth + ballDiameter))
                {
                    return 25;
                }

                return 33;
            }

            throw new ArgumentOutOfRangeException("Pitch.Px and Pitch.Pz does not fall into any region.");
        }
    }
}
