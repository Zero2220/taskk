using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public Student(string fullname)
        {
            this.Fullname = fullname;
            this.No=NoCount;
            NoCount++;
        }
        
        public static int NoCount =0;
        public int No;
        public string Fullname;
        public Dictionary<string, double> Exams = new Dictionary<string, double>();


        public void AddExam(string examName,double point)
        {
            Exams.Add(examName, point);
        }
        public double GetExamResult(string examName)
        {
            double key=0;
            foreach(var student in Exams.Values)
            {
                key = student;
            }
            return key;
        }   
        public double GetExamAvg()
        {
            double sum=0;
            int count=0;
            foreach(var student in Exams.Values)
            {
                sum += student;
                count++;
            }
            return sum/count;            
        }
        public void RemoveExam(string exam)
        {
            Exams.Remove(exam);
        }
        
    }
}
