using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace CsvFileReader
{
    public static class ReadStyreGruppeMedlemmer
    {
        static readonly string rootFolder = @"C:\Temp";
        static readonly string textFile = @"styregruppemedlemmer.txt";
        //string filepathProject = "C:\\Repos\\CsvFileReader\\CsvFileReader\\Archive\\";

        public static void ReadFileAndPrint()
        {
            Console.WriteLine("");
            Console.WriteLine("Start programmet ved at klikke en vilkårlig knap");
            Console.ReadKey();

            string filepath = $"{rootFolder}\\{textFile}";

            if (!File.Exists(filepath))
            {
                Console.WriteLine("");
                Console.WriteLine($"Der er ikke nogen txt fil under: {filepath}");
                Console.ReadKey();
            }

            using (var reader = new StreamReader(@"C:\Temp\styregruppemedlemmer.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Der er en fejl i txt filen");
                        Console.ReadKey();
                    }
                    else
                    {
                        var values = line.Split(',');
                        string firstname = string.Empty;
                        string middlename = string.Empty;
                        string lastname = string.Empty;

                        try
                        {
                            firstname = values[0];
                            middlename = values[1];
                            lastname = values[2];
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Der er fejl i txt filen");
                            Console.WriteLine("");
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }

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
                Console.WriteLine("");
                Console.WriteLine("Programmet er afsluttet successfuldt");
                Console.ReadKey();
            }
        }
    }
}
