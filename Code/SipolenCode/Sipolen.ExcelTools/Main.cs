using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDIFramework.Controls;
using RDIFramework.Utilities;
using RDIFramework.WinForm.Utilities;
using Sipolen.Code;
using Sipolen.ExcelTools.DTO;
using Sipolen.ExcelTools.Model;

namespace Sipolen.ExcelTools
{
    public partial class Main : BaseForm
    {
        /// <summary>
        /// 推荐节点码
        /// </summary>
        public string BrowseNodeNum { get; set; }

        /// <summary>
        /// 业务逻辑数据库连接字符串
        /// </summary>
        public string BusinessDbConnection = SystemInfo.BusinessDbConnection;

        CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 国家列表
        /// </summary>
        private List<Country> countryList = new List<Country>();

        /// <summary>
        /// 国家模板列表
        /// </summary>
        private List<CountryTemplate> templateList = new List<CountryTemplate>();

        /// <summary>
        /// 原表Excel路径
        /// </summary>
        private string sourceExcelPath = "";

        /// <summary>
        /// 目标模板Excel路径
        /// </summary>
        private string targetExcelPath = "";

        public Main()
        {
            InitializeComponent();

            InitData();//初始化数据
        }

        #region 数据初始化
        /// <summary>
        /// 初始化基础数据
        /// </summary>
        private void InitData()
        {
            #region 国家数据初始化

            //欧洲
            countryList.Add(new Country { CountryName = "英国", CountryCode = "Britain", ContinentCode = "Europe", CurrencyUnit = "GBP", CurrencyUnitName = "英镑", CurrencyExchangeRate = "8.56" });
            countryList.Add(new Country { CountryName = "德国", CountryCode = "Germany", ContinentCode = "Europe", CurrencyUnit = "EUR", CurrencyUnitName = "欧元", CurrencyExchangeRate = "7.26" });
            countryList.Add(new Country { CountryName = "法国", CountryCode = "France", ContinentCode = "Europe", CurrencyUnit = "EUR", CurrencyUnitName = "欧元", CurrencyExchangeRate = "7.26" });
            countryList.Add(new Country { CountryName = "意大利", CountryCode = "Italy", ContinentCode = "Europe", CurrencyUnit = "EUR", CurrencyUnitName = "欧元", CurrencyExchangeRate = "7.26" });
            countryList.Add(new Country { CountryName = "西班牙", CountryCode = "Spain", ContinentCode = "Europe", CurrencyUnit = "EUR", CurrencyUnitName = "欧元", CurrencyExchangeRate = "7.26" });

            //美洲
            countryList.Add(new Country { CountryName = "美国", CountryCode = "America", ContinentCode = "America", CurrencyUnit = "USD", CurrencyUnitName = "美元", CurrencyExchangeRate = "6.9" });
            countryList.Add(new Country { CountryName = "加拿大", CountryCode = "Canada", ContinentCode = "America", CurrencyUnit = "CAD", CurrencyUnitName = "加元", CurrencyExchangeRate = "5.1" });
            countryList.Add(new Country { CountryName = "墨西哥", CountryCode = "Mexico", ContinentCode = "America", CurrencyUnit = "USD", CurrencyUnitName = "美元", CurrencyExchangeRate = "6.9" });
            #endregion

            #region 国家模板数据初始化

            #region 欧洲站国家
            #region 英国
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "宠物用品", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑和配件", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "行李箱包", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "家居", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "家居装修", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "汽车用品", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "消费电子", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            templateList.Add(new CountryTemplate { TemplateName = "照明", TemplateCode = "", CountryCode = "Britain", TemplateSheetName = "模板" });
            #endregion

            #region 德国
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "宠物用品", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "灯表", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "计算机", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "家居厨房", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "家居建材", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "汽车", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            templateList.Add(new CountryTemplate { TemplateName = "消费电子", TemplateCode = "", CountryCode = "Germany", TemplateSheetName = "Vorlage" });
            #endregion

            #region 法国
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "宠物用品", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "灯表", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑配件", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电子科技", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居建材", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具", TemplateCode = "", CountryCode = "France", TemplateSheetName = "Template" });
            #endregion

            #region 意大利
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "灯表", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑配件", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居材料", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具和游戏", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "消费电子", TemplateCode = "", CountryCode = "Italy", TemplateSheetName = "Template" });
            #endregion

            #region 西班牙
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "灯表", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "户外", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居建材", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具和游戏", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "消费电子", TemplateCode = "", CountryCode = "Spain", TemplateSheetName = "Template" });
            #endregion
            #endregion

            #region 美洲站国家

            #region 美国
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "宠物用品", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "灯表", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "工具和家居装修", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居和园艺", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "手机及配件", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具和游戏", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "相机和摄影", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "消费类电子产品", TemplateCode = "", CountryCode = "America", TemplateSheetName = "Template" });
            #endregion

            #region 加拿大
            templateList.Add(new CountryTemplate { TemplateName = "办公用品", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "宠物用品", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "电脑", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "户外运动", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "家居建材", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "母婴用品", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "玩具和游戏", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            templateList.Add(new CountryTemplate { TemplateName = "箱包", TemplateCode = "", CountryCode = "Canada", TemplateSheetName = "Template" });
            #endregion

            #region 墨西哥
            templateList.Add(new CountryTemplate { TemplateName = "家居建材", TemplateCode = "", CountryCode = "Mexico", TemplateSheetName = "Formatos" });
            templateList.Add(new CountryTemplate { TemplateName = "墨西哥灯表", TemplateCode = "", CountryCode = "Mexico", TemplateSheetName = "Formatos" });
            templateList.Add(new CountryTemplate { TemplateName = "墨西哥家居表", TemplateCode = "", CountryCode = "Mexico", TemplateSheetName = "Formatos" });
            templateList.Add(new CountryTemplate { TemplateName = "消费电子", TemplateCode = "", CountryCode = "Mexico", TemplateSheetName = "Formatos" });
            #endregion

            #endregion

            #endregion

            #region 初始化绑定国家及模板数据

            //绑定国家列表  --默认初始化选中欧洲站
            BindCountryList("Europe");

            #endregion


            #region 关键词模式类型

            cmbKeyWordStyle.Items.Add("AliexpressKey");
            cmbKeyWordStyle.Items.Add("KeyWordTool");
            cmbKeyWordStyle.SelectedIndex = 0;

            #endregion

        }
        #endregion

        #region 国家与国家模板列表绑定

        /// <summary>
        /// 绑定国家列表
        /// </summary>
        /// <param name="continentCode">洲际编码</param>
        private void BindCountryList(string continentCode)
        {
            var countryListData = countryList.Where(t => t.ContinentCode == continentCode).ToList();
            cbCountry.DataSource = countryListData;
            cbCountry.ValueMember = "CountryCode";//赋值Value
            cbCountry.DisplayMember = "CountryName";//赋值显示名称 

            ChangeCountry();
        }

        /// <summary>
        /// 切换国家列表
        /// </summary>
        private void ChangeCountry()
        {
            var selectCountry = cbCountry.SelectedItem as Country;
            BindCountryTemplateList(selectCountry.CountryCode, selectCountry.CountryName);

            //绑定货币、汇率信息
            lbCurrencyUnit.Text = $"货币单位：{selectCountry.CurrencyUnitName}({selectCountry.CurrencyUnit})";
            lbCurrencyExchangeRate.Text = $"货币汇率：{selectCountry.CurrencyExchangeRate}";
        }

        /// <summary>
        /// 绑定国家模板列表
        /// </summary>
        /// <param name="countryCode">国家编码</param>
        private void BindCountryTemplateList(string countryCode, string coutryName)
        {
            var templateListData = templateList.Where(t => t.CountryCode == countryCode).ToList();
            cbCountryTemplate.DataSource = templateListData;
            cbCountryTemplate.ValueMember = "TemplateName";//赋值Value
            cbCountryTemplate.DisplayMember = "TemplateName";//赋值显示名称 

            BindProductType(coutryName, templateListData[0].TemplateName);
        }

        private void BindProductType(string coutryName, string templateName)
        {
            string searchSql = $"select VaildValue,VaildValueDesc from S_VAILDVALUE where country='{coutryName}' and templete='{templateName}'";
            var dt = ExecSql(searchSql);
            cbProductType.DataSource = dt;
            cbProductType.ValueMember = "VaildValue";//赋值Value
            cbProductType.DisplayMember = "VaildValueDesc";//赋值显示名称 
        }

        #endregion

        #region 事件绑定

        /// <summary>
        /// 选择原始导出表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSourceExcel_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名
                string[] str = new string[] { ".xls", ".xlsx" };
                if (!((IList)str).Contains(extension))
                {
                    MessageBox.Show("仅能选择xls,xlsx类型的Excel导出表！");
                }
                else
                {
                    //获取用户选择的文件
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    lbSourceExcelPath.Text = "已选择原表信息：" + fileInfo.Name;
                    sourceExcelPath = fileDialog.FileName;//为源excel路径赋值
                }
            }
        }

        /// <summary>
        /// 设置工作目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWorkPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请设置工作目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                txtWorkPath.Text = foldPath;
            }
            //


        }

        /// <summary>
        /// 国家列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCountry();
        }

        /// <summary>
        /// 选择模板事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCountryTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectCountry = cbCountry.SelectedItem as Country;
            var selectTemplete = cbCountryTemplate.SelectedItem as CountryTemplate;

            BindProductType(selectCountry.CountryName, selectTemplete.TemplateName);
        }

        /// <summary>
        /// 欧洲站选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbEuropeSite_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEuropeSite.Checked)
                BindCountryList(rbEuropeSite.Tag.ToString());//绑定欧洲站国家
            else
                BindCountryList(rbAmericaSite.Tag.ToString());//绑定美洲站国家
        }

        /// <summary>
        /// 确定国际及模板 - 实质是复制模板到工作目录并重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSureConturyTemplate_Click(object sender, EventArgs e)
        {
            var selectedCountry = cbCountry.SelectedItem as Country;
            var selectedCountryTemplate = cbCountryTemplate.SelectedItem as CountryTemplate;
            var workPath = txtWorkPath.Text.Trim();

            //获取源Excel文件名
            var sourceExcelName = Path.GetFileNameWithoutExtension(sourceExcelPath);
            var sourceExcelNameFlag = sourceExcelName.Split('_')[1];

            //获得模板excel路径
            var extensionName = "xls";
            string templatePath = string.Format("Template/{0}/{1}.xls", selectedCountry.CountryName, selectedCountryTemplate.TemplateName);
            if (!File.Exists(templatePath))
            {
                templatePath = string.Format("Template/{0}/{1}.xlsm", selectedCountry.CountryName, selectedCountryTemplate.TemplateName);
                extensionName = "xlsm";
            }
            //复制目标文件名
            var targetFileName = string.Format("{0}_{1}_{2}_{3}.{4}", selectedCountry.CountryName, selectedCountryTemplate.TemplateName, sourceExcelNameFlag, DateTime.Now.ToString("yyyyMMdd-HHmm"), extensionName);
            //复制目标文件路径
            var targetPath = Path.Combine(workPath, DateTime.Now.ToString("yyyy-MM-dd"), selectedCountry.CountryName, targetFileName);
            //复制目标目录路径，不存在则创建
            var targetDirectory = Path.Combine(workPath, DateTime.Now.ToString("yyyy-MM-dd"), selectedCountry.CountryName);
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            targetExcelPath = targetPath;
            //执行复制操作
            File.Copy(templatePath, targetPath);
        }

        /// <summary>
        /// 开始移表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBeginMove_Click(object sender, EventArgs e)
        {
            string sourcePath = sourceExcelPath;//原Excel表路径
            var currentCountryTemplate = cbCountryTemplate.SelectedItem as CountryTemplate;

            if (NullCheck())
            {
                MessageBox.Show("请检查必填项");
                return;
            }

            var sourceTb = ExcelHelper.RenderDataTableFromExcel(sourcePath, 0, 2);
            var inputDto = GetExcelInputDto();
            sourceTb = new SipolenExcelUtility().HanderSourceDt(sourceTb, inputDto);
            var targetTb = ExcelHelper.RenderDataTableFromExcel(targetExcelPath, currentCountryTemplate.TemplateSheetName, 2);
            var dt = SipolenExcelUtility.MoveDataTable(sourceTb, targetTb);

            SipolenExcelUtility.ExportExcelFromDt(dt, targetExcelPath, currentCountryTemplate.TemplateSheetName);
        }


        #region 选择推荐节点

        private string nodeFlag = string.Empty;

        private void browse_nodes1_MouseClick(object sender, MouseEventArgs e)
        {
            nodeFlag = "browse_nodes1";
            BrowseNodes formBrowseNodes = new BrowseNodes(cbCountry.SelectedItem as Country, cbCountryTemplate.SelectedItem as CountryTemplate);
            formBrowseNodes.Owner = this;
            formBrowseNodes.StartPosition = FormStartPosition.CenterScreen;
            formBrowseNodes.WindowState = FormWindowState.Maximized;
            formBrowseNodes.ShowDialog();
            browse_nodes1.Text = BrowseNodeNum;
        }

        private void browse_nodes2_MouseClick(object sender, MouseEventArgs e)
        {
            nodeFlag = "browse_nodes2";
            BrowseNodes formBrowseNodes = new BrowseNodes(cbCountry.SelectedItem as Country, cbCountryTemplate.SelectedItem as CountryTemplate);
            formBrowseNodes.Owner = this;
            formBrowseNodes.StartPosition = FormStartPosition.CenterScreen;
            formBrowseNodes.WindowState = FormWindowState.Maximized;
            formBrowseNodes.ShowDialog();
            browse_nodes2.Text = BrowseNodeNum;
        }

        #endregion

        #region 关键字

        #region 统计
        private void btnKeyWordStatistics_Click(object sender, EventArgs e)
        {
            //判断类型
            if (cmbKeyWordStyle.SelectedIndex == 0) //选择阿里通关键字模式
            {
                string keyword = txtKeyWords.Text;
                string[] keyArr = keyword.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                var keyWordList = new List<AliexpressKeyWord>();
                foreach (var key in keyArr)
                {
                    if (string.IsNullOrEmpty(key.Trim()))//如果为空则跳出
                        continue;
                    if (key.Trim().IndexOf('-') != -1)//如果找到'-'则跳出
                        continue;
                    string[] arr = key.Split('|');
                    keyWordList.Add(new AliexpressKeyWord() { KeyWord = arr[0].TrimStart().TrimEnd(), SeachCount = string.IsNullOrEmpty(arr[1].Trim()) ? "99999" : arr[1].Trim() });
                }
                //按搜索量排序
                keyWordList = keyWordList.OrderByDescending(t => t.SeachCount).ToList();

            }
        }

        #endregion

        #endregion

        #endregion

        #region private方法

        private bool NullCheck()
        {
            bool flag = false;
            if (string.IsNullOrEmpty(browse_nodes1.Text.Trim()) || string.IsNullOrEmpty(browse_nodes2.Text.Trim()))
            {
                flag = true;
            }
            return flag;
        }

        private TargetExcelInputDto GetExcelInputDto()
        {
            var selectCountry = cbCountry.SelectedItem as Country;

            var inputDto = new TargetExcelInputDto();
            inputDto.ExternalProductId = txtEANCountryCode.Text.Trim() + txtEANFactoryCode.Text.Trim() + txtEANProductCode.Text.Trim();
            inputDto.BrandName = txtBrandName.Text.Trim();
            inputDto.FeedProductType = cbProductType.SelectedValue.ToString();
            inputDto.CurrencyExchangeRate = selectCountry.CurrencyExchangeRate;
            inputDto.Currency = selectCountry.CurrencyUnit;
            inputDto.Quantity = txtQuantity.Text.Trim();
            inputDto.ConditionNote = $"Delivery Time {txtDeliveryTimeMin.Text.Trim()}-{txtDeliveryTimeMax.Text.Trim()} Days";
            inputDto.WebsiteShippingWeight = txtShippingWeight.Text.Trim();
            inputDto.RecommendedBrowseNodes1 = browse_nodes1.Text.Trim();
            inputDto.RecommendedBrowseNodes2 = browse_nodes2.Text.Trim();
            return inputDto;
        }


        private DataTable ExecSql(string sql)
        {
            DataTable dt = new DataTable();
            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    dt = dbProvider.Fill(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            return dt;
        }





        #endregion


    }
}
