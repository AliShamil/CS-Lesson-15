using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace CS_Lesson_15;



internal class Program
{


    static void Main()
    {

        List<Reception> receptionTimes = new List<Reception>()
        {
            new Reception(new TimeOnly(9,0),new TimeOnly(11,0)),
            new Reception(new TimeOnly(12, 0),new TimeOnly(14, 0)),
            new Reception(new TimeOnly(15, 0),new TimeOnly(17, 0)),
        };


        List<Doctor> Pediatrics = new List<Doctor>()
        {
            new("Tyson" ,"Claye" , 22,receptionTimes),
            new("Lenard" ,"Cheyenne" , 5,receptionTimes),
            new("Freeman" ,"Heskin" , 11,receptionTimes),
            new("Cory" ,"Sharrem" , 3,receptionTimes)
        };


        List<Doctor> Traumatology = new List<Doctor>()
        {
            new("Maurizio" ,"Cheyenne" , 7,receptionTimes),
            new("Delmor" ,"Bosley" , 1,receptionTimes),
            new("Bondie" ,"Kelner" , 4,receptionTimes)
        };

        List<Doctor> Stomatology = new List<Doctor>()
        {
            new("Johny" ,"Sins" , 31,receptionTimes),
            new("Hanson" ,"Meuse" , 2,receptionTimes),
            new("Nehemiah" ,"Knowlden" , 8,receptionTimes),
            new("Lenci" ,"Huxham" , 12,receptionTimes),
            new("Brewster" ,"Ruslinge" , 21,receptionTimes)
        };



        bool clinic = false;


        Console.WriteLine("\n\n\n\n\n\t\t\t\t\tWELCOME");
        Thread.Sleep(1500);
        while (true)
        {
            Console.Clear();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Phone number: ");
            string phone = Console.ReadLine()!;

            Patient patient;

            try
            {
                patient = new(name, surname, email, phone);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey(false);
                continue;
            }


            clinic = false;
            while (!clinic)
            {
                Console.Clear();
                List<Doctor> doctors = null!;
                Doctor currentDoc;
                int row;
                Console.Write(@"
1. Pediatrics
2. Traumatology
3. Stomatology
0. Exit

Pls select: ");

                switch (Console.ReadLine())
                {
                    case "1":

                        doctors = Pediatrics;

                        break;

                    case "2":
                        doctors= Traumatology;
                        break;

                    case "3":
                        doctors = Stomatology;
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("GOOD BYE!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown command !");
                        Thread.Sleep(1500);
                        break;
                }

                while (true)
                {
                    Console.Clear();
                    row = 1;
                    foreach (var doctor in doctors)
                    {
                        Console.WriteLine($"{row++}) {doctor}\n");
                    }

                    Console.Write("Pls select: ");

                    try
                    {
                        if (!int.TryParse(Console.ReadLine(), out int result))
                            throw new InvalidCastException("Invalid Choice!");
                        if (result <= 0 || result > Pediatrics.Count)
                            throw new IndexOutOfRangeException("Invalid Choice!");

                        currentDoc = doctors[--result];
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1500);
                        continue;
                    }

                    while (true)
                    {
                        Console.Clear();
                        row = 1;
                        foreach (var receptionTime in currentDoc.ReceptionTimes)
                        {
                            Console.WriteLine($"{row++}) {receptionTime}");
                        }
                        Console.Write("\nPls select: ");

                        try
                        {
                            if (!int.TryParse(Console.ReadLine(), out int time))
                                throw new InvalidCastException("Invalid Choice!");
                            if (time <= 0 || time > currentDoc.ReceptionTimes.Count)
                                throw new IndexOutOfRangeException("Invalid Choice!");


                            if (currentDoc.ReceptionTimes[time - 1].ReservedPatient is not null)
                                throw new ArgumentException("This Time is already reserved!");

                            currentDoc.ReceptionTimes[time - 1].ReservedPatient = patient;
                            Console.WriteLine($"{patient.Name} {patient.Surname},you signed up for doctor {currentDoc.Name} {currentDoc.Surname}'s appointment between {currentDoc.ReceptionTimes[time - 1].RandevuTimeStart} and {currentDoc.ReceptionTimes[time - 1].RandevuTimeEnd}.");
                            clinic = true;
                            Console.ReadKey(false);

                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
                            Thread.Sleep(1500);
                            continue;
                        }
                        break;
                    }

                    break;
                }


            }




        }




    }
}
