/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-6 11:15:59
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    public partial class UcDataNavigator : UserControl
    {
        public delegate void PostionChangedEventHandler(object sender, EventArgs e);
        
        public UcDataNavigator()
        {
            InitializeComponent();
        }

        public event PostionChangedEventHandler PositionChanged;
        private int currentIndex = 0;//当前的位置

        private List<string> idList = new List<string>();
        public List<string> IDList
        {
            get
            {
                return idList;
            }
            set
            {
                idList = value;
            }
        }

        /// <summary>
        /// 获取或设置索引值
        /// </summary>
        public int CurrentIndex
        {
            get { return currentIndex; }
            set 
            {
                currentIndex = value;
                ChangePosition(value);
            }
        }
        

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ChangePosition(0);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ChangePosition(currentIndex - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangePosition(currentIndex + 1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ChangePosition(IDList.Count - 1);
        }

        private void EnableControl(bool enable)
        {
            this.btnFirst.Enabled = enable;
            this.btnLast.Enabled = enable;
            this.btnNext.Enabled = enable;
            this.btnPrevious.Enabled = enable;
        }

        private void ChangePosition(int newPos)
        {
            int count = IDList.Count;
            if (count == 0)
            {
                EnableControl(false);
                this.txtNavInfo.Clear();
            }
            else
            {
                EnableControl(true);

                newPos = (newPos < 0) ? 0 : newPos;
                currentIndex = ((count - 1) > newPos) ? newPos : (count - 1);
                this.btnFirst.Enabled = currentIndex > 0;
                this.btnPrevious.Enabled = (currentIndex > 0);
                this.btnNext.Enabled = currentIndex < (count - 1);
                this.btnLast.Enabled = currentIndex < (count - 1);
                this.txtNavInfo.Text = string.Format("{0}/{1}", currentIndex + 1, count);

                if (PositionChanged != null)
                {
                    PositionChanged(this, new EventArgs());
                }
            }
        }
       
    }
}
