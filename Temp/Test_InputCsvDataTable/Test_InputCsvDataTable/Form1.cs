using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_InputCsvDataTable
{
    public partial class Form1 : Form
    {
        string[] wordCsvDataRow;
        string[] wordCsvDataColumn;
        int IndexOfCsvDataRow = 0;
        int IndexOfCsvDataColumn = 0;
        DataTable datatableCsvData = new DataTable();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            
            datatableCsvData.Clear(); //Clear datatable of CSV Data
            datatableCsvData.Columns.Clear(); //Clear Columns of datatable CSV Data
            datatableCsvData.Rows.Clear(); //Clear Rows of datatable CSV Data

            IndexOfCsvDataRow = 0; //Initial IndexofCsvDataRow
            IndexOfCsvDataColumn = 0; //Initial IndexofCsvDataColumn

            wordCsvDataRow = textBoxCsvData.Text.Split('\n'); //Split Row by new line(\n)

            wordCsvDataColumn = wordCsvDataRow[0].Split(','); //Split Column of Row0 by comma(,)

            foreach (var dataColumn in wordCsvDataColumn) //Add Other 42 Columns of CSV Header
            {
                datatableCsvData.Columns.Add(dataColumn);

                textBoxIndexOfCsvDataColumn.Text = IndexOfCsvDataColumn.ToString();
                IndexOfCsvDataColumn++;
            }

            foreach (var dataRow in wordCsvDataRow)
            {
                if(dataRow == wordCsvDataRow[0])
                {
                }
                else
                {
                    wordCsvDataColumn = dataRow.Split(',');
                    datatableCsvData.Rows.Add(wordCsvDataColumn);
                }
                textBoxIndexOfCsvDataRow.Text = IndexOfCsvDataRow.ToString();
                IndexOfCsvDataRow++;
            }

            dataGridView2.DataSource = datatableCsvData;
        }

        private void buttonCheckDataInDataGridView2_Click(object sender, EventArgs e)
        {
            textBoxDataGridView2Value.Text = dataGridView2[int.Parse(textBoxDataGridView2Column.Text), int.Parse(textBoxDataGridView2Row.Text)].Value.ToString();
        }
    }
}
