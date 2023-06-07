using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class GeneralClass
    {
        public static List<GameBoardClass> GetNextBoardStates(GameBoardClass now, PointClass pos)
        {
            List<GameBoardClass> gBNxtList = new List<GameBoardClass>();
            PointClass nxtPt = new PointClass();
            int[] dr = { 1, 1, 1, 0, -1, -1, -1, 0 }, dc = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int r = pos.ROW, c = pos.COL;
            for (int i = 0; i < 8; i++)
            {
                int nr = r + dr[i], nc = c + dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                char piece = now.GetPiece(nr, nc);
                if (now.IsEmpty(nr, nc) || (GameBoardClass.IsEnemy(piece) && !now.IsSentinelNearHere(nr, nc))) continue;
                GameBoardClass nxtgB = new GameBoardClass(now);
                nxtgB.Go(r, c, nr, nc);
                gBNxtList.Add(nxtgB);
            }

            return gBNxtList;
        }

        static public int GetScore()
        {
            return 1000;
        }

    }
}
