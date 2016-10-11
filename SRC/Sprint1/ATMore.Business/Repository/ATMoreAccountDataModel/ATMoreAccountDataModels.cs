using ATMore.Business.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace ATMore.Business.Repository.ATMoreAccountDataModel
{
    public class ATMoreAccountDataModels
    {
        private  BaseDao _baseDao;
        private  string _con;

        private const string usp_Account_CheckPhone = "usp_Account_CheckPhone";
        private const string usp_Account_Authenticate = "usp_Account_Authenticate";
        private const string usp_Account_Create = "usp_Account_Create";
        private const string usp_Account_Select_ByID = "usp_Account_Select_ByID";
        private const string usp_Account_Update = "usp_Account_Update";

        public ATMoreAccountDataModels(string connectionString)
        {
            _con = connectionString;
        }
        private BaseDao getDao()
        {
            if (_baseDao==null)
            {
                _baseDao = new BaseDao(_con);
            }
            return _baseDao;
        }
       
        public Int32 Account_CheckPhone(Dictionary<string,object> paramIN )
        {
           return AppHelper.ToInt(getDao().ProcForValue(usp_Account_CheckPhone, paramIN, "RESULT",TypeCode.Int32));
        }

        public DataTable Account_Authenticate(Dictionary<string,object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Account_Authenticate, paramIN);
        }

        public DataTable Account_Create (Dictionary<string, object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Account_Create, paramIN);
        }

        public DataTable Account_Select_ByID (Dictionary<string,object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Account_Select_ByID, paramIN);
        }

        public object Account_Update(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(getDao().ProcForValue(usp_Account_Update, paramIN, "RESULT", TypeCode.Int32));
        }
    }
}
