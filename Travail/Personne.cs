public class Personne
{
    public string Name { get; set; }

    public Personne()
    {
        Name = "";
    }

    public Personne(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}


//public class Personne
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public DateTime DateOfBirth { get; set; }

//    public Personne(string firstName, string lastName, DateTime dateOfBirth)
//    {
//        FirstName = firstName;
//        LastName = lastName;
//        DateOfBirth = dateOfBirth;
//    }
//}