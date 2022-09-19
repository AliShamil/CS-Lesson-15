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



            while (!clinic)
            {
                Console.Clear();
                Console.Write(@"
1. Pediatrics
2. Traumatology
3. Stomatology
0. Exit

Pls select: ");
            }




        }




    }
}