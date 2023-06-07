using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class AIClass
    {
        GameBoardClass gameBoard;
        const int MaxDP = 3;
        int score = -100000;

        public int SCORE
        {
            get { return score; }
        }
        public AIClass(GameBoardClass gB)
        {
            gameBoard = new GameBoardClass(gB);
        }

        public int Find(int dp = 0)
        {
            int score = -10000;
            GameBoardClass lastBoard = null;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char piece = gameBoard.GetPiece(i, j);
                    if (!GameBoardClass.IsAlly(piece)) continue;
                    List<GameBoardClass> gblist = null;
                    switch (piece)
                    {
                        case 'z': gblist = ZombiesClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'b': gblist = BuilderClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'm': gblist = MinerClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'j': gblist = JesterClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 's': gblist = SentinelClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'c': gblist = CatapultClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'd': gblist = DragonClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        case 'g': gblist = GeneralClass.GetNextBoardStates(gameBoard, new PointClass(i, j)); break;
                        default: break;
                    }
                    foreach(var gb in gblist)
                    {
                        if (dp < MaxDP)
                        {
                            GameBoardClass ngB = gameBoard.Reverse();
                            AIClass nxtAI = new AIClass(gb);
                            int sc = nxtAI.Find(dp + 1);
                            if (sc < score)
                            {
                                score = sc;
                                lastBoard = gb;
                            }
                        }
                        else if (dp == MaxDP)
                        {
                            GameBoardClass ngB = gameBoard.Reverse();
                            AIClass nxtAI = new AIClass(gb);
                            int sc = nxtAI.Find(dp + 1);
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
            this.score = score;
            return score;
        }
    }
}
