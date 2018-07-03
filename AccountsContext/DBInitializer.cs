using AccountsEntity;
using System.Data.Entity;


namespace AccountsContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            context.Roles.Add(
                new ERole
                {
                    Name = "AccountAdministrator",
                    Description = "Survey - Pay - AndersonCRM - AndersonForms - HROnline - AIMS - Accounts - AccountsExternal - AndersonWorklogs - ELogbook"
                });
            base.Seed(context);
        }
    }
}
