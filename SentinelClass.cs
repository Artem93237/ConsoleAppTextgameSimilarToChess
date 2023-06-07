using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class SentinelClass
    {
        public static List<GameBoardClass> GetNextBoardStates(GameBoardClass now, PointClass pos)
        {
            List<GameBoardClass> gBNxtList = new List<GameBoardClass>();
            PointClass nxtPt = new PointClass();
            int[] dr = { 1, 0, -1, 0 }, dc = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; i++)
            {
                int r = pos.ROW, c = pos.COL;
                int nr = r + dr[i], nc = c + dc[i];
                if (!now.IsEmpty(nr, nc)) continue;
                if (dr[i] == 0)
                {
                    nr++; nc += dc[i];
                    if (!GameBoardClass.IsOutPosition(nr, nc) && now.IsEmpty(nr, nc))
                    {
                        GameBoardClass nxtgB = new GameBoardClass(now);
                        nxtgB.Go(r, c, nr, nc);
                        gBNxtList.Add(nxtgB);
                    }
                    nr -= 2;
                    if (!GameBoardClass.IsOutPosition(nr, nc) && now.IsEmpty(nr, nc))
                    {
                        GameBoardClass nxtgB = new GameBoardClass(now);
                        nxtgB.Go(r, c, nr, nc);
                        gBNxtList.Add(nxtgB);
                    }
                }
            }

            return gBNxtList;
        }

        public static int GetScore()
        {
            return 5;
        }
    }
}
