using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ComputeCommon;
using ComputeCommon.Enum;
using ComputeCommon.Functions;
using ComputeCommon.Interface;

namespace Computer
{
    public partial class Form1 : Form
    {
        Stopwatch ws = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            LoadConstForShow();
            LoadUfuncForShow();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Compute();
        }

        private void KeyUp_RichTestBox(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    Compute();
                    break;
            }
        }

        private void Compute()
        {
            if (richTextBox_expression.Text != null && richTextBox_expression.Text.Length > 0)
            {
                ws.Reset(); ws.Start();
                string expression;
                try
                {
                    if (richTextBox_expression.SelectedText != null && richTextBox_expression.SelectedText.Length > 0)
                        expression = richTextBox_expression.SelectedText;
                    else
                        expression = richTextBox_expression.Text;

                    textBox_result.Text = ComputeCommon.ComputAbstract.DoCompute(expression).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ws.Stop();
                label_consumeTime.Text = ws.Elapsed.Milliseconds.ToString() + " ms";
                label2.Text = ComputAbstract.Computer.StackDeep.ToString();
                ComputAbstract.Computer.CleanUp();
            }
            richTextBox_expression.Text = richTextBox_expression.Text.Trim();
        }

        private void Bt_AddConsts_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tx_constName.Text)
                && !string.IsNullOrEmpty(tb_constValue.Text))
            {
                try
                {
                    double value = Convert.ToDouble(tb_constValue.Text);
                    string name =tx_constName.Text.Trim();

                    if (ConstNumbers.CreateConst(name, value))
                    {
                        tb_constValue.Text = tx_constName.Text = string.Empty;
                        LoadConstForShow();
                        MessageBox.Show("OK!");
                    }
                    else
                    {
                        if (MessageBox.Show("已经存在：变量：" + name + " 值：" + ConstNumbers.Consts[name].ToString()+" 覆盖？","冲突",MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            ConstNumbers.CreateConstOverWrite(name, value);
                            LoadConstForShow();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail!"+" "+ex.Message);
                }
            }
        }

        private void LoadConstForShow()
        {
            listBox_const.Items.Clear();
            listBox_const.Refresh();

            foreach (KeyValuePair<string, double> pair in ConstNumbers.Consts)
            {
                listBox_const.Items.Add(pair.Key + "  -  " + pair.Value.ToString());
            }
            listBox_const.Refresh();
        }

        private void LoadUfuncForShow()
        {
            listBox_ufuncs.Items.Clear();
            listBox_ufuncs.Refresh();

            foreach (KeyValuePair<string, string> pair in UserDefinFuncManager.UserFuncDic)
            {
                listBox_ufuncs.Items.Add(pair.Value);
            }

            foreach (KeyValuePair<string, IFunctionConponent> pair in FunctionManager.FuncModols)
            {
                listBox_ufuncs.Items.Add(pair.Value.Expression);
            }
            listBox_ufuncs.Refresh();
        }

        private void bt_constSave_Click(object sender, EventArgs e)
        {
            try
            {
                ConstNumbers.Dump();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected string FindItemKey(string s)
        {
            string[] temp = s.Split(new char[] { '-' });
            return temp[0].Trim();
        }

        private void ListBox_keyPress(object sender, KeyPressEventArgs e)
        {
            //no use
        }

        private void ListBoxConst_keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ConstNumbers.Consts.Remove(FindItemKey(listBox_const.SelectedItem.ToString()));
                LoadConstForShow();
            }
        }

        private void listboxconst_doubleclick(object sender, EventArgs e)
        {
            string s=FindItemKey(listBox_const.SelectedItem.ToString());

            string t = richTextBox_expression.Text;
            richTextBox_expression.Text = t.Insert(richTextBox_expression.SelectionStart, s);

            richTextBox_expression.Refresh();
        }

        private void bt_AddUfunc_Click(object sender, EventArgs e)
        {
            if (richTextBox_ufunc.Text.Length > 0)
            {
                try
                {
                    string wholething = richTextBox_ufunc.Text.Trim();
                    string ufuncName = UFuncParser.GetUfuncName(wholething);
                    if (UserDefinFuncManager.CreateUfunc(ufuncName, wholething))
                    {
                        LoadUfuncForShow();
                        MessageBox.Show("OK!");
                    }
                    else
                    {
                        if (MessageBox.Show("已经存在：函数：" + ufuncName + " 表达式：" + UserDefinFuncManager.UserFuncDic[ufuncName] + " 覆盖？", "冲突", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            UserDefinFuncManager.CreateUfuncOverWrite(ufuncName, wholething);
                            LoadUfuncForShow();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail!" + " " + ex.Message);
                }
            }
        
        }

        private void bt_saveUfunc_Click(object sender, EventArgs e)
        {
            try
            {
                UserDefinFuncManager.Dump();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listbox_ufuncDoubleClick(object sender, EventArgs e)
        {
            string s = UFuncParser.GetDefinition(listBox_ufuncs.SelectedItem.ToString());

            string t = richTextBox_expression.Text;
            richTextBox_expression.Text = t.Insert(richTextBox_expression.SelectionStart, s);

            richTextBox_expression.Refresh();

            richTextBox_ufunc.Text = listBox_ufuncs.SelectedItem.ToString();
            richTextBox_ufunc.Refresh();
        }

        private void listBox_ufuncs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                UserDefinFuncManager.UserFuncDic.Remove(UFuncParser.GetUfuncName(listBox_ufuncs.SelectedItem.ToString()));
                LoadUfuncForShow();
            }
        }
    }
}
