using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmOrderProduct : Form
    {


        IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();

        public int OrderId { get; set; }
        public frmOrderProduct()
        {
            InitializeComponent();
        }
    }
}
