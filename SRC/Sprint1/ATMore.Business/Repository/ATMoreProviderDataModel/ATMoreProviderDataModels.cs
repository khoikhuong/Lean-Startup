using ATMore.Business.Helper;
using System.Collections.Generic;
using System.Data;

namespace ATMore.Business.Repository.ATMoreProviderDataModel
{
    public class ATMoreProviderDataModels
    {
        private BaseDao _baseDao;
        private string _con;

        private const string usp_Provider_Select = "usp_Provider_Select";
       
        public ATMoreProviderDataModels(string connectionString)
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
        
        public DataTable Provider_Select(Dictionary<string,object> paramIN)
        {
            return getDao().ProcForDataTable(usp_Provider_Select, paramIN);
        }

    }
}
