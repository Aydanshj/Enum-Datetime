using System;
using System.Text.RegularExpressions;

namespace HomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Group[] groups = new Group[0];
            string opt;
            do
            {
                Console.WriteLine("1. qrup daxil edin");
                Console.WriteLine("2. qruplara bax");
                Console.WriteLine("3. deyere gore qruplara bax");
                Console.WriteLine("4: bu gune qeder olan qruplara bax");
                Console.WriteLine("5: son iki ayda baslamis qruplara bax");
                Console.WriteLine("6: bu ayin sonuna qeder baslayacaq qruplara bax");
                Console.WriteLine("7: verilmis iki tarix arasinda olan qruplara bax");
                Console.WriteLine("0. menudan cix");
                Console.WriteLine("zehmet olmasa emeliyyat secin");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Write("No:  ");
                        string No = Console.ReadLine();
                        Console.Write("Type:  ");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");

                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;
                        Console.Write("StartDate:  ");
                        string Datestr = Console.ReadLine();
                        DateTime StartDate = Convert.ToDateTime(Datestr);

                        Group group = new Group
                        {
                            No = No,
                            Type = type,
                            StartDate = StartDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":


                        foreach (var Group in groups)
                        {
                            Console.WriteLine($"No: {Group.No} - Type: {Group.Type} - StartDate: {Group.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;
                        foreach (var grp in groups)
                        {
                            if (grp.Type == type)
                            {
                                Console.WriteLine($"No: {grp.No} - Type: {grp.Type}  - StartDate:  {grp.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "4":
                        int count = 0;
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type}  - StartDate:  {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("There is no such group");
                        }
                        break;
                    case "5":

                        foreach (var grop in groups)
                        {
                            if (grop.StartDate > DateTime.Now.AddMonths(-2) && grop.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {grop.No} - Type: {grop.Type}  - StartDate:  {grop.StartDate.ToString("dd-MM-yyyy HH:mm")}");

                            }
                        }

                        break;
                    case "6":

                        foreach (var groupgr in groups)
                        {
                            if (grop.StartDate.Year > DateTime.Now.Year && grop.StartDate.Month > DateTime.Now.Month && grop.StartDate.Day > DateTime.Now.Day)
                            {
                                Console.WriteLine($"No: {groupgr.No} - Type: {groupgr.Type}  - StartDate:  {groupgr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }

                        break;
                    case "7":
                        Console.WriteLine("Enter the first date");
                        string firstDate = Console.ReadLine();
                        DateTime FirstDate = Convert.ToDateTime(firstDate);

                        Console.WriteLine("Enter the second date");
                        string secondDate = Console.ReadLine();
                        DateTime SecondDate = Convert.ToDateTime(secondDate);

                        foreach (var group1 in groups)
                        {
                            if (group1.StartDate > FirstDate && group1.StartDate < SecondDate)
                            {
                                Console.WriteLine($"No: {group1.No} - Type: {group1.Type}  - StartDate:  {group1.StartDate.ToString("dd-MM-yyyy HH:mm")}");

                            }
                        }

                        break;

                    case "0":
                        Console.WriteLine("Program bitdi");
                        break;
                    default:
                        Console.WriteLine("Seciminiz sehvdir");
                        break;
                }

            } while (opt != "0");


        }
    }
}
