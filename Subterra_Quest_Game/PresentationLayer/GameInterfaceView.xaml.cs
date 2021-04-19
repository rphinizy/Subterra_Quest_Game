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

namespace Subterra_Quest_Game.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameInterfaceView.xaml
    /// </summary>
    public partial class GameInterfaceView : Window
    {
        GameInterfaceViewModel _gameInterfaceViewModel;


        public GameInterfaceView(GameInterfaceViewModel gameInterfaceViewModel)
        {
            _gameInterfaceViewModel = gameInterfaceViewModel;
            InitializeComponent();
            SetupWindow();
        }

        private void SetupWindow()
        {
            
            _gameInterfaceViewModel.InitialLocation();

        }

        public void STRStatButtonClick(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.STRStatPointClick();
        }

        public void DEFStatButtonClick(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.DEFStatPointClick();
        }

        private void North_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.MoveNorth();
        }
        private void East_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.MoveEast();

        }
        private void South_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.MoveSouth();
        }
        private void West_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.MoveWest();

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.MoveStart();
            this.StartButton.Visibility = System.Windows.Visibility.Collapsed;
           
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                
                _gameInterfaceViewModel.AddItemToInventory();
                

            }
        }

        private void DropButton_Click(object sender, RoutedEventArgs e)
        {
             if (PlayerDataTabControl.SelectedItem != null)
                {

                _gameInterfaceViewModel.RemoveItemFromInventory();


            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameInterfaceViewModel.OnUseGameItem();
            }
        }

        private void SpeakToButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameInterfaceViewModel.OnPlayerTalkTo();
            }
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameInterfaceViewModel.OnPlayerAttack();
            }
        }

        //remove method
        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameInterfaceViewModel.OnPlayerDefend();
            }
        }
        //remove method
        private void RetreatButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameInterfaceViewModel.OnPlayerRetreat();
            }
        }

        private void QuestStatus_Click(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.OpenQuestView();
        }

        private void Button_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
    }
}
