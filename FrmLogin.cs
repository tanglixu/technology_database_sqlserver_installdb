using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MySoft.Common.WinForm;
using MySoft.Common.Classes;
using MySoft.Common.DataBase;
using System.Configuration;

namespace My.Tools.InstallDB
{
    public partial class FrmLogin : Form
    {
        public static bool IsNeedExecute = false;

        private string _SaveConnectionString;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void LoadConfig()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(DbHelper.CS.ConnectionString);
            txtDBServer.Text = builder.DataSource;
            txtDBUser.Text = builder.UserID;
            txtDBPassWord.Text = builder.Password;
            cboDBAudit.SelectedIndex = builder.IntegratedSecurity ? 1 : 0;

            string[] dbs = ConfigurationManager.AppSettings["RecentDB"].Split(',');
            txtDBName.Items.Clear();
            foreach (var db in dbs)
                txtDBName.Items.Add(db);
            int index = Array.FindIndex(dbs, x => x.IsSame(builder.InitialCatalog));
            if (index < 0)
            {
                txtDBName.Items.Add(builder.InitialCatalog);
                txtDBName.Text = builder.InitialCatalog;
            }
            else
                txtDBName.SelectedIndex = index;
        }
        private void SaveConfig()
        {
            List<string> dbs = new List<string>();
            foreach (string item in txtDBName.Items)
                if (dbs.FindIndex(x => x.IsSame(item)) < 0)
                    dbs.Add(item);
            if (dbs.FindIndex(x => x.IsSame(txtDBName.Text)) < 0)
                dbs.Add(txtDBName.Text);

            string file = Environment.GetCommandLineArgs()[0] + ".config";
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode root = doc.DocumentElement.SelectSingleNode("connectionStrings");
            root.SelectSingleNode("add[@name='MyDB']").Attributes["connectionString"].Value = _SaveConnectionString;

            root = doc.DocumentElement.SelectSingleNode("appSettings");
            root.SelectSingleNode("add[@key='RecentDB']").Attributes["value"].Value = dbs.GetDelimitedText();
            doc.Save(file);
        }

        private bool TestConnection(string desc, string connection)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                DialogHelper.ShowInfo("���� " + desc + " ���ݿ������ʧ�ܣ�" + Environment.NewLine + e.Message);
                return false;
            }
        }

        private bool Prepare()
        {
            string dbName = txtDBName.Text;
            if (string.IsNullOrEmpty(dbName))
            {
                DialogHelper.ShowInfo("���ݿⲻ��Ϊ��");
                return false;
            }
            if (dbName.IsSame("master") || dbName.IsSame("model") || dbName.IsSame("msdb") || dbName.IsSame("tempdb"))
            {
                DialogHelper.ShowInfo("Ŀ�����ݿⲻ��Ϊϵͳ���ݿ�����");
                return false;
            }

            string csConn;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = txtDBServer.Text;
            builder.UserID = txtDBUser.Text;
            builder.Password = txtDBPassWord.Text;
            builder.IntegratedSecurity = cboDBAudit.SelectedIndex == 1;
            //builder.InitialCatalog = txtDBName.Text;
            builder.InitialCatalog = "master";
            csConn = builder.ConnectionString;

            if (TestConnection("", csConn))
            {
                DbHelper.CS.ConnectionString = csConn;

                builder.InitialCatalog = txtDBName.Text;
                _SaveConnectionString = builder.ConnectionString;
                return true;
            }
            return false;
        }

        private bool InstallDB()
        {
            using (OpenFileDialog dlg = new OpenFileDialog { DefaultExt = ".bak", Filter = "���ݱ����ļ�(*.bak)|*.bak|�����ļ�(*.*)|*.*" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Application.DoEvents();
                    try
                    {
                        StaticWaitDialog.Start("���ڰ�װ���ݣ����Ժ�...", "��ʾ", 380);

                        DbHelper.CS.CommandTimeout = 600;
                        new MSSQLUtils(DbHelper.CS).RestoreDB(txtDBName.Text, dlg.FileName);
                        DialogHelper.ShowInfo("���ݿ�" + txtDBName.Text + "��װ�ɹ�!");
                        return true;
                    }
                    catch (Exception e)
                    {
                        DialogHelper.ShowInfo("���ݿⰲװʧ��!\r\n\r\n����ԭ��\r\n" + e.Message);
                    }
                    finally
                    {
                        StaticWaitDialog.End();
                    }
                }
            }
            return false;
        }

        public static bool InstallDBAuto(string dataBaseBakFile)
        {
            Console.WriteLine("���ڼ�������...");
            var frm = new FrmLogin();
            frm.LoadConfig();
            if (!frm.Prepare())
                return false;
            string dataBaseName = frm.txtDBName.Text;
            Console.WriteLine("���ڻָ����ݿ�{0}���ļ�{1}...".FormatMe(dataBaseName, dataBaseBakFile));
            DbHelper.CS.CommandTimeout = 600;
            bool b = new MSSQLUtils(DbHelper.CS).RestoreDB(dataBaseName, dataBaseBakFile);
            if(b)
                Console.WriteLine("���ݿ�ָ��ɹ�������");
            return b;
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            if (!Prepare())
                return;
            SaveConfig();
            if (!InstallDB())
                return;
            IsNeedExecute = true;
            Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cboDBAudit.SelectedIndex = 0;
            LoadConfig();
        }

        private void cboDBAudit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDBUser.Enabled = cboDBAudit.SelectedIndex == 0;
            txtDBPassWord.Enabled = txtDBUser.Enabled;
        }

        private void cboBSDBAudit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsNeedExecute = false;
            Close();
        }
    }
}