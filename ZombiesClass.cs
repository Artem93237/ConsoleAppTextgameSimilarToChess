using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class ZombiesClass
    {
        public ZombiesClass()
        {

        }
        /// <summary>
        /// Get the Next possible GameBoard list from current board
        /// Done but not check
        /// </summary>
        /// <param name="now">The current game board state</param>
        /// <param name="pos">pos to move</param>
        /// <returns></returns>
        public static List<GameBoardClass> GetNextBoardStates(GameBoardClass now, PointClass pos)
        {
            List<GameBoardClass> gBNxtList = new List<GameBoardClass>();
            PointClass nxtPt = new PointClass();
            int[] dr = { 1, 1, 1 }, dc = { -1, 0, 1 };
            for (int i = 0; i < 3; i++)
            {
                int r = pos.ROW, c = pos.COL;
                int nr = r + dr[i], nc = c + dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                char piece = now.GetPiece(nr, nc);
                if (GameBoardClass.IsEmpty(piece))
                {
                    GameBoardClass nxtgB = new GameBoardClass(now);
                    nxtgB.Go(r, c, nr, nc);
                    gBNxtList.Add(nxtgB);

                    nr += dr[i]; nc += dc[i];
                    if (GameBoardClass.IsOutPosition(nr, nc))
                    {
                        piece = now.GetPiece(nr, nc);
                        if (GameBoardClass.IsEnemy(piece) && now.IsSentinelNearHere(nr, nc) == false)
                        {
                            nxtgB = new GameBoardClass(now);
                            nxtgB.Go(r, c, nr, nc);
                            gBNxtList.Add(nxtgB);
                        }
                    }
                }
                else if (GameBoardClass.IsEnemy(piece) && now.IsSentinelNearHere(nr, nc) == false)
                {
                    GameBoardClass nxtgB = new GameBoardClass(now);
                    nxtgB.Go(r, c, nr, nc);
                    gBNxtList.Add(nxtgB);
                }
            }

            return gBNxtList;
        }
        public static int GetScore()
        {
            return 1;
        }
    }
}
