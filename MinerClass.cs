using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class MinerClass
    {
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
            int[] dr = { 1, 0, -1, 0 }, dc = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; i++)
            {
                int r = pos.ROW, c = pos.COL;
                int nr = r, nc = c;
                while (true) {
                    nr += dr[i]; nc+= dc[i];
                    if (GameBoardClass.IsOutPosition(nr, nc)) break;
                    char piece = now.GetPiece(nr, nc);
                    if (GameBoardClass.IsEmpty(piece))
                    {
                        //Move
                        GameBoardClass nxtgB = new GameBoardClass(now);
                        nxtgB.Go(r, c, nr, nc);
                        gBNxtList.Add(nxtgB);
                    }
                    else if (GameBoardClass.IsAlly(piece))
                    {
                        break;
                    }
                    else if ((GameBoardClass.IsEnemy(piece) && !now.IsSentinelNearHere(nr, nc)) || piece == '#')
                    {
                        //Capture
                        GameBoardClass nxtgB = new GameBoardClass(now);
                        nxtgB.Go(r, c, nr, nc);
                        gBNxtList.Add(nxtgB);
                        break;
                    }

                }
            }

            return gBNxtList;
        }

        static public int GetScore()
        {
            return 4;
        }

    }
}
