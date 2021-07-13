using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}
