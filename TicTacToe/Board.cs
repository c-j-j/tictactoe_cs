using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        readonly private Mark[] positions;
        public const int BOARD_SIZE = 9;

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

        public static readonly int[][] ROW_POSITIONS =
        {
                new int[]{ 0, 1, 2 },
                new int[]{ 3, 4, 5 },
                new int[]{ 6, 7, 8 }
        };

        public Board()
        {
            positions = new Mark[BOARD_SIZE];
        }

		public void AddMove(Move move)
        {
			positions[move.Position] = move.Mark;
        }

        public Mark GetMarkAtPosition(int position)
        {
            return positions[position];
        }

        public bool IsPositionInRange(int position)
        {
            return !(position < 0 || position >= BOARD_SIZE);
        }

        public List<Line> Rows
        {
            get{
                return BuildLines(ROW_POSITIONS);
            }
        }

        public List<Line> GetLines()
        {
            return BuildLines(LINE_POSITIONS);
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

        private List<Line> BuildLines(int[][] line_positions)
        {
            var lines = new List<Line>();
            foreach (var l in line_positions)
            {
                lines.Add(new Line(positions[l[0]], positions[l[1]], positions[l[2]]));
            }
            return lines;
        }

        public class Line
        {
            private readonly Mark[] marks;

            public Line(params Mark[] marks)
            {
                this.marks = marks;
            }

            public Mark[] Marks
            {
              get{
                return marks;
              }
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

                return Enumerable.SequenceEqual(marks, l2.Marks);
            }

            public override int GetHashCode()
            {
                return marks.GetHashCode();
            }

            public bool ContainSameMark()
            {
                return marks.All(e => e==marks[0] && e != Mark.EMPTY);
            }

            public override string ToString()
            {
                return string.Format(",", marks);
            }

        }
    }
}
