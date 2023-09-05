namespace ATMconsoleProject.Classes;

internal class Admin
{
    public string ? Username { get; set; }

    public string? Password { get; set; }  

    public Admin(string? username, string? password)
    {
        if (username == null || password == null) throw new ArgumentNullException("Admin Username Or Password Can Not Be Null !");
        Username = username;
        Password = password;
    }   

}
