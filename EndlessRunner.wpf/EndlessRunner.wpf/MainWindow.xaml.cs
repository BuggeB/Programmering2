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

            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,, /images/background.gif"));

            background.Fill = backgroundSprite;
            background2.Fill = backgroundSprite;

            StartGame();
        }

        /// <summary>
        /// Själva motorn för spelet som ställer in alla bakgrunder och som får spelaren att fungera
        /// </summary>
        /// <param name="sender"> objektet </param>
        /// <param name="e"></param>
        private void GameEngine(object sender, EventArgs e)
        {
            Canvas.SetLeft(background, Canvas.GetLeft(background) - 3);
            Canvas.SetLeft(background2, Canvas.GetLeft(background2) - 3);

            // Sätter bakgrund och storlek
            if (Canvas.GetLeft(background) < -1262)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background2) + background2.Width);
            }

            // Sätter bakgrund och storlek
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

            // Kontrollerar om spelaren nuddar marken
            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                speed = 0;

                Canvas.SetTop(player, Canvas.GetTop(ground) - player.Height);

                jumping = false;

                Spriteindex += .5;

             // Kontrollerar antalet "sprites" på skärmen
                if (Spriteindex > 8)
                {
                    Spriteindex = 1;
                }

                RunSprite(Spriteindex);
            }

            // Om man hoppar så blir man lite långsammare
            if(jumping == true)
            {
                speed = -9;

                force -= 1;
            }
            else
            {
                speed = 12;
            }

            // Om force är under 0 så kan man inte hoppa
            if(force < 0)
            {
                jumping = false;
            }

            // För varje hinder som man hoppar över så får man ett till poäng
            if(Canvas.GetLeft(obsticle) < -50)
            {
                Canvas.SetLeft(obsticle, 950);

                Canvas.SetTop(obsticle, obsticlePosition[rnd.Next(0, obsticlePosition.Length)]);

                score += 1;
            }

            // Om spelaren träffar ett hinder så avslutas spelet
            if (playerHitBox.IntersectsWith(obsticleHitBox))
            {
                gameOver = true;

                gameTimer.Stop();
            }

            // Om spelet tar slut så får man upp sina poäng samt en fråga om man vill spela igen genom att klicka på enter
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
        /// <param name="sender"> objektet </param>
        /// <param name="e"> sender (Enter knappen) </param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
           // När man klickar på enter så startas spelet
            if (e.Key == Key.Enter && gameOver == true)
            {
                StartGame();
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"> objektet </param>
        /// <param name="e"> sender (space kanppen) </param>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Om man trucker ner space tangenten och man inte är i luften så kommer gubben att hoppa
            if (e.Key == Key.Space && jumping == false && Canvas.GetTop(player) > 260)
            {
                jumping = true;
                force = 15;
                speed = -12;

                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
            }
        }



        /// <summary>
        /// Ställer in standardvärderna för spelet när spelet startas
        /// </summary>
        private void StartGame()
        {
            Canvas.SetLeft(background, 0);
            Canvas.SetLeft(background2, 1262);

            Canvas.SetLeft(player, 110);
            Canvas.SetTop(player, 140);

            Canvas.SetLeft(obsticle, 950);
            Canvas.SetTop(obsticle, 310);

            RunSprite(1);

            obsticleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obsticle.Fill = obsticleSprite;

            jumping = false;
            gameOver = false;
            score = 0;

            scoreText.Content = "Score: " + score;

            gameTimer.Start();

        }

        /// <summary>
        /// Olika animationer för karaktären beroende på vad den gör
        /// </summary>
        /// <param name="i"> Eventet </param>
        private void RunSprite(double i)
        {
            switch (i)
            {
                case 1:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,, /images/newRunner_01.gif"));
                    break;
                case 2:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,, /images/newRunner_02.gif"));
                    break;
                case 3:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,, /images/newRunner_03.gif"));
                    break;
                case 4:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_04.gif"));
                    break;
                case 5:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 6:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_06.gif"));
                    break;
                case 7:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_07.gif"));
                    break;
                case 8:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_08.gif"));
                    break;
            }

            player.Fill = playerSprite;

        }
    }
}
