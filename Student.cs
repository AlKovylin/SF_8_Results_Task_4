using System;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }//Группа
        public DateTime DateOfBirth { get; set; }//Дата рождения
        //public string DateOfBirth { get; set; }

        public Student() { }

        public Student(string Name, string Group, DateTime DateOfBirth) 
        {
            this.Name = Name;
            this.Group = Group;
            this.DateOfBirth = DateOfBirth;
        }
        
        /*public Student(string Name, string Group, string DateOfBirth)
        {
            this.Name = Name;
            this.Group = Group;
            this.DateOfBirth = DateOfBirth;
        }*/
    }
}
