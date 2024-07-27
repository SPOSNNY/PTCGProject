using System.Data;

namespace PTCGProject.DataProcess
{
    public class BaseDataProcess
    {
        protected IDbConnection _dbConnection;

        protected BaseDataProcess(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

    }
}
