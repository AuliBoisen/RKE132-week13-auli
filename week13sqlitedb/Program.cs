
using System.Data.SQLite;
readdata(createconnection());
//insertcustomer(createconnection());
//removecustomer(createconnection());
findcustomer();

static SQLiteConnection createconnection()
{
SQLiteConnection connection = new SQLiteConnection("data source=mydb.db; version = 3; new = true; compress = true;");

try
{
    connection.Open();
    Console.WriteLine("db found.");
}
catch
{
    Console.WriteLine("db not found.");
}
    return connection; 
}

static void readdata(SQLiteConnection myconnection)
{
    Console.Clear();
    SQLiteDataReader reader;
    SQLiteCommand command;

    command = myconnection.CreateCommand();
    command.CommandText = "select rowid * from customer";
    
    reader = command.ExecuteReader();

    while (reader.Read())
    {
        string readerrowid = reader["rowid"].ToString(0);
        string readerstringfirstname = reader.GetString(1);
        string readerstringlastname = reader.GetString(2);  
        string readerstringstatus = reader.GetString(3);

        Console.WriteLine($"{readerrowid}. full name: {readerstringfirstname} {readerstringlastname}; status: {readerstringstatus}");

    }
myconnection.Close();

}


static void insertcustomer(SQLiteConnection myconnection)
{
    SQLiteCommand command;
    string fname, lname, dob;

    Console.WriteLine("enter first name:");
    fname = Console.WriteLine();
    Console.WriteLine("enter last name:");
    lname = Console.ReadLine();
    Console.WriteLine("enter date of birth(mm-dd-yyyy):");
    dob = Console.ReadLine();

    command = myconnection.CreateCommand();
    command.CommandText = $"insert ino customer(firstname, lastname, dateofbirth)" +
        $"values ('{fname}', '{lname}', '{dob}')";

    int rowinserted = command.ExecuteNonQuery();
    Console.WriteLine($"row inserted: {rowinserted}");

    readdata(myconnection);

}

static void removecustomer(SQLiteConnection myconnection)
{
    SQLiteCommand command;

    string idtodelete;
    Console.WriteLine("enter an id to delete a customer:");
    idtodelete = Console.WriteLine();

    command= myconnection.CreateCommand();
    command.CommandText = $"delete from customer where rowid = {idtodelete}";

    int rowremove = command.ExecuteNonQuery();
    Console.WriteLine($"{rowremove} was removed from the table customer.");

    readdata(myconnection);
}
static void findcustomer()
{

}