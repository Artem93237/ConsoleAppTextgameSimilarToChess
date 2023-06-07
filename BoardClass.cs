using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class BoardClass
    {
        public static string[] state;

        /// <summary>
        /// Not complete yet
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsEmpty(int r, int c)
        {
            return true;
        }
        public static bool IsEmpty(PointClass pos)
        {
            return IsEmpty(pos.ROW, pos.COL);
        }

        public static bool InValidPostion(int r, int c)
        {
            if (r < 0 || r >= 9 || c < 0 || c >= 9)
                return false;
            return true;
        }

    }
}
