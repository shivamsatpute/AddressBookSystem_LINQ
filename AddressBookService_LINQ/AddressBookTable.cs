using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace AddressBookService_LINQ
{
    class AddressBookTable
    {
        public DataTable CreateAddressBookDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));

            table.Rows.Add("Shivam", "Satpute", "Bajaj Nagr", "Nagpur", "Maharashtra", "412105", "8788566219", "shivsat@gmail.com");
            table.Rows.Add("Suyog", "Kumbhare", "Aund", "Pune", "Maharashtra", "125121", "8570934858", "suyog@gmail.com");
            table.Rows.Add("Vishal", "Raut", "Mumbai", "Mumbai", "Maharashtra", "442206", "7894561230", "vishal@gmail.com");
            return table;
        }
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {
                Console.WriteLine("First Name : " + contact.Field<string>("First Name") + " " + "Last Name : " + contact.Field<string>("Last Name") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                    + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
            }
        }
        public void EditExistingContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("First Name") == "Vishal");
            foreach (var Editcontact in contacts)
            {
                Editcontact.SetField("Last Name", "Rokde");
            }
            Console.WriteLine("The Contact is edited succesfully");
            DisplayContacts(contacts.CopyToDataTable());
        }
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Shivam");
            foreach (var row in contacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("The Contact is deleted succesfully.\n");
            DisplayContacts(table);
        }
        public void RetrieveContactBelongingToCityOrState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("City") == "Pune");
            foreach (var contact in contacts)
            {
                Console.Write("First Name : " + contact.Field<string>("First Name") + " " + "Last Name : " + contact.Field<string>("Last Name") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                     + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine("\n------------------------------------");
            }
        }
        public void GetSizeByCity(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["State"].Equals("Maharashtra")).Count();
            Console.WriteLine(" : {0} ", contacts);
        }

        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("First Name"));
            DisplayContacts(contacts.CopyToDataTable());
        }
    }
}

