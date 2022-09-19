using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS_Lesson_15;

internal class Patient
{
    #region Helper_func

    protected bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    protected const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

    protected static bool IsPhoneNbr(string number)
    {
        if (number != null) return Regex.IsMatch(number, motif);
        else return false;
    }

    #endregion

    private string? name;
    private string? surname;
    private string? email;
    private string? phone;


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


    public string? Email
    {
        get { return email; }
        set
        {
            if (!IsValidEmail(value))
                throw new InvalidOperationException("Invalid Email!");

            email = value;
        }
    }


    public string? Phone
    {
        get { return phone; }
        set
        {
            if (!IsPhoneNbr(value))
                throw new InvalidOperationException("Incorrect Number!");

            phone = value;
        }
    }

    public Patient(string? name, string? surname, string? email, string? phone)
    {
        Name=name;
        Surname=surname;
        Email=email;
        Phone=phone;
    }


    public override string ToString()
=> $@"Name: {Name}
Surname: {Surname}
Email: {Email}
Phone: {Phone}";
}
