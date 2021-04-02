using SpinTheWheel.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinTheWheel.Utility
{
    public class StudentLoader
    {
        private const string FILENAME = "students.json";
        private const string FIRST_NAME = "firstName";
        private const string LAST_NAME = "lastName";
        private const string NUMBER = "number";
        private const string IN_CLASS = "inClass";

        public static List<Student> Load(string fileName = FILENAME)
        {
            var studentsInList = new List<Student>();

            if (File.Exists(fileName))
            {
                try
                {
                    var contents = File.ReadAllText(fileName);
                    var jArrayStudents = JArray.Parse(contents);
                    foreach (JObject jObjectStudent in jArrayStudents)
                    {

                        studentsInList.Add(new Student()
                        {
                            FirstName = JObjectHelper.GetString(jObjectStudent, FIRST_NAME),
                            LastName = JObjectHelper.GetString(jObjectStudent, LAST_NAME),
                            Number = JObjectHelper.GetInt32(jObjectStudent, NUMBER),
                            InClass = JObjectHelper.GetBoolean(jObjectStudent, IN_CLASS)
                        });
                    }

                    return studentsInList;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError($"Student could not be loaded. Error message: {ex.Message}");
                    return studentsInList;
                }
            }

            return studentsInList;
        }

        public static List<Student> LoadWheel(string fileName = FILENAME)
        {
            var studentsReadyInClass = new List<Student>();

            if (File.Exists(fileName))
            {
                try
                {
                    var contents = File.ReadAllText(fileName);
                    var jArrayStudents = JArray.Parse(contents);
                    foreach (JObject jObjectStudent in jArrayStudents)
                    {
                        if (JObjectHelper.GetBoolean(jObjectStudent, IN_CLASS))
                        {
                            studentsReadyInClass.Add(new Student()
                            {
                                FirstName = JObjectHelper.GetString(jObjectStudent, FIRST_NAME),
                                LastName = JObjectHelper.GetString(jObjectStudent, LAST_NAME),
                                Number = JObjectHelper.GetInt32(jObjectStudent, NUMBER),
                                InClass = JObjectHelper.GetBoolean(jObjectStudent, IN_CLASS)
                            });
                        }
                       
                    }

                    return studentsReadyInClass;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError($"Student could not be loaded. Error message: {ex.Message}");
                    return studentsReadyInClass;
                }
            }

            return studentsReadyInClass;
        }

        public static bool Save(List<Student> students, string fileName = FILENAME)
        {
            try
            {
                var jArrayStudents = new JArray();
                foreach (var student in students)
                {
                    jArrayStudents.Add(new JObject()
                    {
                        [FIRST_NAME] = student.FirstName,
                        [LAST_NAME] = student.LastName,
                        [NUMBER] = student.Number,
                        [IN_CLASS]= student.InClass
                    });
                }

                File.WriteAllText(fileName, jArrayStudents.ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError($"Student could not be saved. Error message: {ex.Message}");
                return false;
            }
        }
    }
}
