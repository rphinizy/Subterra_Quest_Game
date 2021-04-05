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
        //bool _newPlayer = true;
        LoginView _loginView = null;
        Player _player = new Player();
        List<string> _messages;

        public GameBusiness()
        {
            ShowLoginWindow();
           
           
        }

        private void ShowLoginWindow()
        {
            _loginView = new LoginView(_player);
            _player.Experience = GameData.PlayerData().Experience;
            _player.StatPoints = GameData.PlayerData().StatPoints;
            _player.HealthPoints = GameData.PlayerData().HealthPoints;
            _player.Stamina = GameData.PlayerData().Stamina;
            _player.Defense = GameData.PlayerData().Defense;
            _player.Strength = GameData.PlayerData().Strength;
            _player.Color = GameData.PlayerData().Color;

            _loginView.ShowDialog();
             InitializeDataSet();
             ShowGameInterface();

        }
        private void InitializeDataSet()
        {

            _player.Inventory = GameData.PlayerData().Inventory;
            _player.Form = GameData.PlayerData().Form;
            _player.FormImg = GameData.PlayerData().FormImg;
            _player.SkillLevel = GameData.PlayerData().SkillLevel;
           

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
