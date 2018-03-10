using System.Data.Entity;

namespace StudentManagement.DAL.EFManager
{
    public class EfStartUpTask
    {
        public static void Execute()
        {
            //It's required to set initialize to null (for SQL Server Compact).
            //otherwise, you'll get something like 
            //"The model backing the 'your context name' context has changed 
            //since the database was created. Consider using Code First Migrations
            //to update the database"

            Database.SetInitializer(new 
                DropCreateDatabaseIfModelChanges<StudentManagemenetObjectContext>());
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
