using System.Net;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string opr;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================================Menu======================================");
                Console.WriteLine("1.Telebe elave et");
                Console.WriteLine("2.Telebeye imtahan elave et");
                Console.WriteLine("3.Telebenin bir imtahan balina bax");
                Console.WriteLine("4.Telebenin butun imtahanlarini goster");
                Console.WriteLine("5.Telebenin imtahan ortalamasini goster");
                Console.WriteLine("6.Telebeden imtahan sil");
                Console.WriteLine("0.Proqramı bitir");

                opr = Console.ReadLine();

                switch (opr)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("==============================Telebe Fullname'i daxil edin=============================");
                        string fullname = Console.ReadLine();
                        bool check = CheckStudentFullname(fullname);
                        Console.Clear();
                        if (check)
                        {
                            Student student = new Student(fullname);
                            students.Add(student);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Telebe elave edildi!!!!");
                        }
                        else 
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Telebe elave edile bilmedi!!!!");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("========================================Telebe nomresini daxil edin======================================");
                        string studentNoStr = Console.ReadLine();
                        int StudentNo;
                        Console.Clear();
                        Console.WriteLine("========================================Imtahan adini daxil edin======================================");
                        string examName = Console.ReadLine();
                        bool check1 = checkExamName(examName);
                        Console.Clear();
                        Console.WriteLine("========================================Imtahan balini daxil edin======================================");
                        string pointStr = Console.ReadLine();
                        double point;
                        Console.Clear();
                        bool look = false;
                        if (pointStr != null&& studentNoStr != null && check1 && double.TryParse(pointStr,out point)&& int.TryParse(studentNoStr, out StudentNo))
                        { 
                            foreach(var item in students)
                            {
                                if (item.No == StudentNo)
                                {
                                    item.AddExam(examName,point);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Imtahan elave edildi!!!!!!");
                                    look =true;
                                    break;

                                }
                            }
                            if (!look)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Imtahan elave edile bilmedi!!!!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Imtahan elave edile bilmedi!!!!");
                        }

                        break;
                    case "3":
                        Console.WriteLine("===================================Telebe nomresi daxil edin============================");
                        string studentNo1Str = Console.ReadLine();
                        int Student1No;
                        Console.Clear();
                        Console.WriteLine("========================================Imtahan adini daxil edin======================================");
                        string exam1Name = Console.ReadLine();
                        bool check2 = checkExamName(exam1Name);
                        if ( studentNo1Str != null && check2 &&  int.TryParse(studentNo1Str, out StudentNo))
                        {
                            foreach(var item in students)
                            {
                                if(item.No == StudentNo)
                                {
                                    double result =item.GetExamResult(exam1Name);
                                    Console.WriteLine($"Imtahanin bali:{result}");
                                }
                            }
                            
                        }

                        
                        break;
                    case "4":
                        Console.WriteLine("===================================Telebe nomresi daxil edin============================");
                        string noStr =Console.ReadLine();
                        int no;
                        List<string> select = new List<string>();
                        List<double> select1 = new List<double>();
                        if (noStr != null &&int.TryParse(noStr,out no))
                        {                          
                            foreach (var item in students)
                            {                                
                               if(item.No == no)
                               {
                                    foreach (var item2 in item.Exams.Keys)
                                    {
                                        select.Add(item2);
                                    }
                                    foreach (var item2 in item.Exams.Values)
                                    {
                                        select1.Add(item2);
                                    }
                                    for (int i = 0; i < item.Exams.Count; i++)
                                    {
                                        Console.WriteLine($"Imtahan adi {select[i]} Imtahan bali:{select1[i]}");
                                    }
                               }
                            }

                            
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("===================================Telebe nomresi daxil edin============================");
                        string no1str = Console.ReadLine();
                        int no1;
                        double avrg;
                        if (no1str != null && int.TryParse(no1str,out no1))
                        {
                            foreach(var item in students)
                            {
                                if(item.No == no1)
                                {
                                    avrg = item.GetExamAvg();
                                    Console.WriteLine($"Telebe ortalamasi :{avrg}");
                                }
                            }
                        }
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("===============================Telebe nomresini  daxil edin ============================");
                        string no6str = Console.ReadLine();
                        int no6;
                        Console.WriteLine("==================================Imtahan adini daxil edin ==================================");
                        
                        string studentNo6 = Console.ReadLine();

                        if (studentNo6 != null && no6str != null && int.TryParse(no6str, out no6))
                        {
                            foreach(var item in students)
                            {
                                if (item.No ==no6)
                                {
                                    item.RemoveExam(studentNo6);
                                }
                            }
                        }
                        else { Console.WriteLine("Siline bilmedi!!!!!!!");}
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            while (opr != "0");
        }
        static bool CheckStudentFullname(string Str)
        {
            if (Str != null && Str.Length>2 && Str.Length<30)
            {
                return true;
            }
            else { return false; }
        }
        static bool checkExamName(string exam)
        {
            if (exam != null && exam.Length > 2 && exam.Length < 30)
            {
                return true;
            }
            else { return false; }
        }
    }
    
}
