using System;
using System.Collections.Generic;

namespace WTW_InterviewChallenge.Game
{
    /// <summary>
    /// TicTacToe game class
    /// </summary>
    public class TicTacToe
    {
        private readonly int[] _rows;
        private readonly int[] _columns;
        private readonly int _gridSize;
        private int _diagonalRight;
        private int _diagonalLeft;
        private int _moves;
        private readonly HashSet<Tuple<int, int>> _claimed;
        public int Winner { get; private set; }

        /// <summary>
        /// TicTacToe constructor
        /// </summary>
        /// <param name="n">Grid size nxn</param>
        public TicTacToe(int n)
        {
            _gridSize = n;
            _rows = new int[n];
            _columns = new int[n];
            _claimed = new HashSet<Tuple<int, int>>();
            _moves = 0;
            Winner = 0;
        }

        /// <summary>
        /// Places a game piece on a grid cell for the given player.
        /// </summary>
        /// <param name="row">cell row</param>
        /// <param name="col">cell column</param>
        /// <param name="player">player placing piece</param>
        /// <returns> player number if game winner, 0 otherwise.</returns>
        public int PlacePiece( int row, int col, int player )
        {
            var coords = new Tuple<int, int>(row, col);
            if( Winner != 0 )
            {
                throw new InvalidOperationException("The game has concluded.");
            }
            if( player == 0 || player > 2 )
            {
                throw new InvalidOperationException($"Invalid player: {player}. Player must be either 1 or 2.");
            }
            if( row > _gridSize || col > _gridSize )
            {
                throw new ArgumentOutOfRangeException("Move exceeds gameboard boundaries.");
            }
            if( _claimed.Contains(coords) )
            {
                throw new InvalidOperationException("A player has already claimed this space.");
            }
            _claimed.Add(coords);
            _moves++;            
            var move = player == 1 ? 1 : -1; //Player one positive, player 2 negative.

            //We don't care exactly which cells a player has. We can tell if they have won if the absolute value sum of pieces in a row/column/diagonal equals n.
            //for example: When n=4, p1 wins when a row, column, or diagonal has a sum of 4. P2 wins if a row, column, or diagonal has a sum of -4.
            _rows[row] += move; 
            _columns[col] += move;
            if( row == col )
            {
                _diagonalRight += move;
            }
            if( col == _gridSize - row - 1 )
            {
                _diagonalLeft += move;
            }

            if( CheckForWinner( row, col ) )
            {
                Winner = player;
                return player;
            }
            return 0;
        }

        private bool CheckForWinner( int row, int col )
        {
            if( _moves >= ( _gridSize * _gridSize ))
            {
                Winner = -1;
                return false;
            }
            if ( Math.Abs(_rows[row]) == _gridSize || Math.Abs(_columns[col]) == _gridSize || Math.Abs(_diagonalRight) == _gridSize || Math.Abs(_diagonalLeft) == _gridSize )
            {
                return true;
            }
            return false;
        }
    }
}
