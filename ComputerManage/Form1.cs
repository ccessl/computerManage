using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Excel;
using System.Threading;

namespace ComputerManage
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection("Data Source=" + System.Windows.Forms.Application.StartupPath + "\\config\\cinfor.mdb;Provider=Microsoft.Jet.OLEDB.4.0");
        Form2 dataEdit = new Form2();
       // int rowIndex = -1;
       // bool serchFlag = false;

        public Form1()
        {
            InitializeComponent();
            //初始化
            InitCombo();
            InitGridView();

        }
        //初始化下拉列表
        private void InitCombo()
        {
            this.comboGroup.Items.Add("全部");
            this.comboGroup.Items.Add("502");
            this.comboGroup.Items.Add("508");
            this.comboGroup.Items.Add("510");
            this.comboGroup.Items.Add("506");
            this.comboGroup.Items.Add("617");
            this.comboGroup.Items.Add("503");
            this.comboGroup.Items.Add("530");
            this.comboGroup.Items.Add("614");

            this.comboState.Items.Add("全部");
            this.comboState.Items.Add("使用中");
            this.comboState.Items.Add("停用");
        }
       
        //初始化gridview1
        private void InitGridView()
        {
            //不显示最后一行的空白行
            dataGridView1.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            string allInformation = "select * from detailInfor order by ID";
            dt = DataTableExcute(allInformation);
            dataGridView1.DataSource = dt;

        }
        //得到所选行索引
        public int getSelectedIndex()
        {
            int count = this.dataGridView1.Rows.Count;
            for (int i = 0; i < count - 1; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                    return i;
            }
            return -1;   
        }
        //查询得到datatable
        public DataTable DataTableExcute(string cmdstr)
        {
            OleDbCommand cmd = new OleDbCommand(cmdstr, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable datatable = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                conn.Open();
                dataAdapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    datatable = dataset.Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                dataAdapter.Dispose();
            }
            return datatable;

        }
        //对数据表的操作
        public bool DataSheetOperate(string cmdstr)
        {
            OleDbCommand cmd = new OleDbCommand(cmdstr, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return true;

        }

       
        //刷新一行
        public void GridViewRowRefresh(string newName,string newDeclare,string newUser,string newGroup,string newGettime,string newUpdate,string newHisuser,int newState)
        {
            int rowIndex = getSelectedIndex();
            dataGridView1.Rows[rowIndex].Cells[1].Value = newName;
            dataGridView1.Rows[rowIndex].Cells[2].Value = newDeclare;
            dataGridView1.Rows[rowIndex].Cells[3].Value = newUser;
            dataGridView1.Rows[rowIndex].Cells[4].Value = newGroup;
            dataGridView1.Rows[rowIndex].Cells[5].Value = newGettime;
            dataGridView1.Rows[rowIndex].Cells[6].Value = newUpdate;
            dataGridView1.Rows[rowIndex].Cells[7].Value = newHisuser;
            dataGridView1.Rows[rowIndex].Cells[8].Value = newState;

        }
        //下拉列表动态绑定
        //public void initCombobox()
        //{
        //    string cmdstr = "select ID,c_name from baseInfor";
        //    DataTable dt = new DataTable();
        //    dt = DataTableExcute(cmdstr);
        //    if (dt.Rows.Count > 0)
        //    {

        //        // MessageBox.Show(dt.Rows.Count.ToString());
        //        this.comboGroup.DisplayMember = "c_name";
        //        this.comboGroup.ValueMember = "ID";
        //        this.comboGroup.DataSource = dt;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Combobox get data error!");
        //    }

        //}
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string cmdstr = "";
            string group = this.comboGroup.Text;
            string state = this.comboState.Text;
            string stateValue = null;
            if (state == "使用中")
                stateValue = "1";
            else
                stateValue = "0";
            string user = this.textBox1.Text.ToString();
            try
            {
                if ((group == "" || group == "全部") && (state == "" || state == "全部") && user == "")
                {
                    cmdstr = "select * from detailInfor order by ID";
                }
                else if ((group == "" || group == "全部") && (state == "" || state == "全部"))
                {
                    cmdstr = "select * from detailInfor where d_user='" + user + "'";
                }
                else if ((state == "" || state == "全部") && user == "")
                {
                    cmdstr = "select * from detailInfor where d_group='" + group + "'";
                }
                else if ((group == "" || group == "全部") && user == "")
                {
                    cmdstr = "select * from detailInfor where d_state=" + stateValue + "";
                }
                else if(group == "" || group == "全部")
                {
                      cmdstr = "select * from detailInfor where d_user='" + user + "' and  d_state=" + stateValue + "";
                }
                 else if(state == "" || state == "全部")
                {
                    cmdstr = "select * from detailInfor where d_user='" + user + "' and  d_group='" + group + "'";
                }
                else if (user == "")
                {
                    cmdstr = "select * from detailInfor where d_group='" + group + "' and  d_state=" + stateValue + "";
                }
                else
                {
                    cmdstr = "select * from detailInfor where d_group='" + group + "' and  d_state=" + stateValue + " and d_user='" + user+"'";
                }
                dt = DataTableExcute(cmdstr);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有相关信息！，请重新选择查询条件");
                }
                else
                {
                    this.dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                dt.Dispose();
            }
        }

       
        //生成报表
        private void button3_Click(object sender, EventArgs e)
        {
            Thread generateMyWord = new Thread(new ThreadStart(OutputAsExcelFile));
            //设置为后台线程
            generateMyWord.IsBackground = true;
            //开启线程
            generateMyWord.Start();

        }
        private void OutputAsExcelFile()
        {
            //将datagridView中的数据导出到一张表中
            DataTable tempTable = this.exporeDataToTable(this.dataGridView1);
            //导出信息到Excel表
            Microsoft.Office.Interop.Excel.ApplicationClass myExcel;
            Microsoft.Office.Interop.Excel.Workbooks myWorkBooks;
            Microsoft.Office.Interop.Excel.Workbook myWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet myWorkSheet;
            char myColumns;
            Microsoft.Office.Interop.Excel.Range myRange;
            object[,] myData = new object[500, 35];
            int i, j;//j代表行,i代表列
            myExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //显示EXCEL
            myExcel.Visible = true;
            if (myExcel == null)
            {
                MessageBox.Show("本地Excel程序无法启动!请检查您的Microsoft Office正确安装并能正常使用", "提示");
                return;
            }
            myWorkBooks = myExcel.Workbooks;
            myWorkBook = myWorkBooks.Add(System.Reflection.Missing.Value);
            myWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myWorkBook.Worksheets[1];
            myColumns = (char)(tempTable.Columns.Count + 64);//设置列
            myRange = myWorkSheet.get_Range("A4", myColumns.ToString() + "5");//设置列宽
            int count = 0;
            //设置列名
            foreach (DataColumn myNewColumn in tempTable.Columns)
            {
                myData[0, count] = myNewColumn.ColumnName;
                count = count + 1;
            }
            //输出datagridview中的数据记录并放在一个二维数组中
            j = 1;
            foreach (DataRow myRow in tempTable.Rows)//循环行
            {
                for (i = 0; i < tempTable.Columns.Count; i++)//循环列
                {
                    myData[j, i] = myRow[i].ToString();
                }
                j++;
            }
            //将二维数组中的数据写到Excel中
            myRange = myRange.get_Resize(tempTable.Rows.Count + 1, tempTable.Columns.Count);//创建列和行
            myRange.Value2 = myData;
            myRange.EntireColumn.AutoFit();
            myRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; 
            //删除前方空白三行
            Microsoft.Office.Interop.Excel.Range deleteRng = (Microsoft.Office.Interop.Excel.Range)myWorkSheet.Rows[1, System.Type.Missing];
            deleteRng.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
            Microsoft.Office.Interop.Excel.Range deleteRng1 = (Microsoft.Office.Interop.Excel.Range)myWorkSheet.Rows[1, System.Type.Missing];
            deleteRng1.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
            Microsoft.Office.Interop.Excel.Range deleteRng2 = (Microsoft.Office.Interop.Excel.Range)myWorkSheet.Rows[1, System.Type.Missing];
            deleteRng2.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
           
        }
        private DataTable exporeDataToTable(DataGridView dataGridView)
        {
            //将datagridview中的数据导入到表中
            DataTable tempTable = new DataTable("tempTable");
            //定义一个模板表，专门用来获取列名
            DataTable modelTable = new DataTable("ModelTable");
            //创建列
            for (int column = 0; column < dataGridView.Columns.Count; column++)
            {
                //可见的列才显示出来
                if (dataGridView.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(dataGridView.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(dataGridView.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加datagridview中行的数据到表
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                if (dataGridView.Rows[row].Visible == false)
                {
                    continue;
                }
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = dataGridView.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }
                tempTable.Rows.Add(tempRow);
            }
            //添加签名一栏**************************************************************
            tempTable.Columns.Remove("使用状态");
            tempTable.Columns.Add("领用人签名");
           // MessageBox.Show(tempTable.Rows.Count.ToString());
            return tempTable;
        }
        //右键
        private void Fundelete()
        {
            if (getSelectedIndex() >= 0)
            {
                int rowIndex = getSelectedIndex();
                string id = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string cmdstr = "delete from detailInfor where ID=" + id;
                if (DataSheetOperate(cmdstr))
                {
                    this.dataGridView1.Rows.RemoveAt(rowIndex);
                    MessageBox.Show("删除数据成功！");
                }
                else
                {
                    MessageBox.Show("删除数据失败！");
                }
            }
            else
            {
                MessageBox.Show("请先选择一行数据");
            }
        }
        public void FuncEdit()
        {
            try
            {
                if (getSelectedIndex() >= 0)
                {
                    int rowIndex = getSelectedIndex();
                    string id = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                    dataEdit.t_name = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                    dataEdit.t_declare = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    dataEdit.t_user = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    dataEdit.t_group = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    dataEdit.t_gettime = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                    dataEdit.t_update = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                    dataEdit.t_hisuser = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                    dataEdit.t_state= dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                    dataEdit.ShowDialog();

                    int newstate;
                    if (dataEdit.t_state == "使用中")
                        newstate = 1;
                    else
                        newstate = 0;

                    GridViewRowRefresh(dataEdit.t_name, dataEdit.t_declare, dataEdit.t_user, dataEdit.t_group, dataEdit.t_gettime, dataEdit.t_update, dataEdit.t_hisuser, newstate);
                    bool ifclick = dataEdit.ifClickOk;
                    string cmdstr = "update detailInfor set d_name='" + dataEdit.t_name + "',d_declare='" + dataEdit.t_declare + "',d_user='" + dataEdit.t_user + "',d_group='" + dataEdit.t_group + "',d_gettime='" + dataEdit.t_gettime + "',d_update='" + dataEdit.t_update + "',d_hisuser='" + dataEdit.t_hisuser + "',d_state=" + newstate.ToString() + " where ID=" + id;
                    if (ifclick)
                    {
                        if (DataSheetOperate(cmdstr))
                        {
                            MessageBox.Show("编辑成功！");
                        }
                        else
                        {
                            MessageBox.Show("编辑失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择一行数据！");
                }

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message.ToString());
            }
               
        }
        private void FuncAdd()
        {
            try
            {
                dataEdit.t_name = null;
                dataEdit.t_declare = null;
                dataEdit.t_user = null;
                dataEdit.t_group = null;
                dataEdit.t_gettime = null;
                dataEdit.t_update = null;
                dataEdit.t_hisuser = null;
                dataEdit.t_state = null;
                dataEdit.ShowDialog();
                //默认是使用中的
                int newstate = 1;
                if (dataEdit.t_state == "使用中")
                    newstate = 1;
                else
                    newstate = 0;

                string cmdstr = "insert into detailInfor(d_name,d_declare,d_user,d_group,d_gettime,d_update,d_hisuser,d_state) values('" + dataEdit.t_name + "','" + dataEdit.t_declare + "','" + dataEdit.t_user + "','"+dataEdit.t_group+"','" + dataEdit.t_gettime + "','" + dataEdit.t_update +"','"+dataEdit.t_hisuser+ "',"+newstate+")";
                if (dataEdit.ifClickOk)
                {
                    if (DataSheetOperate(cmdstr))
                    {
                        DataTable dt = new DataTable();
                        string allInformation = "select * from detailInfor";
                        dt = DataTableExcute(allInformation);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Rows[0].Cells[0].Selected = false;

                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
               
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Fundelete();

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncEdit();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncAdd();
               
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
               //MessageBox.Show(e.RowIndex.ToString());
               // MessageBox.Show("总行数："+dataGridView1.Rows.Count.ToString());
            }
        }

        private void 显示所有信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string allInformation = "select * from detailInfor order by ID";
            dt = DataTableExcute(allInformation);
            dataGridView1.DataSource = dt;

        }
        //添加
        private void button2_Click(object sender, EventArgs e)
        {
            FuncAdd();
        }
        //编辑
        private void button4_Click(object sender, EventArgs e)
        {
            FuncEdit();
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            Fundelete();
        }

      
    }
}
