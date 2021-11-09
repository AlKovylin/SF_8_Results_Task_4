using System;
using System.Collections.Generic;
using System.Text;

namespace SF_8_Results_Task_4
{
    class Students
    {
        List<Student> Students_ = new List<Student>();

        public void CreatList()
        {
            Students_.Add(new Student("Василий", "1", new DateTime(2001, 12, 25)));
        }
    }
}
