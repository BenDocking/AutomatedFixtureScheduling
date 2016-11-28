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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\\Program Files (x86)\\swipl");
            Environment.SetEnvironmentVariable("Path", @"C:\\PROGRAM FILES (x86)\\swipl");
            Environment.SetEnvironmentVariable("Path", @"C:\\PROGRAM FILES (x86)\\swipl\bin");

            String[] param = { "-q", "-f", @"calculate.pl" };
            PlEngine.Initialize(param);

            //CODE

            //PlQuery.PlCall("assert(team(brz))");
            
            //DONE

            using (var q = new PlQuery("playing(fra,R,G), atomic_list_concat(['France plays in round ', R, ' game ', G], L)"))
            {
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    richTextBox1.AppendText(v["L"].ToString());
                    richTextBox1.AppendText("\n");
                }

                /*richTextBox1.AppendText("\n\nall children from uwe:");
                q.Variables["P"].Unify("uwe");
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    richTextBox1.AppendText("\n");
                    richTextBox1.AppendText(v["C"].ToString());
                }*/
            }

            using (var q = new PlQuery("plays(ger,fra,R,G), atomic_list_concat(['Germany could play France in round ', R, ' game ', G], L)"))
            {
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    richTextBox1.AppendText(v["L"].ToString());
                    richTextBox1.AppendText("\n");
                }
            }

            PlEngine.PlCleanup();
        }
    }
}
