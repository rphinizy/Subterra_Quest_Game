using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Subterra_Quest_Game.Models;

namespace Subterra_Quest_Game.PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private Player _player;
        public LoginView(Player player)
        {
          
            _player = player;

            InitializeComponent();

            SetupWindow();


        }

        private void SetupWindow()
        {
            //List<string> races = Enum.GetNames(typeof(Player.RaceType)).ToList();
            //List<string> jobTitles = Enum.GetNames(typeof(Player.JobTitleName)).ToList();
            //List<string> colors = Enum.GetNames(typeof(Player.ColorType)).ToList();
            //PlayerColor.ItemsSource = colors;
        }
      
        private void EnterGame_Click(object sender, RoutedEventArgs e)
           
        {
            string errorMessage;

            if(IsValidInput(out errorMessage))
            {
                _player.Name = PlayerName.Text;
                //Enum.TryParse(PlayerColor.SelectionBoxItem.ToString(), out Player.ColorType color);
                this.Hide();

                //_player.Color = color;
            }
            else
            {
                //
                // display error messages
                //
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }

        }
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (PlayerName.Text == "" || PlayerName.Text == "Enter a Name")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = PlayerName.Text;
            }
            return errorMessage == "" ? true : false;
        }

        private void addDEF_Click(object sender, RoutedEventArgs e)
        {
            if (_player.StatPoints > 0)
            {
                _player.Defense = _player.Defense + 1;
                _player.StatPoints = _player.StatPoints - 1;
            }

        }

        private void addSTR_Click(object sender, RoutedEventArgs e)
        {

            if (_player.StatPoints > 0)
            {
                _player.Strength = _player.Strength + 1;
                _player.StatPoints = _player.StatPoints - 1;
            }

        }

        private void addHP_Click(object sender, RoutedEventArgs e)
        {
            if (_player.StatPoints > 0)
            {
                _player.Health = _player.Health + 1;
                _player.StatPoints = _player.StatPoints - 1;
            }
        }
    }
}
