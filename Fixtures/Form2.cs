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
        private int[,] sharedCount = new int[15, 15];
        private int[,] noPlayCount = new int[15, 15];
        private int[,] homeCount = new int[15, 15];
        private string[,] game = new string[15, 210]; //Division, Matches ... The list of all matches which must take place

        private string[,] name = new string[15, 15]; //Division, Team
        private string[,,] shared = new string[15, 15, 2]; //Max 15 divisions, 15 teams, 4 teams for single grounds
        private string[,,] datesHome = new string[15, 15, 13]; //Division, Team, Dates
        private string[,,] datesNoPlay = new string[15, 15, 13]; //Division, Team, Dates

        private string[,,] matchesAssigned = new string[15, 23, 7]; //Division, Date, Matches
        private bool[,,] teamAssigned = new bool[15, 23, 15]; //Division, Date, Team

        public Form2(int d, int[] m, string[,] g, string[,] n, string[, ,] s, string[, ,] dh, string[, ,] dnp, int[] tc, int[,] sc, int[,] npc, int[,] hc)
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
            sharedCount = sc;
            noPlayCount = npc;
            homeCount = hc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Initialize
            matchA1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG23.DropDownStyle = ComboBoxStyle.DropDownList;
            team1.Hide();
            team1.CustomBackground = true;
            team1.BackColor = Color.White;
            team2.Hide();
            team2.CustomBackground = true;
            team2.BackColor = Color.White;
            team3.Hide();
            team3.CustomBackground = true;
            team3.BackColor = Color.White;
            team4.Hide();
            team4.CustomBackground = true;
            team4.BackColor = Color.White;
            team5.Hide();
            team5.CustomBackground = true;
            team5.BackColor = Color.White;
            team6.Hide();
            team6.CustomBackground = true;
            team6.BackColor = Color.White;
            team7.Hide();
            team7.CustomBackground = true;
            team7.BackColor = Color.White;
            team8.Hide();
            team8.CustomBackground = true;
            team8.BackColor = Color.White;
            team9.Hide();
            team9.CustomBackground = true;
            team9.BackColor = Color.White;
            team10.Hide();
            team10.CustomBackground = true;
            team10.BackColor = Color.White;
            team11.Hide();
            team11.CustomBackground = true;
            team11.BackColor = Color.White;
            team12.Hide();
            team12.CustomBackground = true;
            team12.BackColor = Color.White;
            team13.Hide();
            team13.CustomBackground = true;
            team13.BackColor = Color.White;
            team14.Hide();
            team14.CustomBackground = true;
            team14.BackColor = Color.White;
            team15.Hide();
            team15.CustomBackground = true;
            team15.BackColor = Color.White;
            #endregion

            for (int i = 15; i > divCount; i--)
            {
                //remove non-used divisions
                metTabControl.SelectedIndex = divCount;
                metTabControl.TabPages.Remove(metTabControl.SelectedTab);
            }

            this.metTabControl.SelectedIndex = 0;
        }

        private int convertDate(string x)
        {
            int res = 1;

            switch (x)
            {
                case "Week 1":
                    res = 1;
                    break;
                case "Week 2":
                    res = 2;
                    break;
                case "Week 3":
                    res = 3;
                    break;
                case "Week 4":
                    res = 4;
                    break;
                case "Week 5":
                    res = 5;
                    break;
                case "Week 6":
                    res = 6;
                    break;
                case "Week 7":
                    res = 7;
                    break;
                case "Week 8":
                    res = 8;
                    break;
                case "Week 9":
                    res = 9;
                    break;
                case "Week 10":
                    res = 10;
                    break;
                case "Week 11":
                    res = 11;
                    break;
                case "Week 12":
                    res = 12;
                    break;
                case "Week 13":
                    res = 13;
                    break;
                case "Week 14":
                    res = 14;
                    break;
                case "Week 15":
                    res = 15;
                    break;
                case "Week 16":
                    res = 16;
                    break;
                case "Week 17":
                    res = 17;
                    break;
                case "Week 18":
                    res = 18;
                    break;
                case "Week 19":
                    res = 19;
                    break;
                case "Week 20":
                    res = 20;
                    break;
                case "Week 21":
                    res = 21;
                    break;
                case "Week 22":
                    res = 22;
                    break;
                case "Week 23":
                    res = 23;
                    break;
                default:
                    res = 100;
                    break;
            }
            return res;
        }

        private void metTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sharedGroundsInfo = "";

            richTextBox1.Hide();
            richTextBox2.Hide();
            richTextBox3.Hide();
            richTextBox4.Hide();
            richTextBox5.Hide();
            richTextBox6.Hide();
            richTextBox7.Hide();
            richTextBox8.Hide();
            richTextBox9.Hide();
            richTextBox10.Hide();
            richTextBox11.Hide();
            richTextBox12.Hide();
            richTextBox13.Hide();
            richTextBox14.Hide();
            richTextBox15.Hide();
            metroLabel24.Hide();
            metroLabel25.Hide();
            line2.Hide();
            line3.Hide();
            line4.Hide();
            line5.Hide();
            line6.Hide();
            line7.Hide();
            line8.Hide();
            line9.Hide();
            line10.Hide();
            line11.Hide();
            line12.Hide();
            line13.Hide();
            line14.Hide();
            sharedLine.Hide();

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
            metTabControl.SelectedTab.Controls.Add(richTextBox1);
            metTabControl.SelectedTab.Controls.Add(richTextBox2);
            metTabControl.SelectedTab.Controls.Add(richTextBox3);
            metTabControl.SelectedTab.Controls.Add(richTextBox4);
            metTabControl.SelectedTab.Controls.Add(richTextBox5);
            metTabControl.SelectedTab.Controls.Add(richTextBox6);
            metTabControl.SelectedTab.Controls.Add(richTextBox7);
            metTabControl.SelectedTab.Controls.Add(richTextBox8);
            metTabControl.SelectedTab.Controls.Add(richTextBox9);
            metTabControl.SelectedTab.Controls.Add(richTextBox10);
            metTabControl.SelectedTab.Controls.Add(richTextBox11);
            metTabControl.SelectedTab.Controls.Add(richTextBox12);
            metTabControl.SelectedTab.Controls.Add(richTextBox13);
            metTabControl.SelectedTab.Controls.Add(richTextBox14);
            metTabControl.SelectedTab.Controls.Add(richTextBox15);
            metTabControl.SelectedTab.Controls.Add(metroLabel24);
            metTabControl.SelectedTab.Controls.Add(metroLabel25);
            metTabControl.SelectedTab.Controls.Add(line2);
            metTabControl.SelectedTab.Controls.Add(line3);
            metTabControl.SelectedTab.Controls.Add(line4);
            metTabControl.SelectedTab.Controls.Add(line5);
            metTabControl.SelectedTab.Controls.Add(line6);
            metTabControl.SelectedTab.Controls.Add(line7);
            metTabControl.SelectedTab.Controls.Add(line8);
            metTabControl.SelectedTab.Controls.Add(line9);
            metTabControl.SelectedTab.Controls.Add(line10);
            metTabControl.SelectedTab.Controls.Add(line11);
            metTabControl.SelectedTab.Controls.Add(line12);
            metTabControl.SelectedTab.Controls.Add(line13);
            metTabControl.SelectedTab.Controls.Add(line14);
            metTabControl.SelectedTab.Controls.Add(sharedLine);
            metroLabel15.BringToFront();
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
            metroLabel15.BringToFront();
            richTextBox1.BringToFront();
            richTextBox2.BringToFront();
            richTextBox3.BringToFront();
            richTextBox4.BringToFront();
            richTextBox5.BringToFront();
            richTextBox6.BringToFront();
            richTextBox7.BringToFront();
            richTextBox8.BringToFront();
            richTextBox9.BringToFront();
            richTextBox10.BringToFront();
            richTextBox11.BringToFront();
            richTextBox12.BringToFront();
            richTextBox13.BringToFront();
            richTextBox14.BringToFront();
            richTextBox15.BringToFront();
            metroLabel24.BringToFront();
            metroLabel25.BringToFront();
            line2.BringToFront();
            line3.BringToFront();
            line4.BringToFront();
            line5.BringToFront();
            line6.BringToFront();
            line7.BringToFront();
            line8.BringToFront();
            line9.BringToFront();
            line10.BringToFront();
            line11.BringToFront();
            line12.BringToFront();
            line13.BringToFront();
            line14.BringToFront();
            sharedLine.BringToFront();
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

            #region Display correct number of possible possible matches per date
            assignA1.Show();
            assignA2.Show();
            assignA3.Show();
            assignA4.Show();
            assignA5.Show();
            assignA6.Show();
            assignA7.Show();
            assignA8.Show();
            assignA9.Show();
            assignA10.Show();
            assignA11.Show();
            assignA12.Show();
            assignA13.Show();
            assignA14.Show();
            assignA15.Show();
            assignA16.Show();
            assignA17.Show();
            assignA18.Show();
            assignA19.Show();
            assignA20.Show();
            assignA21.Show();
            assignA22.Show();
            assignA23.Show();
            assignB1.Show();
            assignB2.Show();
            assignB3.Show();
            assignB4.Show();
            assignB5.Show();
            assignB6.Show();
            assignB7.Show();
            assignB8.Show();
            assignB9.Show();
            assignB10.Show();
            assignB11.Show();
            assignB12.Show();
            assignB13.Show();
            assignB14.Show();
            assignB15.Show();
            assignB16.Show();
            assignB17.Show();
            assignB18.Show();
            assignB19.Show();
            assignB20.Show();
            assignB21.Show();
            assignB22.Show();
            assignB23.Show();
            assignC1.Show();
            assignC2.Show();
            assignC3.Show();
            assignC4.Show();
            assignC5.Show();
            assignC6.Show();
            assignC7.Show();
            assignC8.Show();
            assignC9.Show();
            assignC10.Show();
            assignC11.Show();
            assignC12.Show();
            assignC13.Show();
            assignC14.Show();
            assignC15.Show();
            assignC16.Show();
            assignC17.Show();
            assignC18.Show();
            assignC19.Show();
            assignC20.Show();
            assignC21.Show();
            assignC22.Show();
            assignC23.Show();
            assignD1.Show();
            assignD2.Show();
            assignD3.Show();
            assignD4.Show();
            assignD5.Show();
            assignD6.Show();
            assignD7.Show();
            assignD8.Show();
            assignD9.Show();
            assignD10.Show();
            assignD11.Show();
            assignD12.Show();
            assignD13.Show();
            assignD14.Show();
            assignD15.Show();
            assignD16.Show();
            assignD17.Show();
            assignD18.Show();
            assignD19.Show();
            assignD20.Show();
            assignD21.Show();
            assignD22.Show();
            assignD23.Show();
            assignE1.Show();
            assignE2.Show();
            assignE3.Show();
            assignE4.Show();
            assignE5.Show();
            assignE6.Show();
            assignE7.Show();
            assignE8.Show();
            assignE9.Show();
            assignE10.Show();
            assignE11.Show();
            assignE12.Show();
            assignE13.Show();
            assignE14.Show();
            assignE15.Show();
            assignE16.Show();
            assignE17.Show();
            assignE18.Show();
            assignE19.Show();
            assignE20.Show();
            assignE21.Show();
            assignE22.Show();
            assignE23.Show();
            assignF1.Show();
            assignF2.Show();
            assignF3.Show();
            assignF4.Show();
            assignF5.Show();
            assignF6.Show();
            assignF7.Show();
            assignF8.Show();
            assignF9.Show();
            assignF10.Show();
            assignF11.Show();
            assignF12.Show();
            assignF13.Show();
            assignF14.Show();
            assignF15.Show();
            assignF16.Show();
            assignF17.Show();
            assignF18.Show();
            assignF19.Show();
            assignF20.Show();
            assignF21.Show();
            assignF22.Show();
            assignF23.Show();
            assignG1.Show();
            assignG2.Show();
            assignG3.Show();
            assignG4.Show();
            assignG5.Show();
            assignG6.Show();
            assignG7.Show();
            assignG8.Show();
            assignG9.Show();
            assignG10.Show();
            assignG11.Show();
            assignG12.Show();
            assignG13.Show();
            assignG14.Show();
            assignG15.Show();
            assignG16.Show();
            assignG17.Show();
            assignG18.Show();
            assignG19.Show();
            assignG20.Show();
            assignG21.Show();
            assignG22.Show();
            assignG23.Show();
            matchA1.Show();
            matchA2.Show();
            matchA3.Show();
            matchA4.Show();
            matchA5.Show();
            matchA6.Show();
            matchA7.Show();
            matchA8.Show();
            matchA9.Show();
            matchA10.Show();
            matchA11.Show();
            matchA12.Show();
            matchA13.Show();
            matchA14.Show();
            matchA15.Show();
            matchA16.Show();
            matchA17.Show();
            matchA18.Show();
            matchA19.Show();
            matchA20.Show();
            matchA21.Show();
            matchA22.Show();
            matchA23.Show();
            matchB1.Show();
            matchB2.Show();
            matchB3.Show();
            matchB4.Show();
            matchB5.Show();
            matchB6.Show();
            matchB7.Show();
            matchB8.Show();
            matchB9.Show();
            matchB10.Show();
            matchB11.Show();
            matchB12.Show();
            matchB13.Show();
            matchB14.Show();
            matchB15.Show();
            matchB16.Show();
            matchB17.Show();
            matchB18.Show();
            matchB19.Show();
            matchB20.Show();
            matchB21.Show();
            matchB22.Show();
            matchB23.Show();
            matchC1.Show();
            matchC2.Show();
            matchC3.Show();
            matchC4.Show();
            matchC5.Show();
            matchC6.Show();
            matchC7.Show();
            matchC8.Show();
            matchC9.Show();
            matchC10.Show();
            matchC11.Show();
            matchC12.Show();
            matchC13.Show();
            matchC14.Show();
            matchC15.Show();
            matchC16.Show();
            matchC17.Show();
            matchC18.Show();
            matchC19.Show();
            matchC20.Show();
            matchC21.Show();
            matchC22.Show();
            matchC23.Show();
            matchD1.Show();
            matchD2.Show();
            matchD3.Show();
            matchD4.Show();
            matchD5.Show();
            matchD6.Show();
            matchD7.Show();
            matchD8.Show();
            matchD9.Show();
            matchD10.Show();
            matchD11.Show();
            matchD12.Show();
            matchD13.Show();
            matchD14.Show();
            matchD15.Show();
            matchD16.Show();
            matchD17.Show();
            matchD18.Show();
            matchD19.Show();
            matchD20.Show();
            matchD21.Show();
            matchD22.Show();
            matchD23.Show();
            matchE1.Show();
            matchE2.Show();
            matchE3.Show();
            matchE4.Show();
            matchE5.Show();
            matchE6.Show();
            matchE7.Show();
            matchE8.Show();
            matchE9.Show();
            matchE10.Show();
            matchE11.Show();
            matchE12.Show();
            matchE13.Show();
            matchE14.Show();
            matchE15.Show();
            matchE16.Show();
            matchE17.Show();
            matchE18.Show();
            matchE19.Show();
            matchE20.Show();
            matchE21.Show();
            matchE22.Show();
            matchE23.Show();
            matchF1.Show();
            matchF2.Show();
            matchF3.Show();
            matchF4.Show();
            matchF5.Show();
            matchF6.Show();
            matchF7.Show();
            matchF8.Show();
            matchF9.Show();
            matchF10.Show();
            matchF11.Show();
            matchF12.Show();
            matchF13.Show();
            matchF14.Show();
            matchF15.Show();
            matchF16.Show();
            matchF17.Show();
            matchF18.Show();
            matchF19.Show();
            matchF20.Show();
            matchF21.Show();
            matchF22.Show();
            matchF23.Show();
            matchG1.Show();
            matchG2.Show();
            matchG3.Show();
            matchG4.Show();
            matchG5.Show();
            matchG6.Show();
            matchG7.Show();
            matchG8.Show();
            matchG9.Show();
            matchG10.Show();
            matchG11.Show();
            matchG12.Show();
            matchG13.Show();
            matchG14.Show();
            matchG15.Show();
            matchG16.Show();
            matchG17.Show();
            matchG18.Show();
            matchG19.Show();
            matchG20.Show();
            matchG21.Show();
            matchG22.Show();
            matchG23.Show();

            if (teamCount[division] == 0 || teamCount[division] /2 == 6 || teamCount[division] / 2 == 5 || teamCount[division] / 2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide G
                assignG1.Hide();
                assignG2.Hide();
                assignG3.Hide();
                assignG4.Hide();
                assignG5.Hide();
                assignG6.Hide();
                assignG7.Hide();
                assignG8.Hide();
                assignG9.Hide();
                assignG10.Hide();
                assignG11.Hide();
                assignG12.Hide();
                assignG13.Hide();
                assignG14.Hide();
                assignG15.Hide();
                assignG16.Hide();
                assignG17.Hide();
                assignG18.Hide();
                assignG19.Hide();
                assignG20.Hide();
                assignG21.Hide();
                assignG22.Hide();
                assignG23.Hide();
                matchG1.Hide();
                matchG2.Hide();
                matchG3.Hide();
                matchG4.Hide();
                matchG5.Hide();
                matchG6.Hide();
                matchG7.Hide();
                matchG8.Hide();
                matchG9.Hide();
                matchG10.Hide();
                matchG11.Hide();
                matchG12.Hide();
                matchG13.Hide();
                matchG14.Hide();
                matchG15.Hide();
                matchG16.Hide();
                matchG17.Hide();
                matchG18.Hide();
                matchG19.Hide();
                matchG20.Hide();
                matchG21.Hide();
                matchG22.Hide();
                matchG23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 5 || teamCount[division] / 2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide F
                assignF1.Hide();
                assignF2.Hide();
                assignF3.Hide();
                assignF4.Hide();
                assignF5.Hide();
                assignF6.Hide();
                assignF7.Hide();
                assignF8.Hide();
                assignF9.Hide();
                assignF10.Hide();
                assignF11.Hide();
                assignF12.Hide();
                assignF13.Hide();
                assignF14.Hide();
                assignF15.Hide();
                assignF16.Hide();
                assignF17.Hide();
                assignF18.Hide();
                assignF19.Hide();
                assignF20.Hide();
                assignF21.Hide();
                assignF22.Hide();
                assignF23.Hide();
                matchF1.Hide();
                matchF2.Hide();
                matchF3.Hide();
                matchF4.Hide();
                matchF5.Hide();
                matchF6.Hide();
                matchF7.Hide();
                matchF8.Hide();
                matchF9.Hide();
                matchF10.Hide();
                matchF11.Hide();
                matchF12.Hide();
                matchF13.Hide();
                matchF14.Hide();
                matchF15.Hide();
                matchF16.Hide();
                matchF17.Hide();
                matchF18.Hide();
                matchF19.Hide();
                matchF20.Hide();
                matchF21.Hide();
                matchF22.Hide();
                matchF23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide E
                assignE1.Hide();
                assignE2.Hide();
                assignE3.Hide();
                assignE4.Hide();
                assignE5.Hide();
                assignE6.Hide();
                assignE7.Hide();
                assignE8.Hide();
                assignE9.Hide();
                assignE10.Hide();
                assignE11.Hide();
                assignE12.Hide();
                assignE13.Hide();
                assignE14.Hide();
                assignE15.Hide();
                assignE16.Hide();
                assignE17.Hide();
                assignE18.Hide();
                assignE19.Hide();
                assignE20.Hide();
                assignE21.Hide();
                assignE22.Hide();
                assignE23.Hide();
                matchE1.Hide();
                matchE2.Hide();
                matchE3.Hide();
                matchE4.Hide();
                matchE5.Hide();
                matchE6.Hide();
                matchE7.Hide();
                matchE8.Hide();
                matchE9.Hide();
                matchE10.Hide();
                matchE11.Hide();
                matchE12.Hide();
                matchE13.Hide();
                matchE14.Hide();
                matchE15.Hide();
                matchE16.Hide();
                matchE17.Hide();
                matchE18.Hide();
                matchE19.Hide();
                matchE20.Hide();
                matchE21.Hide();
                matchE22.Hide();
                matchE23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide D
                assignD1.Hide();
                assignD2.Hide();
                assignD3.Hide();
                assignD4.Hide();
                assignD5.Hide();
                assignD6.Hide();
                assignD7.Hide();
                assignD8.Hide();
                assignD9.Hide();
                assignD10.Hide();
                assignD11.Hide();
                assignD12.Hide();
                assignD13.Hide();
                assignD14.Hide();
                assignD15.Hide();
                assignD16.Hide();
                assignD17.Hide();
                assignD18.Hide();
                assignD19.Hide();
                assignD20.Hide();
                assignD21.Hide();
                assignD22.Hide();
                assignD23.Hide();
                matchD1.Hide();
                matchD2.Hide();
                matchD3.Hide();
                matchD4.Hide();
                matchD5.Hide();
                matchD6.Hide();
                matchD7.Hide();
                matchD8.Hide();
                matchD9.Hide();
                matchD10.Hide();
                matchD11.Hide();
                matchD12.Hide();
                matchD13.Hide();
                matchD14.Hide();
                matchD15.Hide();
                matchD16.Hide();
                matchD17.Hide();
                matchD18.Hide();
                matchD19.Hide();
                matchD20.Hide();
                matchD21.Hide();
                matchD22.Hide();
                matchD23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide C
                assignC1.Hide();
                assignC2.Hide();
                assignC3.Hide();
                assignC4.Hide();
                assignC5.Hide();
                assignC6.Hide();
                assignC7.Hide();
                assignC8.Hide();
                assignC9.Hide();
                assignC10.Hide();
                assignC11.Hide();
                assignC12.Hide();
                assignC13.Hide();
                assignC14.Hide();
                assignC15.Hide();
                assignC16.Hide();
                assignC17.Hide();
                assignC18.Hide();
                assignC19.Hide();
                assignC20.Hide();
                assignC21.Hide();
                assignC22.Hide();
                assignC23.Hide();
                matchC1.Hide();
                matchC2.Hide();
                matchC3.Hide();
                matchC4.Hide();
                matchC5.Hide();
                matchC6.Hide();
                matchC7.Hide();
                matchC8.Hide();
                matchC9.Hide();
                matchC10.Hide();
                matchC11.Hide();
                matchC12.Hide();
                matchC13.Hide();
                matchC14.Hide();
                matchC15.Hide();
                matchC16.Hide();
                matchC17.Hide();
                matchC18.Hide();
                matchC19.Hide();
                matchC20.Hide();
                matchC21.Hide();
                matchC22.Hide();
                matchC23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 1)
            {
                //Hide B
                assignB1.Hide();
                assignB2.Hide();
                assignB3.Hide();
                assignB4.Hide();
                assignB5.Hide();
                assignB6.Hide();
                assignB7.Hide();
                assignB8.Hide();
                assignB9.Hide();
                assignB10.Hide();
                assignB11.Hide();
                assignB12.Hide();
                assignB13.Hide();
                assignB14.Hide();
                assignB15.Hide();
                assignB16.Hide();
                assignB17.Hide();
                assignB18.Hide();
                assignB19.Hide();
                assignB20.Hide();
                assignB21.Hide();
                assignB22.Hide();
                assignB23.Hide();
                matchB1.Hide();
                matchB2.Hide();
                matchB3.Hide();
                matchB4.Hide();
                matchB5.Hide();
                matchB6.Hide();
                matchB7.Hide();
                matchB8.Hide();
                matchB9.Hide();
                matchB10.Hide();
                matchB11.Hide();
                matchB12.Hide();
                matchB13.Hide();
                matchB14.Hide();
                matchB15.Hide();
                matchB16.Hide();
                matchB17.Hide();
                matchB18.Hide();
                matchB19.Hide();
                matchB20.Hide();
                matchB21.Hide();
                matchB22.Hide();
                matchB23.Hide();
            }

            if (teamCount[division] == 0)
            {
                //Hide A
                assignA1.Hide();
                assignA2.Hide();
                assignA3.Hide();
                assignA4.Hide();
                assignA5.Hide();
                assignA6.Hide();
                assignA7.Hide();
                assignA8.Hide();
                assignA9.Hide();
                assignA10.Hide();
                assignA11.Hide();
                assignA12.Hide();
                assignA13.Hide();
                assignA14.Hide();
                assignA15.Hide();
                assignA16.Hide();
                assignA17.Hide();
                assignA18.Hide();
                assignA19.Hide();
                assignA20.Hide();
                assignA21.Hide();
                assignA22.Hide();
                assignA23.Hide();
                matchA1.Hide();
                matchA2.Hide();
                matchA3.Hide();
                matchA4.Hide();
                matchA5.Hide();
                matchA6.Hide();
                matchA7.Hide();
                matchA8.Hide();
                matchA9.Hide();
                matchA10.Hide();
                matchA11.Hide();
                matchA12.Hide();
                matchA13.Hide();
                matchA14.Hide();
                matchA15.Hide();
                matchA16.Hide();
                matchA17.Hide();
                matchA18.Hide();
                matchA19.Hide();
                matchA20.Hide();
                matchA21.Hide();
                matchA22.Hide();
                matchA23.Hide();
            }
            #endregion

            #region Display teams key + Shared grounds indicator
            switch (teamCount[division])
            {
                case 0:
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
                    break;
                case 1:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
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
                    break;
                case 2:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
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
                    break;
                case 3:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 1];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
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
                    break;
                case 4:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
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
                    break;
                case 5:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
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
                    break;
                case 6:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 7:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 8:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 9:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 10:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 11:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 12:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 13:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Hide();
                    team15.Hide();
                    break;
                case 14:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Show();
                    team14.Text = "14 - " + name[division, 13];
                    team15.Hide();
                    break;
                case 15:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Show();
                    team14.Text = "14 - " + name[division, 13];
                    team15.Show();
                    team15.Text = "15 - " + name[division, 14];
                    break;
            }

            //Shared grounds indicator

            if (sharedCount[division, 0] != 0)
            {
                //team shares grounds
                richTextBox1.Show();
                team1.BringToFront();
                team1.BackColor = SystemColors.Control;
                metroLabel24.Show();
                metroLabel25.Show();
                metroLabel25.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team1.Text + " shares with:\n      " + shared[division, 0, 0];
                for (int j = 1; j < sharedCount[division, 0]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 0, j];
                }
            }
            else
            {
                team1.BackColor = Color.White;
            }
            if (sharedCount[division, 1] != 0)
            {
                //team shares grounds
                richTextBox2.Show();
                team2.BringToFront();
                team2.BackColor = SystemColors.Control;
                metroLabel24.Show();
                metroLabel25.Show();
                line2.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team2.Text + " shares with:\n      " + shared[division, 1, 0];
                for (int j = 1; j < sharedCount[division, 1]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 1, j];
                }
            }
            else
            {
                team2.BackColor = Color.White;
            }
            if (sharedCount[division, 2] != 0)
            {
                //team shares grounds
                richTextBox3.Show();
                team3.BringToFront();
                team3.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line2.Show();
                line3.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team3.Text + " shares with:\n      " + shared[division, 2, 0];
                for (int j = 1; j < sharedCount[division, 2]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 2, j];
                }
            }
            else
            {
                team3.BackColor = Color.White;
            }
            if (sharedCount[division, 3] != 0)
            {
                //team shares grounds
                richTextBox4.Show();
                team4.BringToFront();
                team4.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line3.Show();
                line4.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team4.Text + " shares with:\n      " + shared[division, 3, 0];
                for (int j = 1; j < sharedCount[division, 3]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 3, j];
                }
            }
            else
            {
                team4.BackColor = Color.White;
            }
            if (sharedCount[division, 4] != 0)
            {
                //team shares grounds
                richTextBox5.Show();
                team5.BringToFront();
                team5.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line4.Show();
                line5.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team5.Text + " shares with:\n      " + shared[division, 4, 0];
                for (int j = 1; j < sharedCount[division, 4]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 4, j];
                }
            }
            else
            {
                team5.BackColor = Color.White;
            }
            if (sharedCount[division, 5] != 0)
            {
                //team shares grounds
                richTextBox6.Show();
                team6.BringToFront();
                team6.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line5.Show();
                line6.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team6.Text + " shares with:\n      " + shared[division, 5, 0];
                for (int j = 1; j < sharedCount[division, 5]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 5, j];
                }
            }
            else
            {
                team6.BackColor = Color.White;
            }
            if (sharedCount[division, 6] != 0)
            {
                //team shares grounds
                richTextBox7.Show();
                team7.BringToFront();
                team7.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line6.Show();
                line7.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team7.Text + " shares with:\n      " + shared[division, 6, 0];
                for (int j = 1; j < sharedCount[division, 6]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 6, j];
                }
            }
            else
            {
                team7.BackColor = Color.White;
            }
            if (sharedCount[division, 7] != 0)
            {
                //team shares grounds
                richTextBox8.Show();
                team8.BringToFront();
                team8.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line7.Show();
                line8.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team8.Text + " shares with:\n      " + shared[division, 7, 0];
                for (int j = 1; j < sharedCount[division, 7]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 7, j];
                }
            }
            else
            {
                team8.BackColor = Color.White;
            }
            if (sharedCount[division, 8] != 0)
            {
                //team shares grounds
                richTextBox9.Show();
                team9.BringToFront();
                team9.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line8.Show();
                line9.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team9.Text + " shares with:\n      " + shared[division, 8, 0];
                for (int j = 1; j < sharedCount[division, 8]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 8, j];
                }
            }
            else
            {
                team9.BackColor = Color.White;
            }
            if (sharedCount[division, 9] != 0)
            {
                //team shares grounds
                richTextBox10.Show();
                team10.BringToFront();
                team10.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line9.Show();
                line10.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team10.Text + " shares with:\n      " + shared[division, 9, 0];
                for (int j = 1; j < sharedCount[division, 9]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 9, j];
                }
            }
            else
            {
                team10.BackColor = Color.White;
            }
            if (sharedCount[division, 10] != 0)
            {
                //team shares grounds
                richTextBox11.Show();
                team11.BringToFront();
                team11.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line10.Show();
                line11.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team11.Text + " shares with:\n      " + shared[division, 10, 0];
                for (int j = 1; j < sharedCount[division, 10]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 10, j];
                }
            }
            else
            {
                team11.BackColor = Color.White;
            }
            if (sharedCount[division, 11] != 0)
            {
                //team shares grounds
                richTextBox12.Show();
                team12.BringToFront();
                team12.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line11.Show();
                line12.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team12.Text + " shares with:\n      " + shared[division, 11, 0];
                for (int j = 1; j < sharedCount[division, 11]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 11, j];
                }
            }
            else
            {
                team12.BackColor = Color.White;
            }
            if (sharedCount[division, 12] != 0)
            {
                //team shares grounds
                richTextBox13.Show();
                team13.BringToFront();
                team13.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line12.Show();
                line13.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team13.Text + " shares with:\n      " + shared[division, 12, 0];
                for (int j = 1; j < sharedCount[division, 12]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 12, j];
                }
            }
            else
            {
                team13.BackColor = Color.White;
            }
            if (sharedCount[division, 13] != 0)
            {
                //team shares grounds
                richTextBox14.Show();
                team14.BringToFront();
                team14.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line13.Show();
                line14.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team14.Text + " shares with:\n      " + shared[division, 13, 0];
                for (int j = 1; j < sharedCount[division, 13]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 13, j];
                }
            }
            else
            {
                team14.BackColor = Color.White;
            }
            if (sharedCount[division, 14] != 0)
            {
                //team shares grounds
                richTextBox15.Show();
                team15.BringToFront();
                team15.BackColor = SystemColors.Control;
                metroLabel24.Show();
                line14.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team15.Text + " shares with:\n      " + shared[division, 14, 0];
                for (int j = 1; j < sharedCount[division, 14]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + " and " + shared[division, 14, j];
                }
            }
            else
            {
                team15.BackColor = Color.White;
            }

            metroLabel24.Text = sharedGroundsInfo;
            #endregion

        }

        private bool checkValid(string g, int week) //used to check if a game is valid for a given date
        {
            bool valid = true;
            Tuple<int, int> teams = getHomeAway(g);

            //loop through every date team cannot play
            for (int i = 0; i < noPlayCount[division, teams.Item1]; i++)
            {
                if (convertDate(datesNoPlay[division, teams.Item1, i]) == week)
                    valid = false;
            }
            //loop through every date team cannot play
            for (int i = 0; i < noPlayCount[division, teams.Item2]; i++)
            {
                if (convertDate(datesNoPlay[division, teams.Item2, i]) == week)
                    valid = false;
            }
            //loop through every date teamAway must play home
            for (int i = 0; i < homeCount[division, teams.Item2]; i++)
            {
                if (convertDate(datesHome[division, teams.Item2, i]) == week)
                    valid = false;
            }
            //check if match is already assigned to date
            if (teamAssigned[division, week-1, teams.Item1] == true || teamAssigned[division, week-1, teams.Item2] == true)
            {
                valid = false;
            }

            return valid;
        }

        private Tuple<int, int> getHomeAway(string g)
        {
            string previous = "start";
            bool home = true;
            string temp = "";
            int teamHome = 0;
            int teamAway = 0;

            //store teams at integers for home and away
            foreach (char c in g.Trim())
            {
                if (c != 'v' && c != 's') //if c is a team number
                {
                    if (previous == "start")
                    {
                        home = true;
                        teamHome = (int)Char.GetNumericValue(c) - 1;
                    }
                    else if (previous == "s")
                    {
                        home = false;
                        teamAway = (int)Char.GetNumericValue(c) - 1;
                    }
                    else if (c != ' ')
                    {
                        temp = previous + Convert.ToString(c);

                        if (home == true)
                        {
                            teamHome = Convert.ToInt16(temp) - 1;
                        }
                        else
                        {
                            teamAway = Convert.ToInt16(temp) - 1;
                        }
                    }
                }

                previous = Convert.ToString(c);
            }

            return new Tuple<int, int>(teamHome, teamAway);
        }

        #region comboBoxes_Click

        private void matchA1_Click(object sender, EventArgs e)
        {
            matchA1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchA1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB1_Click(object sender, EventArgs e)
        {
            matchB1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchB1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC1_Click(object sender, EventArgs e)
        {
            matchC1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchC1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD1_Click(object sender, EventArgs e)
        {
            matchD1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchD1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE1_Click(object sender, EventArgs e)
        {
            matchE1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchE1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF1_Click(object sender, EventArgs e)
        {
            matchF1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchF1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG1_Click(object sender, EventArgs e)
        {
            matchG1.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 1);
                    if (valid != false)
                        matchG1.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA2_Click(object sender, EventArgs e)
        {
            matchA2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchA2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB2_Click(object sender, EventArgs e)
        {
            matchB2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchB2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC2_Click(object sender, EventArgs e)
        {
            matchC2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchC2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD2_Click(object sender, EventArgs e)
        {
            matchD2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchD2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE2_Click(object sender, EventArgs e)
        {
            matchE2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchE2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF2_Click(object sender, EventArgs e)
        {
            matchF2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchF2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG2_Click(object sender, EventArgs e)
        {
            matchG2.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 2);
                    if (valid != false)
                        matchG2.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA3_Click(object sender, EventArgs e)
        {
            matchA3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchA3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB3_Click(object sender, EventArgs e)
        {
            matchB3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchB3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC3_Click(object sender, EventArgs e)
        {
            matchC3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchC3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD3_Click(object sender, EventArgs e)
        {
            matchD3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchD3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE3_Click(object sender, EventArgs e)
        {
            matchE3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchE3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF3_Click(object sender, EventArgs e)
        {
            matchF3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchF3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG3_Click(object sender, EventArgs e)
        {
            matchG3.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 3);
                    if (valid != false)
                        matchG3.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA4_Click(object sender, EventArgs e)
        {
            matchA4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchA4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB4_Click(object sender, EventArgs e)
        {
            matchB4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchB4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC4_Click(object sender, EventArgs e)
        {
            matchC4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchC4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD4_Click(object sender, EventArgs e)
        {
            matchD4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchD4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE4_Click(object sender, EventArgs e)
        {
            matchE4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchE4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF4_Click(object sender, EventArgs e)
        {
            matchF4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchF4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG4_Click(object sender, EventArgs e)
        {
            matchG4.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 4);
                    if (valid != false)
                        matchG4.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA5_Click(object sender, EventArgs e)
        {
            matchA5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchA5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB5_Click(object sender, EventArgs e)
        {
            matchB5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchB5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC5_Click(object sender, EventArgs e)
        {
            matchC5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchC5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD5_Click(object sender, EventArgs e)
        {
            matchD5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchD5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE5_Click(object sender, EventArgs e)
        {
            matchE5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchE5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF5_Click(object sender, EventArgs e)
        {
            matchF5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchF5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG5_Click(object sender, EventArgs e)
        {
            matchG5.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 5);
                    if (valid != false)
                        matchG5.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA6_Click(object sender, EventArgs e)
        {
            matchA6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchA6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB6_Click(object sender, EventArgs e)
        {
            matchB6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchB6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC6_Click(object sender, EventArgs e)
        {
            matchC6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchC6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD6_Click(object sender, EventArgs e)
        {
            matchD6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchD6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE6_Click(object sender, EventArgs e)
        {
            matchE6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchE6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF6_Click(object sender, EventArgs e)
        {
            matchF6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchF6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG6_Click(object sender, EventArgs e)
        {
            matchG6.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 6);
                    if (valid != false)
                        matchG6.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA7_Click(object sender, EventArgs e)
        {
            matchA7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchA7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB7_Click(object sender, EventArgs e)
        {
            matchB7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchB7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC7_Click(object sender, EventArgs e)
        {
            matchC7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchC7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD7_Click(object sender, EventArgs e)
        {
            matchD7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchD7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE7_Click(object sender, EventArgs e)
        {
            matchE7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchE7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF7_Click(object sender, EventArgs e)
        {
            matchF7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchF7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG7_Click(object sender, EventArgs e)
        {
            matchG7.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 7);
                    if (valid != false)
                        matchG7.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA8_Click(object sender, EventArgs e)
        {
            matchA8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchA8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB8_Click(object sender, EventArgs e)
        {
            matchB8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchB8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC8_Click(object sender, EventArgs e)
        {
            matchC8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchC8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD8_Click(object sender, EventArgs e)
        {
            matchD8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchD8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE8_Click(object sender, EventArgs e)
        {
            matchE8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchE8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF8_Click(object sender, EventArgs e)
        {
            matchF8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchF8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG8_Click(object sender, EventArgs e)
        {
            matchG8.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 8);
                    if (valid != false)
                        matchG8.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA9_Click(object sender, EventArgs e)
        {
            matchA9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchA9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB9_Click(object sender, EventArgs e)
        {
            matchB9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchB9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC9_Click(object sender, EventArgs e)
        {
            matchC9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchC9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD9_Click(object sender, EventArgs e)
        {
            matchD9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchD9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE9_Click(object sender, EventArgs e)
        {
            matchE9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchE9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF9_Click(object sender, EventArgs e)
        {
            matchF9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchF9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG9_Click(object sender, EventArgs e)
        {
            matchG9.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 9);
                    if (valid != false)
                        matchG9.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA10_Click(object sender, EventArgs e)
        {
            matchA10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchA10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB10_Click(object sender, EventArgs e)
        {
            matchB10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchB10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC10_Click(object sender, EventArgs e)
        {
            matchC10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchC10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD10_Click(object sender, EventArgs e)
        {
            matchD10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchD10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE10_Click(object sender, EventArgs e)
        {
            matchE10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchE10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF10_Click(object sender, EventArgs e)
        {
            matchF10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchF10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG10_Click(object sender, EventArgs e)
        {
            matchG10.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 10);
                    if (valid != false)
                        matchG10.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA11_Click(object sender, EventArgs e)
        {
            matchA11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchA11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB11_Click(object sender, EventArgs e)
        {
            matchB11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchB11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC11_Click(object sender, EventArgs e)
        {
            matchC11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchC11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD11_Click(object sender, EventArgs e)
        {
            matchD11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchD11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE11_Click(object sender, EventArgs e)
        {
            matchE11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchE11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF11_Click(object sender, EventArgs e)
        {
            matchF11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchF11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG11_Click(object sender, EventArgs e)
        {
            matchG11.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 11);
                    if (valid != false)
                        matchG11.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA12_Click(object sender, EventArgs e)
        {
            matchA12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchA12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB12_Click(object sender, EventArgs e)
        {
            matchB12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchB12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC12_Click(object sender, EventArgs e)
        {
            matchC12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchC12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD12_Click(object sender, EventArgs e)
        {
            matchD12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchD12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE12_Click(object sender, EventArgs e)
        {
            matchE12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchE12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF12_Click(object sender, EventArgs e)
        {
            matchF12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchF12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG12_Click(object sender, EventArgs e)
        {
            matchG12.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 12);
                    if (valid != false)
                        matchG12.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA13_Click(object sender, EventArgs e)
        {
            matchA13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchA13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB13_Click(object sender, EventArgs e)
        {
            matchB13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchB13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC13_Click(object sender, EventArgs e)
        {
            matchC13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchC13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD13_Click(object sender, EventArgs e)
        {
            matchD13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchD13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE13_Click(object sender, EventArgs e)
        {
            matchE13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchE13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF13_Click(object sender, EventArgs e)
        {
            matchF13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchF13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG13_Click(object sender, EventArgs e)
        {
            matchG13.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 13);
                    if (valid != false)
                        matchG13.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA14_Click(object sender, EventArgs e)
        {
            matchA14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchA14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB14_Click(object sender, EventArgs e)
        {
            matchB14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchB14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC14_Click(object sender, EventArgs e)
        {
            matchC14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchC14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD14_Click(object sender, EventArgs e)
        {
            matchD14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchD14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE14_Click(object sender, EventArgs e)
        {
            matchE14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchE14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF14_Click(object sender, EventArgs e)
        {
            matchF14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchF14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG14_Click(object sender, EventArgs e)
        {
            matchG14.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 14);
                    if (valid != false)
                        matchG14.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA15_Click(object sender, EventArgs e)
        {
            matchA15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchA15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB15_Click(object sender, EventArgs e)
        {
            matchB15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchB15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC15_Click(object sender, EventArgs e)
        {
            matchC15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchC15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD15_Click(object sender, EventArgs e)
        {
            matchD15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchD15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE15_Click(object sender, EventArgs e)
        {
            matchE15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchE15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF15_Click(object sender, EventArgs e)
        {
            matchF15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchF15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG15_Click(object sender, EventArgs e)
        {
            matchG15.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 15);
                    if (valid != false)
                        matchG15.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA16_Click(object sender, EventArgs e)
        {
            matchA16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchA16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB16_Click(object sender, EventArgs e)
        {
            matchB16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchB16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC16_Click(object sender, EventArgs e)
        {
            matchC16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchC16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD16_Click(object sender, EventArgs e)
        {
            matchD16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchD16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE16_Click(object sender, EventArgs e)
        {
            matchE16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchE16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF16_Click(object sender, EventArgs e)
        {
            matchF16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchF16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG16_Click(object sender, EventArgs e)
        {
            matchG16.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 16);
                    if (valid != false)
                        matchG16.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA17_Click(object sender, EventArgs e)
        {
            matchA17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchA17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB17_Click(object sender, EventArgs e)
        {
            matchB17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchB17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC17_Click(object sender, EventArgs e)
        {
            matchC17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchC17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD17_Click(object sender, EventArgs e)
        {
            matchD17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchD17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE17_Click(object sender, EventArgs e)
        {
            matchE17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchE17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF17_Click(object sender, EventArgs e)
        {
            matchF17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchF17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG17_Click(object sender, EventArgs e)
        {
            matchG17.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 17);
                    if (valid != false)
                        matchG17.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA18_Click(object sender, EventArgs e)
        {
            matchA18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchA18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB18_Click(object sender, EventArgs e)
        {
            matchB18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchB18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC18_Click(object sender, EventArgs e)
        {
            matchC18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchC18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD18_Click(object sender, EventArgs e)
        {
            matchD18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchD18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE18_Click(object sender, EventArgs e)
        {
            matchE18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchE18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF18_Click(object sender, EventArgs e)
        {
            matchF18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchF18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG18_Click(object sender, EventArgs e)
        {
            matchG18.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 18);
                    if (valid != false)
                        matchG18.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA19_Click(object sender, EventArgs e)
        {
            matchA19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchA19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB19_Click(object sender, EventArgs e)
        {
            matchB19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchB19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC19_Click(object sender, EventArgs e)
        {
            matchC19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchC19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD19_Click(object sender, EventArgs e)
        {
            matchD19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchD19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE19_Click(object sender, EventArgs e)
        {
            matchE19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchE19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF19_Click(object sender, EventArgs e)
        {
            matchF19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchF19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG19_Click(object sender, EventArgs e)
        {
            matchG19.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 19);
                    if (valid != false)
                        matchG19.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA20_Click(object sender, EventArgs e)
        {
            matchA20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchA20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB20_Click(object sender, EventArgs e)
        {
            matchB20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchB20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC20_Click(object sender, EventArgs e)
        {
            matchC20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchC20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD20_Click(object sender, EventArgs e)
        {
            matchD20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchD20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE20_Click(object sender, EventArgs e)
        {
            matchE20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchE20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF20_Click(object sender, EventArgs e)
        {
            matchF20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchF20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG20_Click(object sender, EventArgs e)
        {
            matchG20.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 20);
                    if (valid != false)
                        matchG20.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA21_Click(object sender, EventArgs e)
        {
            matchA21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchA21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB21_Click(object sender, EventArgs e)
        {
            matchB21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchB21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC21_Click(object sender, EventArgs e)
        {
            matchC21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchC21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD21_Click(object sender, EventArgs e)
        {
            matchD21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchD21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE21_Click(object sender, EventArgs e)
        {
            matchE21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchE21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF21_Click(object sender, EventArgs e)
        {
            matchF21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchF21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG21_Click(object sender, EventArgs e)
        {
            matchG21.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 21);
                    if (valid != false)
                        matchG21.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA22_Click(object sender, EventArgs e)
        {
            matchA22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchA22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB22_Click(object sender, EventArgs e)
        {
            matchB22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchB22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchC22_Click(object sender, EventArgs e)
        {
            matchC22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchC22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD22_Click(object sender, EventArgs e)
        {
            matchD22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchD22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE22_Click(object sender, EventArgs e)
        {
            matchE22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchE22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF22_Click(object sender, EventArgs e)
        {
            matchF22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchF22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG22_Click(object sender, EventArgs e)
        {
            matchG22.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 22);
                    if (valid != false)
                        matchG22.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchA23_Click(object sender, EventArgs e)
        {
            matchA23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchA23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchB23_Click(object sender, EventArgs e)
        {
            matchB23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchB23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void MatchC23_Click(object sender, EventArgs e)
        {
            matchC23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchC23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchD23_Click(object sender, EventArgs e)
        {
            matchD23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchD23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchE23_Click(object sender, EventArgs e)
        {
            matchE23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchE23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchF23_Click(object sender, EventArgs e)
        {
            matchF23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchF23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        private void matchG23_Click(object sender, EventArgs e)
        {
            matchG23.Items.Clear(); //reset comboBox
            bool valid = true;
            foreach (string g in game) //loop through each match/ game which must be assigned
            {
                if (g != null)
                {
                    valid = checkValid(g, 23);
                    if (valid != false)
                        matchG23.Items.Add(g); //add game to comboBox
                    valid = true;
                }
            }
        }

        #endregion

        #region buttons_Click

        private void assignA1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA1.Text.Trim());

            if (assignA1.Text == "Assign")
            {
                assignA1.Text = "Undo";
                matchA1.Enabled = false;
                matchesAssigned[division, 0, 0] = matchA1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 0] = null; //remove assigned match
                matchA1.Enabled = true;
            }
        }

        private void assignB1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB1.Text.Trim());

            if (assignB1.Text == "Assign")
            {
                assignB1.Text = "Undo";
                matchB1.Enabled = false;
                matchesAssigned[division, 0, 1] = matchB1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 1] = null; //remove assigned match
                matchB1.Enabled = true;
            }
        }

        private void assignC1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC1.Text.Trim());

            if (assignC1.Text == "Assign")
            {
                assignC1.Text = "Undo";
                matchC1.Enabled = false;
                matchesAssigned[division, 0, 2] = matchC1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 2] = null; //remove assigned match
                matchC1.Enabled = true;
            }
        }

        private void assignD1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD1.Text.Trim());

            if (assignD1.Text == "Assign")
            {
                assignD1.Text = "Undo";
                matchD1.Enabled = false;
                matchesAssigned[division, 0, 3] = matchD1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 3] = null; //remove assigned match
                matchD1.Enabled = true;
            }
        }

        private void assignE1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE1.Text.Trim());

            if (assignE1.Text == "Assign")
            {
                assignE1.Text = "Undo";
                matchE1.Enabled = false;
                matchesAssigned[division, 0, 4] = matchE1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 4] = null; //remove assigned match
                matchE1.Enabled = true;
            }
        }

        private void assignF1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF1.Text.Trim());

            if (assignF1.Text == "Assign")
            {
                assignF1.Text = "Undo";
                matchF1.Enabled = false;
                matchesAssigned[division, 0, 5] = matchF1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 5] = null; //remove assigned match
                matchF1.Enabled = true;
            }
        }

        private void assignG1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG1.Text.Trim());

            if (assignG1.Text == "Assign")
            {
                assignG1.Text = "Undo";
                matchG1.Enabled = false;
                matchesAssigned[division, 0, 6] = matchG1.Text; //Assign the match
                teamAssigned[division, 0, teams.Item1] = true;//assign the teams
                teamAssigned[division, 0, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG1.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG1.Text = "Assign";
                teamAssigned[division, 0, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 0, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG1.Text;
                        break;
                    }
                }
                matchesAssigned[division, 0, 6] = null; //remove assigned match
                matchG1.Enabled = true;
            }
        }

        private void assignA2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA2.Text.Trim());

            if (assignA2.Text == "Assign")
            {
                assignA2.Text = "Undo";
                matchA2.Enabled = false;
                matchesAssigned[division, 1, 0] = matchA2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 0] = null; //remove assigned match
                matchA2.Enabled = true;
            }
        }

        private void assignB2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB2.Text.Trim());

            if (assignB2.Text == "Assign")
            {
                assignB2.Text = "Undo";
                matchB2.Enabled = false;
                matchesAssigned[division, 1, 1] = matchB2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 1] = null; //remove assigned match
                matchB2.Enabled = true;
            }
        }

        private void assignC2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC2.Text.Trim());

            if (assignC2.Text == "Assign")
            {
                assignC2.Text = "Undo";
                matchC2.Enabled = false;
                matchesAssigned[division, 1, 2] = matchC2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 2] = null; //remove assigned match
                matchC2.Enabled = true;
            }
        }

        private void assignD2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD2.Text.Trim());

            if (assignD2.Text == "Assign")
            {
                assignD2.Text = "Undo";
                matchD2.Enabled = false;
                matchesAssigned[division, 1, 3] = matchD2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 3] = null; //remove assigned match
                matchD2.Enabled = true;
            }
        }

        private void assignE2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE2.Text.Trim());

            if (assignE2.Text == "Assign")
            {
                assignE2.Text = "Undo";
                matchE2.Enabled = false;
                matchesAssigned[division, 1, 4] = matchE2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 4] = null; //remove assigned match
                matchE2.Enabled = true;
            }
        }

        private void assignF2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF2.Text.Trim());

            if (assignF2.Text == "Assign")
            {
                assignF2.Text = "Undo";
                matchF2.Enabled = false;
                matchesAssigned[division, 1, 5] = matchF2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 5] = null; //remove assigned match
                matchF2.Enabled = true;
            }
        }

        private void assignG2_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG2.Text.Trim());

            if (assignG2.Text == "Assign")
            {
                assignG2.Text = "Undo";
                matchG2.Enabled = false;
                matchesAssigned[division, 1, 6] = matchG2.Text; //Assign the match
                teamAssigned[division, 1, teams.Item1] = true;//assign the teams
                teamAssigned[division, 1, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG2.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG2.Text = "Assign";
                teamAssigned[division, 1, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 1, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG2.Text;
                        break;
                    }
                }
                matchesAssigned[division, 1, 6] = null; //remove assigned match
                matchG2.Enabled = true;
            }
        }

        private void assignA3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA3.Text.Trim());

            if (assignA3.Text == "Assign")
            {
                assignA3.Text = "Undo";
                matchA3.Enabled = false;
                matchesAssigned[division, 2, 0] = matchA3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 0] = null; //remove assigned match
                matchA3.Enabled = true;
            }
        }

        private void assignB3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB3.Text.Trim());

            if (assignB3.Text == "Assign")
            {
                assignB3.Text = "Undo";
                matchB3.Enabled = false;
                matchesAssigned[division, 2, 1] = matchB3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 1] = null; //remove assigned match
                matchB3.Enabled = true;
            }
        }

        private void assignC3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC3.Text.Trim());

            if (assignC3.Text == "Assign")
            {
                assignC3.Text = "Undo";
                matchC3.Enabled = false;
                matchesAssigned[division, 2, 2] = matchC3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 2] = null; //remove assigned match
                matchC3.Enabled = true;
            }
        }

        private void assignD3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD3.Text.Trim());

            if (assignD3.Text == "Assign")
            {
                assignD3.Text = "Undo";
                matchD3.Enabled = false;
                matchesAssigned[division, 2, 3] = matchD3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 3] = null; //remove assigned match
                matchD3.Enabled = true;
            }
        }

        private void assignE3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE3.Text.Trim());

            if (assignE3.Text == "Assign")
            {
                assignE3.Text = "Undo";
                matchE3.Enabled = false;
                matchesAssigned[division, 2, 4] = matchE3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 4] = null; //remove assigned match
                matchE3.Enabled = true;
            }
        }

        private void assignF3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF3.Text.Trim());

            if (assignF3.Text == "Assign")
            {
                assignF3.Text = "Undo";
                matchF3.Enabled = false;
                matchesAssigned[division, 2, 5] = matchF3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 5] = null; //remove assigned match
                matchF3.Enabled = true;
            }
        }

        private void assignG3_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG3.Text.Trim());

            if (assignG3.Text == "Assign")
            {
                assignG3.Text = "Undo";
                matchG3.Enabled = false;
                matchesAssigned[division, 2, 6] = matchG3.Text; //Assign the match
                teamAssigned[division, 2, teams.Item1] = true;//assign the teams
                teamAssigned[division, 2, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG3.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG3.Text = "Assign";
                teamAssigned[division, 2, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 2, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG3.Text;
                        break;
                    }
                }
                matchesAssigned[division, 2, 6] = null; //remove assigned match
                matchG3.Enabled = true;
            }
        }

        private void assignA4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA4.Text.Trim());

            if (assignA4.Text == "Assign")
            {
                assignA4.Text = "Undo";
                matchA4.Enabled = false;
                matchesAssigned[division, 3, 0] = matchA4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 0] = null; //remove assigned match
                matchA4.Enabled = true;
            }
        }

        private void assignB4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB4.Text.Trim());

            if (assignB4.Text == "Assign")
            {
                assignB4.Text = "Undo";
                matchB4.Enabled = false;
                matchesAssigned[division, 3, 1] = matchB4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 1] = null; //remove assigned match
                matchB4.Enabled = true;
            }
        }

        private void assignC4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC4.Text.Trim());

            if (assignC4.Text == "Assign")
            {
                assignC4.Text = "Undo";
                matchC4.Enabled = false;
                matchesAssigned[division, 3, 2] = matchC4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 2] = null; //remove assigned match
                matchC4.Enabled = true;
            }
        }

        private void assignD4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD4.Text.Trim());

            if (assignD4.Text == "Assign")
            {
                assignD4.Text = "Undo";
                matchD4.Enabled = false;
                matchesAssigned[division, 3, 3] = matchD4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 3] = null; //remove assigned match
                matchD4.Enabled = true;
            }
        }

        private void assignE4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE4.Text.Trim());

            if (assignE4.Text == "Assign")
            {
                assignE4.Text = "Undo";
                matchE4.Enabled = false;
                matchesAssigned[division, 3, 4] = matchE4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 4] = null; //remove assigned match
                matchE4.Enabled = true;
            }
        }

        private void assignF4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF4.Text.Trim());

            if (assignF4.Text == "Assign")
            {
                assignF4.Text = "Undo";
                matchF4.Enabled = false;
                matchesAssigned[division, 3, 5] = matchF4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 5] = null; //remove assigned match
                matchF4.Enabled = true;
            }
        }

        private void assignG4_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG4.Text.Trim());

            if (assignG4.Text == "Assign")
            {
                assignG4.Text = "Undo";
                matchG4.Enabled = false;
                matchesAssigned[division, 3, 6] = matchG4.Text; //Assign the match
                teamAssigned[division, 3, teams.Item1] = true;//assign the teams
                teamAssigned[division, 3, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG4.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG4.Text = "Assign";
                teamAssigned[division, 3, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 3, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG4.Text;
                        break;
                    }
                }
                matchesAssigned[division, 3, 6] = null; //remove assigned match
                matchG4.Enabled = true;
            }
        }

        private void assignA5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA5.Text.Trim());

            if (assignA5.Text == "Assign")
            {
                assignA5.Text = "Undo";
                matchA5.Enabled = false;
                matchesAssigned[division, 4, 0] = matchA5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 0] = null; //remove assigned match
                matchA5.Enabled = true;
            }
        }

        private void assignB5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB5.Text.Trim());

            if (assignB5.Text == "Assign")
            {
                assignB5.Text = "Undo";
                matchB5.Enabled = false;
                matchesAssigned[division, 4, 1] = matchB5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 1] = null; //remove assigned match
                matchB5.Enabled = true;
            }
        }

        private void assignC5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC5.Text.Trim());

            if (assignC5.Text == "Assign")
            {
                assignC5.Text = "Undo";
                matchC5.Enabled = false;
                matchesAssigned[division, 4, 2] = matchC5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 2] = null; //remove assigned match
                matchC5.Enabled = true;
            }
        }

        private void assignD5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD5.Text.Trim());

            if (assignD5.Text == "Assign")
            {
                assignD5.Text = "Undo";
                matchD5.Enabled = false;
                matchesAssigned[division, 4, 3] = matchD5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 3] = null; //remove assigned match
                matchD5.Enabled = true;
            }
        }

        private void assignE5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE5.Text.Trim());

            if (assignE5.Text == "Assign")
            {
                assignE5.Text = "Undo";
                matchE5.Enabled = false;
                matchesAssigned[division, 4, 4] = matchE5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 4] = null; //remove assigned match
                matchE5.Enabled = true;
            }
        }

        private void assignF5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF5.Text.Trim());

            if (assignF5.Text == "Assign")
            {
                assignF5.Text = "Undo";
                matchF5.Enabled = false;
                matchesAssigned[division, 4, 5] = matchF5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 5] = null; //remove assigned match
                matchF5.Enabled = true;
            }
        }

        private void assignG5_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG5.Text.Trim());

            if (assignG5.Text == "Assign")
            {
                assignG5.Text = "Undo";
                matchG5.Enabled = false;
                matchesAssigned[division, 4, 6] = matchG5.Text; //Assign the match
                teamAssigned[division, 4, teams.Item1] = true;//assign the teams
                teamAssigned[division, 4, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG5.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG5.Text = "Assign";
                teamAssigned[division, 4, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 4, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG5.Text;
                        break;
                    }
                }
                matchesAssigned[division, 4, 6] = null; //remove assigned match
                matchG5.Enabled = true;
            }
        }

        private void assignA6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA6.Text.Trim());

            if (assignA6.Text == "Assign")
            {
                assignA6.Text = "Undo";
                matchA6.Enabled = false;
                matchesAssigned[division, 5, 0] = matchA6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 0] = null; //remove assigned match
                matchA6.Enabled = true;
            }
        }

        private void assignB6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB6.Text.Trim());

            if (assignB6.Text == "Assign")
            {
                assignB6.Text = "Undo";
                matchB6.Enabled = false;
                matchesAssigned[division, 5, 1] = matchB6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 1] = null; //remove assigned match
                matchB6.Enabled = true;
            }
        }

        private void assignC6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC6.Text.Trim());

            if (assignC6.Text == "Assign")
            {
                assignC6.Text = "Undo";
                matchC6.Enabled = false;
                matchesAssigned[division, 5, 2] = matchC6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 2] = null; //remove assigned match
                matchC6.Enabled = true;
            }
        }

        private void assignD6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD6.Text.Trim());

            if (assignD6.Text == "Assign")
            {
                assignD6.Text = "Undo";
                matchD6.Enabled = false;
                matchesAssigned[division, 5, 3] = matchD6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 3] = null; //remove assigned match
                matchD6.Enabled = true;
            }
        }

        private void assignE6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE6.Text.Trim());

            if (assignE6.Text == "Assign")
            {
                assignE6.Text = "Undo";
                matchE6.Enabled = false;
                matchesAssigned[division, 5, 4] = matchE6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 4] = null; //remove assigned match
                matchE6.Enabled = true;
            }
        }

        private void assignF6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF6.Text.Trim());

            if (assignF6.Text == "Assign")
            {
                assignF6.Text = "Undo";
                matchF6.Enabled = false;
                matchesAssigned[division, 5, 5] = matchF6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 5] = null; //remove assigned match
                matchF6.Enabled = true;
            }
        }

        private void assignG6_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG6.Text.Trim());

            if (assignG6.Text == "Assign")
            {
                assignG6.Text = "Undo";
                matchG6.Enabled = false;
                matchesAssigned[division, 5, 6] = matchG6.Text; //Assign the match
                teamAssigned[division, 5, teams.Item1] = true;//assign the teams
                teamAssigned[division, 5, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG6.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG6.Text = "Assign";
                teamAssigned[division, 5, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 5, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG6.Text;
                        break;
                    }
                }
                matchesAssigned[division, 5, 6] = null; //remove assigned match
                matchG6.Enabled = true;
            }
        }

        private void assignA7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA7.Text.Trim());

            if (assignA7.Text == "Assign")
            {
                assignA7.Text = "Undo";
                matchA7.Enabled = false;
                matchesAssigned[division, 6, 0] = matchA7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 0] = null; //remove assigned match
                matchA7.Enabled = true;
            }
        }

        private void assignB7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB7.Text.Trim());

            if (assignB7.Text == "Assign")
            {
                assignB7.Text = "Undo";
                matchB7.Enabled = false;
                matchesAssigned[division, 6, 1] = matchB7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 1] = null; //remove assigned match
                matchB7.Enabled = true;
            }
        }

        private void assignC7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC7.Text.Trim());

            if (assignC7.Text == "Assign")
            {
                assignC7.Text = "Undo";
                matchC7.Enabled = false;
                matchesAssigned[division, 6, 2] = matchC7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 2] = null; //remove assigned match
                matchC7.Enabled = true;
            }
        }

        private void assignD7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD7.Text.Trim());

            if (assignD7.Text == "Assign")
            {
                assignD7.Text = "Undo";
                matchD7.Enabled = false;
                matchesAssigned[division, 6, 3] = matchD7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 3] = null; //remove assigned match
                matchD7.Enabled = true;
            }
        }

        private void assignE7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE7.Text.Trim());

            if (assignE7.Text == "Assign")
            {
                assignE7.Text = "Undo";
                matchE7.Enabled = false;
                matchesAssigned[division, 6, 4] = matchE7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 4] = null; //remove assigned match
                matchE7.Enabled = true;
            }
        }

        private void assignF7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF7.Text.Trim());

            if (assignF7.Text == "Assign")
            {
                assignF7.Text = "Undo";
                matchF7.Enabled = false;
                matchesAssigned[division, 6, 5] = matchF7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 5] = null; //remove assigned match
                matchF7.Enabled = true;
            }
        }

        private void assignG7_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG7.Text.Trim());

            if (assignG7.Text == "Assign")
            {
                assignG7.Text = "Undo";
                matchG7.Enabled = false;
                matchesAssigned[division, 6, 6] = matchG7.Text; //Assign the match
                teamAssigned[division, 6, teams.Item1] = true;//assign the teams
                teamAssigned[division, 6, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG7.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG7.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG7.Text;
                        break;
                    }
                }
                matchesAssigned[division, 6, 6] = null; //remove assigned match
                matchG7.Enabled = true;
            }
        }

        private void assignA8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA8.Text.Trim());

            if (assignA8.Text == "Assign")
            {
                assignA8.Text = "Undo";
                matchA8.Enabled = false;
                matchesAssigned[division, 7, 0] = matchA8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 0] = null; //remove assigned match
                matchA8.Enabled = true;
            }
        }

        private void assignB8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB8.Text.Trim());

            if (assignB8.Text == "Assign")
            {
                assignB8.Text = "Undo";
                matchB8.Enabled = false;
                matchesAssigned[division, 7, 1] = matchB8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 1] = null; //remove assigned match
                matchB8.Enabled = true;
            }
        }

        private void assignC8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC8.Text.Trim());

            if (assignC8.Text == "Assign")
            {
                assignC8.Text = "Undo";
                matchC8.Enabled = false;
                matchesAssigned[division, 7, 2] = matchC8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 2] = null; //remove assigned match
                matchC8.Enabled = true;
            }
        }

        private void assignD8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD8.Text.Trim());

            if (assignD8.Text == "Assign")
            {
                assignD8.Text = "Undo";
                matchD8.Enabled = false;
                matchesAssigned[division, 7, 3] = matchD8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 3] = null; //remove assigned match
                matchD8.Enabled = true;
            }
        }

        private void assignE8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE8.Text.Trim());

            if (assignE8.Text == "Assign")
            {
                assignE8.Text = "Undo";
                matchE8.Enabled = false;
                matchesAssigned[division, 7, 4] = matchE8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 4] = null; //remove assigned match
                matchE8.Enabled = true;
            }
        }

        private void assignF8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF8.Text.Trim());

            if (assignA8.Text == "Assign")
            {
                assignF8.Text = "Undo";
                matchF8.Enabled = false;
                matchesAssigned[division, 7, 5] = matchF8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 5] = null; //remove assigned match
                matchF8.Enabled = true;
            }
        }

        private void assignG8_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG8.Text.Trim());

            if (assignG8.Text == "Assign")
            {
                assignG8.Text = "Undo";
                matchG8.Enabled = false;
                matchesAssigned[division, 7, 6] = matchG8.Text; //Assign the match
                teamAssigned[division, 7, teams.Item1] = true;//assign the teams
                teamAssigned[division, 7, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG8.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG8.Text = "Assign";
                teamAssigned[division, 6, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 6, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG8.Text;
                        break;
                    }
                }
                matchesAssigned[division, 7, 6] = null; //remove assigned match
                matchG8.Enabled = true;
            }
        }

        private void assignA9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA9.Text.Trim());

            if (assignA9.Text == "Assign")
            {
                assignA9.Text = "Undo";
                matchA9.Enabled = false;
                matchesAssigned[division, 8, 0] = matchA9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 0] = null; //remove assigned match
                matchA9.Enabled = true;
            }
        }

        private void assignB9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB9.Text.Trim());

            if (assignB9.Text == "Assign")
            {
                assignB9.Text = "Undo";
                matchB9.Enabled = false;
                matchesAssigned[division, 8, 1] = matchB9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 1] = null; //remove assigned match
                matchB9.Enabled = true;
            }
        }

        private void assignC9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC9.Text.Trim());

            if (assignC9.Text == "Assign")
            {
                assignC9.Text = "Undo";
                matchC9.Enabled = false;
                matchesAssigned[division, 8, 2] = matchC9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 2] = null; //remove assigned match
                matchC9.Enabled = true;
            }
        }

        private void assignD9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD9.Text.Trim());

            if (assignD9.Text == "Assign")
            {
                assignD9.Text = "Undo";
                matchD9.Enabled = false;
                matchesAssigned[division, 8, 3] = matchD9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 3] = null; //remove assigned match
                matchD9.Enabled = true;
            }
        }

        private void assignE9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE9.Text.Trim());

            if (assignE9.Text == "Assign")
            {
                assignE9.Text = "Undo";
                matchE9.Enabled = false;
                matchesAssigned[division, 8, 4] = matchE9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 4] = null; //remove assigned match
                matchE9.Enabled = true;
            }
        }

        private void assignF9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF9.Text.Trim());

            if (assignF9.Text == "Assign")
            {
                assignF9.Text = "Undo";
                matchF9.Enabled = false;
                matchesAssigned[division, 8, 5] = matchF9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 5] = null; //remove assigned match
                matchF9.Enabled = true;
            }
        }

        private void assignG9_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG9.Text.Trim());

            if (assignG9.Text == "Assign")
            {
                assignG9.Text = "Undo";
                matchG9.Enabled = false;
                matchesAssigned[division, 8, 6] = matchG9.Text; //Assign the match
                teamAssigned[division, 8, teams.Item1] = true;//assign the teams
                teamAssigned[division, 8, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG9.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG9.Text = "Assign";
                teamAssigned[division, 8, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 8, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG9.Text;
                        break;
                    }
                }
                matchesAssigned[division, 8, 6] = null; //remove assigned match
                matchG9.Enabled = true;
            }
        }

        private void assignA10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA10.Text.Trim());

            if (assignA10.Text == "Assign")
            {
                assignA10.Text = "Undo";
                matchA10.Enabled = false;
                matchesAssigned[division, 9, 0] = matchA10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 0] = null; //remove assigned match
                matchA10.Enabled = true;
            }
        }

        private void assignB10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB10.Text.Trim());

            if (assignB10.Text == "Assign")
            {
                assignB10.Text = "Undo";
                matchB10.Enabled = false;
                matchesAssigned[division, 9, 1] = matchB10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 1] = null; //remove assigned match
                matchB10.Enabled = true;
            }
        }

        private void assignC10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC10.Text.Trim());

            if (assignC10.Text == "Assign")
            {
                assignC10.Text = "Undo";
                matchC10.Enabled = false;
                matchesAssigned[division, 9, 2] = matchC10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 2] = null; //remove assigned match
                matchC10.Enabled = true;
            }
        }

        private void assignD10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD10.Text.Trim());

            if (assignD10.Text == "Assign")
            {
                assignD10.Text = "Undo";
                matchD10.Enabled = false;
                matchesAssigned[division, 9, 3] = matchD10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 3] = null; //remove assigned match
                matchD10.Enabled = true;
            }
        }

        private void assignE10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE10.Text.Trim());

            if (assignE10.Text == "Assign")
            {
                assignE10.Text = "Undo";
                matchE10.Enabled = false;
                matchesAssigned[division, 9, 4] = matchE10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 4] = null; //remove assigned match
                matchE10.Enabled = true;
            }
        }

        private void assignF10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF10.Text.Trim());

            if (assignF10.Text == "Assign")
            {
                assignF10.Text = "Undo";
                matchF10.Enabled = false;
                matchesAssigned[division, 9, 5] = matchF10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 5] = null; //remove assigned match
                matchF10.Enabled = true;
            }
        }

        private void assignG10_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG10.Text.Trim());

            if (assignG10.Text == "Assign")
            {
                assignG10.Text = "Undo";
                matchG10.Enabled = false;
                matchesAssigned[division, 9, 6] = matchG10.Text; //Assign the match
                teamAssigned[division, 9, teams.Item1] = true;//assign the teams
                teamAssigned[division, 9, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG10.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG10.Text = "Assign";
                teamAssigned[division, 9, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 9, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG10.Text;
                        break;
                    }
                }
                matchesAssigned[division, 9, 6] = null; //remove assigned match
                matchG10.Enabled = true;
            }
        }

        private void assignA11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA11.Text.Trim());

            if (assignA11.Text == "Assign")
            {
                assignA11.Text = "Undo";
                matchA11.Enabled = false;
                matchesAssigned[division, 10, 0] = matchA11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 0] = null; //remove assigned match
                matchA11.Enabled = true;
            }
        }

        private void assignB11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB11.Text.Trim());

            if (assignB11.Text == "Assign")
            {
                assignB11.Text = "Undo";
                matchB11.Enabled = false;
                matchesAssigned[division, 10, 1] = matchB11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 1] = null; //remove assigned match
                matchB11.Enabled = true;
            }
        }

        private void assignC11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC11.Text.Trim());

            if (assignC11.Text == "Assign")
            {
                assignC11.Text = "Undo";
                matchC11.Enabled = false;
                matchesAssigned[division, 10, 2] = matchC11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 2] = null; //remove assigned match
                matchC11.Enabled = true;
            }
        }

        private void assignD11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD11.Text.Trim());

            if (assignD11.Text == "Assign")
            {
                assignD11.Text = "Undo";
                matchD11.Enabled = false;
                matchesAssigned[division, 10, 3] = matchD11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 3] = null; //remove assigned match
                matchD11.Enabled = true;
            }
        }

        private void assignE11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE11.Text.Trim());

            if (assignE11.Text == "Assign")
            {
                assignE11.Text = "Undo";
                matchE11.Enabled = false;
                matchesAssigned[division, 10, 4] = matchE11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 4] = null; //remove assigned match
                matchE11.Enabled = true;
            }
        }

        private void assignF11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF11.Text.Trim());

            if (assignF11.Text == "Assign")
            {
                assignF11.Text = "Undo";
                matchF11.Enabled = false;
                matchesAssigned[division, 10, 5] = matchF11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 5] = null; //remove assigned match
                matchF11.Enabled = true;
            }
        }

        private void assignG11_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG11.Text.Trim());

            if (assignG11.Text == "Assign")
            {
                assignG11.Text = "Undo";
                matchG11.Enabled = false;
                matchesAssigned[division, 10, 6] = matchG11.Text; //Assign the match
                teamAssigned[division, 10, teams.Item1] = true;//assign the teams
                teamAssigned[division, 10, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG11.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG11.Text = "Assign";
                teamAssigned[division, 10, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 10, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG11.Text;
                        break;
                    }
                }
                matchesAssigned[division, 10, 6] = null; //remove assigned match
                matchG11.Enabled = true;
            }
        }

        private void assignA12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA12.Text.Trim());

            if (assignA12.Text == "Assign")
            {
                assignA12.Text = "Undo";
                matchA12.Enabled = false;
                matchesAssigned[division, 11, 0] = matchA12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 0] = null; //remove assigned match
                matchA12.Enabled = true;
            }
        }

        private void assignB12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB12.Text.Trim());

            if (assignB12.Text == "Assign")
            {
                assignB12.Text = "Undo";
                matchB12.Enabled = false;
                matchesAssigned[division, 11, 1] = matchB12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 1] = null; //remove assigned match
                matchB12.Enabled = true;
            }
        }

        private void assignC12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC12.Text.Trim());

            if (assignC12.Text == "Assign")
            {
                assignC12.Text = "Undo";
                matchC12.Enabled = false;
                matchesAssigned[division, 11, 2] = matchC12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 2] = null; //remove assigned match
                matchC12.Enabled = true;
            }
        }

        private void assignD12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD12.Text.Trim());

            if (assignD12.Text == "Assign")
            {
                assignD12.Text = "Undo";
                matchD12.Enabled = false;
                matchesAssigned[division, 11, 3] = matchD12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 3] = null; //remove assigned match
                matchD12.Enabled = true;
            }
        }

        private void assignE12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE12.Text.Trim());

            if (assignE12.Text == "Assign")
            {
                assignE12.Text = "Undo";
                matchE12.Enabled = false;
                matchesAssigned[division, 11, 4] = matchE12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 4] = null; //remove assigned match
                matchE12.Enabled = true;
            }
        }

        private void assignF12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF12.Text.Trim());

            if (assignF12.Text == "Assign")
            {
                assignF12.Text = "Undo";
                matchF12.Enabled = false;
                matchesAssigned[division, 11, 5] = matchF12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 5] = null; //remove assigned match
                matchF12.Enabled = true;
            }
        }

        private void assignG12_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG12.Text.Trim());

            if (assignG12.Text == "Assign")
            {
                assignG12.Text = "Undo";
                matchG12.Enabled = false;
                matchesAssigned[division, 11, 6] = matchG12.Text; //Assign the match
                teamAssigned[division, 11, teams.Item1] = true;//assign the teams
                teamAssigned[division, 11, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG12.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG12.Text = "Assign";
                teamAssigned[division, 11, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 11, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG12.Text;
                        break;
                    }
                }
                matchesAssigned[division, 11, 6] = null; //remove assigned match
                matchG12.Enabled = true;
            }
        }

        private void assignA13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA13.Text.Trim());

            if (assignA13.Text == "Assign")
            {
                assignA13.Text = "Undo";
                matchA13.Enabled = false;
                matchesAssigned[division, 12, 0] = matchA13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 0] = null; //remove assigned match
                matchA13.Enabled = true;
            }
        }

        private void assignB13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB13.Text.Trim());

            if (assignB13.Text == "Assign")
            {
                assignB13.Text = "Undo";
                matchB13.Enabled = false;
                matchesAssigned[division, 12, 1] = matchB13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 1] = null; //remove assigned match
                matchB13.Enabled = true;
            }
        }

        private void assignC13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC13.Text.Trim());

            if (assignC13.Text == "Assign")
            {
                assignC13.Text = "Undo";
                matchC13.Enabled = false;
                matchesAssigned[division, 12, 2] = matchC13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 2] = null; //remove assigned match
                matchC13.Enabled = true;
            }
        }

        private void assignD13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD13.Text.Trim());

            if (assignD13.Text == "Assign")
            {
                assignD13.Text = "Undo";
                matchD13.Enabled = false;
                matchesAssigned[division, 12, 3] = matchD13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 3] = null; //remove assigned match
                matchD13.Enabled = true;
            }
        }

        private void assignE13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE13.Text.Trim());

            if (assignE13.Text == "Assign")
            {
                assignE13.Text = "Undo";
                matchE13.Enabled = false;
                matchesAssigned[division, 12, 4] = matchE13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 4] = null; //remove assigned match
                matchE13.Enabled = true;
            }
        }

        private void assignF13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF13.Text.Trim());

            if (assignF13.Text == "Assign")
            {
                assignF13.Text = "Undo";
                matchF13.Enabled = false;
                matchesAssigned[division, 12, 5] = matchF13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 5] = null; //remove assigned match
                matchF13.Enabled = true;
            }
        }

        private void assignG13_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG13.Text.Trim());

            if (assignG13.Text == "Assign")
            {
                assignG13.Text = "Undo";
                matchG13.Enabled = false;
                matchesAssigned[division, 12, 6] = matchG13.Text; //Assign the match
                teamAssigned[division, 12, teams.Item1] = true;//assign the teams
                teamAssigned[division, 12, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG13.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG13.Text = "Assign";
                teamAssigned[division, 12, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 12, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG13.Text;
                        break;
                    }
                }
                matchesAssigned[division, 12, 6] = null; //remove assigned match
                matchG13.Enabled = true;
            }
        }

        private void assignA14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA14.Text.Trim());

            if (assignA14.Text == "Assign")
            {
                assignA14.Text = "Undo";
                matchA14.Enabled = false;
                matchesAssigned[division, 13, 0] = matchA14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 0] = null; //remove assigned match
                matchA14.Enabled = true;
            }
        }

        private void assignB14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB14.Text.Trim());

            if (assignB14.Text == "Assign")
            {
                assignB14.Text = "Undo";
                matchB14.Enabled = false;
                matchesAssigned[division, 13, 1] = matchB14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 1] = null; //remove assigned match
                matchB14.Enabled = true;
            }
        }

        private void assignC14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC14.Text.Trim());

            if (assignC14.Text == "Assign")
            {
                assignC14.Text = "Undo";
                matchC14.Enabled = false;
                matchesAssigned[division, 13, 2] = matchC14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 2] = null; //remove assigned match
                matchC14.Enabled = true;
            }
        }

        private void assignD14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD14.Text.Trim());

            if (assignD14.Text == "Assign")
            {
                assignD14.Text = "Undo";
                matchD14.Enabled = false;
                matchesAssigned[division, 13, 3] = matchD14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 3] = null; //remove assigned match
                matchD14.Enabled = true;
            }
        }

        private void assignE14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE14.Text.Trim());

            if (assignE14.Text == "Assign")
            {
                assignE14.Text = "Undo";
                matchE14.Enabled = false;
                matchesAssigned[division, 13, 4] = matchE14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 4] = null; //remove assigned match
                matchE14.Enabled = true;
            }
        }

        private void assignF14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF14.Text.Trim());

            if (assignF14.Text == "Assign")
            {
                assignF14.Text = "Undo";
                matchF14.Enabled = false;
                matchesAssigned[division, 13, 5] = matchF14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 5] = null; //remove assigned match
                matchF14.Enabled = true;
            }
        }

        private void assignG14_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG14.Text.Trim());

            if (assignG14.Text == "Assign")
            {
                assignG14.Text = "Undo";
                matchG14.Enabled = false;
                matchesAssigned[division, 13, 6] = matchG14.Text; //Assign the match
                teamAssigned[division, 13, teams.Item1] = true;//assign the teams
                teamAssigned[division, 13, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG14.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG14.Text = "Assign";
                teamAssigned[division, 13, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 13, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG14.Text;
                        break;
                    }
                }
                matchesAssigned[division, 13, 6] = null; //remove assigned match
                matchG14.Enabled = true;
            }
        }

        private void assignA15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA15.Text.Trim());

            if (assignA15.Text == "Assign")
            {
                assignA15.Text = "Undo";
                matchA15.Enabled = false;
                matchesAssigned[division, 14, 0] = matchA15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 0] = null; //remove assigned match
                matchA15.Enabled = true;
            }
        }

        private void assignB15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB15.Text.Trim());

            if (assignB15.Text == "Assign")
            {
                assignB15.Text = "Undo";
                matchB15.Enabled = false;
                matchesAssigned[division, 14, 1] = matchB15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 1] = null; //remove assigned match
                matchB15.Enabled = true;
            }
        }

        private void assignC15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC15.Text.Trim());

            if (assignC15.Text == "Assign")
            {
                assignC15.Text = "Undo";
                matchC15.Enabled = false;
                matchesAssigned[division, 14, 2] = matchC15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 2] = null; //remove assigned match
                matchC15.Enabled = true;
            }
        }

        private void assignD15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD15.Text.Trim());

            if (assignD15.Text == "Assign")
            {
                assignD15.Text = "Undo";
                matchD15.Enabled = false;
                matchesAssigned[division, 14, 3] = matchD15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 3] = null; //remove assigned match
                matchD15.Enabled = true;
            }
        }

        private void assignE15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE15.Text.Trim());

            if (assignE15.Text == "Assign")
            {
                assignE15.Text = "Undo";
                matchE15.Enabled = false;
                matchesAssigned[division, 14, 4] = matchE15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 4] = null; //remove assigned match
                matchE15.Enabled = true;
            }
        }

        private void assignF15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF15.Text.Trim());

            if (assignF15.Text == "Assign")
            {
                assignF15.Text = "Undo";
                matchF15.Enabled = false;
                matchesAssigned[division, 14, 5] = matchF15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 5] = null; //remove assigned match
                matchF15.Enabled = true;
            }
        }

        private void assignG15_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG15.Text.Trim());

            if (assignG15.Text == "Assign")
            {
                assignG15.Text = "Undo";
                matchG15.Enabled = false;
                matchesAssigned[division, 14, 6] = matchG15.Text; //Assign the match
                teamAssigned[division, 14, teams.Item1] = true;//assign the teams
                teamAssigned[division, 14, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG15.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG15.Text = "Assign";
                teamAssigned[division, 14, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 14, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG15.Text;
                        break;
                    }
                }
                matchesAssigned[division, 14, 6] = null; //remove assigned match
                matchG15.Enabled = true;
            }
        }

        private void assignA16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA16.Text.Trim());

            if (assignA16.Text == "Assign")
            {
                assignA16.Text = "Undo";
                matchA16.Enabled = false;
                matchesAssigned[division, 15, 0] = matchA16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 0] = null; //remove assigned match
                matchA16.Enabled = true;
            }
        }

        private void assignB16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB16.Text.Trim());

            if (assignB16.Text == "Assign")
            {
                assignB16.Text = "Undo";
                matchB16.Enabled = false;
                matchesAssigned[division, 15, 1] = matchB16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 1] = null; //remove assigned match
                matchB16.Enabled = true;
            }
        }

        private void assignC16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC16.Text.Trim());

            if (assignC16.Text == "Assign")
            {
                assignC16.Text = "Undo";
                matchC16.Enabled = false;
                matchesAssigned[division, 15, 2] = matchC16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 2] = null; //remove assigned match
                matchC16.Enabled = true;
            }
        }

        private void assignD16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD16.Text.Trim());

            if (assignD16.Text == "Assign")
            {
                assignD16.Text = "Undo";
                matchD16.Enabled = false;
                matchesAssigned[division, 15, 3] = matchD16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 3] = null; //remove assigned match
                matchD16.Enabled = true;
            }
        }

        private void assignE16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE16.Text.Trim());

            if (assignE16.Text == "Assign")
            {
                assignE16.Text = "Undo";
                matchE16.Enabled = false;
                matchesAssigned[division, 15, 4] = matchE16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 4] = null; //remove assigned match
                matchE16.Enabled = true;
            }
        }

        private void assignF16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF16.Text.Trim());

            if (assignF16.Text == "Assign")
            {
                assignF16.Text = "Undo";
                matchF16.Enabled = false;
                matchesAssigned[division, 15, 5] = matchF16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 5] = null; //remove assigned match
                matchF16.Enabled = true;
            }
        }

        private void assignG16_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG16.Text.Trim());

            if (assignG16.Text == "Assign")
            {
                assignG16.Text = "Undo";
                matchG16.Enabled = false;
                matchesAssigned[division, 15, 6] = matchG16.Text; //Assign the match
                teamAssigned[division, 15, teams.Item1] = true;//assign the teams
                teamAssigned[division, 15, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG16.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG16.Text = "Assign";
                teamAssigned[division, 15, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 15, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG16.Text;
                        break;
                    }
                }
                matchesAssigned[division, 15, 6] = null; //remove assigned match
                matchG16.Enabled = true;
            }
        }

        private void assignA17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA17.Text.Trim());

            if (assignA17.Text == "Assign")
            {
                assignA17.Text = "Undo";
                matchA17.Enabled = false;
                matchesAssigned[division, 16, 0] = matchA17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 0] = null; //remove assigned match
                matchA17.Enabled = true;
            }
        }

        private void assignB17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB17.Text.Trim());

            if (assignB17.Text == "Assign")
            {
                assignB17.Text = "Undo";
                matchB17.Enabled = false;
                matchesAssigned[division, 16, 1] = matchB17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 1] = null; //remove assigned match
                matchB17.Enabled = true;
            }
        }

        private void assignC17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC17.Text.Trim());

            if (assignC17.Text == "Assign")
            {
                assignC17.Text = "Undo";
                matchC17.Enabled = false;
                matchesAssigned[division, 16, 2] = matchC17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 2] = null; //remove assigned match
                matchC17.Enabled = true;
            }
        }

        private void assignD17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD17.Text.Trim());

            if (assignD17.Text == "Assign")
            {
                assignD17.Text = "Undo";
                matchD17.Enabled = false;
                matchesAssigned[division, 16, 3] = matchD17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 3] = null; //remove assigned match
                matchD17.Enabled = true;
            }
        }

        private void assignE17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE17.Text.Trim());

            if (assignE17.Text == "Assign")
            {
                assignE17.Text = "Undo";
                matchE17.Enabled = false;
                matchesAssigned[division, 16, 4] = matchE17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 4] = null; //remove assigned match
                matchE17.Enabled = true;
            }
        }

        private void assignF17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF17.Text.Trim());

            if (assignF17.Text == "Assign")
            {
                assignF17.Text = "Undo";
                matchF17.Enabled = false;
                matchesAssigned[division, 16, 5] = matchF17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 5] = null; //remove assigned match
                matchF17.Enabled = true;
            }
        }

        private void assignG17_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG17.Text.Trim());

            if (assignG17.Text == "Assign")
            {
                assignG17.Text = "Undo";
                matchG17.Enabled = false;
                matchesAssigned[division, 16, 6] = matchG17.Text; //Assign the match
                teamAssigned[division, 16, teams.Item1] = true;//assign the teams
                teamAssigned[division, 16, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG17.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG17.Text = "Assign";
                teamAssigned[division, 16, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 16, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG17.Text;
                        break;
                    }
                }
                matchesAssigned[division, 16, 6] = null; //remove assigned match
                matchG17.Enabled = true;
            }
        }

        private void assignA18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA18.Text.Trim());

            if (assignA18.Text == "Assign")
            {
                assignA18.Text = "Undo";
                matchA18.Enabled = false;
                matchesAssigned[division, 17, 0] = matchA18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 0] = null; //remove assigned match
                matchA18.Enabled = true;
            }
        }

        private void assignB18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB18.Text.Trim());

            if (assignB18.Text == "Assign")
            {
                assignB18.Text = "Undo";
                matchB18.Enabled = false;
                matchesAssigned[division, 17, 1] = matchB18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 1] = null; //remove assigned match
                matchB18.Enabled = true;
            }
        }

        private void assignC18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC18.Text.Trim());

            if (assignC18.Text == "Assign")
            {
                assignC18.Text = "Undo";
                matchC18.Enabled = false;
                matchesAssigned[division, 17, 2] = matchC18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 2] = null; //remove assigned match
                matchC18.Enabled = true;
            }
        }

        private void assignD18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD18.Text.Trim());

            if (assignD18.Text == "Assign")
            {
                assignD18.Text = "Undo";
                matchD18.Enabled = false;
                matchesAssigned[division, 17, 3] = matchD18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 3] = null; //remove assigned match
                matchD18.Enabled = true;
            }
        }

        private void assignE18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE18.Text.Trim());

            if (assignE18.Text == "Assign")
            {
                assignE18.Text = "Undo";
                matchE18.Enabled = false;
                matchesAssigned[division, 17, 4] = matchE18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 4] = null; //remove assigned match
                matchE18.Enabled = true;
            }
        }

        private void assignF18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF18.Text.Trim());

            if (assignF18.Text == "Assign")
            {
                assignF18.Text = "Undo";
                matchF18.Enabled = false;
                matchesAssigned[division, 17, 5] = matchF18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 5] = null; //remove assigned match
                matchF18.Enabled = true;
            }
        }

        private void assignG18_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG18.Text.Trim());

            if (assignG18.Text == "Assign")
            {
                assignG18.Text = "Undo";
                matchG18.Enabled = false;
                matchesAssigned[division, 17, 6] = matchG18.Text; //Assign the match
                teamAssigned[division, 17, teams.Item1] = true;//assign the teams
                teamAssigned[division, 17, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG18.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG18.Text = "Assign";
                teamAssigned[division, 17, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 17, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG18.Text;
                        break;
                    }
                }
                matchesAssigned[division, 17, 6] = null; //remove assigned match
                matchG18.Enabled = true;
            }
        }

        private void assignA19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA19.Text.Trim());

            if (assignA19.Text == "Assign")
            {
                assignA19.Text = "Undo";
                matchA19.Enabled = false;
                matchesAssigned[division, 18, 0] = matchA19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 0] = null; //remove assigned match
                matchA19.Enabled = true;
            }
        }

        private void assignB19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB19.Text.Trim());

            if (assignB19.Text == "Assign")
            {
                assignB19.Text = "Undo";
                matchB19.Enabled = false;
                matchesAssigned[division, 18, 1] = matchB19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 1] = null; //remove assigned match
                matchB19.Enabled = true;
            }
        }

        private void assignC19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC19.Text.Trim());

            if (assignC19.Text == "Assign")
            {
                assignC19.Text = "Undo";
                matchC19.Enabled = false;
                matchesAssigned[division, 18, 2] = matchC19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 2] = null; //remove assigned match
                matchC19.Enabled = true;
            }
        }

        private void assignD19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD19.Text.Trim());

            if (assignD19.Text == "Assign")
            {
                assignD19.Text = "Undo";
                matchD19.Enabled = false;
                matchesAssigned[division, 18, 3] = matchD19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 3] = null; //remove assigned match
                matchD19.Enabled = true;
            }
        }

        private void assignE19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE19.Text.Trim());

            if (assignE19.Text == "Assign")
            {
                assignE19.Text = "Undo";
                matchE19.Enabled = false;
                matchesAssigned[division, 18, 4] = matchE19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 4] = null; //remove assigned match
                matchE19.Enabled = true;
            }
        }

        private void assignF19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF19.Text.Trim());

            if (assignF19.Text == "Assign")
            {
                assignF19.Text = "Undo";
                matchF19.Enabled = false;
                matchesAssigned[division, 18, 5] = matchF19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 5] = null; //remove assigned match
                matchF19.Enabled = true;
            }
        }

        private void assignG19_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG19.Text.Trim());

            if (assignG19.Text == "Assign")
            {
                assignG19.Text = "Undo";
                matchG19.Enabled = false;
                matchesAssigned[division, 18, 6] = matchG19.Text; //Assign the match
                teamAssigned[division, 18, teams.Item1] = true;//assign the teams
                teamAssigned[division, 18, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG19.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG19.Text = "Assign";
                teamAssigned[division, 18, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 18, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG19.Text;
                        break;
                    }
                }
                matchesAssigned[division, 18, 6] = null; //remove assigned match
                matchG19.Enabled = true;
            }
        }

        private void assignA20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA20.Text.Trim());

            if (assignA20.Text == "Assign")
            {
                assignA20.Text = "Undo";
                matchA20.Enabled = false;
                matchesAssigned[division, 19, 0] = matchA20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 0] = null; //remove assigned match
                matchA20.Enabled = true;
            }
        }

        private void assignB20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB20.Text.Trim());

            if (assignB20.Text == "Assign")
            {
                assignB20.Text = "Undo";
                matchB20.Enabled = false;
                matchesAssigned[division, 19, 1] = matchB20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 1] = null; //remove assigned match
                matchB20.Enabled = true;
            }
        }

        private void assignC20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC20.Text.Trim());

            if (assignC20.Text == "Assign")
            {
                assignC20.Text = "Undo";
                matchC20.Enabled = false;
                matchesAssigned[division, 19, 2] = matchC20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 2] = null; //remove assigned match
                matchC20.Enabled = true;
            }
        }

        private void assignD20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD20.Text.Trim());

            if (assignD20.Text == "Assign")
            {
                assignD20.Text = "Undo";
                matchD20.Enabled = false;
                matchesAssigned[division, 19, 3] = matchD20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 3] = null; //remove assigned match
                matchD20.Enabled = true;
            }
        }

        private void assignE20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE20.Text.Trim());

            if (assignE20.Text == "Assign")
            {
                assignE20.Text = "Undo";
                matchE20.Enabled = false;
                matchesAssigned[division, 19, 4] = matchE20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 4] = null; //remove assigned match
                matchE20.Enabled = true;
            }
        }

        private void assignF20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF20.Text.Trim());

            if (assignF20.Text == "Assign")
            {
                assignF20.Text = "Undo";
                matchF20.Enabled = false;
                matchesAssigned[division, 19, 5] = matchF20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 5] = null; //remove assigned match
                matchF20.Enabled = true;
            }
        }

        private void assignG20_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG20.Text.Trim());

            if (assignG20.Text == "Assign")
            {
                assignG20.Text = "Undo";
                matchG20.Enabled = false;
                matchesAssigned[division, 19, 6] = matchG20.Text; //Assign the match
                teamAssigned[division, 19, teams.Item1] = true;//assign the teams
                teamAssigned[division, 19, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG20.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG20.Text = "Assign";
                teamAssigned[division, 19, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 19, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG20.Text;
                        break;
                    }
                }
                matchesAssigned[division, 19, 6] = null; //remove assigned match
                matchG20.Enabled = true;
            }
        }

        private void assignA21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA21.Text.Trim());

            if (assignA21.Text == "Assign")
            {
                assignA21.Text = "Undo";
                matchA21.Enabled = false;
                matchesAssigned[division, 20, 0] = matchA21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 0] = null; //remove assigned match
                matchA21.Enabled = true;
            }
        }

        private void assignB21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB21.Text.Trim());

            if (assignB21.Text == "Assign")
            {
                assignB21.Text = "Undo";
                matchB21.Enabled = false;
                matchesAssigned[division, 20, 1] = matchB21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 1] = null; //remove assigned match
                matchB21.Enabled = true;
            }
        }

        private void assignC21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC21.Text.Trim());

            if (assignC21.Text == "Assign")
            {
                assignC21.Text = "Undo";
                matchC21.Enabled = false;
                matchesAssigned[division, 20, 2] = matchC21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 2] = null; //remove assigned match
                matchC21.Enabled = true;
            }
        }

        private void assignD21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD21.Text.Trim());

            if (assignD21.Text == "Assign")
            {
                assignD21.Text = "Undo";
                matchD21.Enabled = false;
                matchesAssigned[division, 20, 3] = matchD21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 3] = null; //remove assigned match
                matchD21.Enabled = true;
            }
        }

        private void assignE21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE21.Text.Trim());

            if (assignE21.Text == "Assign")
            {
                assignE21.Text = "Undo";
                matchE21.Enabled = false;
                matchesAssigned[division, 20, 4] = matchE21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 4] = null; //remove assigned match
                matchE21.Enabled = true;
            }
        }

        private void assignF21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF21.Text.Trim());

            if (assignF21.Text == "Assign")
            {
                assignF21.Text = "Undo";
                matchF21.Enabled = false;
                matchesAssigned[division, 20, 5] = matchF21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 5] = null; //remove assigned match
                matchF21.Enabled = true;
            }
        }

        private void assignG21_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG21.Text.Trim());

            if (assignG21.Text == "Assign")
            {
                assignG21.Text = "Undo";
                matchG21.Enabled = false;
                matchesAssigned[division, 20, 6] = matchG21.Text; //Assign the match
                teamAssigned[division, 20, teams.Item1] = true;//assign the teams
                teamAssigned[division, 20, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG21.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG21.Text = "Assign";
                teamAssigned[division, 20, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 20, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG21.Text;
                        break;
                    }
                }
                matchesAssigned[division, 20, 6] = null; //remove assigned match
                matchG21.Enabled = true;
            }
        }

        private void assignA22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA22.Text.Trim());

            if (assignA22.Text == "Assign")
            {
                assignA22.Text = "Undo";
                matchA22.Enabled = false;
                matchesAssigned[division, 21, 0] = matchA22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 0] = null; //remove assigned match
                matchA22.Enabled = true;
            }
        }

        private void assignB22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB22.Text.Trim());

            if (assignB22.Text == "Assign")
            {
                assignB22.Text = "Undo";
                matchB22.Enabled = false;
                matchesAssigned[division, 21, 1] = matchB22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 1] = null; //remove assigned match
                matchB22.Enabled = true;
            }
        }

        private void assignC22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC22.Text.Trim());

            if (assignC22.Text == "Assign")
            {
                assignC22.Text = "Undo";
                matchC22.Enabled = false;
                matchesAssigned[division, 21, 2] = matchC22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 2] = null; //remove assigned match
                matchC22.Enabled = true;
            }
        }

        private void assignD22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD22.Text.Trim());

            if (assignD22.Text == "Assign")
            {
                assignD22.Text = "Undo";
                matchD22.Enabled = false;
                matchesAssigned[division, 21, 3] = matchD22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 3] = null; //remove assigned match
                matchD22.Enabled = true;
            }
        }

        private void assignE22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE22.Text.Trim());

            if (assignE22.Text == "Assign")
            {
                assignE22.Text = "Undo";
                matchE22.Enabled = false;
                matchesAssigned[division, 21, 4] = matchE22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 4] = null; //remove assigned match
                matchE22.Enabled = true;
            }
        }

        private void assignF22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF22.Text.Trim());

            if (assignF22.Text == "Assign")
            {
                assignF22.Text = "Undo";
                matchF22.Enabled = false;
                matchesAssigned[division, 21, 5] = matchF22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 5] = null; //remove assigned match
                matchF22.Enabled = true;
            }
        }

        private void assignG22_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG22.Text.Trim());

            if (assignG22.Text == "Assign")
            {
                assignG22.Text = "Undo";
                matchG22.Enabled = false;
                matchesAssigned[division, 21, 6] = matchG22.Text; //Assign the match
                teamAssigned[division, 21, teams.Item1] = true;//assign the teams
                teamAssigned[division, 21, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG22.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG22.Text = "Assign";
                teamAssigned[division, 21, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 21, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG22.Text;
                        break;
                    }
                }
                matchesAssigned[division, 21, 6] = null; //remove assigned match
                matchG22.Enabled = true;
            }
        }

        private void assignA23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchA23.Text.Trim());

            if (assignA23.Text == "Assign")
            {
                assignA23.Text = "Undo";
                matchA23.Enabled = false;
                matchesAssigned[division, 22, 0] = matchA23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchA23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignA23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchA23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 0] = null; //remove assigned match
                matchA23.Enabled = true;
            }
        }

        private void assignB23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchB23.Text.Trim());

            if (assignB23.Text == "Assign")
            {
                assignB23.Text = "Undo";
                matchB23.Enabled = false;
                matchesAssigned[division, 22, 1] = matchB23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchB23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignB23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchB23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 1] = null; //remove assigned match
                matchB23.Enabled = true;
            }
        }

        private void assignC23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchC23.Text.Trim());

            if (assignC23.Text == "Assign")
            {
                assignC23.Text = "Undo";
                matchC23.Enabled = false;
                matchesAssigned[division, 22, 2] = matchC23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchC23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignC23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchC23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 2] = null; //remove assigned match
                matchC23.Enabled = true;
            }
        }

        private void assignD23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchD23.Text.Trim());

            if (assignD23.Text == "Assign")
            {
                assignD23.Text = "Undo";
                matchD23.Enabled = false;
                matchesAssigned[division, 22, 3] = matchD23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchD23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignD23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchD23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 3] = null; //remove assigned match
                matchD23.Enabled = true;
            }
        }

        private void assignE23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchE23.Text.Trim());

            if (assignE23.Text == "Assign")
            {
                assignE23.Text = "Undo";
                matchE23.Enabled = false;
                matchesAssigned[division, 22, 4] = matchE23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchE23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignE23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchE23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 4] = null; //remove assigned match
                matchE23.Enabled = true;
            }
        }

        private void assignF23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchF23.Text.Trim());

            if (assignF23.Text == "Assign")
            {
                assignF23.Text = "Undo";
                matchF23.Enabled = false;
                matchesAssigned[division, 22, 5] = matchF23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchF23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignF23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchF23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 5] = null; //remove assigned match
                matchF23.Enabled = true;
            }
        }

        private void assignG23_Click(object sender, EventArgs e)
        {
            Tuple<int, int> teams = getHomeAway(matchG23.Text.Trim());

            if (assignG23.Text == "Assign")
            {
                assignG23.Text = "Undo";
                matchG23.Enabled = false;
                matchesAssigned[division, 22, 6] = matchG23.Text; //Assign the match
                teamAssigned[division, 22, teams.Item1] = true;//assign the teams
                teamAssigned[division, 22, teams.Item2] = true;
                for (int i = 0; i < 210; i++) //remove match from game array
                {
                    if (game[division, i] == matchG23.Text)
                    {
                        game[division, i] = null;
                        break;
                    }
                }
            }
            else
            {
                assignG23.Text = "Assign";
                teamAssigned[division, 22, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, 22, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = matchG23.Text;
                        break;
                    }
                }
                matchesAssigned[division, 22, 6] = null; //remove assigned match
                matchG23.Enabled = true;
            }
        }
    }

    #endregion
}
