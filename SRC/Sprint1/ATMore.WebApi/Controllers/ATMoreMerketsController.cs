using ATMore.Business.ATMoreMarketDataModel;
using ATMore.Business.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ATMore.WebApi.Controllers
{
    public class ATMoreMerketsController : ApiController
    {
        private string connnectionString = ConfigurationManager.ConnectionStrings["ATMoreConnectionString"].ConnectionString;
        private ATMoreMarketDataModels _ATMoreMarketDataModels;
        public ATMoreMerketsController()
        {
            _ATMoreMarketDataModels = new ATMoreMarketDataModels(connnectionString);
        }

        [HttpPost]
        [Route("ATMoreMerkets/Market_Insert")]
        public async Task<HttpResponseMessage> Market_Insert()
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreMarketDataModels.Market_Insert(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        [HttpPost]
        [Route("ATMoreMerkets/Market_Delete")]
        public async Task<HttpResponseMessage> Market_Delete()
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreMarketDataModels.Market_Delete(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        [HttpPost]
        [Route("ATMoreMerkets/Market_Select")]
        public async Task<HttpResponseMessage> Market_Select()
        {
            try {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreMarketDataModels.Market_Select(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        [HttpPost]
        [Route("ATMoreMerkets/Market_Select_ByID/{PackageID}")]
        public  HttpResponseMessage Market_Select_ByID(Int64 PackageID)
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>()
                {
                    {"PackageID" , PackageID }
                };
                var Result = _ATMoreMarketDataModels.Market_Select_ByID(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        [HttpPost]
        [Route("ATMoreMerkets/Market_Update")]
        public async Task<HttpResponseMessage> Market_Update()
        {
            try {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreMarketDataModels.Market_Update(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        public async Task<Dictionary<string, object>> getParameterFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                Dictionary<string, object> lst = new Dictionary<string, object>();
                foreach (var key in provider.FormData.AllKeys)
                {
                    lst.Add(key, provider.FormData.GetValues(key)[0].ToString());
                }
                return lst;
            }
            catch (Exception)
            {
            }
            return null;

        }
    }
}
