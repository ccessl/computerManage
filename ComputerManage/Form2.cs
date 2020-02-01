using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerManage
{
    public partial class Form2 : Form
    {
        public bool ifClickOk = false;

        public string t_name=null;
        public string t_declare = null;
        public string t_user = null;
        public string t_hisuser = null;
        public string t_state = null;
        public string t_group = null;
        public string t_gettime = null;
        public string t_update = null;

        public Form2()
        {
            InitializeComponent();
            initComboBox();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //初始化显示值
            this.dname.Text = t_name;
            this.ddeclare.Text = t_declare;
            this.duser.Text = t_user;
            this.dhisuser.Text = t_hisuser;
            this.dgettime.Text = t_gettime;
            this.dupdate.Text = t_update;

            this.dgroup.SelectedIndex = -1;
            this.dstate.SelectedIndex = -1;
            for (int i = 0; i < dgroup.Items.Count; i++)
            {
                if (t_group == this.dgroup.Items[i].ToString())
                {
                    this.dgroup.SelectedIndex = i;
                }
            }
            if (t_state == "1" || t_state == "true")
                this.dstate.SelectedIndex=0;
            else if (t_state == "0" || t_state == "false")
                this.dstate.SelectedIndex=1;

            ifClickOk = false;
        }
        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dname.Text != null && this.duser.Text != null && this.dname.Text != "" && this.duser.Text !="")
            {
                t_name =  this.dname.Text.ToString();
                t_declare =this.ddeclare.Text.ToString();
                t_user = this.duser.Text.ToString();
                t_hisuser = this.dhisuser.Text.ToString();
                t_state = this.dstate.Text.ToString();
                t_group = this.dgroup.Text.ToString();
                t_gettime =this.dgettime.Text.ToString();
                t_update = this.dupdate.Text.ToString(); 

                ifClickOk = true;
                this.Close();
            }
            else
                MessageBox.Show("名称和使用人信息不能为空!");

        }
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            ifClickOk = false;
            this.Close();
        }
        private void initComboBox()
        {
            this.dgroup.Items.Add("502");
            this.dgroup.Items.Add("508");
            this.dgroup.Items.Add("510");
            this.dgroup.Items.Add("506");
            this.dgroup.Items.Add("617");
            this.dgroup.Items.Add("503");
            this.dgroup.Items.Add("530");
            this.dgroup.Items.Add("614");

            this.dstate.Items.Add("使用中");
            this.dstate.Items.Add("停用");
        }
    }
}
