public class Comment
{
    private string _firstName;
    private string _lastName;
    private string _comment;

    public Comment(string comment)
    {
        _firstName = "Anonymous";
        _lastName = "User";
        _comment = comment;
    }

    public Comment(string firstName, string lastName, string comment)
    {
        _firstName = firstName;
        _lastName = lastName;
        _comment = comment;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"\t-{_firstName} {_lastName}: {_comment}");
    }

}