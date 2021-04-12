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
    /// Interaction logic for QuestView.xaml
    /// </summary>
    public partial class QuestView : Window
    {
       QuestViewModel _questViewModel;

        public QuestView(QuestViewModel questViewModel)
        {
            _questViewModel = questViewModel;
            DataContext = questViewModel;

            InitializeWindowTheme();

            InitializeComponent();
        }

        private void InitializeWindowTheme()
        {
            this.Title = "Perpetual Confusion Productions";
        }

        private void QuestWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
