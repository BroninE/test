using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;

namespace BDWorkerApp
{
    public class WorkerManager
    {

        static public int getNumberWorker(int idWantedWorker, ref List<Company> Workers)
        {
            int j = 0;
            while (j <= Workers.Count - 1)
            {
                if (Workers[j].Id == idWantedWorker)
                {
                    return j;
                }
                j = j + 1;
            }
            return j + 1;
        }

        public bool addWorker(ref string[] arg, ref List<Company> Workers)
        {
            int MaxId = 0;

            if (!(Workers == null))
            {
                for (int i = 0; i <= Workers.Count - 1; i++)
                {
                    if (Workers[i].Id > MaxId)
                    {
                        MaxId = Workers[i].Id;
                    }
                }
            }

            try
            {
                Workers.Add(new Company()
                {
                    Id = MaxId + 1,
                    FirstName = arg[1].Remove(0, arg[1].IndexOf(':') + 1),
                    LastName = arg[2].Remove(0, arg[2].IndexOf(':') + 1),
                    SalaryPerHour = Decimal.Parse(arg[3].Remove(0, arg[3].IndexOf(':') + 1), CultureInfo.InvariantCulture)
                });

                File.WriteAllText(@"D:\movie.json", JsonConvert.SerializeObject(Workers));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool updateWorker(string requestedId, ref string[] arg, ref List<Company> Workers)
        {
            try
            {
                int numberUpdateWorker = getNumberWorker(int.Parse(requestedId.Remove(0, requestedId.IndexOf(':') + 1)), ref Workers);

                if (numberUpdateWorker > Workers.Count)
                {
                    throw new System.ArgumentOutOfRangeException();
                }

                int numberField = 4;

                string field = arg[2].Remove(arg[2].IndexOf(':'), arg[2].Length - arg[2].IndexOf(':'));

                if (field == "Id") { numberField = 0; }
                if (field == "FirstName") { numberField = 1; }
                if (field == "LastName") { numberField = 2; }
                if (field == "SalaryPerHour") { numberField = 3; }

                switch (numberField)
                {
                    case 0:
                        System.Console.WriteLine("Don't change Id");
                        throw new System.ArgumentException();
                    case 1:
                        Workers[numberUpdateWorker].FirstName = arg[2].Remove(0, arg[2].IndexOf(':') + 1);
                        break;
                    case 2:
                        Workers[numberUpdateWorker].LastName = arg[2].Remove(0, arg[2].IndexOf(':') + 1);
                        break;
                    case 3:
                        Workers[numberUpdateWorker].SalaryPerHour = Decimal.Parse(arg[2].Remove(0, arg[2].IndexOf(':') + 1), CultureInfo.InvariantCulture);
                        break;
                    default:
                        System.Console.WriteLine("unknow field");
                        throw new System.ArgumentException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                System.Console.WriteLine("Id not found.");
                return false;
            }
            catch
            {
                System.Console.WriteLine("Error.");
                return false;
            }

            File.WriteAllText(@"D:\movie.json", JsonConvert.SerializeObject(Workers));
            return true;
        }

        public bool getWorkers(string requestedId, ref List<Company> Workers)
        {
            try
            {
                int numberGetWorker = getNumberWorker(int.Parse(requestedId.Remove(0, requestedId.IndexOf(':') + 1)), ref Workers);

                if (numberGetWorker > Workers.Count)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                string workerOut = "Id = " + Workers[numberGetWorker].Id +
                                   ", FirstName = " + Workers[numberGetWorker].FirstName +
                                   ", LastName = " + Workers[numberGetWorker].LastName +
                                   ", SalaryPerHour = " + Workers[numberGetWorker].SalaryPerHour;
                System.Console.WriteLine(workerOut);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                System.Console.WriteLine("Id not found.");
                return false;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Incorrerct Format Id");
                Console.ReadKey();
                return false;
            }
            catch
            {
                System.Console.WriteLine("Incorrerct Id2");
                Console.ReadKey();
                return false;
            }
        }

        public bool deleteWorkers(string requestedId, ref List<Company> Workers)
        {
            try
            {
                int numberDeleteWorker = getNumberWorker(int.Parse(requestedId.Remove(0, requestedId.IndexOf(':') + 1)), ref Workers);
                if (numberDeleteWorker > Workers.Count)
                    {
                        throw new System.ArgumentOutOfRangeException();
                    }
                Workers.RemoveAt(numberDeleteWorker);
                File.WriteAllText(@"D:\movie.json", JsonConvert.SerializeObject(Workers));
                return true;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Incorrerct Format Id.");
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                System.Console.WriteLine("Id not found.");
                return false;
            }
            catch
            {
                System.Console.WriteLine("Incorrerct Id2.");
                return false;
            }
        }

        public bool getAllWorkers(ref List<Company> Workers)
        {
            try
            {
                if (!(Workers.Count == 0))
                {
                    for (int k = 0; k <= Workers.Count - 1; k++)
                    {
                        string workersOut = "Id = " + Workers[k].Id +
                                            ", FirstName = " + Workers[k].FirstName +
                                            ", LastName = " + Workers[k].LastName +
                                            ", SalaryPerHour = " + Workers[k].SalaryPerHour;
                        System.Console.WriteLine(workersOut);
                    }
                }
                else
                {
                    System.Console.WriteLine("There are no posts to display");
                    return false;
                }
                return true;
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("There are no posts to display");
                return false;
            }
            catch
            {
                System.Console.WriteLine("Error.");
                return false;
            }

        }
    }
}
