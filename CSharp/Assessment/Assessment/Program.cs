using System.Collections.Generic;

namespace Assessment
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

    }
    class App
    {
        List<Note> list;
        public int NoteId = 1;

        public App()
        {
            list = new List<Note>();
            {
                new Note { Id = NoteId++, Title = "My First Note", Description = "My First Program Assessment", Date = DateTime.Now.ToString("dd/MM/yyyy") };
            };
        }
        public void CreateNote()
        {
            try
            {
                Console.WriteLine("Enter Title");
                string title = Console.ReadLine();
                Console.WriteLine("Enter Description");
                string description = Console.ReadLine();
                int id = NoteId++;
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                list.Add(new Note() { Id = id, Title = title, Description = description, Date = date });
                Console.WriteLine("Notes Created Successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only Strings are Allowes");
            }
            
        }
        public Note ViewNote(int id)
        {
            foreach (Note c in list)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }
        public List<Note> ViewAllNotes()
        {
            return list;
        }
        public void UpdateNote(int id)
        {
            foreach (Note c in list)
            {
                if (c.Id == id)
                {
                    try
                    {
                        Console.WriteLine("Enter updated title");
                        c.Title = Console.ReadLine();
                        Console.WriteLine("Enter updated description");
                        c.Description = Console.ReadLine();
                        Console.WriteLine("Notes Updated Successfully");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Only Strings are Allowed");
                    }
                }
            }
        }
        public bool DeleteNote(int id)
        {
            foreach (Note c in list)
            {
                if (c.Id == id)
                {
                    list.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            App n = new App();
            string res = null;
            do
            {
                try
                {
                    Console.WriteLine("Welcome to notes app");
                    Console.WriteLine("1. Create Notes");
                    Console.WriteLine("2. View Note by Id");
                    Console.WriteLine("3. View All Notes");
                    Console.WriteLine("4. Update Notes By Id");
                    Console.WriteLine("5. Delete Notes By Id");
                    Console.WriteLine("Enter Your choice: ");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                n.CreateNote();
                                break;
                            }
                        case 2:
                            {
                                
                                    Console.WriteLine("Enter Notes Id to view");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    Note? c = n.ViewNote(id);
                                    if (c == null)
                                    {
                                        Console.WriteLine("Notes does not exists");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Note Details of id {c.Id} :");
                                        Console.WriteLine($"Title: {c.Title}\nDescription: {c.Description}\nDate: {c.Date}");
                                    }
                                
                                break;
                            }
                        case 3:
                            {

                                foreach (var c in n.ViewAllNotes())
                                {
                                    int TotalNotes = c.Id - 1;
                                    Console.WriteLine($"id           title           description           date");
                                    Console.WriteLine($"{c.Id}\t\t {c.Title}\t\t{c.Description}\t\t{c.Date}");
                                    Console.WriteLine($"Total Notes \t {TotalNotes}");

                                }

                                break;
                            }
                        case 4:
                            {
                                
                                
                                    Console.WriteLine("Enter Notes Id to Update");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    n.UpdateNote(id);
                                    break;
                                
                            }
                        case 5:

                            {
                                
                                
                                    Console.WriteLine("Enter Notes Id to Delete");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    if (n.DeleteNote(id))
                                    {
                                        Console.WriteLine("Notes Deleted Successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Notes does not exist");
                                    }
                                    break;
                                
                              
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice Entered");
                                break;
                            }
                    }
                    Console.WriteLine("Do you wish to continue? [y/n] ");
                    res = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only  numbers are allowed");
                }
            } while (res.ToLower() == "y");
        }
    }
}