using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS;

namespace AutomaticSortingSystem
{
    public partial class usSignal : UserControl
    {
        public SignalType Signal { get; set; }

        public usSignal()
        {
            InitializeComponent();
        }

        private void usSignal_Load(object sender, EventArgs e)
        {
            txPrefix.Text = Signal.Prefix;
            txContent.Text = Signal.Content;
            txSufix.Text = Signal.Sufix;
        }

        private void txPrefix_TextChanged(object sender, EventArgs e)
        {
            Signal.Prefix = txPrefix.Text;
        }

        private void txContent_TextChanged(object sender, EventArgs e)
        {
            Signal.Content = txContent.Text;
        }

        private void txSufix_TextChanged(object sender, EventArgs e)
        {
            Signal.Sufix = txSufix.Text;
        }
    }
}
