using System;

namespace SF_8_Results_Task_4
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }//Группа
        public DateTime DateOfBirth { get; set; }//Дата рождения

        public Student() { }

        public Student(string Name, string Group, DateTime DateOfBirth) 
        {
            this.Name = Name;
            this.Group = Group;
            this.DateOfBirth = DateOfBirth;
        }
    }
}
