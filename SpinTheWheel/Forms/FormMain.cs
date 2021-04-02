using SpinTheWheel.Data;
using SpinTheWheel.Enum;
using SpinTheWheel.Utility;
using SpinTheWheel.Utility.SettingsManager.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpinTheWheel.Forms
{
    public partial class FormMain : Form
    {
        //private List<Student> studentsInList;
        //private List<Student> studentsReadyInClass;
        private IEnumerable<Student> studentsGeneralClassList;
        private IEnumerable<Student> studentsReadyInClass;
        //List<T> newList = new List<T>(ListToCopy); //c# copy list without reference

        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            studentsGeneralClassList = StudentLoader.Load();
            //studentsReadyInClass = StudentLoader.LoadWheel(); wheel i doldurmak için loader da bir yöntem yapmıştım onu iptal ettim aşağıdaki daha mantıklı.
            //aşağıdak iki satır Lİst kullanınıca çalışabilir. Ayıklamayı iki kademede yapabiliyorum List ile 
            // studentsReadyInClass = studentsGeneralClassList; // önce kopyalıyorum, aşağıda ayıklıyorum.
            //studentsReadyInClass.RemoveAll(x => x.InClass == false); //int döner ve listeden iclass ı false olan elemaları siler

            // yukarıdakini aksine IEnumerable kullanırsam doğrudan where ile ayıklamayı bir kerede yapabliyorum.
            studentsReadyInClass = studentsGeneralClassList.Where(x => x.InClass == true); //int döner ve listeden iclass ı false olan elemaları siler

            int test = studentsReadyInClass.Count();
           
            spinnerWheel.StudentsReadyInClass = studentsReadyInClass.ToList();  // StudentsReadyInClass-->list but studentsReadyInClass--> IEnumerable list. Aktarbilmek için sonuna ToList eklemliyiz.

            spinnerWheel.AnimationEnabled = SettingsManager.Instance.Get(SettingName.ANIMATION_ENABLED, true);
            spinnerWheel.AnimationEndWaitDuration = SettingsManager.Instance.Get(SettingName.ANIMATION_WAIT_DURATION, 2500);
            spinnerWheel.FontSize = SettingsManager.Instance.Get(SettingName.FONT_SIZE, 9);
            spinnerWheel.StudentReelectionInSession = SettingsManager.Instance.Get(SettingName.PICK_STUDENT_AGAIN, true);

            spinnerWheel.RefreshSpinner();

            spinnerWheel.OnStudentSelected += SpinnerWheel_OnStudentSelected;

            labelClassName.Text = SettingsManager.Instance.Get(SettingName.CLASS_NAME, "Name of Classroom");
            labelClassName.Font = FontHelper.GetFont(labelClassName.Font.Size);
            labelSelectedStudent.Font = FontHelper.GetFont(labelSelectedStudent.Font.Size);

        }

        private void SpinnerWheel_OnStudentSelected(object sender, Controls.Events.StudentSelectedEventArgs e)
        {
            labelSelectedStudent.Text = e.Student.FirstName + " " + e.Student.LastName + Environment.NewLine + "No: " + e.Student.Number;
           
        }

        private void toolStripMenuItemFileSettings_Click(object sender, EventArgs e)
        {
            var formSettings = new FormSettings()
            {
                StudentsGeneralClassList = studentsGeneralClassList.ToList()
            };
            if (formSettings.ShowDialog(this) == DialogResult.OK)
            {
                labelClassName.Text = SettingsManager.Instance.Get(SettingName.CLASS_NAME, string.Empty);
                spinnerWheel.AnimationEndWaitDuration = SettingsManager.Instance.Get(SettingName.ANIMATION_WAIT_DURATION, 2500);

                if (formSettings.StudentsChanged)
                {
                    studentsGeneralClassList = formSettings.StudentsGeneralClassList;
                    StudentLoader.Save(studentsGeneralClassList.ToList());
                }

                spinnerWheel.StudentsReadyInClass = studentsGeneralClassList.Where(x => x.InClass == true).ToList();
                spinnerWheel.FontSize = SettingsManager.Instance.Get(SettingName.FONT_SIZE, 9);
                spinnerWheel.RefreshSpinner();
            }

        }

        private void toolStripMenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        public void AddItemToListBoxSelectedStudents(string selectedStudent)
        {
            this.ListBoxSelectedStudents.Items.Add(selectedStudent);
        }

        private void btnResetList_Click(object sender, EventArgs e)
        {
            ListBoxSelectedStudents.Items.Clear();
        }
    }
}
