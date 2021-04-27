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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading;

namespace EndlessRunner.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        Rect playerHitBox;
        Rect groundHitBox;
        Rect obsticleHitBox;

        bool jumping;

        int force = 20;
        int speed = 5;

        Random rnd = new Random();

        bool gameOver;

        Double Spriteindex = 0;

        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush obsticleSprite = new ImageBrush();
        
        //8.56 i videon


        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void StartGame()
        {

        }

        private void RunSprite(double i)
        {

        }
    }
}
