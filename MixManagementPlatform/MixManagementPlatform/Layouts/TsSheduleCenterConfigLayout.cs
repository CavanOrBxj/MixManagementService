using MixManagementPlatform.Utils;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MixManagementPlatform.Layouts
{
    public partial class TsSheduleCenterConfigLayout : UserControl
    {
        private string path;
        private IniFileOperator iniFile;
        private bool hasConfigFile; //是否存在对应的配置文件

        public TsSheduleCenterConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(430, 784);

            InitMicroMode(cbBoxMICROMODE);
            this.path = path;
            if (path != null && !string.IsNullOrWhiteSpace(path))
            {
                InitData();
            }
        }

        private void InitData()
        {
            try
            {
                string configPath = Path.Combine(Path.GetDirectoryName(path), "TsSheduleCenter.ini");
                if (System.Configuration.ConfigurationManager.AppSettings["LogConfigPathFlag"] != "0")
                {
                    MixLogHelper.Info(GetType().Name, configPath);
                }
                hasConfigFile = File.Exists(configPath);
                if (!File.Exists(configPath))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                if (iniFile == null) iniFile = new IniFileOperator(configPath);
                textServerName.Text = iniFile.ReadString("Database", "ServerName", "");
                textDataBase.Text = iniFile.ReadString("Database", "DataBase", "");
                textLogID.Text = iniFile.ReadString("Database", "LogID", "");
                textLogPass.Text = iniFile.ReadString("Database", "LogPass", "");

                textIP.Text = iniFile.ReadString("UDP", "IP", "");
                textPORT.Text = iniFile.ReadString("UDP", "PORT", "");
                textMicroPORT.Text = iniFile.ReadString("UDP", "MicroPORT", "");
                textMicroRecPORT.Text = iniFile.ReadString("UDP", "MicroRecPORT", "");
                textRTSPPORT.Text = iniFile.ReadString("UDP", "RTSPPORT", "");
                textCAIP.Text = iniFile.ReadString("UDP", "CAIP", "");
                textCAPORT.Text = iniFile.ReadString("UDP", "CAPORT", "");
                textCAGAP.Text = iniFile.ReadString("UDP", "CAGAP", "");
                textCATIMES.Text = iniFile.ReadString("UDP", "CATIMES", "");
                textMQIP.Text = iniFile.ReadString("UDP", "MQIP", "");
                textMQPORT.Text = iniFile.ReadString("UDP", "MQPORT", "");
                textMQUSER.Text = iniFile.ReadString("UDP", "MQUSER", "");
                textMQPWD.Text = iniFile.ReadString("UDP", "MQPWD", "");
                textRECTOPIC.Text = iniFile.ReadString("UDP", "RECTOPIC", "");
                textSENDTOPIC.Text = iniFile.ReadString("UDP", "SENDTOPIC", "");

                cbBoxMICROMODE.SelectedValue = iniFile.ReadInteger("SYSSET", "MICROMODE", 1);
                textMULTIPLEXERFLAG.Text = iniFile.ReadString("SYSSET", "MULTIPLEXERFLAG", "");
                textMULTIPLEXERIP.Text = iniFile.ReadString("SYSSET", "MULTIPLEXERIP", "");
                textMULTIPLEXERPORT.Text = iniFile.ReadString("SYSSET", "MULTIPLEXERPORT", "");
                textURL.Text = iniFile.ReadString("SYSSET", "URL", "");
                textSwitchFreq.Text = iniFile.ReadString("SYSSET", "SwitchFreq", "");
                textCCPlayPath.Text = iniFile.ReadString("SYSSET", "CCPlayPath", "");
                textAmTimeOut.Text = iniFile.ReadString("SYSSET", "AmTimeOut", "");
                textPORTL.Text = iniFile.ReadString("SYSSET", "PORTL", "");
                textPORTH.Text = iniFile.ReadString("SYSSET", "PORTH", "");
                textLOCALPATH.Text = iniFile.ReadString("SYSSET", "LOCALPATH", "");
                textURLPATH.Text = iniFile.ReadString("SYSSET", "URLPATH", "");
                textGBSTUDIONO.Text = iniFile.ReadString("SYSSET", "GBSTUDIONO", "");



                textLEDtxtLenth.Text = iniFile.ReadString("LED", "LEDtxtLenth", "");
            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化TsSheduleCenter配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                string configPath = Path.Combine(Path.GetDirectoryName(path), "TsSheduleCenter.ini");
                if(iniFile==null) iniFile = new IniFileOperator(configPath);

                iniFile.WriteString("Database", "ServerName", textServerName.Text.Trim());
                iniFile.WriteString("Database", "DataBase", textDataBase.Text.Trim());
                iniFile.WriteString("Database", "LogID", textLogID.Text.Trim());
                iniFile.WriteString("Database", "LogPass", textLogPass.Text.Trim());

                iniFile.WriteString("UDP", "IP", textIP.Text.Trim());
                iniFile.WriteString("UDP", "PORT", textPORT.Text);
                iniFile.WriteString("UDP", "MicroPORT", textMicroPORT.Text);
                iniFile.WriteString("UDP", "MicroRecPORT", textMicroRecPORT.Text);
                iniFile.WriteString("UDP", "RTSPPORT", textRTSPPORT.Text);
                iniFile.WriteString("UDP", "CAIP", textCAIP.Text);
                iniFile.WriteString("UDP", "CAPORT", textCAPORT.Text);
                iniFile.WriteString("UDP", "CAGAP", textCAGAP.Text);
                iniFile.WriteString("UDP", "CATIMES", textCATIMES.Text);
                iniFile.WriteString("UDP", "MQIP", textMQIP.Text);
                iniFile.WriteString("UDP", "MQPORT", textMQPORT.Text);
                iniFile.WriteString("UDP", "MQUSER", textMQUSER.Text);
                iniFile.WriteString("UDP", "MQPWD", textMQPWD.Text);
                iniFile.WriteString("UDP", "RECTOPIC", textRECTOPIC.Text);
                iniFile.WriteString("UDP", "SENDTOPIC", textSENDTOPIC.Text);

                iniFile.WriteInteger("SYSSET", "MICROMODE", (int)cbBoxMICROMODE.SelectedValue);
                iniFile.WriteString("SYSSET", "MULTIPLEXERFLAG", textMULTIPLEXERFLAG.Text);
                iniFile.WriteString("SYSSET", "MULTIPLEXERIP", textMULTIPLEXERIP.Text);
                iniFile.WriteString("SYSSET", "MULTIPLEXERPORT", textMULTIPLEXERPORT.Text);
                iniFile.WriteString("SYSSET", "URL", textURL.Text);
                iniFile.WriteString("SYSSET", "SwitchFreq", textSwitchFreq.Text);
                iniFile.WriteString("SYSSET", "CCPlayPath", textCCPlayPath.Text);
                iniFile.WriteString("SYSSET", "AmTimeOut", textAmTimeOut.Text);
                iniFile.WriteString("SYSSET", "PORTL", textPORTL.Text);
                iniFile.WriteString("SYSSET", "PORTH", textPORTH.Text);
                iniFile.WriteString("SYSSET", "LOCALPATH", textLOCALPATH.Text);
                iniFile.WriteString("SYSSET", "URLPATH", textURLPATH.Text);
                iniFile.WriteString("SYSSET", "GBSTUDIONO", textGBSTUDIONO.Text);



                iniFile.WriteString("LED", "LEDtxtLenth", textLEDtxtLenth.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateData()
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox && c.Name != "textLogPass")
                {
                    if (string.IsNullOrWhiteSpace((c as TextBox).Text))
                    {
                        MessageBox.Show(this, c.Tag.ToString() + "未填写");
                        return false;
                    }
                }
            }
            if (!Regex.IsMatch(textPORTL.Text.Trim(), @"^\d+$")|| !Regex.IsMatch(textPORTH.Text.Trim(), @"^\d+$") || 
                Convert.ToInt32(textPORTL.Text.Trim()) >= Convert.ToInt32(textPORTH.Text.Trim()))
            {
                MessageBox.Show(this, "起始端口号应小于终止端口号，且为整数");
                return false;
            }
            return true;
        }

        private void InitMicroMode(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Display"] = "密码验证模式";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = "PKI身份认证模式";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = "指纹认证模式";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                base.OnPaintBackground(e);
            }
            catch
            {
                e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);
            }
        }

    }
}
