using System;
using System.Data;

namespace AddressBookService_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBookTable addressBookTable = new AddressBookTable();
            DataTable dataTable = addressBookTable.CreateAddressBookDataTable();
            // addressBookTable.DisplayContacts(dataTable);
            // addressBookTable.EditExistingContact(dataTable);
            // addressBookTable.DeleteContact(dataTable);
            //addressBookTable.RetrieveContactBelongingToCityOrState(dataTable);
            // addressBookTable.GetSizeByCity(dataTable);
            //addressBookTable.SortContacts(dataTable);
            addressBookTable.GetCountByType(dataTable);
            Console.ReadLine();
        }
    }
}
