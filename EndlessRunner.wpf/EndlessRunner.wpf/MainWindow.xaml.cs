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

        // Hitboxen för spelare, marken samt hindrerna
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

        int[] obsticlePosition = { 320, 310, 300, 305, 315 };

        int score = 0;
      


        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus();

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.gif"));

            background.Fill = backgroundSprite;
            background2.Fill = backgroundSprite;

            StartGame();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameEngine(object sender, EventArgs e)
        {
            Canvas.SetLeft(background, Canvas.GetLeft(background) - 3);
            Canvas.SetLeft(background2, Canvas.GetLeft(background2) - 3);

            // 
            if (Canvas.GetLeft(background) < -1262)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background2) + background2.Width);
            }

            // 
            if (Canvas.GetLeft(background2) < -1262)
            {
                Canvas.SetLeft(background2, Canvas.GetLeft(background) + background.Width);
            }

            Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            Canvas.SetLeft(obsticle, Canvas.GetLeft(obsticle) - 12);

            scoreText.Content = "Score: " + score;

            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width - 15, player.Height);
            obsticleHitBox = new Rect(Canvas.GetLeft(obsticle), Canvas.GetTop(obsticle), obsticle.Width, obsticle.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);

            //
            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                speed = 0;

                Canvas.SetTop(player, Canvas.GetTop(ground) - player.Height);

                jumping = false;

                Spriteindex += .5;
             //
                if (Spriteindex > 8)
                {
                    Spriteindex = 1;
                }

                RunSprite(Spriteindex);
            }

            // 
            if(jumping == true)
            {
                speed = -9;

                force -= 1;
            }
            else
            {
                speed = 12;
            }

            //
            if(force < 0)
            {
                jumping = false;
            }

            //
            if(Canvas.GetLeft(obsticle) < -50)
            {
                Canvas.SetLeft(obsticle, 950);

                Canvas.SetTop(obsticle, obsticlePosition[rnd.Next(0, obsticlePosition.Length)]);

                score += 1;
            }

            //
            if (playerHitBox.IntersectsWith(obsticleHitBox))
            {
                gameOver = true;

                gameTimer.Stop();
            }

            // 
            if(gameOver == true)
            {
                obsticle.Stroke = Brushes.Black;
                obsticle.StrokeThickness = 1;

                player.Stroke = Brushes.Red;
                player.StrokeThickness = 1;

                scoreText.Content = "Score: " + score + " Press Enter to play again!!!";
            }
            else
            {
                player.StrokeThickness = 0;
                obsticle.StrokeThickness = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && gameOver == true)
            {
                StartGame();
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && jumping == false && Canvas.GetTop(player) > 260)
            {
                jumping = true;
                force = 15;
                speed = -12;

                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
            }
        }



        private void StartGame()
        {
            Canvas.SetLeft(background, 0);
            Canvas.SetLeft(background2, 1262);

            Canvas.SetLeft(player, 110);
            Canvas.SetTop(player, 140);

            Canvas.SetLeft(obsticle, 950);
            Canvas.SetTop(obsticle, 310);

            RunSprite(1);

            obsticleSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obsticle.Fill = obsticleSprite;

            jumping = false;
            gameOver = false;
            score = 0;

            scoreText.Content = "Score: " + score;

            gameTimer.Start();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void RunSprite(double i)
        {
            switch (i)
            {
                case 1:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_01.gif"));
                    break;
                case 2:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
                    break;
                case 3:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_03.gif"));
                    break;
                case 4:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_04.gif"));
                    break;
                case 5:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 6:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_06.gif"));
                    break;
                case 7:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_07.gif"));
                    break;
                case 8:
                    playerSprite.ImageSource = backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_08.gif"));
                    break;
            }

            player.Fill = playerSprite;

        }
    }
}
