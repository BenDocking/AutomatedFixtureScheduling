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
using System.IO;
using System.Diagnostics;

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

            #region initialize
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
            assignA1.Text = "Assign";
            assignA2.Text = "Assign";
            assignA3.Text = "Assign";
            assignA4.Text = "Assign";
            assignA5.Text = "Assign";
            assignA6.Text = "Assign";
            assignA7.Text = "Assign";
            assignA8.Text = "Assign";
            assignA9.Text = "Assign";
            assignA10.Text = "Assign";
            assignA11.Text = "Assign";
            assignA12.Text = "Assign";
            assignA13.Text = "Assign";
            assignA14.Text = "Assign";
            assignA15.Text = "Assign";
            assignA16.Text = "Assign";
            assignA17.Text = "Assign";
            assignA18.Text = "Assign";
            assignA19.Text = "Assign";
            assignA20.Text = "Assign";
            assignA21.Text = "Assign";
            assignA22.Text = "Assign";
            assignA23.Text = "Assign";
            assignB1.Text = "Assign";
            assignB2.Text = "Assign";
            assignB3.Text = "Assign";
            assignB4.Text = "Assign";
            assignB5.Text = "Assign";
            assignB6.Text = "Assign";
            assignB7.Text = "Assign";
            assignB8.Text = "Assign";
            assignB9.Text = "Assign";
            assignB10.Text = "Assign";
            assignB11.Text = "Assign";
            assignB12.Text = "Assign";
            assignB13.Text = "Assign";
            assignB14.Text = "Assign";
            assignB15.Text = "Assign";
            assignB16.Text = "Assign";
            assignB17.Text = "Assign";
            assignB18.Text = "Assign";
            assignB19.Text = "Assign";
            assignB20.Text = "Assign";
            assignB21.Text = "Assign";
            assignB22.Text = "Assign";
            assignB23.Text = "Assign";
            assignC1.Text = "Assign";
            assignC2.Text = "Assign";
            assignC3.Text = "Assign";
            assignC4.Text = "Assign";
            assignC5.Text = "Assign";
            assignC6.Text = "Assign";
            assignC7.Text = "Assign";
            assignC8.Text = "Assign";
            assignC9.Text = "Assign";
            assignC10.Text = "Assign";
            assignC11.Text = "Assign";
            assignC12.Text = "Assign";
            assignC13.Text = "Assign";
            assignC14.Text = "Assign";
            assignC15.Text = "Assign";
            assignC16.Text = "Assign";
            assignC17.Text = "Assign";
            assignC18.Text = "Assign";
            assignC19.Text = "Assign";
            assignC20.Text = "Assign";
            assignC21.Text = "Assign";
            assignC22.Text = "Assign";
            assignC23.Text = "Assign";
            assignD1.Text = "Assign";
            assignD2.Text = "Assign";
            assignD3.Text = "Assign";
            assignD4.Text = "Assign";
            assignD5.Text = "Assign";
            assignD6.Text = "Assign";
            assignD7.Text = "Assign";
            assignD8.Text = "Assign";
            assignD9.Text = "Assign";
            assignD10.Text = "Assign";
            assignD11.Text = "Assign";
            assignD12.Text = "Assign";
            assignD13.Text = "Assign";
            assignD14.Text = "Assign";
            assignD15.Text = "Assign";
            assignD16.Text = "Assign";
            assignD17.Text = "Assign";
            assignD18.Text = "Assign";
            assignD19.Text = "Assign";
            assignD20.Text = "Assign";
            assignD21.Text = "Assign";
            assignD22.Text = "Assign";
            assignD23.Text = "Assign";
            assignE1.Text = "Assign";
            assignE2.Text = "Assign";
            assignE3.Text = "Assign";
            assignE4.Text = "Assign";
            assignE5.Text = "Assign";
            assignE6.Text = "Assign";
            assignE7.Text = "Assign";
            assignE8.Text = "Assign";
            assignE9.Text = "Assign";
            assignE10.Text = "Assign";
            assignE11.Text = "Assign";
            assignE12.Text = "Assign";
            assignE13.Text = "Assign";
            assignE14.Text = "Assign";
            assignE15.Text = "Assign";
            assignE16.Text = "Assign";
            assignE17.Text = "Assign";
            assignE18.Text = "Assign";
            assignE19.Text = "Assign";
            assignE20.Text = "Assign";
            assignE21.Text = "Assign";
            assignE22.Text = "Assign";
            assignE23.Text = "Assign";
            assignF1.Text = "Assign";
            assignF2.Text = "Assign";
            assignF3.Text = "Assign";
            assignF4.Text = "Assign";
            assignF5.Text = "Assign";
            assignF6.Text = "Assign";
            assignF7.Text = "Assign";
            assignF8.Text = "Assign";
            assignF9.Text = "Assign";
            assignF10.Text = "Assign";
            assignF11.Text = "Assign";
            assignF12.Text = "Assign";
            assignF13.Text = "Assign";
            assignF14.Text = "Assign";
            assignF15.Text = "Assign";
            assignF16.Text = "Assign";
            assignF17.Text = "Assign";
            assignF18.Text = "Assign";
            assignF19.Text = "Assign";
            assignF20.Text = "Assign";
            assignF21.Text = "Assign";
            assignF22.Text = "Assign";
            assignF23.Text = "Assign";
            assignG1.Text = "Assign";
            assignG2.Text = "Assign";
            assignG3.Text = "Assign";
            assignG4.Text = "Assign";
            assignG5.Text = "Assign";
            assignG6.Text = "Assign";
            assignG7.Text = "Assign";
            assignG8.Text = "Assign";
            assignG9.Text = "Assign";
            assignG10.Text = "Assign";
            assignG11.Text = "Assign";
            assignG12.Text = "Assign";
            assignG13.Text = "Assign";
            assignG14.Text = "Assign";
            assignG15.Text = "Assign";
            assignG16.Text = "Assign";
            assignG17.Text = "Assign";
            assignG18.Text = "Assign";
            assignG19.Text = "Assign";
            assignG20.Text = "Assign";
            assignG21.Text = "Assign";
            assignG22.Text = "Assign";
            assignG23.Text = "Assign";
            matchA1.Enabled = true;
            matchA2.Enabled = true;
            matchA3.Enabled = true;
            matchA4.Enabled = true;
            matchA5.Enabled = true;
            matchA6.Enabled = true;
            matchA7.Enabled = true;
            matchA8.Enabled = true;
            matchA9.Enabled = true;
            matchA10.Enabled = true;
            matchA11.Enabled = true;
            matchA12.Enabled = true;
            matchA13.Enabled = true;
            matchA14.Enabled = true;
            matchA15.Enabled = true;
            matchA16.Enabled = true;
            matchA17.Enabled = true;
            matchA18.Enabled = true;
            matchA19.Enabled = true;
            matchA20.Enabled = true;
            matchA21.Enabled = true;
            matchA22.Enabled = true;
            matchA23.Enabled = true;
            matchB1.Enabled = true;
            matchB2.Enabled = true;
            matchB3.Enabled = true;
            matchB4.Enabled = true;
            matchB5.Enabled = true;
            matchB6.Enabled = true;
            matchB7.Enabled = true;
            matchB8.Enabled = true;
            matchB9.Enabled = true;
            matchB10.Enabled = true;
            matchB11.Enabled = true;
            matchB12.Enabled = true;
            matchB13.Enabled = true;
            matchB14.Enabled = true;
            matchB15.Enabled = true;
            matchB16.Enabled = true;
            matchB17.Enabled = true;
            matchB18.Enabled = true;
            matchB19.Enabled = true;
            matchB20.Enabled = true;
            matchB21.Enabled = true;
            matchB22.Enabled = true;
            matchB23.Enabled = true;
            matchC1.Enabled = true;
            matchC2.Enabled = true;
            matchC3.Enabled = true;
            matchC4.Enabled = true;
            matchC5.Enabled = true;
            matchC6.Enabled = true;
            matchC7.Enabled = true;
            matchC8.Enabled = true;
            matchC9.Enabled = true;
            matchC10.Enabled = true;
            matchC11.Enabled = true;
            matchC12.Enabled = true;
            matchC13.Enabled = true;
            matchC14.Enabled = true;
            matchC15.Enabled = true;
            matchC16.Enabled = true;
            matchC17.Enabled = true;
            matchC18.Enabled = true;
            matchC19.Enabled = true;
            matchC20.Enabled = true;
            matchC21.Enabled = true;
            matchC22.Enabled = true;
            matchC23.Enabled = true;
            matchD1.Enabled = true;
            matchD2.Enabled = true;
            matchD3.Enabled = true;
            matchD4.Enabled = true;
            matchD5.Enabled = true;
            matchD6.Enabled = true;
            matchD7.Enabled = true;
            matchD8.Enabled = true;
            matchD9.Enabled = true;
            matchD10.Enabled = true;
            matchD11.Enabled = true;
            matchD12.Enabled = true;
            matchD13.Enabled = true;
            matchD14.Enabled = true;
            matchD15.Enabled = true;
            matchD16.Enabled = true;
            matchD17.Enabled = true;
            matchD18.Enabled = true;
            matchD19.Enabled = true;
            matchD20.Enabled = true;
            matchD21.Enabled = true;
            matchD22.Enabled = true;
            matchD23.Enabled = true;
            matchE1.Enabled = true;
            matchE2.Enabled = true;
            matchE3.Enabled = true;
            matchE4.Enabled = true;
            matchE5.Enabled = true;
            matchE6.Enabled = true;
            matchE7.Enabled = true;
            matchE8.Enabled = true;
            matchE9.Enabled = true;
            matchE10.Enabled = true;
            matchE11.Enabled = true;
            matchE12.Enabled = true;
            matchE13.Enabled = true;
            matchE14.Enabled = true;
            matchE15.Enabled = true;
            matchE16.Enabled = true;
            matchE17.Enabled = true;
            matchE18.Enabled = true;
            matchE19.Enabled = true;
            matchE20.Enabled = true;
            matchE21.Enabled = true;
            matchE22.Enabled = true;
            matchE23.Enabled = true;
            matchF1.Enabled = true;
            matchF2.Enabled = true;
            matchF3.Enabled = true;
            matchF4.Enabled = true;
            matchF5.Enabled = true;
            matchF6.Enabled = true;
            matchF7.Enabled = true;
            matchF8.Enabled = true;
            matchF9.Enabled = true;
            matchF10.Enabled = true;
            matchF11.Enabled = true;
            matchF12.Enabled = true;
            matchF13.Enabled = true;
            matchF14.Enabled = true;
            matchF15.Enabled = true;
            matchF16.Enabled = true;
            matchF17.Enabled = true;
            matchF18.Enabled = true;
            matchF19.Enabled = true;
            matchF20.Enabled = true;
            matchF21.Enabled = true;
            matchF22.Enabled = true;
            matchF23.Enabled = true;
            matchG1.Enabled = true;
            matchG2.Enabled = true;
            matchG3.Enabled = true;
            matchG4.Enabled = true;
            matchG5.Enabled = true;
            matchG6.Enabled = true;
            matchG7.Enabled = true;
            matchG8.Enabled = true;
            matchG9.Enabled = true;
            matchG10.Enabled = true;
            matchG11.Enabled = true;
            matchG12.Enabled = true;
            matchG13.Enabled = true;
            matchG14.Enabled = true;
            matchG15.Enabled = true;
            matchG16.Enabled = true;
            matchG17.Enabled = true;
            matchG18.Enabled = true;
            matchG19.Enabled = true;
            matchG20.Enabled = true;
            matchG21.Enabled = true;
            matchG22.Enabled = true;
            matchG23.Enabled = true;
            matchA1.SelectedIndex = -1;
            matchA2.SelectedIndex = -1;
            matchA3.SelectedIndex = -1;
            matchA4.SelectedIndex = -1;
            matchA5.SelectedIndex = -1;
            matchA6.SelectedIndex = -1;
            matchA7.SelectedIndex = -1;
            matchA8.SelectedIndex = -1;
            matchA9.SelectedIndex = -1;
            matchA10.SelectedIndex = -1;
            matchA11.SelectedIndex = -1;
            matchA12.SelectedIndex = -1;
            matchA13.SelectedIndex = -1;
            matchA14.SelectedIndex = -1;
            matchA15.SelectedIndex = -1;
            matchA16.SelectedIndex = -1;
            matchA17.SelectedIndex = -1;
            matchA18.SelectedIndex = -1;
            matchA19.SelectedIndex = -1;
            matchA20.SelectedIndex = -1;
            matchA21.SelectedIndex = -1;
            matchA22.SelectedIndex = -1;
            matchA23.SelectedIndex = -1;
            matchB1.SelectedIndex = -1;
            matchB2.SelectedIndex = -1;
            matchB3.SelectedIndex = -1;
            matchB4.SelectedIndex = -1;
            matchB5.SelectedIndex = -1;
            matchB6.SelectedIndex = -1;
            matchB7.SelectedIndex = -1;
            matchB8.SelectedIndex = -1;
            matchB9.SelectedIndex = -1;
            matchB10.SelectedIndex = -1;
            matchB11.SelectedIndex = -1;
            matchB12.SelectedIndex = -1;
            matchB13.SelectedIndex = -1;
            matchB14.SelectedIndex = -1;
            matchB15.SelectedIndex = -1;
            matchB16.SelectedIndex = -1;
            matchB17.SelectedIndex = -1;
            matchB18.SelectedIndex = -1;
            matchB19.SelectedIndex = -1;
            matchB20.SelectedIndex = -1;
            matchB21.SelectedIndex = -1;
            matchB22.SelectedIndex = -1;
            matchB23.SelectedIndex = -1;
            matchC1.SelectedIndex = -1;
            matchC2.SelectedIndex = -1;
            matchC3.SelectedIndex = -1;
            matchC4.SelectedIndex = -1;
            matchC5.SelectedIndex = -1;
            matchC6.SelectedIndex = -1;
            matchC7.SelectedIndex = -1;
            matchC8.SelectedIndex = -1;
            matchC9.SelectedIndex = -1;
            matchC10.SelectedIndex = -1;
            matchC11.SelectedIndex = -1;
            matchC12.SelectedIndex = -1;
            matchC13.SelectedIndex = -1;
            matchC14.SelectedIndex = -1;
            matchC15.SelectedIndex = -1;
            matchC16.SelectedIndex = -1;
            matchC17.SelectedIndex = -1;
            matchC18.SelectedIndex = -1;
            matchC19.SelectedIndex = -1;
            matchC20.SelectedIndex = -1;
            matchC21.SelectedIndex = -1;
            matchC22.SelectedIndex = -1;
            matchC23.SelectedIndex = -1;
            matchD1.SelectedIndex = -1;
            matchD2.SelectedIndex = -1;
            matchD3.SelectedIndex = -1;
            matchD4.SelectedIndex = -1;
            matchD5.SelectedIndex = -1;
            matchD6.SelectedIndex = -1;
            matchD7.SelectedIndex = -1;
            matchD8.SelectedIndex = -1;
            matchD9.SelectedIndex = -1;
            matchD10.SelectedIndex = -1;
            matchD11.SelectedIndex = -1;
            matchD12.SelectedIndex = -1;
            matchD13.SelectedIndex = -1;
            matchD14.SelectedIndex = -1;
            matchD15.SelectedIndex = -1;
            matchD16.SelectedIndex = -1;
            matchD17.SelectedIndex = -1;
            matchD18.SelectedIndex = -1;
            matchD19.SelectedIndex = -1;
            matchD20.SelectedIndex = -1;
            matchD21.SelectedIndex = -1;
            matchD22.SelectedIndex = -1;
            matchD23.SelectedIndex = -1;
            matchE1.SelectedIndex = -1;
            matchE2.SelectedIndex = -1;
            matchE3.SelectedIndex = -1;
            matchE4.SelectedIndex = -1;
            matchE5.SelectedIndex = -1;
            matchE6.SelectedIndex = -1;
            matchE7.SelectedIndex = -1;
            matchE8.SelectedIndex = -1;
            matchE9.SelectedIndex = -1;
            matchE10.SelectedIndex = -1;
            matchE11.SelectedIndex = -1;
            matchE12.SelectedIndex = -1;
            matchE13.SelectedIndex = -1;
            matchE14.SelectedIndex = -1;
            matchE15.SelectedIndex = -1;
            matchE16.SelectedIndex = -1;
            matchE17.SelectedIndex = -1;
            matchE18.SelectedIndex = -1;
            matchE19.SelectedIndex = -1;
            matchE20.SelectedIndex = -1;
            matchE21.SelectedIndex = -1;
            matchE22.SelectedIndex = -1;
            matchE23.SelectedIndex = -1;
            matchF1.SelectedIndex = -1;
            matchF2.SelectedIndex = -1;
            matchF3.SelectedIndex = -1;
            matchF4.SelectedIndex = -1;
            matchF5.SelectedIndex = -1;
            matchF6.SelectedIndex = -1;
            matchF7.SelectedIndex = -1;
            matchF8.SelectedIndex = -1;
            matchF9.SelectedIndex = -1;
            matchF10.SelectedIndex = -1;
            matchF11.SelectedIndex = -1;
            matchF12.SelectedIndex = -1;
            matchF13.SelectedIndex = -1;
            matchF14.SelectedIndex = -1;
            matchF15.SelectedIndex = -1;
            matchF16.SelectedIndex = -1;
            matchF17.SelectedIndex = -1;
            matchF18.SelectedIndex = -1;
            matchF19.SelectedIndex = -1;
            matchF20.SelectedIndex = -1;
            matchF21.SelectedIndex = -1;
            matchF22.SelectedIndex = -1;
            matchF23.SelectedIndex = -1;
            matchG1.SelectedIndex = -1;
            matchG2.SelectedIndex = -1;
            matchG3.SelectedIndex = -1;
            matchG4.SelectedIndex = -1;
            matchG5.SelectedIndex = -1;
            matchG6.SelectedIndex = -1;
            matchG7.SelectedIndex = -1;
            matchG8.SelectedIndex = -1;
            matchG9.SelectedIndex = -1;
            matchG10.SelectedIndex = -1;
            matchG11.SelectedIndex = -1;
            matchG12.SelectedIndex = -1;
            matchG13.SelectedIndex = -1;
            matchG14.SelectedIndex = -1;
            matchG15.SelectedIndex = -1;
            matchG16.SelectedIndex = -1;
            matchG17.SelectedIndex = -1;
            matchG18.SelectedIndex = -1;
            matchG19.SelectedIndex = -1;
            matchG20.SelectedIndex = -1;
            matchG21.SelectedIndex = -1;
            matchG22.SelectedIndex = -1;
            matchG23.SelectedIndex = -1;
            #endregion

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
                    team1.Text = "1 - " + name[division, 0];
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

            #region dispay assigned matches
            if (matchesAssigned[division, 0, 0] != null)
            {
                assigned(assignA1, matchA1, matchesAssigned[division, 0, 0]);
            }
            if (matchesAssigned[division, 0, 1] != null)
            {
                assigned(assignB1, matchB1, matchesAssigned[division, 0, 1]);
            }

            if (matchesAssigned[division, 0, 2] != null)
            {
                assigned(assignC1, matchC1, matchesAssigned[division, 0, 2]);
            }
            if (matchesAssigned[division, 0, 3] != null)
            {
                assigned(assignD1, matchD1, matchesAssigned[division, 0, 3]);
            }
            if (matchesAssigned[division, 0, 4] != null)
            {
                assigned(assignE1, matchE1, matchesAssigned[division, 0, 4]);
            }
            if (matchesAssigned[division, 0, 5] != null)
            {
                assigned(assignF1, matchF1, matchesAssigned[division, 0, 5]);
            }
            if (matchesAssigned[division, 0, 6] != null)
            {
                assigned(assignG1, matchG1, matchesAssigned[division, 0, 6]);
            }
            if (matchesAssigned[division, 1, 0] != null)
            {
                assigned(assignA2, matchA2, matchesAssigned[division, 1, 0]);
            }
            if (matchesAssigned[division, 1, 1] != null)
            {
                assigned(assignB2, matchB2, matchesAssigned[division, 1, 1]);
            }
            if (matchesAssigned[division, 1, 2] != null)
            {
                assigned(assignC2, matchC2, matchesAssigned[division, 1, 2]);
            }
            if (matchesAssigned[division, 1, 3] != null)
            {
                assigned(assignD2, matchD2, matchesAssigned[division, 1, 3]);
            }
            if (matchesAssigned[division, 1, 4] != null)
            {
                assigned(assignE2, matchE2, matchesAssigned[division, 1, 4]);
            }
            if (matchesAssigned[division, 1, 5] != null)
            {
                assigned(assignF2, matchF2, matchesAssigned[division, 1, 5]);
            }
            if (matchesAssigned[division, 1, 6] != null)
            {
                assigned(assignG2, matchG2, matchesAssigned[division, 1, 6]);
            }
            if (matchesAssigned[division, 2, 0] != null)
            {
                assigned(assignA3, matchA3, matchesAssigned[division, 2, 0]);
            }
            if (matchesAssigned[division, 2, 1] != null)
            {
                assigned(assignB3, matchB3, matchesAssigned[division, 2, 1]);
            }
            if (matchesAssigned[division, 2, 2] != null)
            {
                assigned(assignC3, matchC3, matchesAssigned[division, 2, 2]);
            }
            if (matchesAssigned[division, 2, 3] != null)
            {
                assigned(assignD3, matchD3, matchesAssigned[division, 2, 3]);
            }
            if (matchesAssigned[division, 2, 4] != null)
            {
                assigned(assignE3, matchE3, matchesAssigned[division, 2, 4]);
            }
            if (matchesAssigned[division, 2, 5] != null)
            {
                assigned(assignF3, matchF3, matchesAssigned[division, 2, 5]);
            }
            if (matchesAssigned[division, 2, 6] != null)
            {
                assigned(assignG3, matchG3, matchesAssigned[division, 2, 6]);
            }
            if (matchesAssigned[division, 3, 0] != null)
            {
                assigned(assignA4, matchA4, matchesAssigned[division, 3, 0]);
            }
            if (matchesAssigned[division, 3, 1] != null)
            {
                assigned(assignB4, matchB4, matchesAssigned[division, 3, 1]);
            }
            if (matchesAssigned[division, 3, 2] != null)
            {
                assigned(assignC4, matchC4, matchesAssigned[division, 3, 2]);
            }
            if (matchesAssigned[division, 3, 3] != null)
            {
                assigned(assignD4, matchD4, matchesAssigned[division, 3, 3]);
            }
            if (matchesAssigned[division, 3, 4] != null)
            {
                assigned(assignE4, matchE4, matchesAssigned[division, 3, 4]);
            }
            if (matchesAssigned[division, 3, 5] != null)
            {
                assigned(assignF4, matchF4, matchesAssigned[division, 3, 5]);
            }
            if (matchesAssigned[division, 3, 6] != null)
            {
                assigned(assignG4, matchG4, matchesAssigned[division, 3, 6]);
            }
            if (matchesAssigned[division, 4, 0] != null)
            {
                assigned(assignA5, matchA5, matchesAssigned[division, 4, 0]);
            }
            if (matchesAssigned[division, 4, 1] != null)
            {
                assigned(assignB5, matchB5, matchesAssigned[division, 4, 1]);
            }
            if (matchesAssigned[division, 4, 2] != null)
            {
                assigned(assignC5, matchC5, matchesAssigned[division, 4, 2]);
            }
            if (matchesAssigned[division, 4, 3] != null)
            {
                assigned(assignD5, matchD5, matchesAssigned[division, 4, 3]);
            }
            if (matchesAssigned[division, 4, 4] != null)
            {
                assigned(assignE5, matchE5, matchesAssigned[division, 4, 4]);
            }
            if (matchesAssigned[division, 4, 5] != null)
            {
                assigned(assignF5, matchF5, matchesAssigned[division, 4, 5]);
            }
            if (matchesAssigned[division, 4, 6] != null)
            {
                assigned(assignG5, matchG5, matchesAssigned[division, 4, 6]);
            }
            if (matchesAssigned[division, 5, 0] != null)
            {
                assigned(assignA6, matchA6, matchesAssigned[division, 5, 0]);
            }
            if (matchesAssigned[division, 5, 1] != null)
            {
                assigned(assignB6, matchB6, matchesAssigned[division, 5, 1]);
            }
            if (matchesAssigned[division, 5, 2] != null)
            {
                assigned(assignC6, matchC6, matchesAssigned[division, 5, 2]);
            }
            if (matchesAssigned[division, 5, 3] != null)
            {
                assigned(assignD6, matchD6, matchesAssigned[division, 5, 3]);
            }
            if (matchesAssigned[division, 5, 4] != null)
            {
                assigned(assignE6, matchE6, matchesAssigned[division, 5, 4]);
            }
            if (matchesAssigned[division, 5, 5] != null)
            {
                assigned(assignF6, matchF6, matchesAssigned[division, 5, 5]);
            }
            if (matchesAssigned[division, 5, 6] != null)
            {
                assigned(assignG6, matchG6, matchesAssigned[division, 5, 6]);
            }
            if (matchesAssigned[division, 6, 0] != null)
            {
                assigned(assignA7, matchA7, matchesAssigned[division, 6, 0]);
            }
            if (matchesAssigned[division, 6, 1] != null)
            {
                assigned(assignB7, matchB7, matchesAssigned[division, 6, 1]);
            }
            if (matchesAssigned[division, 6, 2] != null)
            {
                assigned(assignC7, matchC7, matchesAssigned[division, 6, 2]);
            }
            if (matchesAssigned[division, 6, 3] != null)
            {
                assigned(assignD7, matchD7, matchesAssigned[division, 6, 3]);
            }
            if (matchesAssigned[division, 6, 4] != null)
            {
                assigned(assignE7, matchE7, matchesAssigned[division, 6, 4]);
            }
            if (matchesAssigned[division, 6, 5] != null)
            {
                assigned(assignF7, matchF7, matchesAssigned[division, 6, 5]);
            }
            if (matchesAssigned[division, 6, 6] != null)
            {
                assigned(assignG7, matchG7, matchesAssigned[division, 6, 6]);
            }
            if (matchesAssigned[division, 7, 0] != null)
            {
                assigned(assignA8, matchA8, matchesAssigned[division, 7, 0]);
            }
            if (matchesAssigned[division, 7, 1] != null)
            {
                assigned(assignB8, matchB8, matchesAssigned[division, 7, 1]);
            }
            if (matchesAssigned[division, 7, 2] != null)
            {
                assigned(assignC8, matchC8, matchesAssigned[division, 7, 2]);
            }
            if (matchesAssigned[division, 7, 3] != null)
            {
                assigned(assignD8, matchD8, matchesAssigned[division, 7, 3]);
            }
            if (matchesAssigned[division, 7, 4] != null)
            {
                assigned(assignE8, matchE8, matchesAssigned[division, 7, 4]);
            }
            if (matchesAssigned[division, 7, 5] != null)
            {
                assigned(assignF8, matchF8, matchesAssigned[division, 7, 5]);
            }
            if (matchesAssigned[division, 7, 6] != null)
            {
                assigned(assignG8, matchG8, matchesAssigned[division, 7, 6]);
            }
            if (matchesAssigned[division, 8, 0] != null)
            {
                assigned(assignA9, matchA9, matchesAssigned[division, 8, 0]);
            }
            if (matchesAssigned[division, 8, 1] != null)
            {
                assigned(assignB9, matchB9, matchesAssigned[division, 8, 1]);
            }
            if (matchesAssigned[division, 8, 2] != null)
            {
                assigned(assignC9, matchC9, matchesAssigned[division, 8, 2]);
            }
            if (matchesAssigned[division, 8, 3] != null)
            {
                assigned(assignD9, matchD9, matchesAssigned[division, 8, 3]);
            }
            if (matchesAssigned[division, 8, 4] != null)
            {
                assigned(assignE9, matchE9, matchesAssigned[division, 8, 4]);
            }
            if (matchesAssigned[division, 8, 5] != null)
            {
                assigned(assignF9, matchF9, matchesAssigned[division, 8, 5]);
            }
            if (matchesAssigned[division, 8, 6] != null)
            {
                assigned(assignG9, matchG9, matchesAssigned[division, 8, 6]);
            }
            if (matchesAssigned[division, 9, 0] != null)
            {
                assigned(assignA10, matchA10, matchesAssigned[division, 9, 0]);
            }
            if (matchesAssigned[division, 9, 1] != null)
            {
                assigned(assignB10, matchB10, matchesAssigned[division, 9, 1]);
            }
            if (matchesAssigned[division, 9, 2] != null)
            {
                assigned(assignC10, matchC10, matchesAssigned[division, 9, 2]);
            }
            if (matchesAssigned[division, 9, 3] != null)
            {
                assigned(assignD10, matchD10, matchesAssigned[division, 9, 3]);
            }
            if (matchesAssigned[division, 9, 4] != null)
            {
                assigned(assignE10, matchE10, matchesAssigned[division, 9, 4]);
            }
            if (matchesAssigned[division, 9, 5] != null)
            {
                assigned(assignF10, matchF10, matchesAssigned[division, 9, 5]);
            }
            if (matchesAssigned[division, 9, 6] != null)
            {
                assigned(assignG10, matchG10, matchesAssigned[division, 9, 6]);
            }
            if (matchesAssigned[division, 10, 0] != null)
            {
                assigned(assignA11, matchA11, matchesAssigned[division, 10, 0]);
            }
            if (matchesAssigned[division, 10, 1] != null)
            {
                assigned(assignB11, matchB11, matchesAssigned[division, 10, 1]);
            }
            if (matchesAssigned[division, 10, 2] != null)
            {
                assigned(assignC11, matchC11, matchesAssigned[division, 10, 2]);
            }
            if (matchesAssigned[division, 10, 3] != null)
            {
                assigned(assignD11, matchD11, matchesAssigned[division, 10, 3]);
            }
            if (matchesAssigned[division, 10, 4] != null)
            {
                assigned(assignE11, matchE11, matchesAssigned[division, 10, 4]);
            }
            if (matchesAssigned[division, 10, 5] != null)
            {
                assigned(assignF11, matchF11, matchesAssigned[division, 10, 5]);
            }
            if (matchesAssigned[division, 10, 6] != null)
            {
                assigned(assignG11, matchG11, matchesAssigned[division, 10, 6]);
            }
            if (matchesAssigned[division, 11, 0] != null)
            {
                assigned(assignA12, matchA12, matchesAssigned[division, 11, 0]);
            }
            if (matchesAssigned[division, 11, 1] != null)
            {
                assigned(assignB12, matchB12, matchesAssigned[division, 11, 1]);
            }
            if (matchesAssigned[division, 11, 2] != null)
            {
                assigned(assignC12, matchC12, matchesAssigned[division, 11, 2]);
            }
            if (matchesAssigned[division, 11, 3] != null)
            {
                assigned(assignD12, matchD12, matchesAssigned[division, 11, 3]);
            }
            if (matchesAssigned[division, 11, 4] != null)
            {
                assigned(assignE12, matchE12, matchesAssigned[division, 11, 4]);
            }
            if (matchesAssigned[division, 11, 5] != null)
            {
                assigned(assignF12, matchF12, matchesAssigned[division, 11, 5]);
            }
            if (matchesAssigned[division, 11, 6] != null)
            {
                assigned(assignG12, matchG12, matchesAssigned[division, 11, 6]);
            }
            if (matchesAssigned[division, 12, 0] != null)
            {
                assigned(assignA13, matchA13, matchesAssigned[division, 12, 0]);
            }
            if (matchesAssigned[division, 12, 1] != null)
            {
                assigned(assignB13, matchB13, matchesAssigned[division, 12, 1]);
            }
            if (matchesAssigned[division, 12, 2] != null)
            {
                assigned(assignC13, matchC13, matchesAssigned[division, 12, 2]);
            }
            if (matchesAssigned[division, 12, 3] != null)
            {
                assigned(assignD13, matchD13, matchesAssigned[division, 12, 3]);
            }
            if (matchesAssigned[division, 12, 4] != null)
            {
                assigned(assignE13, matchE13, matchesAssigned[division, 12, 4]);
            }
            if (matchesAssigned[division, 12, 5] != null)
            {
                assigned(assignF13, matchF13, matchesAssigned[division, 12, 5]);
            }
            if (matchesAssigned[division, 12, 6] != null)
            {
                assigned(assignG13, matchG13, matchesAssigned[division, 12, 6]);
            }
            if (matchesAssigned[division, 13, 0] != null)
            {
                assigned(assignA14, matchA14, matchesAssigned[division, 13, 0]);
            }
            if (matchesAssigned[division, 13, 1] != null)
            {
                assigned(assignB14, matchB14, matchesAssigned[division, 13, 1]);
            }
            if (matchesAssigned[division, 13, 2] != null)
            {
                assigned(assignC14, matchC14, matchesAssigned[division, 13, 2]);
            }
            if (matchesAssigned[division, 13, 3] != null)
            {
                assigned(assignD14, matchD14, matchesAssigned[division, 13, 3]);
            }
            if (matchesAssigned[division, 13, 4] != null)
            {
                assigned(assignE14, matchE14, matchesAssigned[division, 13, 4]);
            }
            if (matchesAssigned[division, 13, 5] != null)
            {
                assigned(assignF14, matchF14, matchesAssigned[division, 13, 5]);
            }
            if (matchesAssigned[division, 13, 6] != null)
            {
                assigned(assignG14, matchG14, matchesAssigned[division, 13, 6]);
            }
            if (matchesAssigned[division, 14, 0] != null)
            {
                assigned(assignA15, matchA15, matchesAssigned[division, 14, 0]);
            }
            if (matchesAssigned[division, 14, 1] != null)
            {
                assigned(assignB15, matchB15, matchesAssigned[division, 14, 1]);
            }
            if (matchesAssigned[division, 14, 2] != null)
            {
                assigned(assignC15, matchC15, matchesAssigned[division, 14, 2]);
            }
            if (matchesAssigned[division, 14, 3] != null)
            {
                assigned(assignD15, matchD15, matchesAssigned[division, 14, 3]);
            }
            if (matchesAssigned[division, 14, 4] != null)
            {
                assigned(assignE15, matchE15, matchesAssigned[division, 14, 4]);
            }
            if (matchesAssigned[division, 14, 5] != null)
            {
                assigned(assignF15, matchF15, matchesAssigned[division, 14, 5]);
            }
            if (matchesAssigned[division, 14, 6] != null)
            {
                assigned(assignG15, matchG15, matchesAssigned[division, 14, 6]);
            }
            if (matchesAssigned[division, 15, 0] != null)
            {
                assigned(assignA16, matchA16, matchesAssigned[division, 15, 0]);
            }
            if (matchesAssigned[division, 15, 1] != null)
            {
                assigned(assignB16, matchB16, matchesAssigned[division, 15, 1]);
            }
            if (matchesAssigned[division, 15, 2] != null)
            {
                assigned(assignC16, matchC16, matchesAssigned[division, 15, 2]);
            }
            if (matchesAssigned[division, 15, 3] != null)
            {
                assigned(assignD16, matchD16, matchesAssigned[division, 15, 3]);
            }
            if (matchesAssigned[division, 15, 4] != null)
            {
                assigned(assignE16, matchE16, matchesAssigned[division, 15, 4]);
            }
            if (matchesAssigned[division, 15, 5] != null)
            {
                assigned(assignF16, matchF16, matchesAssigned[division, 15, 5]);
            }
            if (matchesAssigned[division, 15, 6] != null)
            {
                assigned(assignG16, matchG16, matchesAssigned[division, 15, 6]);
            }
            if (matchesAssigned[division, 16, 0] != null)
            {
                assigned(assignA17, matchA17, matchesAssigned[division, 16, 0]);
            }
            if (matchesAssigned[division, 16, 1] != null)
            {
                assigned(assignB17, matchB17, matchesAssigned[division, 16, 1]);
            }
            if (matchesAssigned[division, 16, 2] != null)
            {
                assigned(assignC17, matchC17, matchesAssigned[division, 16, 2]);
            }
            if (matchesAssigned[division, 16, 3] != null)
            {
                assigned(assignD17, matchD17, matchesAssigned[division, 16, 3]);
            }
            if (matchesAssigned[division, 16, 4] != null)
            {
                assigned(assignE17, matchE17, matchesAssigned[division, 16, 4]);
            }
            if (matchesAssigned[division, 16, 5] != null)
            {
                assigned(assignF17, matchF17, matchesAssigned[division, 16, 5]);
            }
            if (matchesAssigned[division, 16, 6] != null)
            {
                assigned(assignG17, matchG17, matchesAssigned[division, 16, 6]);
            }
            if (matchesAssigned[division, 17, 0] != null)
            {
                assigned(assignA18, matchA18, matchesAssigned[division, 17, 0]);
            }
            if (matchesAssigned[division, 17, 1] != null)
            {
                assigned(assignB18, matchB18, matchesAssigned[division, 17, 1]);
            }
            if (matchesAssigned[division, 17, 2] != null)
            {
                assigned(assignC18, matchC18, matchesAssigned[division, 17, 2]);
            }
            if (matchesAssigned[division, 17, 3] != null)
            {
                assigned(assignD18, matchD18, matchesAssigned[division, 17, 3]);
            }
            if (matchesAssigned[division, 17, 4] != null)
            {
                assigned(assignE18, matchE18, matchesAssigned[division, 17, 4]);
            }
            if (matchesAssigned[division, 17, 5] != null)
            {
                assigned(assignF18, matchF18, matchesAssigned[division, 17, 5]);
            }
            if (matchesAssigned[division, 17, 6] != null)
            {
                assigned(assignG18, matchG18, matchesAssigned[division, 17, 6]);
            }
            if (matchesAssigned[division, 18, 0] != null)
            {
                assigned(assignA19, matchA19, matchesAssigned[division, 18, 0]);
            }
            if (matchesAssigned[division, 18, 1] != null)
            {
                assigned(assignB19, matchB19, matchesAssigned[division, 18, 1]);
            }
            if (matchesAssigned[division, 18, 2] != null)
            {
                assigned(assignC19, matchC19, matchesAssigned[division, 18, 2]);
            }
            if (matchesAssigned[division, 18, 3] != null)
            {
                assigned(assignD19, matchD19, matchesAssigned[division, 18, 3]);
            }
            if (matchesAssigned[division, 18, 4] != null)
            {
                assigned(assignE19, matchE19, matchesAssigned[division, 18, 4]);
            }
            if (matchesAssigned[division, 18, 5] != null)
            {
                assigned(assignF19, matchF19, matchesAssigned[division, 18, 5]);
            }
            if (matchesAssigned[division, 18, 6] != null)
            {
                assigned(assignG19, matchG19, matchesAssigned[division, 18, 6]);
            }
            if (matchesAssigned[division, 19, 0] != null)
            {
                assigned(assignA20, matchA20, matchesAssigned[division, 19, 0]);
            }
            if (matchesAssigned[division, 19, 1] != null)
            {
                assigned(assignB20, matchB20, matchesAssigned[division, 19, 1]);
            }
            if (matchesAssigned[division, 19, 2] != null)
            {
                assigned(assignC20, matchC20, matchesAssigned[division, 19, 2]);
            }
            if (matchesAssigned[division, 19, 3] != null)
            {
                assigned(assignD20, matchD20, matchesAssigned[division, 19, 3]);
            }
            if (matchesAssigned[division, 19, 4] != null)
            {
                assigned(assignE20, matchE20, matchesAssigned[division, 19, 4]);
            }
            if (matchesAssigned[division, 19, 5] != null)
            {
                assigned(assignF20, matchF20, matchesAssigned[division, 19, 5]);
            }
            if (matchesAssigned[division, 19, 6] != null)
            {
                assigned(assignG20, matchG20, matchesAssigned[division, 19, 6]);
            }
            if (matchesAssigned[division, 20, 0] != null)
            {
                assigned(assignA21, matchA21, matchesAssigned[division, 20, 0]);
            }
            if (matchesAssigned[division, 20, 1] != null)
            {
                assigned(assignB21, matchB21, matchesAssigned[division, 20, 1]);
            }
            if (matchesAssigned[division, 20, 2] != null)
            {
                assigned(assignC21, matchC21, matchesAssigned[division, 20, 2]);
            }
            if (matchesAssigned[division, 20, 3] != null)
            {
                assigned(assignD21, matchD21, matchesAssigned[division, 20, 3]);
            }
            if (matchesAssigned[division, 20, 4] != null)
            {
                assigned(assignE21, matchE21, matchesAssigned[division, 20, 4]);
            }
            if (matchesAssigned[division, 20, 5] != null)
            {
                assigned(assignF21, matchF21, matchesAssigned[division, 20, 5]);
            }
            if (matchesAssigned[division, 20, 6] != null)
            {
                assigned(assignG21, matchG21, matchesAssigned[division, 20, 6]);
            }
            if (matchesAssigned[division, 21, 0] != null)
            {
                assigned(assignA22, matchA22, matchesAssigned[division, 21, 0]);
            }
            if (matchesAssigned[division, 21, 1] != null)
            {
                assigned(assignB22, matchB22, matchesAssigned[division, 21, 1]);
            }
            if (matchesAssigned[division, 21, 2] != null)
            {
                assigned(assignC22, matchC22, matchesAssigned[division, 21, 2]);
            }
            if (matchesAssigned[division, 21, 3] != null)
            {
                assigned(assignD22, matchD22, matchesAssigned[division, 21, 3]);
            }
            if (matchesAssigned[division, 21, 4] != null)
            {
                assigned(assignE22, matchE22, matchesAssigned[division, 21, 4]);
            }
            if (matchesAssigned[division, 21, 5] != null)
            {
                assigned(assignF22, matchF22, matchesAssigned[division, 21, 5]);
            }
            if (matchesAssigned[division, 21, 6] != null)
            {
                assigned(assignG22, matchG22, matchesAssigned[division, 21, 6]);
            }
            if (matchesAssigned[division, 22, 0] != null)
            {
                assigned(assignA23, matchA23, matchesAssigned[division, 22, 0]);
            }
            if (matchesAssigned[division, 22, 1] != null)
            {
                assigned(assignB23, matchB23, matchesAssigned[division, 22, 1]);
            }
            if (matchesAssigned[division, 22, 2] != null)
            {
                assigned(assignC23, matchC23, matchesAssigned[division, 22, 2]);
            }
            if (matchesAssigned[division, 22, 3] != null)
            {
                assigned(assignD23, matchD23, matchesAssigned[division, 22, 3]);
            }
            if (matchesAssigned[division, 22, 4] != null)
            {
                assigned(assignE23, matchE23, matchesAssigned[division, 22, 4]);
            }
            if (matchesAssigned[division, 22, 5] != null)
            {
                assigned(assignF23, matchF23, matchesAssigned[division, 22, 5]);
            }
            if (matchesAssigned[division, 22, 6] != null)
            {
                assigned(assignG23, matchG23, matchesAssigned[division, 22, 6]);
            }
            #endregion
        }

        private void assigned(Button b, ComboBox c, string m)
        {
            c.Items.Clear();
            c.Items.Add(m);
            c.SelectedIndex = 0;
            c.Enabled = false;
            b.Text = "Undo";
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

        private void displayMatches(ComboBox c, int week)
        {
            c.Items.Clear(); //reset comboBox
            bool valid = true;

            for (int i = 0; i < 210; i++)
            {
                string g = game[division, i]; //loop through each game to be assigned in division
                
                if (g != null)
                {
                    valid = checkValid(g, week);

                    if (valid != false)
                    {
                        c.Items.Add(g); //add game to comboBox
                    }
                    else
                    {
                        valid = true;
                    }
                }
            }
        }

        private void assignMatch(Button b, ComboBox c, int week, int matchNo)
        {
            bool valid = true;
            Tuple<int, int> teams = getHomeAway(c.Text.Trim());

            if (b.Text == "Assign")
            {
                for (int i = 0; i < 23; i++) //for each week, check match not already assigned
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (matchesAssigned[division, i, j] == c.Text)
                        {
                            valid = false;
                        }
                    }
                }

                if (valid != false)
                {
                    b.Text = "Undo";
                    c.Enabled = false;
                    matchesAssigned[division, week, matchNo] = c.Text; //assign the match
                    teamAssigned[division, week, teams.Item1] = true; //assign the teams
                    teamAssigned[division, week, teams.Item2] = true;

                    for (int i = 0; i < 210; i++) //remove match from game array
                    {
                        if (game[division, i] == c.Text)
                        {
                            game[division, i] = null;
                            break;
                        }
                    }
                }
            }
            else
            {
                b.Text = "Assign";
                teamAssigned[division, week, teams.Item1] = false; //un-assign the teams
                teamAssigned[division, week, teams.Item2] = false;
                for (int i = 0; i < 210; i++) //add match back to game array
                {
                    if (game[division, i] == null)
                    {
                        game[division, i] = c.Text;
                        break;
                    }
                }
                matchesAssigned[division, week, matchNo] = null; //remove assigned match
                c.Enabled = true;
            }
        }

        #region comboBoxes_Click

        private void matchA1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchB1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchC1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchD1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchE1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchF1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchG1_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 1);
        }

        private void matchA2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchB2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchC2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchD2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchE2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchF2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchG2_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 2);
        }

        private void matchA3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchB3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchC3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchD3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchE3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchF3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchG3_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 3);
        }

        private void matchA4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchB4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchC4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchD4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchE4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchF4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchG4_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 4);
        }

        private void matchA5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchB5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchC5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchD5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchE5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchF5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchG5_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 5);
        }

        private void matchA6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchB6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchC6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchD6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchE6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchF6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchG6_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 6);
        }

        private void matchA7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchB7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchC7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchD7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchE7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchF7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchG7_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 7);
        }

        private void matchA8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchB8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchC8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchD8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchE8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchF8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchG8_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 8);
        }

        private void matchA9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchB9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchC9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchD9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchE9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchF9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchG9_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 9);
        }

        private void matchA10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchB10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchC10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchD10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchE10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchF10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchG10_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 10);
        }

        private void matchA11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchB11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchC11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchD11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchE11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchF11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchG11_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 11);
        }

        private void matchA12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchB12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchC12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchD12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchE12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchF12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchG12_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 12);
        }

        private void matchA13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchB13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchC13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchD13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchE13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchF13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchG13_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 13);
        }

        private void matchA14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchB14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchC14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchD14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchE14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchF14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchG14_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 14);
        }

        private void matchA15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchB15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchC15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchD15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchE15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchF15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchG15_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 15);
        }

        private void matchA16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchB16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchC16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchD16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchE16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchF16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchG16_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 16);
        }

        private void matchA17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchB17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchC17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchD17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchE17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchF17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchG17_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 17);
        }

        private void matchA18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchB18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchC18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchD18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchE18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchF18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchG18_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 18);
        }

        private void matchA19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchB19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchC19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchD19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchE19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchF19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchG19_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 19);
        }

        private void matchA20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchB20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchC20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchD20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchE20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchF20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchG20_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 20);
        }

        private void matchA21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchB21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchC21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchD21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchE21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchF21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchG21_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 21);
        }

        private void matchA22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchB22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchC22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchD22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchE22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchF22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchG22_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 22);
        }

        private void matchA23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void matchB23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void MatchC23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void matchD23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void matchE23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void matchF23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        private void matchG23_Click(object sender, EventArgs e)
        {
            var matchObject = sender as ComboBox;
            displayMatches(matchObject, 23);
        }

        #endregion

        #region buttons_Click

        private void assignA1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA1, 0, 0);
        }

        private void assignB1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB1, 0, 1);
        }

        private void assignC1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC1, 0, 2);
        }

        private void assignD1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD1, 0, 3);
        }

        private void assignE1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE1, 0, 4);
        }

        private void assignF1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF1, 0, 5);
        }

        private void assignG1_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG1, 0, 6);
        }

        private void assignA2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA2, 1, 0);
        }

        private void assignB2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB2, 1, 1);
        }

        private void assignC2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC2, 1, 2);
        }

        private void assignD2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD2, 1, 3);
        }

        private void assignE2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE2, 1, 4);
        }

        private void assignF2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF2, 1, 5);
        }

        private void assignG2_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG2, 1, 6);
        }

        private void assignA3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA3, 2, 0);
        }

        private void assignB3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB3, 2, 1);
        }

        private void assignC3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC3, 2, 2);
        }

        private void assignD3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD3, 2, 3);
        }

        private void assignE3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE3, 2, 4);
        }

        private void assignF3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF3, 2, 5);
        }

        private void assignG3_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG3, 2, 6);
        }

        private void assignA4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA4, 3, 0);
        }

        private void assignB4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB4, 3, 1);
        }

        private void assignC4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC4, 3, 2);
        }

        private void assignD4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD4, 3, 3);
        }

        private void assignE4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE4, 3, 4);
        }

        private void assignF4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF4, 3, 5);
        }

        private void assignG4_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG4, 3, 6);
        }

        private void assignA5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA5, 4, 0);
        }

        private void assignB5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB5, 4, 1);
        }

        private void assignC5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC5, 4, 2);
        }

        private void assignD5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD5, 4, 3);
        }

        private void assignE5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE5, 4, 4);
        }

        private void assignF5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF5, 4, 5);
        }

        private void assignG5_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG5, 4, 6);
        }

        private void assignA6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA6, 5, 0);
        }

        private void assignB6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB6, 5, 1);
        }

        private void assignC6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC6, 5, 2);
        }

        private void assignD6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD6, 5, 3);
        }

        private void assignE6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE6, 5, 4);
        }

        private void assignF6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF6, 5, 5);
        }

        private void assignG6_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG6, 5, 6);
        }

        private void assignA7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA7, 6, 0);
        }

        private void assignB7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB7, 6, 1);
        }

        private void assignC7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC7, 6, 2);
        }

        private void assignD7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD7, 6, 3);
        }

        private void assignE7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE7, 6, 4);
        }

        private void assignF7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF7, 6, 5);
        }

        private void assignG7_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG7, 6, 6);
        }

        private void assignA8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA8, 7, 0);
        }

        private void assignB8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB8, 7, 1);
        }

        private void assignC8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC8, 7, 2);
        }

        private void assignD8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD8, 7, 3);
        }

        private void assignE8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE8, 7, 4);
        }

        private void assignF8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF8, 7, 5);
        }

        private void assignG8_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG8, 7, 6);
        }

        private void assignA9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA9, 8, 0);
        }

        private void assignB9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB9, 8, 1);
        }

        private void assignC9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC9, 8, 2);
        }

        private void assignD9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD9, 8, 3);
        }

        private void assignE9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE9, 8, 4);
        }

        private void assignF9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF9, 8, 5);
        }

        private void assignG9_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG9, 8, 6);
        }

        private void assignA10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA10, 9, 0);
        }

        private void assignB10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB10, 9, 1);
        }

        private void assignC10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC10, 9, 2);
        }

        private void assignD10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD10, 9, 3);
        }

        private void assignE10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE10, 9, 4);
        }

        private void assignF10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF10, 9, 5);
        }

        private void assignG10_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG10, 9, 6);
        }

        private void assignA11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA11, 10, 0);
        }

        private void assignB11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB11, 10, 1);
        }

        private void assignC11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC11, 10, 2);
        }

        private void assignD11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD11, 10, 3);
        }

        private void assignE11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE11, 10, 4);
        }

        private void assignF11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF11, 10, 5);
        }

        private void assignG11_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG11, 10, 6);
        }

        private void assignA12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA12, 11, 0);
        }

        private void assignB12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB12, 11, 1);
        }

        private void assignC12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC12, 11, 2);
        }

        private void assignD12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD12, 11, 3);
        }

        private void assignE12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE12, 11, 4);
        }

        private void assignF12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF12, 11, 5);
        }

        private void assignG12_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG12, 11, 6);
        }

        private void assignA13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA13, 12, 0);
        }

        private void assignB13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB13, 12, 1);
        }

        private void assignC13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC13, 12, 2);
        }

        private void assignD13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD13, 12, 3);
        }

        private void assignE13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE13, 12, 4);
        }

        private void assignF13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF13, 12, 5);
        }

        private void assignG13_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG13, 12, 6);
        }

        private void assignA14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA14, 13, 0);
        }

        private void assignB14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB14, 13, 1);
        }

        private void assignC14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC14, 13, 2);
        }

        private void assignD14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD14, 13, 3);
        }

        private void assignE14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE14, 13, 4);
        }

        private void assignF14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF14, 13, 5);
        }

        private void assignG14_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG14, 13, 6);
        }

        private void assignA15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA15, 14, 0);
        }

        private void assignB15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB15, 14, 1);
        }

        private void assignC15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC15, 14, 2);
        }

        private void assignD15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD15, 14, 3);
        }

        private void assignE15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE15, 14, 4);
        }

        private void assignF15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF15, 14, 5);
        }

        private void assignG15_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG15, 14, 6);
        }

        private void assignA16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA16, 15, 0);
        }

        private void assignB16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB16, 15, 1);
        }

        private void assignC16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC16, 15, 2);
        }

        private void assignD16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD16, 15, 3);
        }

        private void assignE16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE16, 15, 4);
        }

        private void assignF16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF16, 15, 5);
        }

        private void assignG16_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG16, 15, 6);
        }

        private void assignA17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA17, 16, 0);
        }

        private void assignB17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB17, 16, 1);
        }

        private void assignC17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC17, 16, 2);
        }

        private void assignD17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD17, 16, 3);
        }

        private void assignE17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE17, 16, 4);
        }

        private void assignF17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF17, 16, 5);
        }

        private void assignG17_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG17, 16, 6);
        }

        private void assignA18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA18, 17, 0);
        }

        private void assignB18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB18, 17, 1);
        }

        private void assignC18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC18, 17, 2);
        }

        private void assignD18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD18, 17, 3);
        }

        private void assignE18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE18, 17, 4);
        }

        private void assignF18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF18, 17, 5);
        }

        private void assignG18_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG18, 17, 6);
        }

        private void assignA19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA19, 18, 0);
        }

        private void assignB19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB19, 18, 1);
        }

        private void assignC19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC19, 18, 2);
        }

        private void assignD19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD19, 18, 3);
        }

        private void assignE19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE19, 18, 4);
        }

        private void assignF19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF19, 18, 5);
        }

        private void assignG19_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG19, 18, 6);
        }

        private void assignA20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA20, 19, 0);
        }

        private void assignB20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB20, 19, 1);
        }

        private void assignC20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC20, 19, 2);
        }

        private void assignD20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD20, 19, 3);
        }

        private void assignE20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE20, 19, 4);
        }

        private void assignF20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF20, 19, 5);
        }

        private void assignG20_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG20, 19, 6);
        }

        private void assignA21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA21, 20, 0);
        }

        private void assignB21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB21, 20, 1);
        }

        private void assignC21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC21, 20, 2);
        }

        private void assignD21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD21, 20, 3);
        }

        private void assignE21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE21, 20, 4);
        }

        private void assignF21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF21, 20, 5);
        }

        private void assignG21_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG21, 20, 6);
        }

        private void assignA22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA22, 21, 0);
        }

        private void assignB22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB22, 21, 1);
        }

        private void assignC22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC22, 21, 2);
        }

        private void assignD22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD22, 21, 3);
        }

        private void assignE22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE22, 21, 4);
        }

        private void assignF22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF22, 21, 5);
        }

        private void assignG22_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG22, 21, 6);
        }

        private void assignA23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchA23, 22, 0);
        }

        private void assignB23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchB23, 22, 1);
        }

        private void assignC23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchC23, 22, 2);
        }

        private void assignD23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchD23, 22, 3);
        }

        private void assignE23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchE23, 22, 4);
        }

        private void assignF23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchF23, 22, 5);
        }

        private void assignG23_Click(object sender, EventArgs e)
        {
            var assignObject = sender as Button;
            assignMatch(assignObject, matchG23, 22, 6);
        }

        #endregion

        private void btnDone_Click(object sender, EventArgs e) //output results to excel
        {
            DialogResult done = MessageBox.Show("Completed the schedule?", "Export", MessageBoxButtons.YesNo);
            if (done == DialogResult.Yes)
            {
                Tuple<int, int> teams = getHomeAway("3 vs 4"); //init tuple
                string path = @".\cricketSchedule.csv";
                string teamHome = "";
                string teamAway = "";
                var output = new StringBuilder();

                for (int i = 0; i < divCount; i++) //loop through each division
                {
                    var line = String.Format("Division {0}\n", i+1);
                    output.Append(line);
                    //print weeks
                    line = String.Format("Week 1,Week 2,Week 3,Week 4,Week 5,Week 6,Week 7,Week 8,Week 9,Week 10,Week 11,Week 12,Week 13,Week 14,Week 15,Week 16,Week 17,Week 18,Week 19,Week 20,Week 21,Week 22,Week 23\n");
                    output.Append(line);
                    //Print each assigned match
                    for (int x = 0; x < teamCount[i]/2; x++) //for each week
                    {                  
                        for (int y = 0; y < 23; y++) //for each match in week
                        {
                            if (matchesAssigned[i, y, x] != null)
                            {
                                teams = getHomeAway(matchesAssigned[i, y, x]);
                                teamHome = name[i, teams.Item1];
                                teamAway = name[i, teams.Item2];

                                line = String.Format("{0} vs {1}", teamHome, teamAway);
                                output.Append(line);
                            }
                            line = String.Format(",");
                            output.Append(line);
                        }

                        line = String.Format("\n");
                        output.Append(line);
                    }

                    line = string.Format("\n");
                    output.Append(line);
                }

                File.WriteAllText(path, output.ToString()); //write file to .csv
                Process.Start(path); //open file
            }
        }
    }
}
