using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace Fixtures
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        //global output variables
        private int divCount = 0;
        private int[] matchCount = new int[15];
        private string[,] game = new string[15, 210]; //Division, Matches ... The list of all matches which must take place

        private string[,] name = new string[15, 15]; //Division, Team
        private string[,,] shared = new string[15, 15, 4]; //Max 15 divisions, 15 teams, 4 teams for single grounds
        private string[,,] datesHome = new string[15, 15, 13]; //Division, Team, Dates
        private string[,,] datesNoPlay = new string[15, 15, 13]; //Division, Team, Dates

        public Form2(int d, int[] m, string[,] g, string[,] n, string[, ,] s, string[, ,] dh, string[, ,] dnp)
        {
            InitializeComponent();
            divCount = d;
            matchCount = m;
            game = g;
            name = n;
            shared = s;
            datesHome = dh;
            datesNoPlay = dnp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int teamHome = 0;
            int teamAway = 0;
            string previous = "start";
            string temp = "";
            bool home = true;
            int count = 0;

            for (int div = 0; div < divCount; div++) //for each division
            {
                for (int date = 0; date < 26; date++) //for each date
                {
                    for (int m = 0; m < matchCount[div]; m++) //for each match in division
                    {
                        //store teams at integers for home and away
                        foreach (char c in game[div, m])
                        {
                            if (c != 'v' && c != 's') //if c is a team number
                            {
                                if (previous == "start")
                                {
                                    home = true;
                                    teamHome = (int)Char.GetNumericValue(c);
                                }
                                else if (previous == "s")
                                {
                                    home = false;
                                    teamAway = (int)Char.GetNumericValue(c);
                                }
                                else
                                {
                                    temp = previous + Convert.ToString(c);

                                    if (home == true)
                                    {
                                        teamHome = Convert.ToInt32(temp);
                                    }
                                    else
                                    {
                                        teamAway = Convert.ToInt32(temp);
                                    }
                                }
                            }

                            previous = Convert.ToString(c);
                        }

                        previous = "start";
                        bool valid = true;

                        for (int i = 0; i < 13; i++) //for each possible dates home
                        {
                            if (convertDate(datesHome[div, teamAway-1, i]) == date ||     //team playing away must play home ... invalid match date
                                convertDate(datesNoPlay[div, teamHome-1, i]) == date ||   //team in match cannot play on date ... invalid match date
                                convertDate(datesNoPlay[div, teamAway-1, i]) == date)  
                            {
                                valid = false;
                                count++;
                            }
                        }
                        
                        //if away team not play home and not noPlay for any of the teams in match 
                        //then add match as available for that date

                        //Add another variable to teams called assigned... if not assigned for any of the teams...
                    }
                }
            }
        }

        private int convertDate(string x)
        {
            int res = 1;

            switch (x)
            {
                case "17th April":
                    res = 0;
                    break;
                case "24th April":
                    res = 1;
                    break;
                case "1st May":
                    res = 2;
                    break;
                case "8th May":
                    res = 3;
                    break;
                case "15th May":
                    res = 4;
                    break;
                case "22nd May":
                    res = 5;
                    break;
                case "29th May":
                    res = 6;
                    break;
                case "5th June":
                    res = 7;
                    break;
                case "12th June":
                    res = 8;
                    break;
                case "19th June":
                    res = 9;
                    break;
                case "26th June":
                    res = 10;
                    break;
                case "3rd July":
                    res = 11;
                    break;
                case "10th July":
                    res = 12;
                    break;
                case "17th July":
                    res = 13;
                    break;
                case "24th July":
                    res = 14;
                    break;
                case "31st July":
                    res = 15;
                    break;
                case "7th August":
                    res = 16;
                    break;
                case "14th August":
                    res = 17;
                    break;
                case "21st August":
                    res = 18;
                    break;
                case "28th August":
                    res = 19;
                    break;
                case "4th September":
                    res = 20;
                    break;
                case "11th September":
                    res = 21;
                    break;
                case "18th September":
                    res = 22;
                    break;
                case "2nd May (Holiday)":
                    res = 23;
                    break;
                case "30th May (Holiday)":
                    res = 24;
                    break;
                case "29th August (Holiday)":
                    res = 25;
                    break;
                default:
                    res = 100;
                    break;
            }
            return res;
        }
    }
}
