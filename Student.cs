using System;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }//Группа
        public DateTime DateOfBirth { get; set; }//Дата рождения
    }
}
