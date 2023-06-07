using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class GameBoardClass
    {
        char[][] state;
        int score = -100000;

        public int SCORE
        {
            get { if (score == -100000) score = GetScore(this); return score; }
        }
        public GameBoardClass(string[] vs)
        {
            state = new char[vs.Length][];
            for (int i = vs.Length - 1; i >= 0; i--)
            {
                state[i] = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    state[i][j] = vs[i][j];
                }
            }
        }

        public GameBoardClass(GameBoardClass gB)
        {
            state = new char[9][];
            for (int i = 9; i >= 0; i--)
            {
                state[i] = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    state[i][j] = gB.state[i][j];
                }
            }
        }

        private GameBoardClass()
        {
        }
        public GameBoardClass Reverse()
        {
            GameBoardClass gb = new GameBoardClass();
            gb.state = new char[9][];

            for (int i = 0; i < 9; i++)
            {
                gb.state[8 - i] = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    char piece = this.GetPiece(i, j);
                    if (IsAlly(piece)) piece = (char)(piece - 'a' + 'A');
                    else if (IsEnemy(piece)) piece = (char)(piece - 'A' + 'a');
                    gb.SetPiece(8 - i, j, piece);
                }
            }
            return gb;
        }

        public char GetPiece(PointClass pt)
        {
            return GetPiece(pt.ROW, pt.COL);
        }

        public void SetPiece(int r, int c, char ch)
        {
            state[r][c] = ch;
        }
        /// <summary>
        /// This point must be valid point
        /// </summary>
        /// <param name="r"> 0<=r<9 </param>
        /// <param name="c"> 0<=c<9 </param>
        /// <returns></returns>
        public char GetPiece(int r, int c)
        {
            return state[r][c];
        }

        /// <summary>
        /// Done
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsEmpty(int r, int c)
        {
            if (GetPiece(r, c) == '.') return true;
            return false;
        }

        /// <summary>
        /// must be valid
        /// Go and Capture.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="nr"></param>
        /// <param name="nc"></param>
        public void Go(int r, int c, int nr, int nc)
        {
            state[r][c] = state[nr][nc];
            state[nr][nc] = '.';
        }

        public void Swap(int r, int c, int nr, int nc)
        {
            char piece = state[r][c];
            state[r][c] = state[nr][nc];
            state[nr][nc] = piece;

        }
        public void Change(int r, int c)
        {
            char piece = state[r][c];
            state[r][c] = (char)(piece - 'A' + 'a');
        }
        /// <summary>
        /// must be valid
        /// </summary>
        /// <param name="now"></param>
        /// <param name="nxt"></param>
        public void Go(PointClass now, PointClass nxt)
        {
            Go(now.ROW, now.COL, nxt.ROW, nxt.COL);
        }
        public bool IsEmpty(PointClass pos)
        {
            return IsEmpty(pos.ROW, pos.COL);
        }

        /// <summary>
        /// Done. but not check
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsSentinelNearHere(int r, int c)
        {
            int[] dr = { 1, 0, -1, 0 }, dc = { 0, 1, 0, -1 };
            int nr, nc;
            for (int i = 0; i < 4; i++)
            {
                nr = r + dr[i];
                nc = c + dc[i];
                if (IsOutPosition(nr, nc)) continue;
                if (GetPiece(nr, nc) == 'S') return true;
            }
            return false;
        }

        public bool IsSentinelNearHere(PointClass pt)
        {
            return IsSentinelNearHere(pt.ROW, pt.COL);
        }

        public static bool IsEnemy(char c)
        {
            if (c >= 'A' && c <= 'Z') return true;
            return false;
        }

        public static bool IsAlly(char c)
        {
            if (c >= 'a' && c <= 'z') return true;
            return false;
        }
        public static bool IsOutPosition(int r, int c)
        {
            if (r < 0 || r >= 9 || c < 0 || c >= 9)
                return true;
            return false;
        }
        public static bool IsEmpty(char c)
        {
            if (c == '.') return true;
            return false;
        }

        public static int GetScore(GameBoardClass gB)
        {
            int score = 0, ws = 0, bs = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char piece = gB.state[i][j];
                    switch (piece)
                    {
                        case 'z': bs += ZombiesClass.GetScore(); break;
                        case 'Z': ws += ZombiesClass.GetScore(); break;
                        case 'b': bs += BuilderClass.GetScore(); break;
                        case 'B': ws += BuilderClass.GetScore(); break;
                        case 'm': bs += MinerClass.GetScore(); break;
                        case 'M': ws += MinerClass.GetScore(); break;
                        case 'j': bs += JesterClass.GetScore(); break;
                        case 'J': ws += JesterClass.GetScore(); break;
                        case 's': bs += SentinelClass.GetScore(); break;
                        case 'S': ws += SentinelClass.GetScore(); break;
                        case 'c': bs += CatapultClass.GetScore(); break;
                        case 'C': ws += CatapultClass.GetScore(); break;
                        case 'd': bs += DragonClass.GetScore(); break;
                        case 'D': ws += DragonClass.GetScore(); break;
                        case 'g': bs += GeneralClass.GetScore(); break;
                        case 'G': ws += GeneralClass.GetScore(); break;
                        default: break;
                    }
                }
            }
            score = bs - ws;
            return score;
        }
    }
}
