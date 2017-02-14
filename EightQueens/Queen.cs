using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Queen
    {
        public int Row;
        public static int BoardSize;

        private Queen _nextQueen;
        public int _column;

        public Queen(Queen nextQueen, int column)
        {
            this._nextQueen = nextQueen;
            this._column = column;
            this.Row = 1;
        }
        public void MoveNext()
        {
            this.Row++;
        }

        public bool CanPositionBeAttacked(int possibleRow, int possibleColumn)
        {
            if (this.Row == possibleRow)
            {
                return true;
            }
            else if (this.IsOnDiagonal(possibleRow, possibleColumn))
            {
                return true;
            }
            else if (this._nextQueen != null)
            {
                return this._nextQueen.CanPositionBeAttacked(possibleRow, possibleColumn);
            }
            else
            {
                return false;
            }
        }

        private bool IsOnDiagonal(int possibleRow, int possibleColumn)
        {
            var columnDiff = possibleColumn - this._column;
            if (possibleRow - columnDiff == this.Row ||
               possibleRow + columnDiff == this.Row)
            {
                return true;
            }
            return false;
        }

        public bool Solve()
        {
            if (_nextQueen == null)
            {
                return true;
            }

            _nextQueen.Solve();

            while (_nextQueen.CanPositionBeAttacked(this.Row, this._column) ||
                  this.Row > Queen.BoardSize)
            {
                this.MoveNext();

                if (this.Row > Queen.BoardSize)
                {
                    this.Row = 1;
                    _nextQueen.MoveNext();
                    _nextQueen.Solve();
                }
            }

            return true;
        }
    }
}
