using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileReader
{
    public static class ReadRoles
    {
        public static void ReadFileAndPrint()
        {
            using (var reader = new StreamReader(@"C:\temp\roles.csv"))
            {
                //List<string> listA = new List<string>();
                //List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    //var values = line.Split(';');

                    //listA.Add(values[0]);
                    //listB.Add(values[1]);

                    //Console.WriteLine($"INSERT [dbo].[WorkAddresses] ([Location], [Created], [LastUpdated]) VALUES (N\'{line}\', NULL, NULL)");
                    //Console.WriteLine($"INSERT [dbo].[Titles] ([Name], [Created], [LastUpdated]) VALUES (N'{line}', NULL, NULL)");
                    Console.WriteLine($"INSERT [dbo].[ClientRoles] ([Name]) VALUES (N'${line}')");
                }
                Console.ReadKey();
            }
        }
    }
}
