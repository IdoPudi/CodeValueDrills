using BackGammon.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Classes
{
    public class GameManager : IGameManager
    {
        #region Private Members
        private Board _board;
        private StoneColor _player;
        private Dices _dices;
        #endregion

        #region Constructor
        public GameManager()
        {
            _board = new Board();
            _player = StoneColor.None;
            _dices = new Dices();
        }
        #endregion

        #region Public Methods
        public bool HasMove()
        {
            bool valid = false;

            if (_player == StoneColor.White)
            {
                valid = WhitePlayerHasMove();
            }
            else
            {
                valid = BlackPlayerHasMove();
            }

            return valid;
        }

        public bool CanMove(int FromCell, int CountOfStoneMove)
        {
            var valid = false;
            if (_dices.IsDicesRolled() && _dices.IsOnDice(CountOfStoneMove)
                && _board.CanMoveGameStone(FromCell, CountOfStoneMove) && _board.GetStone(FromCell).Color == _player)
            {
                valid = true;
            }
            return valid;
        }

        public bool CanPut(int CellNumber)
        {
            var color = StoneColor.White;
            if (!_dices.IsDicesRolled()) return false;
            if (_player == color)
            {
                if (!IsPlayerWhiteOnDice(CellNumber)) return false;
            }
            else
            {
                if (!IsPlayerBlackOnDice(CellNumber)) return false;
            }
            if (!_board.CanPutGameStoneBackInBoard(_player, CellNumber)) return false;

            return true;
        }

        public Board GetBoard() => _board;

        public StoneColor GetPlayer() => _player;

        public bool IsEnded()
        {
            return _board.GetPlayersGameStonesInHome(StoneColor.White) == 15 || _board.GetPlayersGameStonesInHome(StoneColor.Black) == 15;
        }

        public void Move(int FromCell, int CountOfStoneMove)
        {
            _board.MoveGameStone(FromCell, CountOfStoneMove);
            _dices.UseDice(CountOfStoneMove);
        }

        public void Put(int CellNumber)
        {
            if (CanPut(CellNumber))
            {
                _board.PutGameStoneBackOnBoard(_player, CellNumber);
            }
            _dices.UseDice(GetDiceNumber(CellNumber));
        }

        public StoneColor Winner()
        {
            if (!IsEnded()) return StoneColor.None;
            if (_board.GetPlayersGameStonesInHome(StoneColor.White) == 15) return StoneColor.White;
            return StoneColor.Black;
        }

        public void Roll()
        {
            _dices.RollDices();

            if (_player == StoneColor.White)
                _player = StoneColor.Black;
            else
                _player = StoneColor.White;
        }

        public ShowDices getDice()
        {
            return new ShowDices(_dices);
        }

        public void RollStartingPlayer()
        {
            _dices.RollDifferentDices();

            if (_dices.GetDiceOne() > _dices.GetDiceTwo())
                _player = StoneColor.White;
            else
                _player = StoneColor.Black;
        }

        public int GetPlayerStoneOnBar(StoneColor Color)
        {
            int bar = 0;
            if (StoneColor.White == Color)
                bar = _board.GetWhiteBar();
            else
                bar = _board.GetBlackBar();

            return bar;
        }
        #endregion

        #region Private Merthods
        private bool IsPlayerBlackOnDice(int number)
        {
            bool valid = false;
            if (NumberInRangeToLandBlack(number))
            {
                number = GetDiceNumber(number);
                valid = _dices.IsOnDice(number);
            }
            return valid;
        }

        private bool IsPlayerWhiteOnDice(int number)
        {
            bool valid = false;
            if (NumberInRangeToLandWhite(number))
            {
                number = GetDiceNumber(number);
                valid = _dices.IsOnDice(number);
            }
            return valid;
        }

        private int GetDiceNumber(int number)
        {
            int diceNumber = 0;
            if (_player == StoneColor.White)
            {
                diceNumber = number + 1;
            }
            else
            {
                diceNumber = 23 - number + 1;
            }
            return diceNumber;
        }

        private bool NumberInRangeToLandBlack(int number)
        {
            bool valid = false;
            if (number >= 18 && number <= 23)
            {
                valid = true;
            }
            return valid;
        }

        private bool NumberInRangeToLandWhite(int number)
        {
            bool valid = false;
            if (number >= 0 && number <= 5)
            {
                valid = true;
            }
            return valid;
        }

        private bool WhitePlayerHasMove()
        {
            bool valid = false;

            if (_board.WhitePlayerHasMoveToMake(_dices.GetDiceOne(), _dices.GetDiceTwo()))
            {
                valid = true;
            }

            return valid;
        }

        private bool BlackPlayerHasMove()
        {
            bool valid = false;

            if (_board.BlackPlayerHasMoveToMake(_dices.GetDiceOne(), _dices.GetDiceTwo()))
            {
                valid = true;
            }

            return valid;
        } 
        #endregion
    }
}
