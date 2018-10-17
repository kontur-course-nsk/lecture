using System;
using CleanCode.Examples;

namespace CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void RunExample1()
        {
            Example1.GetResult(new DateTime(1988, 10, 15));
        }

        private static void RunExample2()
        {
            var car = new Example2.Car();
            car.CarName = "Name";
            car.DateOfTheExport = 1990;
            car.ManagerPhoneString = "+7923000000";
        }

        private static void RunExample3()
        {
            var temp = new Example3();
            temp.srvcprt = 8080;
            temp.employeeemail = "test@kontur.ru";
        }

        private static void RunExample4()
        {
            var accountList = new Example4.AccountList();
            var phoneList = new Example4.PhoneList();
            var documentList = new Example4.DocumentListManager();

            accountList.Add("asd");
            accountList.Add("xxx");
            accountList.Remove("xxx");

            phoneList.Add("123");
            phoneList.Add("345");
            phoneList.Delete("444");
            var phone = phoneList.Search();

            documentList.PutNew("doc1");
            documentList.PutNew("doc2");
            documentList.Remove("doc2");
            var doc = documentList.Find();
        }

        private static void RunExample12()
        {
            Example12.CreateFile("file1", "aaaa", true);

            Example12.CreateFile("file2", "bbbbbbb", false);
        }
    }
}
