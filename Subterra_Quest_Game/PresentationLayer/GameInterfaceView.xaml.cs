﻿using System;
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
        }

        public void HPStatButtonClick(object sender, RoutedEventArgs e)
        {
            _gameInterfaceViewModel.HPStatPointClick();
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
            this.StartBorder.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
