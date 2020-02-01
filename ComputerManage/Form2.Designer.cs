namespace ComputerManage
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dname = new System.Windows.Forms.TextBox();
            this.ddeclare = new System.Windows.Forms.TextBox();
            this.duser = new System.Windows.Forms.TextBox();
            this.dgettime = new System.Windows.Forms.TextBox();
            this.dupdate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dstate = new System.Windows.Forms.ComboBox();
            this.dhisuser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "描述：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "领用时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "升级记录：";
            // 
            // dname
            // 
            this.dname.Location = new System.Drawing.Point(76, 31);
            this.dname.Name = "dname";
            this.dname.Size = new System.Drawing.Size(260, 23);
            this.dname.TabIndex = 5;
            // 
            // ddeclare
            // 
            this.ddeclare.Location = new System.Drawing.Point(76, 72);
            this.ddeclare.Multiline = true;
            this.ddeclare.Name = "ddeclare";
            this.ddeclare.Size = new System.Drawing.Size(260, 57);
            this.ddeclare.TabIndex = 6;
            // 
            // duser
            // 
            this.duser.Location = new System.Drawing.Point(80, 161);
            this.duser.Name = "duser";
            this.duser.Size = new System.Drawing.Size(82, 23);
            this.duser.TabIndex = 7;
            // 
            // dgettime
            // 
            this.dgettime.Location = new System.Drawing.Point(80, 203);
            this.dgettime.Name = "dgettime";
            this.dgettime.Size = new System.Drawing.Size(256, 23);
            this.dgettime.TabIndex = 8;
            // 
            // dupdate
            // 
            this.dupdate.Location = new System.Drawing.Point(80, 240);
            this.dupdate.Multiline = true;
            this.dupdate.Name = "dupdate";
            this.dupdate.Size = new System.Drawing.Size(256, 55);
            this.dupdate.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dstate);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dhisuser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dgroup);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dupdate);
            this.groupBox1.Controls.Add(this.ddeclare);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgettime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.duser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 446);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "使用状态";
            // 
            // dstate
            // 
            this.dstate.FormattingEnabled = true;
            this.dstate.Location = new System.Drawing.Point(242, 308);
            this.dstate.Name = "dstate";
            this.dstate.Size = new System.Drawing.Size(94, 25);
            this.dstate.TabIndex = 14;
            // 
            // dhisuser
            // 
            this.dhisuser.Location = new System.Drawing.Point(242, 164);
            this.dhisuser.Name = "dhisuser";
            this.dhisuser.Size = new System.Drawing.Size(94, 23);
            this.dhisuser.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "历史用户：";
            // 
            // dgroup
            // 
            this.dgroup.FormattingEnabled = true;
            this.dgroup.Location = new System.Drawing.Point(80, 308);
            this.dgroup.Name = "dgroup";
            this.dgroup.Size = new System.Drawing.Size(82, 25);
            this.dgroup.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "小组：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 470);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "编辑";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dname;
        private System.Windows.Forms.TextBox ddeclare;
        private System.Windows.Forms.TextBox duser;
        private System.Windows.Forms.TextBox dgettime;
        private System.Windows.Forms.TextBox dupdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox dstate;
        private System.Windows.Forms.TextBox dhisuser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox dgroup;
        private System.Windows.Forms.Label label6;
    }
}