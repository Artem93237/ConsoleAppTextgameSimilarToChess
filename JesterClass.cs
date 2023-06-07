using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class JesterClass
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
            int[] dr = { 1, 1, 1, 0, -1, -1, -1, 0 }, dc = { -1, 0, 1, 1, 1, 0, -1, -1 };
            for (int i = 0; i < 8; i++)
            {
                int r = pos.ROW, c = pos.COL;
                int nr = r + dr[i], nc = c + dc[i];
                if (GameBoardClass.IsOutPosition(nr, nc)) continue;
                char piece = now.GetPiece(nr, nc);
                if (GameBoardClass.IsEmpty(piece))
                {
                    //Move
                    GameBoardClass nxtgB = new GameBoardClass(now);
                    nxtgB.Go(r, c, nr, nc);
                    gBNxtList.Add(nxtgB);
                }
                else if (GameBoardClass.IsAlly(piece) && piece != 'j')
                {
                    //Swap
                    GameBoardClass nxtgB = new GameBoardClass(now);
                    nxtgB.Swap(r, c, nr, nc);
                    gBNxtList.Add(nxtgB);
                }
                else if (GameBoardClass.IsEnemy(piece))
                {
                    //Change
                    GameBoardClass nxtgB = new GameBoardClass(now);
                    nxtgB.Change(r, c);
                    gBNxtList.Add(nxtgB);
                }
            }

            return gBNxtList;
        }

        public static int GetScore()
        {
            return 3;
        }

    }
}
