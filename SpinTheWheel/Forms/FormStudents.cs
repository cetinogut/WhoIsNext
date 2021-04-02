using SpinTheWheel.Data;
using SpinTheWheel.Properties;
using SpinTheWheel.Utility;
using SpinTheWheel.Utility.Data;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using CheckBox = System.Windows.Forms.CheckBox;

namespace SpinTheWheel.Forms
{
    public partial class FormStudents : Form
    {
        #region Constants

        private const string FIRST_NAME = "FirstName";
        private const string LAST_NAME = "LastName";
        private const string NUMBER = "Number";
        private const string IN_CLASS = "InClass";

        #endregion

        #region Private Variables

        private BindingSource bindingSource;
        private List<Student> students;
        private List<Student> studentsInClass;  // sadece bu form içinde kontrol maksadıyla oluşturuldu. Genel listede değişiklik yapılınca gösterilecek listede ne kalıyor görmek için .diğr formlaredan çağrılmıyor. Program düzgün çalıştığında silinecek..

        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        System.Windows.Forms.CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        #endregion

        #region Properties

        public List<Student> StudentsGeneralClassList { get; set; }
        //public List<Student> StudentsInClass { get; set; } // buna gerek yok yukarıda private alan oluşturdum geçici kullanım için.

        #endregion

        public FormStudents()
        {
            InitializeComponent();
        }


        private void FormStudents_Load(object sender, EventArgs e)
        {
            AddHeaderCheckBox();
            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dataGridView.CellValueChanged += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
            dataGridView.CurrentCellDirtyStateChanged += new EventHandler(dataGridView_CurrentCellDirtyStateChanged);
            dataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView_CellPainting);

            BindGridView();

            //RefreshDataGridView();
        }

        private void BindGridView()
        {
            students = new List<Student>();

            foreach (var student in StudentsGeneralClassList)
                students.Add(student.Clone());

            TotalCheckBoxes = students.Count;
            TotalCheckedCheckBoxes = 0;
            for (int i = 0; i < TotalCheckBoxes; i++)
            {
                if (students[i].InClass)
                {
                    TotalCheckedCheckBoxes ++;
                }
            }
            //TotalCheckedCheckBoxes = TotalCheckBoxes;

            RefreshDataGridView();
        }
        //private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (!IsHeaderCheckBoxClicked)
        //        RowCheckBoxClick((DataGridViewCheckBoxCell)dataGridView[e.ColumnIndex, e.RowIndex]);
        //}


        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new System.Windows.Forms.CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dataGridView.Controls.Add(HeaderCheckBox);
        }

        private void RefreshDataGridView()
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = CreateDataTable();
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = IN_CLASS,
                DataPropertyName = "InClass",
                HeaderText = "Öğrenci Sınıfta",
                Tag = IN_CLASS
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = FIRST_NAME,
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Tag = FIRST_NAME
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = LAST_NAME,
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Tag = LAST_NAME
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = NUMBER,
                DataPropertyName = "Number",
                HeaderText = "No",
                Tag = NUMBER
            });

            dataGridView.DataSource = bindingSource;
        }


        #region DataGridView Functions

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private System.Data.DataTable CreateDataTable()
        {
            var table = new CustomDataTable();
            bool isFirst = true;

            // without Linq
            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                if (isFirst)
                {
                    //table.Columns.Add(IN_CLASS, System.Type.GetType("System.Boolean"));
                    table.Columns.Add(IN_CLASS);
                    table.Columns.Add(FIRST_NAME);
                    table.Columns.Add(LAST_NAME);
                    table.Columns.Add(NUMBER);
                    isFirst = false;
                }

                //var dataRow = (CustomDataRow)table.NewRow();
                //dataRow.ItemArray = new string[] { student.FirstName, student.LastName, student.Number.ToString() };
                //dataRow.Tag = student;
                //table.Rows.Add(dataRow);

                var dataRow = (CustomDataRow)table.NewRow();

                //dataRow["InClass"] = "true"; bu otomatik olarak checkbox u dataya bakmadan işaretli getiriyor.
                dataRow["InClass"] = student.InClass; // bu haliyle jsondakini doğru okuyor. 
                dataRow["FirstName"] = student.FirstName;
                dataRow["LastName"] = student.LastName;
                dataRow["Number"] = student.Number; 

                dataRow.Tag = student;

                table.Rows.Add(dataRow);
                table.AcceptChanges();
            }

            return table;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex != -1)
            {
                var propertyName = (string)dataGridView.Columns[e.ColumnIndex].Tag;
                var dataView = (DataRowView)bindingSource.Current;
                var dataRow = (CustomDataRow)dataView.Row;
                var newValue = dataView.Row.Field<string>(propertyName);
                var student = (Student)dataRow.Tag;

                student.GetType().GetProperty(propertyName).SetValue(student, newValue, null);
            }
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                RowCheckBoxClick((DataGridViewCheckBoxCell)dataGridView[e.ColumnIndex, e.RowIndex]);
                var propertyName = (string)dataGridView.Columns[e.ColumnIndex].Tag;
                var dataView = (DataRowView)bindingSource.Current;
                var dataRow = (CustomDataRow)dataView.Row;
                var newValue = Convert.ToBoolean(dataView.Row.Field<string>(propertyName));
                //dataView.Row.Field
                var student = (Student)dataRow.Tag;

                student.GetType().GetProperty(propertyName).SetValue(student, newValue, null);
               // student.GetType().Get
            }
        }
            //if (!IsHeaderCheckBoxClicked)
            //   

        private void dataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            dataGridView.CurrentCell = dataGridView[e.ColumnIndex, e.RowIndex];
            e.ContextMenuStrip = new ContextMenuStrip();
            e.ContextMenuStrip.Items.Add("Remove", Resources.delete, dataGridView_ContextMenuDeleteClicked);
            e.ContextMenuStrip.Show(Cursor.Position);
        }

        private void dataGridView_ContextMenuDeleteClicked(object sender, EventArgs e)
        {
            if (bindingSource?.Current != null)
            {
                if (MessageBoxHelper.QuestionYesNo(this, "Warning", "Are you sure about to remove selected student?") == DialogResult.Yes)
                {
                    var dataView = (DataRowView)bindingSource.Current;
                    var dataRow = (CustomDataRow)dataView.Row;
                    var student = (Student)dataRow.Tag;

                    students.Remove(student);
                    dataView.Delete();
                }
            }
        }


        #endregion

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void AddStudent()
        {
            if (string.IsNullOrEmpty(textBoxName.Text) ||
                string.IsNullOrEmpty(textBoxSurname.Text) ||
                string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBoxHelper.ShowWarning(this, "Please fill all the blanks.");

                if (string.IsNullOrEmpty(textBoxName.Text))
                    textBoxName.Focus();
                else if (string.IsNullOrEmpty(textBoxSurname.Text))
                    textBoxSurname.Focus();
                else if (string.IsNullOrEmpty(textBoxNumber.Text))
                    textBoxNumber.Focus();
            }
            else
            {
                var number = 0;
                if (int.TryParse(textBoxNumber.Text, out number))
                {
                    students.Add(new Student()
                    {
                        FirstName = textBoxName.Text,
                        LastName = textBoxSurname.Text,
                        Number = number,
                        InClass= true  // yeni kayıt yapılıyorsa zaten sınıftadır deyip kayıt sırasında bir daha checkbox işaretleme eklemedim.
                    });

                    RefreshDataGridView();

                    textBoxName.Text = string.Empty;
                    textBoxSurname.Text = string.Empty;
                    textBoxNumber.Text = string.Empty;

                    textBoxName.Focus();
                }
                else
                    MessageBoxHelper.ShowError(this, "Please enter student number.");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e) // aslında formdaki save butonuna tıklayınca buraya giriyoruz
        {
            DialogResult = DialogResult.OK;

            int studenttoShow = 0;
            StudentsGeneralClassList = students;

            //aşağısı test için oluşturuldu silinecek...
            //studentsInClass = students;
            //for (int i = 0; i < students.Count; i++)
            //{
            //    if (!students[i].InClass)
            //    {
            //        studentsInClass.Remove(students[i]);
            //    }
            //}
            
            //studenttoShow = studentsInClass.Count;
                //ForEach( x=> x.InClass == true));
            //DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AddStudent();
                e.Handled = true;
            }
        }


        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }


        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }



        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            System.Drawing.Rectangle oRectangle = this.dataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            System.Drawing.Point oPoint = new System.Drawing.Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dataGridView.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["InClass"]).Value = HCheckBox.Checked;

            dataGridView.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modifiy Counter;            
                //if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                {
                    TotalCheckedCheckBoxes++;
                }

                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }

    }
}
