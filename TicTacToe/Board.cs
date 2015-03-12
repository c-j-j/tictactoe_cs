using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        readonly private Mark[] positions;

        public static readonly int[][] LINE_POSITIONS =
            {
                new int[]{ 0, 1, 2 },
                new int[]{ 3, 4, 5 },
                new int[]{ 6, 7, 8 },
                new int[]{ 0, 3, 6 },
                new int[]{ 1, 4, 7 },
                new int[]{ 2, 5, 8 },
                new int[]{ 0, 4, 8 },
                new int[]{ 2, 4, 6 },
            };

        public Board()
        {
            positions = new Mark[9];
        }

        public void AddMove(Mark mark, int position)
        {
            positions[position] = mark;
        }

        public Mark GetMarkAtPosition(int position)
        {
            return positions[position];
        }

        public List<Line> GetLines()
        {
            var lines = new List<Line>();
            foreach (var l in LINE_POSITIONS) {
				lines.Add (new Line (positions [l [0]], positions [l [1]], positions [l [2]]));
			}
            return lines;
        }

        public List<int> GetAvailablePositions()
        {
            var emptyPositions = new List<int>();

            for (int i = 0; i < positions.Length; i++)
            {
                if(positions[i]==Mark.EMPTY){
                   emptyPositions.Add(i);
                }
            }
            return emptyPositions;
        }

        public class Line
        {
            private Mark m1;
            private Mark m2;
            private Mark m3;

            public Line(Mark m1, Mark m2, Mark m3)
            {
                this.m1 = m1;
                this.m2 = m2;
                this.m3 = m3;
            }

            public override bool Equals(System.Object o)
            {
                if (o == null)
                {
                    return false;
                }

                var l2 = o as Line;
                if ((System.Object)l2 == null)
                {
                    return false;
                }

                return this.m1 == l2.m1 && this.m2 == l2.m2 && this.m3 == l2.m3;
            }

            public override int GetHashCode()
            {
                int result = m1.GetHashCode();
                result = (result * 397) ^ m2.GetHashCode();
                result = (result * 397) ^ m3.GetHashCode();
                return result;
            }

            public override string ToString()
            {
                return String.Format("{0},{1},{2}", m1, m2, m3);
            }

        }
    }
}
