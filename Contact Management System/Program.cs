////// See https://aka.ms/new-console-template for more information
///// <summary>
///// </summary>
///


// CABADOR JHON LLOYD B.
// BSCS 2-2

using System;
using System.Collections.Generic;

//Struct Variables
struct Contact
{
    
    public string name;
    public string phone;
    public string email;
    public string address;

    //  CONSTRUCTOR 
    public Contact(string _name, string _phone, string _email, string _address)
    {
        name = _name;
        phone = _phone;
        email = _email;
        address = _address;
    }


    // 1. Add Name
    public void AddName()
    {
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
    }

    // 2. Add Phone
    public void AddPhone()
    {
        Console.Write("Enter your phone: ");
        phone = Console.ReadLine();
    }

    // 3. Add Email
    public void AddEmail()
    {
        Console.Write("Enter your email: ");
        email = Console.ReadLine();
    }

    // 4. Add Address
    public void AddAddress()
    {
        Console.Write("Enter your address: ");
        address = Console.ReadLine();
    }

    // 5. Display Contact 
    public void DisplayContact()
    {
        Console.WriteLine("\n------------------------------");
        Console.WriteLine("Name:    " + name);
        Console.WriteLine("Phone:   " + phone);
        Console.WriteLine("Email:   " + email);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("------------------------------");
    }

    // 6. Search Contact
    public void SearchContact()
    {
        Console.Write("Enter name to search: ");
        string searchName = Console.ReadLine();

        if (name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("\n=== Contact Found! ===");
            DisplayContact();
        }
        else
        {
            Console.WriteLine("Contact Not Found.");
        }
    }

    // 7. Edit Contact
    public void EditContact()
    {
        Console.WriteLine("\n===== EDIT CONTACT =====");

        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter your phone: ");
        phone = Console.ReadLine();

        Console.Write("Enter your email: ");
        email = Console.ReadLine();

        Console.Write("Enter your address: ");
        address = Console.ReadLine();

        Console.WriteLine("Contact updated!");
    }

    // 8. Delete Contact
    public void DeleteContact()
    {
        name = "";
        phone = "";
        email = "";
        address = "";
        Console.WriteLine("Contact deleted!");
    }

    // 9. Count Contacts
    public void CountContacts()
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Total Contacts: 1");
        }
        else
        {
            Console.WriteLine("Total Contacts: 0");
        }
    }

    // 10. Exit
    public void Exit()
    {
        Console.WriteLine("Exiting the program...");
    }
}

class Program
{
    // List to store multiple contacts dynamically
    static List<Contact> contacts = new List<Contact>();

    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   CONTACT MANAGEMENT SYSTEM");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display All Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Count Contact");
            Console.WriteLine("7. Exit");
            Console.WriteLine("==============================");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1:
                    Contact newContact = new Contact();
                    newContact.AddName();
                    newContact.AddPhone();
                    newContact.AddEmail();
                    newContact.AddAddress();
                    contacts.Add(newContact);
                    Console.WriteLine("Contact added successfully!");
                    break;

                case 2:
                    DisplayAllContacts();
                    break;

                case 3:
                    SearchAllContacts();
                    break;

                case 4:
                    EditContactByName();
                    break;

                case 5:
                    DeleteContactByName();
                    break;

                case 6:
                    Console.WriteLine($"\nTotal Contacts: {contacts.Count}");
                    break;

                case 7:
                    Console.WriteLine("Exiting the program...");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }

        } while (choice != 7);
    }

    // Helper to display ALL contacts in the list
    static void DisplayAllContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\nNo contacts available.");
            return;
        }

        Console.WriteLine($"\n=== ALL CONTACTS ({contacts.Count}) ===");
        foreach (Contact c in contacts)
        {
            c.DisplayContact();
        }
    }

    // Helper to search across ALL contacts
    static void SearchAllContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\nNo contacts to search.");
            return;
        }

        Console.Write("Enter name to search: ");
        string searchName = Console.ReadLine();
        bool found = false;

        foreach (Contact c in contacts)
        {
            if (c.name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n=== Contact Found! ===");
                c.DisplayContact();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Contact Not Found.");
        }
    }

    // Helper to edit a specific contact by name
    static void EditContactByName()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\nNo contacts to edit.");
            return;
        }

        Console.Write("Enter name to edit: ");
        string searchName = Console.ReadLine();

        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Contact updated = contacts[i];
                updated.EditContact();
                contacts[i] = updated; 
                return;
            }
        }

        Console.WriteLine("Contact Not Found.");
    }

    // Helper to delete a specific contact by name
    static void DeleteContactByName()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\nNo contacts to delete.");
            return;
        }

        Console.Write("Enter name to delete: ");
        string searchName = Console.ReadLine();

        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                contacts.RemoveAt(i);
                Console.WriteLine("Contact deleted successfully!");
                return;
            }
        }

        Console.WriteLine("Contact Not Found.");
    }
}