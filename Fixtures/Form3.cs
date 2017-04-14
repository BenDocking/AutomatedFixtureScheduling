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
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        bool loaded = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        public bool getLoad()
        {
            return loaded;
        }
    }
}
