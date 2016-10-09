using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Helper;

namespace ATMore.Business.Common.ATMoreProviderDataModel
{
    public class ATMoreProviderDataModels
    {
        private readonly BaseDao baseDao;
        private const string usp_Provider_Select = "usp_Provider_Select";
        public ATMoreProviderDataModels()
        {
            baseDao = new BaseDao();
        }

        public ATMoreProviderDataModels(string connectionString)
        {
            baseDao = new BaseDao(connectionString);
        }
        public ATMoreProviderDataModels(string connectionString, string userName, string password)
        {
            baseDao = new BaseDao(connectionString, userName, password);
        }
        
        public DataTable Provider_Select(Dictionary<string,object> paramIN)
        {
            return baseDao.ProcForDataTable(usp_Provider_Select,paramIN);
        }

    }
}
