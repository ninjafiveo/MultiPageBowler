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
using msgBox = System.Windows.Forms.MessageBox;
using System.IO;

namespace MultiPage.Views
{
    /// <summary>
    /// Interaction logic for BlueView.xaml
    /// </summary>
    public partial class BlueView : UserControl
    {
        int gameScore1;
        int gameScore2;
        int gameScore3;
        int tieAmount;
        string valString;

       
        public BlueView()
        {
            InitializeComponent();
        }

        private void calculateBtn(object sender, RoutedEventArgs e)
        {
            tieAmount = 0;
            //will try to parse the variables then turn into an array
            try
            {
                gameScore1 = int.Parse(xScore1.Text);
                gameScore2 = int.Parse(xScore2.Text);
                gameScore3 = int.Parse(xScore3.Text);

            }
            catch (FormatException ex)
            {
                msgBox.Show("Error 401: " + ex.Message);
            }

            Name.Text = xPlayerName.Text + "'s Bowling Stats";

            if (xMale.IsChecked == true)
            {
                yourGender.Text = "Male";
            }
            else if (xFemale.IsChecked == true)
            {
                yourGender.Text = "Female";
            }
            else if (xOther.IsChecked == true)
            {
                yourGender.Text = "Other";
            }
            else
            {
                msgBox.Show("You messed up you forgot to check radio button");
            }
            var game_series = new List<int> { gameScore1, gameScore2, gameScore3 };
            //sum of the average
            sum.Text = Convert.ToString(game_series.Sum());

            //Average of the data
            Average.Text = Convert.ToString(game_series.Average());

            //Max of the array
            int maxValue = game_series.Max();
            Largest.Text = Convert.ToString(maxValue);

            for (int i = 0; i < game_series.Count();)
            {
                if (game_series[i] == maxValue)
                {
                    tieAmount++;
                    int game_seriesVal = i + 1;
                    if (tieAmount == 1)
                    {
                        valString = " game " + game_seriesVal + ", and";
                    }
                    else
                    {
                        valString += " game " + game_seriesVal;
                    }
                }
                i++;
            }
            if (tieAmount == 2)
            {
                Largest.Text = "Tie" + valString + ".";
            }
            if (tieAmount == 3)
            {
                Largest.Text = "Three way tie";
            }


            #region

            using (StreamWriter sw = new StreamWriter(@"c:\temp\myScores.txt"))
            {
                sw.WriteLine($"Player name: {xPlayerName.Text}. Gender: {yourGender.Text}. Score 1: {xScore1.Text}, Score 2: {xScore2.Text}, Score 3: {xScore3.Text}, Total Sum: {sum.Text}, Game Average: {Average.Text}, High Game: {Largest.Text}.");
            }

            #endregion
        }

        private void Clear_App(object sender, RoutedEventArgs e)
        {
            xPlayerName.Text = "";
            xMale.IsChecked = false;
            xFemale.IsChecked = false;
            xOther.IsChecked = false;
            xScore1.Text = "";
            xScore2.Text = "";
            xScore3.Text = "";
        }

        private void Application_end(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
