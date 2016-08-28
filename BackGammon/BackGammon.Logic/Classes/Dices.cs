using BackGammon.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Classes
{
    public class Dices : IDices
    {
        #region Private Members
        private int _diceNumberOne;
        private int _diceNumberTwo;

        private int _diceOneNumberOfUses;
        private int _diceTwoNumberOfUses;

        private Random _random;
        #endregion

        #region Constructor
        public Dices()
        {
            _random = new Random();
        }
        #endregion

        #region Public Methods
        public int DiceOneNumberOfMoves() => _diceOneNumberOfUses;

        public int DiceTwoNumberOfMoves() => _diceTwoNumberOfUses;

        public int GetDiceOne() => _diceNumberOne;

        public int GetDiceTwo() => _diceNumberTwo;

        public bool IsDicesRolled() => _diceNumberOne > 0 || _diceNumberTwo > 0;

        public bool IsOnDice(int Number)
        {
            var valid = false;
            if (IsOnDiceValid(_diceOneNumberOfUses, _diceNumberOne, Number)
                || IsOnDiceValid(_diceTwoNumberOfUses, _diceNumberTwo, Number))
            {
                valid = true;
            }
            return valid;
        }

        public void RollDices()
        {
            _diceNumberOne = _random.Next(1, 7);
            _diceNumberTwo = _random.Next(1, 7);

            if (_diceNumberOne == _diceNumberTwo)
            {
                _diceOneNumberOfUses = 2;
                _diceTwoNumberOfUses = 2;
            }
            else
            {
                _diceOneNumberOfUses = 1;
                _diceTwoNumberOfUses = 1;
            }
        }

        public void RollDifferentDices()
        {
            do
            {
                _diceNumberOne = _random.Next(1, 7);
                _diceNumberTwo = _random.Next(1, 7);
            } while (_diceNumberOne == _diceNumberTwo);
            _diceOneNumberOfUses = 1;
            _diceTwoNumberOfUses = 1;
        }

        public int TotalNumberOfMoves() => _diceOneNumberOfUses + _diceTwoNumberOfUses;

        public void UseDice(int Number)
        {
            if (IsOnDiceValid(_diceOneNumberOfUses, _diceNumberOne, Number))
            {
                _diceOneNumberOfUses--;
            }
            else if (IsOnDiceValid(_diceTwoNumberOfUses, _diceNumberTwo, Number))
            {
                _diceTwoNumberOfUses--;
            }
        }
        #endregion

        #region Private Methods
        private bool IsOnDiceValid(int numberOfUses, int diceNumber, int numberToCheck)
        {
            bool valid = false;

            if (numberOfUses > 0 && diceNumber == numberToCheck)
                valid = true;

            return valid;
        } 
        #endregion
    }
}
