/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-8 16:04:34
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// UcImageList
    /// 类似QQ头像的图标浏览器
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(UcImageList), "Images.UcImageList.png")]
    [Description("类似QQ头像的图标浏览器")]
    public partial class UcImageList : UserControl
    {        
        /// <summary>
        /// 增加按钮的单击事件
        /// </summary>
        [Category("用户控件属性"), Description("鼠标双击图片时发生")]
        public event EventHandler MouseDoubleClick;

        public UcImageList()
        {
            InitializeComponent();
        }

        public int w = 10, h = 10;
        public int ImgWidth = 40;
        public int ImgHeight = 55;
        private Bitmap map = new Bitmap(10, 10);
        public int OutBorderWidth = 2;
        public int CurrentImg = 0;
        public Color OutBorderColor = Color.Black;
        public Color SideBorderColor = Color.Black;
        public bool SideStyle = false;
        public bool ShowText = true;
        public ArrayList data = new ArrayList();//PictureItems
        public int Count = 0;
        public PictureItem CurrentPictureItem = new PictureItem();//single PictureItem

        public int MidWidth = 5;

        public void Init()
		{
			pictureList.Width =this.Width -vScrollBar.Width ;
			w=pictureList.Width ;
			int rowcount=w/(this.ImgWidth+this.MidWidth);
			int rows=(data.Count /rowcount);

            if ((rows * rowcount) < this.data.Count)
            {
                rows++;
            }

			h=  rows *(this.ImgHeight+this.MidWidth)+20;
			h=  h<this.Height?h=this.Height :h;
			pictureList.Height =h;
			if(!map.Equals (null))
			{
				map=null;
				map=new Bitmap (w,h);
			}
			int maxval=this.Height >h?0:((h-this.Height)/5)+18;
			vScrollBar.Maximum =maxval;
		}

        /// <summary>
        /// 增加图片到图片管理控件
        /// </summary>
        /// <param name="PictureItem"></param>
        /// <returns></returns>
		public bool AddPictureItem(PictureItem PictureItem)
		{
			data.Add (PictureItem);
			this.Count ++;
			return true;
		}

		public bool AddPictureItem(Bitmap map,string text)
		{
			if(text.Trim ()=="")return false;
			PictureItem it=new PictureItem {Pic = map, Text = text};
		    data.Add (it);
			this.Count ++;
			return true;
		}

        /// <summary>
        /// 移去当前选择的图片、图标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public bool RemovePictureItem(int index)
		{
			try
			{
				data.RemoveAt (index);
				this.Count--;
			}
			catch
            {
                return false;
            }

			return true;
		}

        /// <summary>
        /// 移去所有图片、图标
        /// </summary>
        /// <returns></returns>
        public bool RemoveAllPictureItem()
        {
            try
            {
                data.Clear();
                this.Count = 0;
            }
            catch
            {
                return false;
            }

            return true;
        }

		private void DrawBack()
		{
			Graphics g=Graphics.FromImage (this.map );
			g.DrawRectangle (new Pen (this.OutBorderColor ,this.OutBorderWidth ),1,1,w-2,pictureList.Height-2);
			g.Dispose ();
		}

		public void Draw()
		{
			this.Init ();
			this.DrawBack ();
			int rowcount=w/(this.ImgWidth+this.MidWidth);
			int curx=10;
			int cury=10;
			if(data.Count <1)return;
			Graphics g=Graphics.FromImage (map);
			PictureItem tPictureItem=new PictureItem ();
			RectangleF rect=new RectangleF (0,0,10,10);

			for(int i=0;i<data.Count ;i++)
			{
				tPictureItem=(PictureItem)data[i];
				try
				{
                    if (tPictureItem.Pic.Equals(null))
                    {
                        continue;
                    }

                    if (tPictureItem.Text.Trim() == "")
                    {
                        tPictureItem.Text = "None";
                    }

                    if (i == this.CurrentImg)
                    {
                        g.FillRectangle(new Pen(Color.FromArgb(166, 201, 232)).Brush, curx, cury, this.ImgWidth, this.ImgHeight);
                    }

					g.DrawImage (tPictureItem.Pic ,curx+12,cury+12,this.ImgWidth-24 ,this.ImgHeight-14-24);
					Pen pen=new Pen (this.SideBorderColor ,1);

                    if (i == this.CurrentImg)
                    {
                        pen.DashStyle = DashStyle.DashDotDot;
                    }

					g.DrawRectangle (pen,curx,cury,this.ImgWidth,this.ImgHeight);
					pen.Dispose ();
					rect=new RectangleF (curx+12,cury+(this.ImgHeight-14),this.ImgWidth-24 ,12);

                    if (ShowText)
                    {
                        g.FillRectangle(new Pen(Color.FromArgb(242, 242, 242)).Brush, rect);
                    }

                    if (ShowText)
                    {
                        g.DrawString(tPictureItem.Text, new Font("Arial", 8), new Pen(Color.Black).Brush, rect);
                    }
				}
				catch
                {
                    continue;
                }

				curx+=this.ImgWidth +this.MidWidth;

				if(((i+1)%rowcount)==0)
				{
					curx=10;
					cury+=this.ImgHeight+this.MidWidth;
				}
			}
            
            this.Count =data.Count ;
			g.Dispose ();
			pictureList.Image =this.map ;
		}

		public PictureItem GetPictureItem(int index)
		{
			PictureItem PictureItem=new PictureItem ();
			if(index>this.data.Count || data.Count <1 )return PictureItem;
			PictureItem=(PictureItem)data[index];
			return PictureItem;
		}

		public PictureItem GetCurrentPictureItem()
		{
			PictureItem PictureItem=new PictureItem ();
			if(data.Count <1)return PictureItem;
			PictureItem=(PictureItem)data[this.CurrentImg];
			return PictureItem;
		}

        private void UcImageList_Resize(object sender, System.EventArgs e)
		{
			Draw();
		}

        private void UcImageList_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.Draw ();
		}

        private void UcImageList_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
		{
		
		}

        private void UcImageList_Load(object sender, System.EventArgs e)
		{
			this.Draw ();
		}

		private void vScrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			pictureList.Top =-(vScrollBar.Value*5);           
		}

		private void pictureList_Click(object sender, System.EventArgs e)
		{
			
		}

		private void pictureList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowcount=w/(this.ImgWidth+this.MidWidth);
			long dwCols=e.Y;//(vScrollBar.Value*5)+e.Y;
			int  Rows  =e.X;
			int  cuCols=(int)(dwCols/(long)(this.ImgHeight+this.MidWidth));
			int  cuRows=Rows/(this.ImgWidth+this.MidWidth);
			if(cuCols<=0)
				this.CurrentImg =cuRows;
			else
				this.CurrentImg =((cuCols)*rowcount)+cuRows;
			if(this.CurrentImg >this.data .Count-1)CurrentImg=this.data .Count-1 ;
			this.Draw ();
			this.Count =data.Count ;
		}

        private void pictureList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
            {
                MouseDoubleClick(sender,null);
            }
        }
	};

    public struct PictureItem
    {
        public Bitmap Pic;
        public string Text;
        public string Path;
        public string strMsg1;
        public string strMsg2;
        public object tag;
    }
}
