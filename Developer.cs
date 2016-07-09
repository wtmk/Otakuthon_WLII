using System;

public class Developer
{
    private string firstName;
    private string lastName;
    private int age;
    private string skills;
    private int experience;
    public Developer(string firstName, string lastName, int age, string skills, int experience)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.skills = skills;
        this.experience = experience;
    }
    /// <summary>
    /// First Name
    /// </summary>
    public string FirstName
    {
        get { return this.firstName; }
    }
    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName
    {
        get { return this.lastName; }
    }
    /// <summary>
    /// Age 
    /// </summary>
    public int Age
    {
        get { return this.age; }
    }
    /// <summary>
    /// Skill set
    /// </summary>
    public string Skills
    {
        get { return this.skills; }
    }
    /// <summary>
    /// Number of year experience
    /// </summary>
    public int Experience
    {
        get { return this.experience; }
    }
}
