using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class CatapultClass
    {
        public static List<GameBoardClass> GetNextBoardStates(GameBoardClass now, PointClass pos)
        {
            List<GameBoardClass> gBNxtList = new List<GameBoardClass>();
            PointClass nxtPt = new PointClass();
            int[] dr = { 1, 0, -1, 0 }, dc = { 0, 1, 0, -1 };
            int r = pos.ROW, c = pos.COL;
            for (int i = 0; i < 4; i++)
            {
                int nr = r + dr[i], nc = c + dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                if (!now.IsEmpty(nr, nc)) continue;
                GameBoardClass nxtbG = new GameBoardClass(now);
                nxtbG.Go(r, c, nr, nc);
                gBNxtList.Add(nxtbG);
            }

            for (int i = 0; i < 4; i++)
            {
                int nr = r + 3 * dr[i], nc = c + 3 * dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                char piece = now.GetPiece(nr, nc);
                if (GameBoardClass.IsEnemy(piece) && !now.IsSentinelNearHere(nr, nc))
                {
                    GameBoardClass nxtbG = new GameBoardClass(now);
                    nxtbG.SetPiece(nr, nc, '.');
                    gBNxtList.Add(nxtbG);
                }
            }

            dr = new int[] { 1, 1, -1, -1 };
            dc = new int[] { 1, -1, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int nr = r + 2 * dr[i], nc = c + 2 * dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                char piece = now.GetPiece(nr, nc);
                if (GameBoardClass.IsEnemy(piece) && !now.IsSentinelNearHere(nr, nc))
                {
                    GameBoardClass nxtbG = new GameBoardClass(now);
                    nxtbG.SetPiece(nr, nc, '.');
                    gBNxtList.Add(nxtbG);
                }
            }
            return gBNxtList;
        }

        public static int GetScore()
        {
            return 6;
        }

    }
}
