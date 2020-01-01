using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage.CommonControls
{
    public partial class ConfirmAbortButtons : UserControl
    {
        public delegate void ConfirmBtnClickEventHander(object sender, EventArgs e);
        public delegate void AbortBtnClickEventHander(object sender, EventArgs e);

        public event ConfirmBtnClickEventHander ConfirmBtnClick;
        public event AbortBtnClickEventHander AbortBtnClick;

        public ConfirmAbortButtons()
        {
            InitializeComponent();
        }

        private void SetResult(object sender, EventArgs e)
        {
            if (sender == ConfirmButton)
            {
                ConfirmBtnClick?.Invoke(this, e);
            }
            if(sender== AbortButton)
            {
                AbortBtnClick?.Invoke(this, e);
            }
        }
    }
}
