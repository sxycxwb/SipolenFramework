using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Web.UI;

namespace RDIFramework.WebApp.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class WorkFlowChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objBitmap = new Bitmap(1000, 1000);
            var objGraphics = Graphics.FromImage(objBitmap);
            try
            {
                if (!this.IsPostBack)
                {
                    if (Request["workFlowId"] != null && Request["workFlowInsId"] != null)
                    {
                        string workflowId = Request["workFlowId"].ToString(CultureInfo.InvariantCulture);
                        string workflowInsId = Request["workFlowInsId"].ToString(CultureInfo.InvariantCulture);
                        InitTaskMapData(workflowId, workflowInsId, objGraphics);
                        InitLinkMapData(workflowId, workflowInsId, objGraphics);
                        objBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DrawTaskBitmap(Graphics gc, string taskCaption, string operType, int x, int y, bool isPass, bool isCurrent, string taskDes)
        {
            Bitmap taskBitmap = null;
            var pt = new Point(0, 0);
            Brush bcolor;
            pt.X = x;
            pt.Y = y;
            var font = new Font("Arial", 8);
            var alignVertically = new StringFormat { LineAlignment = StringAlignment.Center };
            var noPassflag = isPass ? ".ico" : "_灰.jpg";
            switch (operType)
            {
                case "1"://启动节点
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/启动节点" + noPassflag));
                    break;
                case "2"://终止节点 
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/终止节点" + noPassflag));
                    break;
                case "3"://交互节点 
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/交互节点" + noPassflag));
                    break;
                case "4"://控制节点 
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/控制节点" + noPassflag));
                    break;
                case "5"://查看节点 
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/查看节点" + noPassflag));
                    break;
                case "6"://子流程节点 
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/子流程节点" + noPassflag));
                    break;
                default:
                    taskBitmap = new Bitmap(Server.MapPath(@"../Content/images/WFImage/note.ico"));
                    break;
            }

            if (isCurrent)
            {
                bcolor = Brushes.Red;
                taskCaption = "当前节点:" + taskCaption;
            }
            else
            {
                bcolor = Brushes.Black;//当前节点
            }
            var bounds = new Rectangle(pt, taskBitmap.Size);
            gc.DrawImage(taskBitmap, bounds.Left, bounds.Top);

            var sizeF = gc.MeasureString(taskCaption, font);
            int captionx = bounds.Left - ((int)sizeF.Width) / 2 + bounds.Width / 2;
            gc.DrawString(taskCaption, font, bcolor, captionx, bounds.Top + bounds.Height + 20, alignVertically);
            bcolor = Brushes.RoyalBlue;
            gc.DrawString(taskDes, font, bcolor, captionx, bounds.Top + bounds.Height + 35, alignVertically);
        }

        private void DrawLinkBitMap(Graphics gs, string linkBreakX, string linkBreakY, int starttaskX, int starttaskY, int endtaskX, int endtaskY, Color clr, string linkDes, float lineWidth = 1)
        {
            var breakPointX = new ArrayList();
            var breakPointY = new ArrayList();

            string[] BreakX;
            string[] BreakY;
            breakPointX.Add(starttaskX + 20);
            breakPointY.Add(starttaskY + 10);

            if (linkBreakX.ToString(CultureInfo.InvariantCulture) != "")
            {
                if (linkBreakX.IndexOf(",") != -1)
                {
                    BreakX = linkBreakX.Split(",".ToCharArray());
                    BreakY = linkBreakY.Split(",".ToCharArray());
                    for (var i = 0; i < BreakX.Length; i++)
                    {
                        breakPointX.Add(BreakX[i]);
                        breakPointY.Add(BreakY[i]);
                    }
                }
                else
                {
                    breakPointX.Add(linkBreakX);
                    breakPointY.Add(linkBreakY);
                }
            }

            breakPointX.Add(endtaskX);
            breakPointY.Add(endtaskY);

            if (breakPointX.Count < 2)
            {
                for (var i = 0; i < breakPointX.Count; i++)
                {
                    if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                        }
                        else
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            breakPointY[i] = Convert.ToInt16(breakPointY[i]) + 10;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 10;
                            breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 10;
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                        }
                        else
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;
                            breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                            breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 20;
                            //breakPointY[i+1]=Convert.ToInt16(breakPointY[i+1])+10;
                        }
                    }
                }
            }
            else
            {
                for (var i = 0; i < breakPointX.Count; i++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            }
                            else
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]) ? Convert.ToInt16(breakPointX[i]) : Convert.ToInt16(breakPointX[i]) + 20;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;
                                    breakPointY[i] = Convert.ToInt16(breakPointY[i]);//20
                                }
                                else
                                {
                                    breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                                }
                            }
                        }
                    }
                    if (i == breakPointX.Count - 2)
                    {
                        if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                                else
                                {
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                                }
                                else
                                {
                                    breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);//20
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                            }
                        }
                    }
                }
            }

            var pen = new Pen(clr, lineWidth);

            for (var i = 0; i < breakPointX.Count - 2; i++)
            {
                var bp = new Point(Convert.ToInt16(breakPointX[i]), Convert.ToInt16(breakPointY[i]));
                var bp2 = new Point(Convert.ToInt16(breakPointX[i + 1]), Convert.ToInt16(breakPointY[i + 1]));
                gs.DrawLine(pen, bp, bp2);
            }

            //画最后一条带箭头的  
            if (breakPointX.Count >= 2)
            {
                int ittX = Convert.ToInt16(breakPointX[breakPointX.Count - 2]);
                int ittY = Convert.ToInt16(breakPointY[breakPointX.Count - 2]);
                int itt2X = Convert.ToInt16(breakPointX[breakPointX.Count - 1]);
                int itt2Y = Convert.ToInt16(breakPointY[breakPointX.Count - 1]);
                var tt = new Point(ittX, ittY);
                var tt2 = new Point(itt2X, itt2Y);
                var arrow = new AdjustableArrowCap(3, 3);
                pen.CustomEndCap = arrow;
                gs.DrawLine(pen, tt, tt2);
                //			}

                //画注释	
                if (string.IsNullOrEmpty(linkDes))
                {
                    return;
                }

                var font = new Font("Arial", 8);
                var alignVertically = new StringFormat { LineAlignment = StringAlignment.Center };
                var sizeF = gs.MeasureString(linkDes, font);
                var x = (Convert.ToInt16(breakPointX[0]) + Convert.ToInt16(breakPointX[1]) - (int)sizeF.Width) / 2;
                var y = (Convert.ToInt16(breakPointY[0]) + Convert.ToInt16(breakPointY[1])) / 2;
                gs.DrawString(linkDes, font, Brushes.Blue, x, y, alignVertically);
            }
        }

        private void InitTaskMapData(string workflowId, string workflowInsId, Graphics gc)
        {
            var dtTask = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTasks(this.UserInfo, workflowId);
            var dtCurr = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowInstance(this.UserInfo, workflowInsId);
            var currTaskId = BusinessLogic.ConvertToString(dtCurr.Rows[0][WorkFlowInstanceTable.FieldNowTaskId]) ?? "";//流程实例当前节点
            gc.Clear(Color.FromArgb(255, 253, 244));   // 改变背景颜色
            string lch = "流程号：";
            lch += dtCurr.Rows[0]["WORKFLOWNO"].ToString();//流程号
            lch += "   主题：" + dtCurr.Rows[0]["FLOWINSCAPTION"].ToString();//流程主题
            DrawTaskBitmap(gc, lch, "99", 200, 0, false, false, "");
            foreach (DataRow dr in dtTask.Rows)
            {
                var taskId = BusinessLogic.ConvertToString(dr[WorkTaskTable.FieldWorkTaskId]) ?? "";
                var taskCaption = BusinessLogic.ConvertToString(dr[WorkTaskTable.FieldTaskCaption]) ?? "";
                int taskX = Convert.ToInt16(dr[WorkTaskTable.FieldIXPosition]);
                int taskY = Convert.ToInt16(dr[WorkTaskTable.FieldIYPosition]) - 10;
                var operType = BusinessLogic.ConvertToString(dr[WorkTaskTable.FieldTaskTypeId]) ?? "";
                bool isPass = RDIFrameworkService.Instance.WorkFlowHelperService.IsPassJudge(this.UserInfo, workflowId, workflowInsId, taskId, WorkConst.Command_And);//是否通过
                var isCurrent = currTaskId == taskId;//是否是当前节点
                var taskDes = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskDoneWhoMsg(this.UserInfo, taskId, workflowInsId);
                DrawTaskBitmap(gc, taskCaption, operType, taskX, taskY, isPass, isCurrent, taskDes);
            }
        }

        private bool IsFromStartTask(string workflowId, string workflowInsId, string startTaskId, string endTaskId)
        {
            var dt1 = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskInstance(this.UserInfo, workflowId, workflowInsId, endTaskId);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                var ptaskInsId = dt1.Rows[0][WorkTaskInstanceTable.FieldPreviousTaskId].ToString();//根据后端节点模板找到前一任务实例
                var dt2 = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskInsTable(this.UserInfo, ptaskInsId);//根据前一任务实例找到任务模板
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    var staskid = dt2.Rows[0][WorkTaskInstanceTable.FieldWorkTaskId].ToString();
                    if (staskid == startTaskId)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        private void InitLinkMapData(string workflowId, string workflowInsId, Graphics gc)
        {
            var linktable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkLinks(this.UserInfo, workflowId);

            foreach (DataRow dr in linktable.Rows)
            {
                string linkBreakX = BusinessLogic.ConvertToString(dr[WorkLinkTable.FieldBreakX]) ?? "";
                string linkBreakY = BusinessLogic.ConvertToString(dr[WorkLinkTable.FieldBreakY]) ?? "";
                var startTaskId = BusinessLogic.ConvertToString(dr[WorkLinkTable.FieldStartTaskId]) ?? "";
                var endTaskId = BusinessLogic.ConvertToString(dr[WorkLinkTable.FieldEndTaskId]) ?? "";
                int starttaskX = Convert.ToInt16(dr["STARTTASKX"]);
                int starttaskY = Convert.ToInt16(dr["STARTTASKY"]);
                int endtaskX = Convert.ToInt16(dr["ENDTASKX"]);
                int endtaskY = Convert.ToInt16(dr["ENDTASKY"]);
                var linkDes = BusinessLogic.ConvertToString(dr[WorkLinkTable.FieldDescription]) ?? "";
                bool started = RDIFrameworkService.Instance.WorkFlowHelperService.IsPassJudge(this.UserInfo, workflowId, workflowInsId, startTaskId, WorkConst.Command_And);
                bool ended = RDIFrameworkService.Instance.WorkFlowHelperService.IsPassJudge(this.UserInfo, workflowId, workflowInsId, endTaskId, WorkConst.Command_And);
                bool fromStart = IsFromStartTask(workflowId, workflowInsId, startTaskId, endTaskId);
                bool isPass = (started && ended && fromStart);//是否通过
                var linkColor = isPass ? Color.Red : Color.Green;
                float linkeWidth = isPass ? 2 : 1;
                DrawLinkBitMap(gc, linkBreakX, linkBreakY, starttaskX, starttaskY, endtaskX, endtaskY, linkColor, linkDes, linkeWidth);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.close();", true);
        }
    }
}