using BackGammon.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Classes
{
    public class Board : IBoard
    {
        #region Private Members
        private int _homeWhite;
        private int _homeBlack;
        private int _barWhite;
        private int _barBlack;
        private const int _totalNumberOfFields = 24;
        private BoardCell[] _boardCells;
        #endregion

        #region Constructor
        public Board()
        {
            initaliseBoard();
        }
        #endregion

        #region Public Methods
        public void initaliseBoard()
        {
            _boardCells = new BoardCell[_totalNumberOfFields];
            FillBoardCellsWithStartSetup();
        }

        public bool CanMoveGameStone(int FromCell, int CountOfStoneMove)
        {
            if (FromCell < 0 || FromCell > 24)
                return false;

            if (_boardCells[FromCell].Number == 0)
                return false;

            StoneColor player = _boardCells[FromCell].Color;
            int target;

            if (player == StoneColor.White)
            {
                if (_barWhite > 0) return false;
                target = FromCell + CountOfStoneMove;
            }
            else
            {
                if (_barBlack > 0) return false;
                target = FromCell - CountOfStoneMove;
            }
            if (target > 23 || target < 0)
                return HasAllGameStonesHome(player, FromCell);
            StoneColor tarWho = _boardCells[target].Color;
            if (tarWho == player || tarWho == StoneColor.None)
                return true;
            else
                return _boardCells[target].Number == 1;
        }

        public void MoveGameStone(int FromCell, int CountOfStoneMove)
        {
            if (_boardCells[FromCell].Color == StoneColor.White)
            {
                MoveWhiteGameStone(FromCell, CountOfStoneMove);
            }
            else
            {
                MoveBlackGameStone(FromCell, CountOfStoneMove);
            }
            RemoveStone(FromCell);
        }

        public bool CanPutGameStoneBackInBoard(StoneColor Color, int CellNumber)
        {
            if (Color == StoneColor.White)
            {
                if (_barWhite == 0) return false;
                if (_boardCells[CellNumber].Color == StoneColor.Black && _boardCells[CellNumber].Number > 1) return false;
                return true;
            }
            else
            {
                if (_barBlack == 0) return false;
                if (_boardCells[CellNumber].Color == StoneColor.White && _boardCells[CellNumber].Number > 1) return false;
                return true;
            }
        }

        public void PutGameStoneBackOnBoard(StoneColor Color, int CellNumber)
        {
            if (StoneColor.White == Color)
            {
                PutWhiteStoneOnBoard(Color, CellNumber);
            }
            else
            {
                PutBlackStoneOnBoard(CellNumber, Color);
            }
        }

        public int GetOutSideBarCount(StoneColor Color)
        {
            int barCount = 0;
            if (Color == StoneColor.White)
            {
                barCount = _barWhite;
            }
            else
            {
                barCount = _barBlack;
            }
            return barCount;
        }

        public int GetPlayersGameStonesInHome(StoneColor Color)
        {
            int homeCount = 0;
            if (Color == StoneColor.White)
            {
                homeCount = _homeWhite;
            }
            else
            {
                homeCount = _homeBlack;
            }
            return homeCount;
        }

        public GameStone GetStone(int CellNumber)
        {
            GameStone stone;
            if (CellNumber < 0 || CellNumber > 24)
                return GameStone.None;

            if (_boardCells[CellNumber].Color == StoneColor.White)
            {
                stone = GameStone.White;
            }
            else
            {
                stone = GameStone.Black;
            }
            return stone;
        }

        public int GetStoneCount(int CellNumber)
        {
            if (CellNumber < 0 || CellNumber > 24)
                return 0;

            return _boardCells[CellNumber].Number;
        }

        public bool HasAllGameStonesHome(StoneColor Color, int Except)
        {
            bool valid = false;
            if (Color == StoneColor.White)
            {
                if ((CountWhiteHome() + _homeWhite) == 15)
                {
                    valid = true;
                }
            }
            else
            {
                if ((CountBlackHome() + _homeBlack) == 15)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public int GetBlackBar() => _barBlack;

        public int GetWhiteBar() => _barWhite;

        public bool WhitePlayerHasMoveToMake(int DiceOne, int DiceTwo)
        {
            bool valid = false;
            int count = 0;

            for (int i = 0; i < _boardCells.Length; i++)
            {
                count = CountMoveForWhitePlayer(DiceOne, DiceTwo, count, i);
            }

            if (count > 0)
            {
                valid = true;
            }

            return valid;
        }

        public bool BlackPlayerHasMoveToMake(int DiceOne, int DiceTwo)
        {
            bool valid = false;
            int count = 0;

            for (int i = 0; i < _boardCells.Length; i++)
            {
                count = CountMoveForBlackPlayer(DiceOne, DiceTwo, count, i);
            }
            if (count > 0)
            {
                valid = true;
            }

            return valid;
        }
        #endregion

        #region Private Methods
        private void MoveBlackGameStone(int FromCell, int CountOfStoneMove)
        {
            int target = FromCell - CountOfStoneMove;
            if (target < 0)
                _homeBlack++;
            else if (_boardCells[target].Color == StoneColor.White)
            {
                RemoveStone(target);
                _barWhite++;
                AddStone(target, StoneColor.Black);
            }
            else
            {
                AddStone(target, StoneColor.Black);
            }
        }

        private void MoveWhiteGameStone(int FromCell, int CountOfStoneMove)
        {
            int target = FromCell + CountOfStoneMove;
            if (target > 23)
                _homeWhite++;
            else if (_boardCells[target].Color == StoneColor.Black)
            {
                RemoveStone(target);
                _barBlack++;
                AddStone(target, StoneColor.White);
            }
            else
                AddStone(target, StoneColor.White);
        }

        private int CountMoveForWhitePlayer(int DiceOne, int DiceTwo, int count, int i)
        {
            if (_boardCells[i].Color == StoneColor.White)
            {
                if (_barWhite != 0)
                {
                    if (CanPutGameStoneBackInBoard(StoneColor.White, DiceOne) || CanPutGameStoneBackInBoard(StoneColor.White, DiceTwo))
                    {
                        count++;
                    }
                }
                else
                {
                    if (CanMoveGameStone(i, DiceOne) || CanMoveGameStone(i, DiceTwo))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private int CountMoveForBlackPlayer(int DiceOne, int DiceTwo, int count, int i)
        {
            if (_boardCells[i].Color == StoneColor.Black)
            {
                if (_barBlack != 0)
                {
                    if (CanPutGameStoneBackInBoard(StoneColor.Black, DiceOne) || CanPutGameStoneBackInBoard(StoneColor.Black, DiceTwo))
                    {
                        count++;
                    }
                }
                else
                {
                    if (CanMoveGameStone(i, DiceOne) || CanMoveGameStone(i, DiceTwo))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private int CountBlackHome() => _boardCells.Take(6).Where(c => c.Color == StoneColor.Black).Select(s => s.Number).Sum();

        private int CountWhiteHome() => _boardCells.Skip(18).Where(c => c.Color == StoneColor.White).Select(s => s.Number).Sum();

        private void FillBoardCellsWithStartSetup()
        {
            for (int i = 0; i < _totalNumberOfFields; i++)
            {
                _boardCells[i] = new BoardCell();
                _boardCells[i].Color = StoneColor.None;
                _boardCells[i].Number = 0;
            }
            FillWhiteStartingBoard();
            FillBlackStartingBoard();
        }

        private void FillBlackStartingBoard()
        {
            _boardCells[0].Number = 2;
            _boardCells[0].Color = StoneColor.White;

            _boardCells[11].Number = 5;
            _boardCells[11].Color = StoneColor.White;

            _boardCells[16].Number = 3;
            _boardCells[16].Color = StoneColor.White;

            _boardCells[18].Number = 5;
            _boardCells[18].Color = StoneColor.White;
        }

        private void FillWhiteStartingBoard()
        {
            _boardCells[5].Number = 5;
            _boardCells[5].Color = StoneColor.Black;

            _boardCells[7].Number = 3;
            _boardCells[7].Color = StoneColor.Black;

            _boardCells[12].Number = 5;
            _boardCells[12].Color = StoneColor.Black;

            _boardCells[23].Number = 2;
            _boardCells[23].Color = StoneColor.Black;
        }

        private void AddStone(int to, StoneColor color)
        {
            if (_boardCells[to].Color != StoneColor.None && _boardCells[to].Color != color)
                throw new Exception();

            _boardCells[to].Number++;
            if (_boardCells[to].Color == StoneColor.None)
                _boardCells[to].Color = color;
        }

        private void RemoveStone(int from)
        {
            if (_boardCells[from].Number <= 0)
                throw new Exception();

            _boardCells[from].Number--;
            if (_boardCells[from].Number == 0)
                _boardCells[from].Color = StoneColor.None;
        }

        private void PutBlackStoneOnBoard(int cellNumber, StoneColor color)
        {
            if (_boardCells[cellNumber].Color == StoneColor.White)
            {
                RemoveStone(cellNumber);
                _barWhite++;
                AddStone(cellNumber, color);
                _barBlack--;
            }
            else
            {
                AddStone(cellNumber, color);
                _barBlack--;
            }
        }

        private void PutWhiteStoneOnBoard(StoneColor color, int cellNumber)
        {
            if (_boardCells[cellNumber].Color == StoneColor.Black)
            {
                RemoveStone(cellNumber);
                _barBlack++;
                AddStone(cellNumber, color);
                _barWhite--;
            }
            else
            {
                AddStone(cellNumber, color);
                _barWhite--;
            }
        } 
        #endregion
    }
}
