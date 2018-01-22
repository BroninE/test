using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDWorkerApp;
using System.Collections.Generic;

namespace BDWorkerAppTests
{
    [TestClass]
    public class WorkerManagerTests
    {
        [TestMethod]
        public void DeleteWorker_0_and_ListWorkers_true_returned()
        {
            // исходные данные
            string Number = "Id:2";
            List<Company> Workers = new List<Company>();
            bool expected = true;

            Workers.Add(new Company()
            {
                Id = 2,
                FirstName = "Egor",
                LastName = "Bronin",
                SalaryPerHour = 20.50M
            });

            Workers.Add(new Company()
            {
                Id = 3,
                FirstName = "Egor2",
                LastName = "Bronin2",
                SalaryPerHour = 20.50M
            });
            // получение значения с помощью тестируемого метода
            WorkerManager manager = new WorkerManager();

            bool actual = manager.deleteWorkers(Number, ref Workers);

            // сравнение ожидаемого результата с полученным
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void DeleteWorker_5_and_ListWorkers_false_returned()
        {
            // исходные данные
            String Number = "Id:5";
            List<Company> Workers = new List<Company>();
            bool expected = false;

            Workers.Add(new Company()
            {
                Id = 2,
                FirstName = "Egor",
                LastName = "Bronin",
                SalaryPerHour = 20.50M
            });

            Workers.Add(new Company()
            {
                Id = 3,
                FirstName = "Egor2",
                LastName = "Bronin2",
                SalaryPerHour = 20.50M
            });
            // получение значения с помощью тестируемого метода
            WorkerManager manager = new WorkerManager();

            bool actual = manager.deleteWorkers(Number, ref Workers);

            // сравнение ожидаемого результата с полученным
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void DeleteWorker_Id1_and_ListWorkers_false_returned()
        {
            // исходные данные
            String Number = "Id1";
            List<Company> Workers = new List<Company>();
            bool expected = false;

            Workers.Add(new Company()
            {
                Id = 2,
                FirstName = "Egor",
                LastName = "Bronin",
                SalaryPerHour = 20.50M
            });

            Workers.Add(new Company()
            {
                Id = 3,
                FirstName = "Egor2",
                LastName = "Bronin2",
                SalaryPerHour = 20.50M
            });
            // получение значения с помощью тестируемого метода
            WorkerManager manager = new WorkerManager();

            bool actual = manager.deleteWorkers(Number, ref Workers);

            // сравнение ожидаемого результата с полученным
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);


        }
    }
}
