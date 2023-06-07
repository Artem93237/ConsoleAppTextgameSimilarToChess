using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextgameSimilarToChess
{
    public class PointClass : Object
    {
        int r, c;
        public int ROW
        {
            get { return r; }
            set { r = value; }
        }
        public int COL
        {
            get { return c; }
            set { c = value; }
        }

        public PointClass() { this.r = -1; this.c = -1; }
        public PointClass(int r, int c)
        {
            this.r = r;
            this.c = c;
        }

        public PointClass(PointClass pt)
        {
            this.r = pt.r;
            this.c = pt.c;
        }
    }
}
