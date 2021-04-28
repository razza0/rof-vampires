using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Vampire
{
    public static class Cache
    {
        public static Dictionary<int, bool> IsDaylight = new Dictionary<int, bool>();
        public static Dictionary<int, int> IsDaylightLastRun = new Dictionary<int, int>();

        public static Dictionary<int, int> TicksPerMoveCardinal = new Dictionary<int, int>();
        public static Dictionary<int, int> TicksPerMoveCardinalLastRun = new Dictionary<int, int>();

        public static Dictionary<int, int> TicksPerMoveDiagonal = new Dictionary<int, int>();
        public static Dictionary<int, int> TicksPerMoveDiagonalLastRun = new Dictionary<int, int>();

        public static int getTicksPerMoveCardinal(Pawn p)
        {
            if (!TicksPerMoveCardinal.ContainsKey(p.thingIDNumber))
            {
                TicksPerMoveCardinalLastRun[p.thingIDNumber] = -9999;
                TicksPerMoveCardinal[p.thingIDNumber] = 0;
            }

            if (Find.TickManager.TicksGame > (TicksPerMoveCardinalLastRun[p.thingIDNumber] + 416) || Find.TickManager.TicksGame < TicksPerMoveCardinalLastRun[p.thingIDNumber])
            {
                TicksPerMoveCardinalLastRun[p.thingIDNumber] = Find.TickManager.TicksGame;
                TicksPerMoveCardinal[p.thingIDNumber] = p.TicksPerMoveCardinal;
            }
            return TicksPerMoveCardinal[p.thingIDNumber];
        }

        public static int getTicksPerMoveDiagonal(Pawn p)
        {
            if (!TicksPerMoveDiagonal.ContainsKey(p.thingIDNumber))
            {
                TicksPerMoveDiagonalLastRun[p.thingIDNumber] = -9999;
                TicksPerMoveDiagonal[p.thingIDNumber] = 0;
            }

            if (Find.TickManager.TicksGame > (TicksPerMoveDiagonalLastRun[p.thingIDNumber] + 416) || Find.TickManager.TicksGame < TicksPerMoveDiagonalLastRun[p.thingIDNumber])
            {
                TicksPerMoveDiagonalLastRun[p.thingIDNumber] = Find.TickManager.TicksGame;
                TicksPerMoveDiagonal[p.thingIDNumber] = p.TicksPerMoveDiagonal;
            }
            return TicksPerMoveDiagonal[p.thingIDNumber];
        }
    }
}
