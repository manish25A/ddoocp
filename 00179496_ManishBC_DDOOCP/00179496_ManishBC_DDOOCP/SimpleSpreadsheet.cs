using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _00179496_ManishBC_DDOOCP
{
    public partial class Simple_Spreadsheet : Form
    {
        String formulae = "";
        int finalColumnIndex = -1;
        int finalRowIndex = -1;

        string[] cols = { "A", "B", "C", "D", "E", "F", "G", "H", "I",
            "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public Simple_Spreadsheet()
        {
            InitializeComponent();
        }
        private void dgvUserDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, 
                    e.RowBounds.Location.Y + 4);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dgvUserDetails_RowPostPaint);
            for (char c = 'A'; c <= 'Z'; c++)
            {
                DataGridViewTextBoxColumn cell = new DataGridViewTextBoxColumn();
                cell.Name = c.ToString();
                cell.HeaderText = c.ToString();
                dataGridView1.Columns.Add(cell);
            }
            for (int row = 0; row < 25; row++)
            {
                DataGridViewRow dr = new DataGridViewRow();

                dataGridView1.Rows.Add(dr);

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string column_row_value = cols[e.ColumnIndex] + (dataGridView1.CurrentCell.RowIndex + 1).ToString();

            textBox1.Text = (column_row_value);

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (column_row_value == Name)
                {
                    
                    textBox2.Text = "textboxtovalue"; //formula display 
                }
                else
                {
                   
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()); 
                }
            }
            else
            {
               
                textBox2.Text = null;
            }


            DataGridView dv = (DataGridView)sender;
            string text = Convert.ToString(dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (text.Contains("=") || text.Contains("*"))
            {
                finalRowIndex = -1;
                finalColumnIndex = -1;
                formulae = "";
            }
            else if (formulae != "")
            {
                text = formulae;
            }

            List<double> values = new List<double>();
            if (text.StartsWith("="))
            {
                if (formulae == "")
                {
                    
                }
                if (text.Contains(":"))
                {
                    string operationName = text.Substring(1, (text.IndexOf(' ') - text.IndexOf('=')) - 1);
                    string lowerValue = text.Substring(text.IndexOf(' ') + 1, (text.IndexOf(':') - text.IndexOf(' ')) - 1);
                    string higherValue = text.Substring(text.IndexOf(':') + 1, (text.Length - 1) - text.IndexOf(':'));

                    char lowerLetter = Convert.ToChar(lowerValue.Substring(0, 1));
                    char higherLetter = Convert.ToChar(higherValue.Substring(0, 1));

                    string lowerNumber = lowerValue.Length < 3 ? lowerValue.Substring(1, 1) : lowerValue.Substring(1, 2);
                    string higherNumber = higherValue.Length < 3 ? higherValue.Substring(1, 1) : higherValue.Substring(1, 2);
                    if (lowerLetter == higherLetter)
                    {

                        try
                        {
                            for (int row = Convert.ToInt32(lowerNumber); row <= Convert.ToInt32(higherNumber); row++)
                            {
                                values.Add(Convert.ToDouble(dv.Rows[row - 1].Cells[e.ColumnIndex].Value));

                            }
                            if (formulae != "")
                            {
                                dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);
                            }
                            else
                            {
                                dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                    }
                    else if (lowerNumber == higherNumber)
                    {
                        try
                        {
                            for (char c = lowerLetter; c <= higherLetter; c++)
                            {

                                values.Add(Convert.ToDouble(dv.Rows[e.RowIndex].Cells[c.ToString()].Value));
                            }

                            if (formulae != "")
                            {
                                dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);
                            }
                            else
                            {
                                dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);
                            }
                        }
                        catch ( Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                    }
                }

                else
                {
                    var calculationType = new System.Text.RegularExpressions.Regex(@"([\*]{1}|[\+]{1}|[\-]{1})|[\/]{1}");
                    var matchPattern = calculationType.Match(text);

                    if (matchPattern.Index > 0)
                    {
                        string operationName = text.Substring(1, (text.IndexOf(' ') - text.IndexOf('=')) - 1);
                        string actualCalculation = text.Substring(1);
                        string[] numbers = actualCalculation.Split(Convert.ToChar(matchPattern.Value));

                        string lowerValue = Convert.ToString(numbers[0].Substring(1, numbers[0].Length - 1));
                        string higherValue = Convert.ToString(numbers[1].Substring(1, numbers[1].Length - 1));

                        char lowerLetter = Convert.ToChar(numbers[0].Substring(0, 1));
                        char higherLetter = Convert.ToChar(numbers[1].Substring(0, 1));
                        string lowerNumber = lowerValue.Length < 3 ? lowerValue.Substring(1, 1) : lowerValue.Substring(1, 2);
                        string higherNumber = higherValue.Length < 3 ? higherValue.Substring(1, 1) : higherValue.Substring(1, 2);

                        if (lowerLetter == higherLetter)
                        {

                            try
                            {
                                for (int row = Convert.ToInt32(lowerNumber); row <= Convert.ToInt32(higherNumber); row++)
                                {
                                    values.Add(Convert.ToDouble(dv.Rows[row - 1].Cells[e.ColumnIndex].Value));

                                }
                                if (formulae != "")
                                {
                                    dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                        (operationName, values);
                                }
                                else
                                {
                                    dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                        (operationName, values);

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else if (lowerNumber == higherNumber)
                        {
                            for (char c = lowerLetter; c <= higherLetter; c++)
                            {

                                values.Add(Convert.ToDouble(dv.Rows[e.RowIndex].Cells[c.ToString()].Value));
                            }
                            if (formulae != "")
                            {
                                dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);
                            }
                            else
                            {
                                dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                    (operationName, values);
                            }
                        }
                    }
                }
            }

            if (text.Contains("*"))
            {

                if (formulae == "")
                {
                    finalRowIndex = e.RowIndex;
                    finalColumnIndex = e.ColumnIndex;
                    formulae = text;
                }
                double firstnum;
                double secondnum;
               string  operationName = "*";
                string lowerValue = text.Substring(0, text.IndexOf('*'));
                string higherValue = text.Substring(text.IndexOf('*') + 1, (text.Length - 1) - text.IndexOf('*'));

                char lowerLetter = Convert.ToChar(lowerValue.Substring(0, 1));
                char higherLetter = Convert.ToChar(higherValue.Substring(0, 1));

                string lowerNumber = lowerValue.Length < 3 ? lowerValue.Substring(1, 1) : lowerValue.Substring(1, 2);
                string higherNumber = higherValue.Length < 3 ? higherValue.Substring(1, 1) : higherValue.Substring(1, 2);

                if (lowerLetter == higherLetter)
                {
                    try
                    {

                        int row1 = Convert.ToInt32(lowerNumber);
                        firstnum = Convert.ToDouble(dv.Rows[row1 - 1].Cells[e.ColumnIndex].Value);
                        values.Add(firstnum);
                        int row2 = Convert.ToInt32(higherNumber);
                        secondnum = Convert.ToDouble(dv.Rows[row2 - 1].Cells[e.ColumnIndex].Value);
                        values.Add(secondnum);

                        if (formulae != "")
                        {
                           
                                dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                (operationName, values);
                        }
                        else
                        {
                            dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue(operationName, values);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (lowerNumber == higherNumber)
                {
                    try
                    {
                        char c = lowerLetter;
                        firstnum = Convert.ToDouble(dv.Rows[e.RowIndex].Cells[c.ToString()].Value);
                        values.Add(firstnum);
                        char d = higherLetter;
                        secondnum = Convert.ToDouble(dv.Rows[e.RowIndex].Cells[d.ToString()].Value);
                        values.Add(secondnum);
                        if (formulae != "")
                        {
                            dv.Rows[finalRowIndex].Cells[finalColumnIndex].Value = new formulacalculation().GetCalculatedValue
                                (operationName, values);
                        }
                        else
                        {
                            dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new formulacalculation().GetCalculatedValue(operationName, values);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> values = new List<int>();
            List<int> rowIndexes = new List<int>();
            List<int> columnIndexes = new List<int>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                var value = dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value;
                values.Add(Convert.ToInt32(value));
                rowIndexes.Add(cell.RowIndex);
                columnIndexes.Add(cell.ColumnIndex);
            }
            ArrayList chars = new ArrayList();
            List<int> uniqueValues = new List<int>();

            int valueIndex = 0;
            foreach (int s in columnIndexes)
            {
                int charIndex = 0;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (charIndex == s)
                    {
                        if (!chars.Contains(c))
                        {
                            uniqueValues.Add(values[valueIndex]);
                            chars.Add(c);
                        }
                        else
                        {
                            uniqueValues[chars.IndexOf(c)] += values[valueIndex];
                        }
                    }
                    charIndex++;

                }
                valueIndex++;

            }
            string[] letters = new string[chars.Count];
            int index = 0;
            foreach (char c in chars)
            {
                letters[index] = c.ToString();
                index++;
            }

            int[] dataValues = new int[uniqueValues.Count];
            int arrIndex = 0;
            foreach (int val in uniqueValues)
            {
                dataValues[arrIndex] = val;
                arrIndex++;
            }

            BarChart BC = new BarChart(letters, dataValues);
            BC.Show();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string column_row_value = cols[e.ColumnIndex] + (dataGridView1.CurrentCell.RowIndex + 1).ToString();
            textBox1.Text = (column_row_value);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
