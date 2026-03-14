using System.Text.RegularExpressions;


Console.WriteLine("Student Registration & Email Validation System");

// Lists required by the assignment
List<string> names = new List<string>();
List<string> emails = new List<string>();
List<int> scores = new List<int>();
List<string> categories = new List<string>();

// Main loop: keeps showing the menu until user chooses Exit
while (true)
{
    Console.WriteLine();
    Console.WriteLine("1 - Add Student");
    Console.WriteLine("2 - Show All Students");
    Console.WriteLine("3 - Show Passed Students");
    Console.WriteLine("4 - Search Student");
    Console.WriteLine("5 - Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    // Switch is required in the assignment for menu handling
    switch (choice)
    {
        case "1":
            AddStudent();
            break;

        case "2":
            ShowAllStudents();
            break;

        case "3":
            ShowPassedStudents();
            break;

        case "4":
            SearchStudent();
            break;

        case "5":
            Console.WriteLine("Program ended.");
            return; // ends the whole program

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}

void AddStudent()
{
    Console.Write("Enter student name: ");
    string name = Console.ReadLine().Trim();

    string email;

    // Keep asking until the email is valid
    while (true)
    {
        Console.Write("Enter email: ");
        email = Console.ReadLine().Trim();

        // Regex required by the assignment
        bool isValidEmail = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        if (isValidEmail)
        {
            break;
        }

        Console.WriteLine("Invalid email format. Try again.");
    }

    int score;

    // Keep asking until score is a valid number between 0 and 100
    while (true)
    {
        Console.Write("Enter score (0-100): ");
        string inputScore = Console.ReadLine().Trim();

        bool isNumber = int.TryParse(inputScore, out score);

        if (isNumber && score >= 0 && score <= 100)
        {
            break;
        }

        Console.WriteLine("Invalid score. Enter a number between 0 and 100.");
    }

    string category;

    // Score classification required by the assignment
    if (score >= 90)
    {
        category = "Excellent";
    }
    else if (score >= 70)
    {
        category = "Good";
    }
    else if (score >= 50)
    {
        category = "Pass";
    }
    else
    {
        category = "Fail";
    }

    // Save all data in lists
    names.Add(name);
    emails.Add(email);
    scores.Add(score);
    categories.Add(category);

    Console.WriteLine("Student added successfully.");
}

void ShowAllStudents()
{
    if (names.Count == 0)
    {
        Console.WriteLine("No students registered.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("All Students:");

    // Same index in all lists belongs to the same student
    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"Name: {names[i]}");
        Console.WriteLine($"Email: {emails[i]}");
        Console.WriteLine($"Score: {scores[i]}");
        Console.WriteLine($"Category: {categories[i]}");
        Console.WriteLine("----------------------");
    }
}

void ShowPassedStudents()
{
    if (names.Count == 0)
    {
        Console.WriteLine("No students registered.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Passed Students:");

    bool found = false;

    for (int i = 0; i < names.Count; i++)
    {
        // According to the assignment, passed means score >= 50
        if (scores[i] >= 50)
        {
            Console.WriteLine($"Name: {names[i]}");
            Console.WriteLine($"Email: {emails[i]}");
            Console.WriteLine($"Score: {scores[i]}");
            Console.WriteLine($"Category: {categories[i]}");
            Console.WriteLine("----------------------");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No passed students found.");
    }
}

void SearchStudent()
{
    if (names.Count == 0)
    {
        Console.WriteLine("No students registered.");
        return;
    }

    Console.Write("Enter student name to search: ");
    string searchName = Console.ReadLine().Trim();

    bool found = false;

    for (int i = 0; i < names.Count; i++)
    {
        // Case-insensitive search
        if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Student found:");
            Console.WriteLine($"Name: {names[i]}");
            Console.WriteLine($"Email: {emails[i]}");
            Console.WriteLine($"Score: {scores[i]}");
            Console.WriteLine($"Category: {categories[i]}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("Student not found.");
    }
}