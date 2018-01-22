using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Company man("-update",1,"Egor","Bronin");
            //Company man2("-add",2,"Galina","Gerasimenko");
            //Company* people = new Company[2] { man, man2 }; // можно поробовать использовать вектор чтобы не указывать размер массива
            int numberFunction = 7;

            if (!(args.Length == 0))// если передаем аргументы, то argc будет больше 1(в зависимости от кол-ва аргументов)
            {
                string test;
                test = args[1]; // потому что прога некорректно сравнивает строку с чар
                                              //cout <<argv[1]<<endl;
                if (test == "-add") { numberFunction = 0; }
                if (test == "'-update'") { numberFunction = 1; }
                if (test == "-get") { numberFunction = 2; }
                if (test == "-delete") { numberFunction = 3; }
                if (test == "-getall") { numberFunction = 4; }
                else  numberFunction = 5;

                switch (numberFunction) //Тут лучше вызывать метод класса контейнера, где прописаны работы этих функций 
                {
                    case 0:
                        System.Console.WriteLine("add function"); // в векторе добавляем новый объект и т.д. все через вектор
                        break;
                    case 1:
                        System.Console.WriteLine("update function");
                        break;
                    case 2:
                        System.Console.WriteLine("get function");
                        break;
                    case 3:
                        System.Console.WriteLine("delete function");
                        break;
                    case 4:
                        System.Console.WriteLine("getall function");
                        break;
                    default:
                        System.Console.WriteLine("unknow function");
                        break;
                }
                //for (int i = 2; i < argc; i++)
                //{

                    //people[1].firstName=argv[i];
                    //people[1].firstName.erase(0,people[1].firstName.find(':')+1);
                    //cout << people[1].firstName<<endl;

                    //for (i = 0; i <= 1; i++)
                    //{
                        //cout << "people[" << i << "].firstName:  " << people[i].firstName << endl;
                    //}


                
            }
            else
            {
                System.Console.WriteLine( "Not arguments");
                Console.ReadKey();
            }
        }
    }
}
