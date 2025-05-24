using System.Text;

string firstname = "John";
string surname = "Cat";
string lastname = "Smith";
string fullname= firstname + " " + surname + " " + lastname;
Console.WriteLine(fullname);
Console.ReadLine();
StringBuilder sb = new StringBuilder();
sb.Append(firstname);
sb.Append(' ');
sb.Append(surname);
sb.Append(' ');
sb.Append(lastname);
Console.WriteLine(sb.ToString());