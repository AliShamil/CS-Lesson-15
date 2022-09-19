using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15;

internal class Doctor
{
    private string? name;
    private string? surname;
    private int workExperiemce = 0;


    public string? Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value)|| value.Length<3)
                throw new ArgumentException("Incorrect Name!");
            name = value;
        }
    }


    public string? Surname
    {
        get { return surname; }
        set
        {
            if (string.IsNullOrWhiteSpace(value)|| value.Length<3)
                throw new ArgumentException("Incorrect Surname!");
            surname = value;
        }
    }


    public int WorkExperiennce
    {
        get { return workExperiemce; }
        set
        {
            if (value < workExperiemce)
                throw new ArgumentException("value < previous experience");
            workExperiemce = value;
        }
    }

    public List<Reception> ReceptionTimes;

    public Doctor(string? name, string? surname, int workExperiennce, List<Reception> receptionTimes)
    {
        Name=name;
        Surname=surname;
        WorkExperiennce=workExperiennce;
        ReceptionTimes=receptionTimes;
    }


    public override string ToString()
=> $@"
Name: {Name}
Surname: {Surname}
Work Experience: {workExperiemce} years";
}
