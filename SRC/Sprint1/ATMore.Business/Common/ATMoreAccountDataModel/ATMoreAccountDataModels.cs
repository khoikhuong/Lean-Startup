using ATMore.Business.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Helper;

namespace ATMore.Business.Common.ATMoreAccountDataModel
{
    public class ATMoreAccountDataModels
    {
        private readonly BaseDao baseDao;
        private const string usp_Account_CheckPhone = "usp_Account_CheckPhone";
        private const string usp_Account_Authenticate = "usp_Account_Authenticate";
        private const string usp_Account_Create = "usp_Account_Create";
        private const string usp_Account_Select_ByID = "usp_Account_Select_ByID";
        private const string usp_Account_Update = "usp_Account_Update";
        public ATMoreAccountDataModels()
        {
            baseDao = new BaseDao();
        }

        public ATMoreAccountDataModels(string connectionString)
        {
            baseDao = new BaseDao(connectionString);
        }
        public ATMoreAccountDataModels(string connectionString, string userName, string password)
        {
            baseDao = new BaseDao(connectionString, userName, password);
        }

        public Int32 Account_CheckPhone(Dictionary<string,object> paramIN )
        {
           return AppHelper.ToInt( baseDao.ProcForValue(usp_Account_CheckPhone, paramIN, "RESULT",TypeCode.Int32));
        }

        public DataTable Account_Authenticate(Dictionary<string,object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Account_Authenticate,paramIN);
        }

        public DataTable Account_Create (Dictionary<string, object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Account_Create, paramIN);
        }

        public DataTable Account_Select_ByID (Dictionary<string,object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Account_Select_ByID, paramIN);
        }

        public object Account_Update(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(baseDao.ProcForValue(usp_Account_Update, paramIN, "RESULT", TypeCode.Int32));
        }
    }
}
