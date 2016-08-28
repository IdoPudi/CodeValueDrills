using BackGammon.Logic.Classes;
using BackGammon.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.UI.Classes
{
    public class PlayBackGammon : IPlayBackGammon
    {
        #region Private Members
        private GameManager _game;
        private Print _print;
        #endregion

        #region Constructor
        public PlayBackGammon()
        {
            _game = new GameManager();
            _print = new Print();
        }
        #endregion

        #region Public Methods
        public void StartGame()
        {
            _print.StartGame();
            Console.ReadKey();
            _game.RollStartingPlayer();
            StartPlayerTurn();
        } 
        #endregion

        #region Private Merthods
        private void StartPlayerTurn()
        {
            while (!_game.IsEnded())
            {
                ClearConsoleAndPrint();
                try
                {
                    if (_game.HasMove())
                    {
                        if (HaveGameStonesOnBar())
                            PutGameStoneBackOnBorad();
                        else
                            MoveGameStone();

                        PlayerGotMoreMovesOrChangePlayer();
                    }
                    else
                    {
                        _print.NoMovesForPlayer();
                        SwitchPlayer();
                    }
                }
                catch (Exception ex)
                {
                    _print.ShowException(ex);
                    StartPlayerTurn();
                }
            }

            _game.Winner();
            _print.WinningPlayer(_game.GetPlayer());
            System.Environment.Exit(0);
        }

        private void ClearConsoleAndPrint()
        {
            Console.Clear();
            _print.DrawBoard(_game.GetBoard());
            _print.CurrentPlayer(_game.GetPlayer());
            _print.PrintDicesAndNumberOfMoves(_game);
        }

        private void SwitchPlayer()
        {
            ChangePlayer();

            StartPlayerTurn();
        }

        private void PlayerGotMoreMovesOrChangePlayer()
        {
            if (_game.getDice().GetDiceTotalMoves() > 0)
                StartPlayerTurn();
            else
            {
                SwitchPlayer();
            }
        }

        private void ChangePlayer()
        {
            _game.Roll();
            _print.PlayerTurn(_game.GetPlayer());
        }

        private bool HaveGameStonesOnBar()
        {
            bool stoneOnBar = false;
            if (_game.GetPlayerStoneOnBar(_game.GetPlayer()) > 0)
                stoneOnBar = true;

            return stoneOnBar;
        }

        private void PutGameStoneBackOnBorad()
        {
            int number = 0;
            _print.GotStonesOnBar();
            if (int.TryParse(Console.ReadLine(), out number))
            {
                ValidatePutAndPrintMessageIfNot(number);
            }
            else
            {
                _print.InputNotValid();
            }
        }

        private void ValidatePutAndPrintMessageIfNot(int number)
        {
            if (_game.CanPut(number))
            {
                _game.Put(number);
            }
            else
            {
                _print.NotAValidMove();
            }
        }

        private void MoveGameStone()
        {
            int from = 0;
            int count = 0;
            bool validFrom = false;
            bool validCount = false;
            _print.EnterNumber();
            validFrom = int.TryParse(Console.ReadLine(), out from);
            _print.EnterNumber();
            validCount = int.TryParse(Console.ReadLine(), out count);
            CheckIfInputValid(from, count, validFrom, validCount);

        }

        private void CheckIfInputValid(int from, int count, bool validFrom, bool validCount)
        {
            if (validFrom && validCount)
            {
                ValidateMoveAndPrintMessageIfNot(from, count);
            }
            else
            {
                _print.InputNotValid();
                _print.PressKryToRestartMove();
                Console.ReadKey();
                StartPlayerTurn();
            }
        }

        private void ValidateMoveAndPrintMessageIfNot(int from, int count)
        {
            if (_game.CanMove(from, count))
            {
                _game.Move(from, count);
            }
            else
            {
                _print.NotAValidMove();
            }
        } 
        #endregion
    }
}
