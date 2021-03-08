using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subterra_Quest_Game.PresentationLayer;
using Subterra_Quest_Game.DataLayer;
using Subterra_Quest_Game.Models;

namespace Subterra_Quest_Game.BusinessLayer
{
    public class GameBusiness
    {
        GameInterfaceViewModel _gameInterfaceViewModel;
        bool _newPlayer = false;
        LoginView _loginView = null;
        Player _player = new Player();
        List<string> _messages;

        public GameBusiness()
        {
            ShowLoginWindow();
            InitializeDataSet();
            ShowGameInterface();
           
        }

        private void ShowLoginWindow()
        {
            if (_newPlayer)
            {
                _loginView = new LoginView();
                _loginView.ShowDialog();

                _player.Experience = 0;
                _player.Health = 100;
            }
            else
            {
                _player = GameData.PlayerData();
            }


        }
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }
        private void ShowGameInterface()
        {
            _gameInterfaceViewModel = new GameInterfaceViewModel(
                _player,
                _messages,
                GameData.GameMap(),
                GameData.InitialGameMapLocation()
                );
            GameInterfaceView gameInterfaceView = new GameInterfaceView(_gameInterfaceViewModel);

            gameInterfaceView.DataContext = _gameInterfaceViewModel;

            gameInterfaceView.Show();

        }


    }

   
}
