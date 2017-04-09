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
        private int division = 0;
        private int[] matchCount = new int[15];
        private int[] teamCount = new int[15];
        private string[,] game = new string[15, 210]; //Division, Matches ... The list of all matches which must take place

        private string[,] name = new string[15, 15]; //Division, Team
        private string[,,] shared = new string[15, 15, 4]; //Max 15 divisions, 15 teams, 4 teams for single grounds
        private string[,,] datesHome = new string[15, 15, 13]; //Division, Team, Dates
        private string[,,] datesNoPlay = new string[15, 15, 13]; //Division, Team, Dates

        public Form2(int d, int[] m, string[,] g, string[,] n, string[, ,] s, string[, ,] dh, string[, ,] dnp, int[] tc)
        {
            InitializeComponent();
            divCount = d;
            matchCount = m;
            game = g;
            name = n;
            shared = s;
            datesHome = dh;
            datesNoPlay = dnp;
            teamCount = tc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int teamHome = 0;
            int teamAway = 0;
            string previous = "start";
            string temp = "";
            bool home = true;
            int count = 0;

            team1.Hide();
            team2.Hide();
            team3.Hide();
            team4.Hide();
            team5.Hide();
            team6.Hide();
            team7.Hide();
            team8.Hide();
            team9.Hide();
            team10.Hide();
            team11.Hide();
            team12.Hide();
            team13.Hide();
            team14.Hide();
            team15.Hide();

            for (int i = 15; i > divCount; i--)
            {
                //remove non-used divisions
                metTabControl.SelectedIndex = divCount;
                metTabControl.TabPages.Remove(metTabControl.SelectedTab);
            }

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

            this.metTabControl.SelectedIndex = 0;

            //Add key for teams
            for (int t = 0; t < teamCount[0]; t++) //division 1
            {
                switch (t)
                {
                    case 0:
                        team1.Show();
                        team1.Text = team1.Text + name[0, 0];
                        break;
                    case 1:
                        team2.Show();
                        team2.Text = team2.Text + name[0, 1];
                        break;
                    case 2:
                        team3.Show();
                        team3.Text = team3.Text + name[0, 2];
                        break;
                    case 3:
                        team4.Show();
                        team4.Text = team4.Text + name[0, 3];
                        break;
                    case 4:
                        team5.Show();
                        team5.Text = team5.Text + name[0, 4];
                        break;
                    case 5:
                        team6.Show();
                        team6.Text = team6.Text + name[0, 5];
                        break;
                    case 6:
                        team7.Show();
                        team7.Text = team7.Text + name[0, 6];
                        break;
                    case 7:
                        team8.Show();
                        team8.Text = team8.Text + name[0, 7];
                        break;
                    case 8:
                        team9.Show();
                        team9.Text = team9.Text + name[0, 8];
                        break;
                    case 9:
                        team10.Show();
                        team10.Text = team10.Text + name[0, 9];
                        break;
                    case 10:
                        team11.Show();
                        team11.Text = team11.Text + name[0, 10];
                        break;
                    case 11:
                        team12.Show();
                        team12.Text = team12.Text + name[0, 11];
                        break;
                    case 12:
                        team13.Show();
                        team13.Text = team13.Text + name[0, 12];
                        break;
                    case 13:
                        team14.Show();
                        team14.Text = team14.Text + name[0, 13];
                        break;
                    case 14:
                        team15.Show();
                        team15.Text = team15.Text + name[0, 14];
                        break;
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

        private void metTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save changes before moving tabs

            //

            division = metTabControl.SelectedIndex; //division = 0 .. 14

            #region Move objects between tabs
            metTabControl.SelectedTab.Controls.Add(team1);
            metTabControl.SelectedTab.Controls.Add(team2);
            metTabControl.SelectedTab.Controls.Add(team3);
            metTabControl.SelectedTab.Controls.Add(team4);
            metTabControl.SelectedTab.Controls.Add(team5);
            metTabControl.SelectedTab.Controls.Add(team6);
            metTabControl.SelectedTab.Controls.Add(team7);
            metTabControl.SelectedTab.Controls.Add(team8);
            metTabControl.SelectedTab.Controls.Add(team9);
            metTabControl.SelectedTab.Controls.Add(team10);
            metTabControl.SelectedTab.Controls.Add(team11);
            metTabControl.SelectedTab.Controls.Add(team12);
            metTabControl.SelectedTab.Controls.Add(team13);
            metTabControl.SelectedTab.Controls.Add(team14);
            metTabControl.SelectedTab.Controls.Add(team15);
            metTabControl.SelectedTab.Controls.Add(metroLabel15);
            metTabControl.SelectedTab.Controls.Add(metroLabel2);
            metTabControl.SelectedTab.Controls.Add(metroLabel13);
            metTabControl.SelectedTab.Controls.Add(metroLabel14);
            metTabControl.SelectedTab.Controls.Add(lblBack);
            metTabControl.SelectedTab.Controls.Add(lblBack1);
            metTabControl.SelectedTab.Controls.Add(lblBack2);
            metTabControl.SelectedTab.Controls.Add(lblBack3);
            metTabControl.SelectedTab.Controls.Add(lblBack4);
            metTabControl.SelectedTab.Controls.Add(lblBack5);
            metTabControl.SelectedTab.Controls.Add(lblBack6);
            metTabControl.SelectedTab.Controls.Add(lblBack7);
            metTabControl.SelectedTab.Controls.Add(lblBack8);
            metTabControl.SelectedTab.Controls.Add(lblBack9);
            metTabControl.SelectedTab.Controls.Add(lblBack10);
            metTabControl.SelectedTab.Controls.Add(lblBack11);
            metTabControl.SelectedTab.Controls.Add(lblBack12);
            metTabControl.SelectedTab.Controls.Add(lblBack13);
            metTabControl.SelectedTab.Controls.Add(lblBack14);
            metTabControl.SelectedTab.Controls.Add(metroLabel11);
            metTabControl.SelectedTab.Controls.Add(metroLabel9);
            metTabControl.SelectedTab.Controls.Add(metroLabel7);
            metTabControl.SelectedTab.Controls.Add(metroLabel5);
            metTabControl.SelectedTab.Controls.Add(metroLabel3);
            metTabControl.SelectedTab.Controls.Add(metroLabel23);
            metTabControl.SelectedTab.Controls.Add(metroLabel21);
            metTabControl.SelectedTab.Controls.Add(metroLabel18);
            metTabControl.SelectedTab.Controls.Add(txtTeam);
            metTabControl.SelectedTab.Controls.Add(txtTeam1);
            metTabControl.SelectedTab.Controls.Add(txtTeam2);
            metTabControl.SelectedTab.Controls.Add(txtTeam3);
            metTabControl.SelectedTab.Controls.Add(txtTeam4);
            metTabControl.SelectedTab.Controls.Add(txtTeam5);
            metTabControl.SelectedTab.Controls.Add(txtTeam6);
            metTabControl.SelectedTab.Controls.Add(txtTeam7);
            metTabControl.SelectedTab.Controls.Add(txtTeam8);
            metTabControl.SelectedTab.Controls.Add(txtTeam9);
            metTabControl.SelectedTab.Controls.Add(txtTeam10);
            metTabControl.SelectedTab.Controls.Add(txtTeam11);
            metTabControl.SelectedTab.Controls.Add(txtTeam12);
            metTabControl.SelectedTab.Controls.Add(txtTeam13);
            metTabControl.SelectedTab.Controls.Add(txtTeam14);
            metTabControl.SelectedTab.Controls.Add(metroLabel10);
            metTabControl.SelectedTab.Controls.Add(metroLabel8);
            metTabControl.SelectedTab.Controls.Add(metroLabel6);
            metTabControl.SelectedTab.Controls.Add(metroLabel4);
            metTabControl.SelectedTab.Controls.Add(metroLabel1);
            metTabControl.SelectedTab.Controls.Add(metroLabel22);
            metTabControl.SelectedTab.Controls.Add(metroLabel20);
            metTabControl.SelectedTab.Controls.Add(metroLabel16);
            metTabControl.SelectedTab.Controls.Add(metroLabel12);
            metTabControl.SelectedTab.Controls.Add(matchA1);
            metTabControl.SelectedTab.Controls.Add(matchA2);
            metTabControl.SelectedTab.Controls.Add(matchA3);
            metTabControl.SelectedTab.Controls.Add(matchA4);
            metTabControl.SelectedTab.Controls.Add(matchA5);
            metTabControl.SelectedTab.Controls.Add(matchA6);
            metTabControl.SelectedTab.Controls.Add(matchA7);
            metTabControl.SelectedTab.Controls.Add(matchA8);
            metTabControl.SelectedTab.Controls.Add(matchA9);
            metTabControl.SelectedTab.Controls.Add(matchA10);
            metTabControl.SelectedTab.Controls.Add(matchA11);
            metTabControl.SelectedTab.Controls.Add(matchA12);
            metTabControl.SelectedTab.Controls.Add(matchA13);
            metTabControl.SelectedTab.Controls.Add(matchA14);
            metTabControl.SelectedTab.Controls.Add(matchA15);
            metTabControl.SelectedTab.Controls.Add(matchA16);
            metTabControl.SelectedTab.Controls.Add(matchA17);
            metTabControl.SelectedTab.Controls.Add(matchA18);
            metTabControl.SelectedTab.Controls.Add(matchA19);
            metTabControl.SelectedTab.Controls.Add(matchA20);
            metTabControl.SelectedTab.Controls.Add(matchA21);
            metTabControl.SelectedTab.Controls.Add(matchA22);
            metTabControl.SelectedTab.Controls.Add(matchA23);
            metTabControl.SelectedTab.Controls.Add(matchB1);
            metTabControl.SelectedTab.Controls.Add(matchB2);
            metTabControl.SelectedTab.Controls.Add(matchB3);
            metTabControl.SelectedTab.Controls.Add(matchB4);
            metTabControl.SelectedTab.Controls.Add(matchB5);
            metTabControl.SelectedTab.Controls.Add(matchB6);
            metTabControl.SelectedTab.Controls.Add(matchB7);
            metTabControl.SelectedTab.Controls.Add(matchB8);
            metTabControl.SelectedTab.Controls.Add(matchB9);
            metTabControl.SelectedTab.Controls.Add(matchB10);
            metTabControl.SelectedTab.Controls.Add(matchB11);
            metTabControl.SelectedTab.Controls.Add(matchB12);
            metTabControl.SelectedTab.Controls.Add(matchB13);
            metTabControl.SelectedTab.Controls.Add(matchB14);
            metTabControl.SelectedTab.Controls.Add(matchB15);
            metTabControl.SelectedTab.Controls.Add(matchB16);
            metTabControl.SelectedTab.Controls.Add(matchB17);
            metTabControl.SelectedTab.Controls.Add(matchB18);
            metTabControl.SelectedTab.Controls.Add(matchB19);
            metTabControl.SelectedTab.Controls.Add(matchB20);
            metTabControl.SelectedTab.Controls.Add(matchB21);
            metTabControl.SelectedTab.Controls.Add(matchB22);
            metTabControl.SelectedTab.Controls.Add(matchB23);
            metTabControl.SelectedTab.Controls.Add(matchC1);
            metTabControl.SelectedTab.Controls.Add(matchC2);
            metTabControl.SelectedTab.Controls.Add(matchC3);
            metTabControl.SelectedTab.Controls.Add(matchC4);
            metTabControl.SelectedTab.Controls.Add(matchC5);
            metTabControl.SelectedTab.Controls.Add(matchC6);
            metTabControl.SelectedTab.Controls.Add(matchC7);
            metTabControl.SelectedTab.Controls.Add(matchC8);
            metTabControl.SelectedTab.Controls.Add(matchC9);
            metTabControl.SelectedTab.Controls.Add(matchC10);
            metTabControl.SelectedTab.Controls.Add(matchC11);
            metTabControl.SelectedTab.Controls.Add(matchC12);
            metTabControl.SelectedTab.Controls.Add(matchC13);
            metTabControl.SelectedTab.Controls.Add(matchC14);
            metTabControl.SelectedTab.Controls.Add(matchC15);
            metTabControl.SelectedTab.Controls.Add(matchC16);
            metTabControl.SelectedTab.Controls.Add(matchC17);
            metTabControl.SelectedTab.Controls.Add(matchC18);
            metTabControl.SelectedTab.Controls.Add(matchC19);
            metTabControl.SelectedTab.Controls.Add(matchC20);
            metTabControl.SelectedTab.Controls.Add(matchC21);
            metTabControl.SelectedTab.Controls.Add(matchC22);
            metTabControl.SelectedTab.Controls.Add(matchC23);
            metTabControl.SelectedTab.Controls.Add(matchD1);
            metTabControl.SelectedTab.Controls.Add(matchD2);
            metTabControl.SelectedTab.Controls.Add(matchD3);
            metTabControl.SelectedTab.Controls.Add(matchD4);
            metTabControl.SelectedTab.Controls.Add(matchD5);
            metTabControl.SelectedTab.Controls.Add(matchD6);
            metTabControl.SelectedTab.Controls.Add(matchD7);
            metTabControl.SelectedTab.Controls.Add(matchD8);
            metTabControl.SelectedTab.Controls.Add(matchD9);
            metTabControl.SelectedTab.Controls.Add(matchD10);
            metTabControl.SelectedTab.Controls.Add(matchD11);
            metTabControl.SelectedTab.Controls.Add(matchD12);
            metTabControl.SelectedTab.Controls.Add(matchD13);
            metTabControl.SelectedTab.Controls.Add(matchD14);
            metTabControl.SelectedTab.Controls.Add(matchD15);
            metTabControl.SelectedTab.Controls.Add(matchD16);
            metTabControl.SelectedTab.Controls.Add(matchD17);
            metTabControl.SelectedTab.Controls.Add(matchD18);
            metTabControl.SelectedTab.Controls.Add(matchD19);
            metTabControl.SelectedTab.Controls.Add(matchD20);
            metTabControl.SelectedTab.Controls.Add(matchD21);
            metTabControl.SelectedTab.Controls.Add(matchD22);
            metTabControl.SelectedTab.Controls.Add(matchD23);
            metTabControl.SelectedTab.Controls.Add(matchE1);
            metTabControl.SelectedTab.Controls.Add(matchE2);
            metTabControl.SelectedTab.Controls.Add(matchE3);
            metTabControl.SelectedTab.Controls.Add(matchE4);
            metTabControl.SelectedTab.Controls.Add(matchE5);
            metTabControl.SelectedTab.Controls.Add(matchE6);
            metTabControl.SelectedTab.Controls.Add(matchE7);
            metTabControl.SelectedTab.Controls.Add(matchE8);
            metTabControl.SelectedTab.Controls.Add(matchE9);
            metTabControl.SelectedTab.Controls.Add(matchE10);
            metTabControl.SelectedTab.Controls.Add(matchE11);
            metTabControl.SelectedTab.Controls.Add(matchE12);
            metTabControl.SelectedTab.Controls.Add(matchE13);
            metTabControl.SelectedTab.Controls.Add(matchE14);
            metTabControl.SelectedTab.Controls.Add(matchE15);
            metTabControl.SelectedTab.Controls.Add(matchE16);
            metTabControl.SelectedTab.Controls.Add(matchE17);
            metTabControl.SelectedTab.Controls.Add(matchE18);
            metTabControl.SelectedTab.Controls.Add(matchE19);
            metTabControl.SelectedTab.Controls.Add(matchE20);
            metTabControl.SelectedTab.Controls.Add(matchE21);
            metTabControl.SelectedTab.Controls.Add(matchE22);
            metTabControl.SelectedTab.Controls.Add(matchE23);
            metTabControl.SelectedTab.Controls.Add(matchF1);
            metTabControl.SelectedTab.Controls.Add(matchF2);
            metTabControl.SelectedTab.Controls.Add(matchF3);
            metTabControl.SelectedTab.Controls.Add(matchF4);
            metTabControl.SelectedTab.Controls.Add(matchF5);
            metTabControl.SelectedTab.Controls.Add(matchF6);
            metTabControl.SelectedTab.Controls.Add(matchF7);
            metTabControl.SelectedTab.Controls.Add(matchF8);
            metTabControl.SelectedTab.Controls.Add(matchF9);
            metTabControl.SelectedTab.Controls.Add(matchF10);
            metTabControl.SelectedTab.Controls.Add(matchF11);
            metTabControl.SelectedTab.Controls.Add(matchF12);
            metTabControl.SelectedTab.Controls.Add(matchF13);
            metTabControl.SelectedTab.Controls.Add(matchF14);
            metTabControl.SelectedTab.Controls.Add(matchF15);
            metTabControl.SelectedTab.Controls.Add(matchF16);
            metTabControl.SelectedTab.Controls.Add(matchF17);
            metTabControl.SelectedTab.Controls.Add(matchF18);
            metTabControl.SelectedTab.Controls.Add(matchF19);
            metTabControl.SelectedTab.Controls.Add(matchF20);
            metTabControl.SelectedTab.Controls.Add(matchF21);
            metTabControl.SelectedTab.Controls.Add(matchF22);
            metTabControl.SelectedTab.Controls.Add(matchF23);
            metTabControl.SelectedTab.Controls.Add(matchG1);
            metTabControl.SelectedTab.Controls.Add(matchG2);
            metTabControl.SelectedTab.Controls.Add(matchG3);
            metTabControl.SelectedTab.Controls.Add(matchG4);
            metTabControl.SelectedTab.Controls.Add(matchG5);
            metTabControl.SelectedTab.Controls.Add(matchG6);
            metTabControl.SelectedTab.Controls.Add(matchG7);
            metTabControl.SelectedTab.Controls.Add(matchG8);
            metTabControl.SelectedTab.Controls.Add(matchG9);
            metTabControl.SelectedTab.Controls.Add(matchG10);
            metTabControl.SelectedTab.Controls.Add(matchG11);
            metTabControl.SelectedTab.Controls.Add(matchG12);
            metTabControl.SelectedTab.Controls.Add(matchG13);
            metTabControl.SelectedTab.Controls.Add(matchG14);
            metTabControl.SelectedTab.Controls.Add(matchG15);
            metTabControl.SelectedTab.Controls.Add(matchG16);
            metTabControl.SelectedTab.Controls.Add(matchG17);
            metTabControl.SelectedTab.Controls.Add(matchG18);
            metTabControl.SelectedTab.Controls.Add(matchG19);
            metTabControl.SelectedTab.Controls.Add(matchG20);
            metTabControl.SelectedTab.Controls.Add(matchG21);
            metTabControl.SelectedTab.Controls.Add(matchG22);
            metTabControl.SelectedTab.Controls.Add(matchG23);
            metTabControl.SelectedTab.Controls.Add(assignA1);
            metTabControl.SelectedTab.Controls.Add(assignA2);
            metTabControl.SelectedTab.Controls.Add(assignA3);
            metTabControl.SelectedTab.Controls.Add(assignA4);
            metTabControl.SelectedTab.Controls.Add(assignA5);
            metTabControl.SelectedTab.Controls.Add(assignA6);
            metTabControl.SelectedTab.Controls.Add(assignA7);
            metTabControl.SelectedTab.Controls.Add(assignA8);
            metTabControl.SelectedTab.Controls.Add(assignA9);
            metTabControl.SelectedTab.Controls.Add(assignA10);
            metTabControl.SelectedTab.Controls.Add(assignA11);
            metTabControl.SelectedTab.Controls.Add(assignA12);
            metTabControl.SelectedTab.Controls.Add(assignA13);
            metTabControl.SelectedTab.Controls.Add(assignA14);
            metTabControl.SelectedTab.Controls.Add(assignA15);
            metTabControl.SelectedTab.Controls.Add(assignA16);
            metTabControl.SelectedTab.Controls.Add(assignA17);
            metTabControl.SelectedTab.Controls.Add(assignA18);
            metTabControl.SelectedTab.Controls.Add(assignA19);
            metTabControl.SelectedTab.Controls.Add(assignA20);
            metTabControl.SelectedTab.Controls.Add(assignA21);
            metTabControl.SelectedTab.Controls.Add(assignA22);
            metTabControl.SelectedTab.Controls.Add(assignA23);
            metTabControl.SelectedTab.Controls.Add(assignB1);
            metTabControl.SelectedTab.Controls.Add(assignB2);
            metTabControl.SelectedTab.Controls.Add(assignB3);
            metTabControl.SelectedTab.Controls.Add(assignB4);
            metTabControl.SelectedTab.Controls.Add(assignB5);
            metTabControl.SelectedTab.Controls.Add(assignB6);
            metTabControl.SelectedTab.Controls.Add(assignB7);
            metTabControl.SelectedTab.Controls.Add(assignB8);
            metTabControl.SelectedTab.Controls.Add(assignB9);
            metTabControl.SelectedTab.Controls.Add(assignB10);
            metTabControl.SelectedTab.Controls.Add(assignB11);
            metTabControl.SelectedTab.Controls.Add(assignB12);
            metTabControl.SelectedTab.Controls.Add(assignB13);
            metTabControl.SelectedTab.Controls.Add(assignB14);
            metTabControl.SelectedTab.Controls.Add(assignB15);
            metTabControl.SelectedTab.Controls.Add(assignB16);
            metTabControl.SelectedTab.Controls.Add(assignB17);
            metTabControl.SelectedTab.Controls.Add(assignB18);
            metTabControl.SelectedTab.Controls.Add(assignB19);
            metTabControl.SelectedTab.Controls.Add(assignB20);
            metTabControl.SelectedTab.Controls.Add(assignB21);
            metTabControl.SelectedTab.Controls.Add(assignB22);
            metTabControl.SelectedTab.Controls.Add(assignB23);
            metTabControl.SelectedTab.Controls.Add(assignC1);
            metTabControl.SelectedTab.Controls.Add(assignC2);
            metTabControl.SelectedTab.Controls.Add(assignC3);
            metTabControl.SelectedTab.Controls.Add(assignC4);
            metTabControl.SelectedTab.Controls.Add(assignC5);
            metTabControl.SelectedTab.Controls.Add(assignC6);
            metTabControl.SelectedTab.Controls.Add(assignC7);
            metTabControl.SelectedTab.Controls.Add(assignC8);
            metTabControl.SelectedTab.Controls.Add(assignC9);
            metTabControl.SelectedTab.Controls.Add(assignC10);
            metTabControl.SelectedTab.Controls.Add(assignC11);
            metTabControl.SelectedTab.Controls.Add(assignC12);
            metTabControl.SelectedTab.Controls.Add(assignC13);
            metTabControl.SelectedTab.Controls.Add(assignC14);
            metTabControl.SelectedTab.Controls.Add(assignC15);
            metTabControl.SelectedTab.Controls.Add(assignC16);
            metTabControl.SelectedTab.Controls.Add(assignC17);
            metTabControl.SelectedTab.Controls.Add(assignC18);
            metTabControl.SelectedTab.Controls.Add(assignC19);
            metTabControl.SelectedTab.Controls.Add(assignC20);
            metTabControl.SelectedTab.Controls.Add(assignC21);
            metTabControl.SelectedTab.Controls.Add(assignC22);
            metTabControl.SelectedTab.Controls.Add(assignC23);
            metTabControl.SelectedTab.Controls.Add(assignD1);
            metTabControl.SelectedTab.Controls.Add(assignD2);
            metTabControl.SelectedTab.Controls.Add(assignD3);
            metTabControl.SelectedTab.Controls.Add(assignD4);
            metTabControl.SelectedTab.Controls.Add(assignD5);
            metTabControl.SelectedTab.Controls.Add(assignD6);
            metTabControl.SelectedTab.Controls.Add(assignD7);
            metTabControl.SelectedTab.Controls.Add(assignD8);
            metTabControl.SelectedTab.Controls.Add(assignD9);
            metTabControl.SelectedTab.Controls.Add(assignD10);
            metTabControl.SelectedTab.Controls.Add(assignD11);
            metTabControl.SelectedTab.Controls.Add(assignD12);
            metTabControl.SelectedTab.Controls.Add(assignD13);
            metTabControl.SelectedTab.Controls.Add(assignD14);
            metTabControl.SelectedTab.Controls.Add(assignD15);
            metTabControl.SelectedTab.Controls.Add(assignD16);
            metTabControl.SelectedTab.Controls.Add(assignD17);
            metTabControl.SelectedTab.Controls.Add(assignD18);
            metTabControl.SelectedTab.Controls.Add(assignD19);
            metTabControl.SelectedTab.Controls.Add(assignD20);
            metTabControl.SelectedTab.Controls.Add(assignD21);
            metTabControl.SelectedTab.Controls.Add(assignD22);
            metTabControl.SelectedTab.Controls.Add(assignD23);
            metTabControl.SelectedTab.Controls.Add(assignE1);
            metTabControl.SelectedTab.Controls.Add(assignE2);
            metTabControl.SelectedTab.Controls.Add(assignE3);
            metTabControl.SelectedTab.Controls.Add(assignE4);
            metTabControl.SelectedTab.Controls.Add(assignE5);
            metTabControl.SelectedTab.Controls.Add(assignE6);
            metTabControl.SelectedTab.Controls.Add(assignE7);
            metTabControl.SelectedTab.Controls.Add(assignE8);
            metTabControl.SelectedTab.Controls.Add(assignE9);
            metTabControl.SelectedTab.Controls.Add(assignE10);
            metTabControl.SelectedTab.Controls.Add(assignE11);
            metTabControl.SelectedTab.Controls.Add(assignE12);
            metTabControl.SelectedTab.Controls.Add(assignE13);
            metTabControl.SelectedTab.Controls.Add(assignE14);
            metTabControl.SelectedTab.Controls.Add(assignE15);
            metTabControl.SelectedTab.Controls.Add(assignE16);
            metTabControl.SelectedTab.Controls.Add(assignE17);
            metTabControl.SelectedTab.Controls.Add(assignE18);
            metTabControl.SelectedTab.Controls.Add(assignE19);
            metTabControl.SelectedTab.Controls.Add(assignE20);
            metTabControl.SelectedTab.Controls.Add(assignE21);
            metTabControl.SelectedTab.Controls.Add(assignE22);
            metTabControl.SelectedTab.Controls.Add(assignE23);
            metTabControl.SelectedTab.Controls.Add(assignF1);
            metTabControl.SelectedTab.Controls.Add(assignF2);
            metTabControl.SelectedTab.Controls.Add(assignF3);
            metTabControl.SelectedTab.Controls.Add(assignF4);
            metTabControl.SelectedTab.Controls.Add(assignF5);
            metTabControl.SelectedTab.Controls.Add(assignF6);
            metTabControl.SelectedTab.Controls.Add(assignF7);
            metTabControl.SelectedTab.Controls.Add(assignF8);
            metTabControl.SelectedTab.Controls.Add(assignF9);
            metTabControl.SelectedTab.Controls.Add(assignF10);
            metTabControl.SelectedTab.Controls.Add(assignF11);
            metTabControl.SelectedTab.Controls.Add(assignF12);
            metTabControl.SelectedTab.Controls.Add(assignF13);
            metTabControl.SelectedTab.Controls.Add(assignF14);
            metTabControl.SelectedTab.Controls.Add(assignF15);
            metTabControl.SelectedTab.Controls.Add(assignF16);
            metTabControl.SelectedTab.Controls.Add(assignF17);
            metTabControl.SelectedTab.Controls.Add(assignF18);
            metTabControl.SelectedTab.Controls.Add(assignF19);
            metTabControl.SelectedTab.Controls.Add(assignF20);
            metTabControl.SelectedTab.Controls.Add(assignF21);
            metTabControl.SelectedTab.Controls.Add(assignF22);
            metTabControl.SelectedTab.Controls.Add(assignF23);
            metTabControl.SelectedTab.Controls.Add(assignG1);
            metTabControl.SelectedTab.Controls.Add(assignG2);
            metTabControl.SelectedTab.Controls.Add(assignG3);
            metTabControl.SelectedTab.Controls.Add(assignG4);
            metTabControl.SelectedTab.Controls.Add(assignG5);
            metTabControl.SelectedTab.Controls.Add(assignG6);
            metTabControl.SelectedTab.Controls.Add(assignG7);
            metTabControl.SelectedTab.Controls.Add(assignG8);
            metTabControl.SelectedTab.Controls.Add(assignG9);
            metTabControl.SelectedTab.Controls.Add(assignG10);
            metTabControl.SelectedTab.Controls.Add(assignG11);
            metTabControl.SelectedTab.Controls.Add(assignG12);
            metTabControl.SelectedTab.Controls.Add(assignG13);
            metTabControl.SelectedTab.Controls.Add(assignG14);
            metTabControl.SelectedTab.Controls.Add(assignG15);
            metTabControl.SelectedTab.Controls.Add(assignG16);
            metTabControl.SelectedTab.Controls.Add(assignG17);
            metTabControl.SelectedTab.Controls.Add(assignG18);
            metTabControl.SelectedTab.Controls.Add(assignG19);
            metTabControl.SelectedTab.Controls.Add(assignG20);
            metTabControl.SelectedTab.Controls.Add(assignG21);
            metTabControl.SelectedTab.Controls.Add(assignG22);
            metTabControl.SelectedTab.Controls.Add(assignG23);
            lblBack.BringToFront();
            lblBack1.BringToFront();
            lblBack2.BringToFront();
            lblBack3.BringToFront();
            lblBack4.BringToFront();
            lblBack5.BringToFront();
            lblBack6.BringToFront();
            lblBack7.BringToFront();
            lblBack8.BringToFront();
            lblBack9.BringToFront();
            lblBack10.BringToFront();
            lblBack11.BringToFront();
            lblBack12.BringToFront();
            lblBack13.BringToFront();
            lblBack14.BringToFront();
            metroLabel11.BringToFront();
            metroLabel9.BringToFront();
            metroLabel7.BringToFront();
            metroLabel5.BringToFront();
            metroLabel3.BringToFront();
            metroLabel23.BringToFront();
            metroLabel21.BringToFront();
            metroLabel18.BringToFront();
            metroLabel15.BringToFront();
            txtTeam.BringToFront();
            txtTeam1.BringToFront();
            txtTeam2.BringToFront();
            txtTeam3.BringToFront();
            txtTeam4.BringToFront();
            txtTeam5.BringToFront();
            txtTeam6.BringToFront();
            txtTeam7.BringToFront();
            txtTeam8.BringToFront();
            txtTeam9.BringToFront();
            txtTeam10.BringToFront();
            txtTeam11.BringToFront();
            txtTeam12.BringToFront();
            txtTeam13.BringToFront();
            txtTeam14.BringToFront();
            metroLabel10.BringToFront();
            metroLabel8.BringToFront();
            metroLabel6.BringToFront();
            metroLabel4.BringToFront();
            metroLabel1.BringToFront();
            metroLabel22.BringToFront();
            metroLabel20.BringToFront();
            metroLabel16.BringToFront();
            metroLabel12.BringToFront();
            team1.BringToFront();
            team2.BringToFront();
            team3.BringToFront();
            team4.BringToFront();
            team5.BringToFront();
            team6.BringToFront();
            team7.BringToFront();
            team8.BringToFront();
            team9.BringToFront();
            team10.BringToFront();
            team11.BringToFront();
            team12.BringToFront();
            team13.BringToFront();
            team14.BringToFront();
            team15.BringToFront();
            metroLabel2.BringToFront();
            metroLabel13.BringToFront();
            metroLabel14.BringToFront();
            assignA1.BringToFront();
            assignA2.BringToFront();
            assignA3.BringToFront();
            assignA4.BringToFront();
            assignA5.BringToFront();
            assignA6.BringToFront();
            assignA7.BringToFront();
            assignA8.BringToFront();
            assignA9.BringToFront();
            assignA10.BringToFront();
            assignA11.BringToFront();
            assignA12.BringToFront();
            assignA13.BringToFront();
            assignA14.BringToFront();
            assignA15.BringToFront();
            assignA16.BringToFront();
            assignA17.BringToFront();
            assignA18.BringToFront();
            assignA19.BringToFront();
            assignA20.BringToFront();
            assignA21.BringToFront();
            assignA22.BringToFront();
            assignA23.BringToFront();
            assignB1.BringToFront();
            assignB2.BringToFront();
            assignB3.BringToFront();
            assignB4.BringToFront();
            assignB5.BringToFront();
            assignB6.BringToFront();
            assignB7.BringToFront();
            assignB8.BringToFront();
            assignB9.BringToFront();
            assignB10.BringToFront();
            assignB11.BringToFront();
            assignB12.BringToFront();
            assignB13.BringToFront();
            assignB14.BringToFront();
            assignB15.BringToFront();
            assignB16.BringToFront();
            assignB17.BringToFront();
            assignB18.BringToFront();
            assignB19.BringToFront();
            assignB20.BringToFront();
            assignB21.BringToFront();
            assignB22.BringToFront();
            assignB23.BringToFront();
            assignC1.BringToFront();
            assignC2.BringToFront();
            assignC3.BringToFront();
            assignC4.BringToFront();
            assignC5.BringToFront();
            assignC6.BringToFront();
            assignC7.BringToFront();
            assignC8.BringToFront();
            assignC9.BringToFront();
            assignC10.BringToFront();
            assignC11.BringToFront();
            assignC12.BringToFront();
            assignC13.BringToFront();
            assignC14.BringToFront();
            assignC15.BringToFront();
            assignC16.BringToFront();
            assignC17.BringToFront();
            assignC18.BringToFront();
            assignC19.BringToFront();
            assignC20.BringToFront();
            assignC21.BringToFront();
            assignC22.BringToFront();
            assignC23.BringToFront();
            assignD1.BringToFront();
            assignD2.BringToFront();
            assignD3.BringToFront();
            assignD4.BringToFront();
            assignD5.BringToFront();
            assignD6.BringToFront();
            assignD7.BringToFront();
            assignD8.BringToFront();
            assignD9.BringToFront();
            assignD10.BringToFront();
            assignD11.BringToFront();
            assignD12.BringToFront();
            assignD13.BringToFront();
            assignD14.BringToFront();
            assignD15.BringToFront();
            assignD16.BringToFront();
            assignD17.BringToFront();
            assignD18.BringToFront();
            assignD19.BringToFront();
            assignD20.BringToFront();
            assignD21.BringToFront();
            assignD22.BringToFront();
            assignD23.BringToFront();
            assignE1.BringToFront();
            assignE2.BringToFront();
            assignE3.BringToFront();
            assignE4.BringToFront();
            assignE5.BringToFront();
            assignE6.BringToFront();
            assignE7.BringToFront();
            assignE8.BringToFront();
            assignE9.BringToFront();
            assignE10.BringToFront();
            assignE11.BringToFront();
            assignE12.BringToFront();
            assignE13.BringToFront();
            assignE14.BringToFront();
            assignE15.BringToFront();
            assignE16.BringToFront();
            assignE17.BringToFront();
            assignE18.BringToFront();
            assignE19.BringToFront();
            assignE20.BringToFront();
            assignE21.BringToFront();
            assignE22.BringToFront();
            assignE23.BringToFront();
            assignF1.BringToFront();
            assignF2.BringToFront();
            assignF3.BringToFront();
            assignF4.BringToFront();
            assignF5.BringToFront();
            assignF6.BringToFront();
            assignF7.BringToFront();
            assignF8.BringToFront();
            assignF9.BringToFront();
            assignF10.BringToFront();
            assignF11.BringToFront();
            assignF12.BringToFront();
            assignF13.BringToFront();
            assignF14.BringToFront();
            assignF15.BringToFront();
            assignF16.BringToFront();
            assignF17.BringToFront();
            assignF18.BringToFront();
            assignF19.BringToFront();
            assignF20.BringToFront();
            assignF21.BringToFront();
            assignF22.BringToFront();
            assignF23.BringToFront();
            assignG1.BringToFront();
            assignG2.BringToFront();
            assignG3.BringToFront();
            assignG4.BringToFront();
            assignG5.BringToFront();
            assignG6.BringToFront();
            assignG7.BringToFront();
            assignG8.BringToFront();
            assignG9.BringToFront();
            assignG10.BringToFront();
            assignG11.BringToFront();
            assignG12.BringToFront();
            assignG13.BringToFront();
            assignG14.BringToFront();
            assignG15.BringToFront();
            assignG16.BringToFront();
            assignG17.BringToFront();
            assignG18.BringToFront();
            assignG19.BringToFront();
            assignG20.BringToFront();
            assignG21.BringToFront();
            assignG22.BringToFront();
            assignG23.BringToFront();
            matchA1.BringToFront();
            matchA2.BringToFront();
            matchA3.BringToFront();
            matchA4.BringToFront();
            matchA5.BringToFront();
            matchA6.BringToFront();
            matchA7.BringToFront();
            matchA8.BringToFront();
            matchA9.BringToFront();
            matchA10.BringToFront();
            matchA11.BringToFront();
            matchA12.BringToFront();
            matchA13.BringToFront();
            matchA14.BringToFront();
            matchA15.BringToFront();
            matchA16.BringToFront();
            matchA17.BringToFront();
            matchA18.BringToFront();
            matchA19.BringToFront();
            matchA20.BringToFront();
            matchA21.BringToFront();
            matchA22.BringToFront();
            matchA23.BringToFront();
            matchB1.BringToFront();
            matchB2.BringToFront();
            matchB3.BringToFront();
            matchB4.BringToFront();
            matchB5.BringToFront();
            matchB6.BringToFront();
            matchB7.BringToFront();
            matchB8.BringToFront();
            matchB9.BringToFront();
            matchB10.BringToFront();
            matchB11.BringToFront();
            matchB12.BringToFront();
            matchB13.BringToFront();
            matchB14.BringToFront();
            matchB15.BringToFront();
            matchB16.BringToFront();
            matchB17.BringToFront();
            matchB18.BringToFront();
            matchB19.BringToFront();
            matchB20.BringToFront();
            matchB21.BringToFront();
            matchB22.BringToFront();
            matchB23.BringToFront();
            matchC1.BringToFront();
            matchC2.BringToFront();
            matchC3.BringToFront();
            matchC4.BringToFront();
            matchC5.BringToFront();
            matchC6.BringToFront();
            matchC7.BringToFront();
            matchC8.BringToFront();
            matchC9.BringToFront();
            matchC10.BringToFront();
            matchC11.BringToFront();
            matchC12.BringToFront();
            matchC13.BringToFront();
            matchC14.BringToFront();
            matchC15.BringToFront();
            matchC16.BringToFront();
            matchC17.BringToFront();
            matchC18.BringToFront();
            matchC19.BringToFront();
            matchC20.BringToFront();
            matchC21.BringToFront();
            matchC22.BringToFront();
            matchC23.BringToFront();
            matchD1.BringToFront();
            matchD2.BringToFront();
            matchD3.BringToFront();
            matchD4.BringToFront();
            matchD5.BringToFront();
            matchD6.BringToFront();
            matchD7.BringToFront();
            matchD8.BringToFront();
            matchD9.BringToFront();
            matchD10.BringToFront();
            matchD11.BringToFront();
            matchD12.BringToFront();
            matchD13.BringToFront();
            matchD14.BringToFront();
            matchD15.BringToFront();
            matchD16.BringToFront();
            matchD17.BringToFront();
            matchD18.BringToFront();
            matchD19.BringToFront();
            matchD20.BringToFront();
            matchD21.BringToFront();
            matchD22.BringToFront();
            matchD23.BringToFront();
            matchE1.BringToFront();
            matchE2.BringToFront();
            matchE3.BringToFront();
            matchE4.BringToFront();
            matchE5.BringToFront();
            matchE6.BringToFront();
            matchE7.BringToFront();
            matchE8.BringToFront();
            matchE9.BringToFront();
            matchE10.BringToFront();
            matchE11.BringToFront();
            matchE12.BringToFront();
            matchE13.BringToFront();
            matchE14.BringToFront();
            matchE15.BringToFront();
            matchE16.BringToFront();
            matchE17.BringToFront();
            matchE18.BringToFront();
            matchE19.BringToFront();
            matchE20.BringToFront();
            matchE21.BringToFront();
            matchE22.BringToFront();
            matchE23.BringToFront();
            matchF1.BringToFront();
            matchF2.BringToFront();
            matchF3.BringToFront();
            matchF4.BringToFront();
            matchF5.BringToFront();
            matchF6.BringToFront();
            matchF7.BringToFront();
            matchF8.BringToFront();
            matchF9.BringToFront();
            matchF10.BringToFront();
            matchF11.BringToFront();
            matchF12.BringToFront();
            matchF13.BringToFront();
            matchF14.BringToFront();
            matchF15.BringToFront();
            matchF16.BringToFront();
            matchF17.BringToFront();
            matchF18.BringToFront();
            matchF19.BringToFront();
            matchF20.BringToFront();
            matchF21.BringToFront();
            matchF22.BringToFront();
            matchF23.BringToFront();
            matchG1.BringToFront();
            matchG2.BringToFront();
            matchG3.BringToFront();
            matchG4.BringToFront();
            matchG5.BringToFront();
            matchG6.BringToFront();
            matchG7.BringToFront();
            matchG8.BringToFront();
            matchG9.BringToFront();
            matchG10.BringToFront();
            matchG11.BringToFront();
            matchG12.BringToFront();
            matchG13.BringToFront();
            matchG14.BringToFront();
            matchG15.BringToFront();
            matchG16.BringToFront();
            matchG17.BringToFront();
            matchG18.BringToFront();
            matchG19.BringToFront();
            matchG20.BringToFront();
            matchG21.BringToFront();
            matchG22.BringToFront();
            matchG23.BringToFront();
            #endregion
        }
    }
}
