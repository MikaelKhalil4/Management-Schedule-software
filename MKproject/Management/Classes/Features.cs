using GlobalFunctions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace MKproject.Management
{
    public class Features
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);

    
        public enum enumFeatures
        {

            [StringValue("Insert Or Edit Clients")]
            EditClients,
            [StringValue("Delete Clients")]
            DeleteClients,
            [StringValue("Edit Registration Fields")]
            RegistrationFields,
            [StringValue("Edit Offres")]
            EditOffres,
            [StringValue("Transactions")]//yaane el backoffice
            Transactions,
            [StringValue("Edit Services,Products and Employees")]
            ServicesProductsEmployees,
            [StringValue("Statistics")]
            Statistics,
            [StringValue("Access Schedule")]
            Schedule,
            [StringValue("Edit past appointments in the schedule")]
            EditPastAppSchedule,

        }
     
       
    }
}
