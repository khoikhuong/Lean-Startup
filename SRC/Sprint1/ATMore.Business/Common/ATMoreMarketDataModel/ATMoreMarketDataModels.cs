using ATMore.Business.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Helper;

namespace ATMore.Business.ATMoreMarketDataModel
{
    public class ATMoreMarketDataModels
    {
        private readonly BaseDao baseDao;
        private const string usp_Market_Insert = "usp_Market_Insert";
        private const string usp_Market_Delete = "usp_Market_Delete";
        private const string usp_Market_Select = "usp_Market_Select";
        private const string usp_Market_Select_ByID = "usp_Market_Select_ByID";
        private const string usp_Market_Update = "usp_Market_Update";
        public ATMoreMarketDataModels()
        {
            baseDao = new BaseDao();
        }

        public ATMoreMarketDataModels(string connectionString)
        {
            baseDao = new BaseDao(connectionString);
        }
        public ATMoreMarketDataModels(string connnectionString, string userName, string password)
        {
            baseDao = new BaseDao(connnectionString, userName, password);
        }

        public object Market_Insert(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(baseDao.ProcForValue(usp_Market_Insert, paramIN, "RESULT", TypeCode.Int32));
        }

        public object Market_Delete(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(baseDao.ProcForValue(usp_Market_Delete, paramIN, "RESULT", TypeCode.Int32));
        }

        public DataTable Market_Select(Dictionary<string,object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Market_Select, paramIN);
        }

        public DataTable Market_Select_ByID(Dictionary<string,object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Market_Select_ByID, paramIN);
        }

        public object Market_Update(Dictionary<string,object> paramIN)
        {
            return AppHelper.ToInt(baseDao.ProcForValue(usp_Market_Update, paramIN, "RESULT", TypeCode.Int32));
        }
    }
}
