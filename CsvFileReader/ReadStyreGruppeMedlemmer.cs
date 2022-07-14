using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CsvFileReader
{
    public static class ReadStyreGruppeMedlemmer
    {
        public static void ReadFileAndPrint()
        {
            string filename = "styregruppemedlemmer.txt";

            using (var reader = new StreamReader(@"C:\Repos\CsvFileReader\CsvFileReader\Archive\" + filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("der er en tom linie");
                        Console.ReadKey();
                    }
                    else
                    {
                        var values = line.Split(',');

                        string firstname = values[0];
                        string middlename = values[1];
                        string lastname = values[2];

                        //Console.WriteLine($"INSERT [dbo].[WorkAddresses] ([Location], [Created], [LastUpdated]) VALUES (N\'{line}\', NULL, NULL)");
                        //Console.WriteLine($"INSERT [dbo].[Titles] ([Name], [Created], [LastUpdated]) VALUES (N'{line}', NULL, NULL)");
                        Console.WriteLine(
                            $"INSERT [dbo].[People] " +
                            $"(" +
                                $"[FirstName], " +
                                $"[MiddleName], " +
                                $"[LastName], " +
                                $"[Email], " +
                                $"[PhoneNumber], " +
                                $"[Deactivated], " +
                                $"[TitleExtra], " +
                                $"[CompanyAffiliationExtra], " +
                                $"[WorkAddressExtra], " +
                                $"[CountryRegionExtra], " +
                                $"[TitleId], " +
                                $"[CompanyAffiliationId], " +
                                $"[WorkAddressId], " +
                                $"[CountryRegionId], " +
                                $"[Created], " +
                                $"[LastUpdated] " +
                            $") " +
                            $"VALUES " +
                            $"(" +
                                $"N'{firstname}', " +
                                $"'{middlename}', " +
                                $"'{lastname}', " +
                                $"NULL, " + //email
                                $"NULL, " + //phone
                                $"0, " + //deactivate = false
                                $"NULL, " + //TitleExtra
                                $"NULL, " + //CompanyAffiliationExtra
                                $"NULL, " + //WorkAddressExtra
                                $"NULL, " + //CountryRegionExtra
                                $"NULL, " + //TitleId
                                $"NULL, " + //CompanyAffiliationId
                                $"NULL, " + //WorkAddressId
                                $"NULL, " + //CountryRegionId
                                $"NULL, " + //Created
                                $"NULL " + //LastUpdated
                             $")");

                        firstname = string.Empty;
                        middlename = string.Empty;
                        lastname = string.Empty;
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
