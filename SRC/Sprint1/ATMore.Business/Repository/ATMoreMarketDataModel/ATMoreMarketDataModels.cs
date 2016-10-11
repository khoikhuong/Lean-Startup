using ATMore.Business.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace ATMore.Business.Repository.ATMoreMarketDataModel
{
    public class ATMoreMarketDataModels
    {
        private BaseDao _baseDao;
        private string _con;

        private const string usp_Market_Insert = "usp_Market_Insert";
        private const string usp_Market_Delete = "usp_Market_Delete";
        private const string usp_Market_Select = "usp_Market_Select";
        private const string usp_Market_Select_ByID = "usp_Market_Select_ByID";
        private const string usp_Market_Update = "usp_Market_Update";
       

        public ATMoreMarketDataModels(string connectionString)
        {
            _con = connectionString;
        }

        private BaseDao getDao()
        {
            if (_baseDao == null)
            {
                _baseDao = new BaseDao(_con);
            }
            return _baseDao;
        }
       

        public object Market_Insert(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(getDao().ProcForValue(usp_Market_Insert, paramIN, "RESULT", TypeCode.Int32));
        }

        public object Market_Delete(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(getDao().ProcForValue(usp_Market_Delete, paramIN, "RESULT", TypeCode.Int32));
        }

        public DataTable Market_Select(Dictionary<string,object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Market_Select, paramIN);
        }

        public DataTable Market_Select_ByID(Dictionary<string,object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Market_Select_ByID, paramIN);
        }

        public object Market_Update(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(getDao().ProcForValue(usp_Market_Update, paramIN, "RESULT", TypeCode.Int32));
        }
    }
}
