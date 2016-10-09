using ATMore.Business.Common.ATMoreProviderDataModel;
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
    public class ATMoreProvidersController : ApiController
    {
        private string connnectionString = ConfigurationManager.ConnectionStrings["ATMoreConnectionString"].ConnectionString;
        private readonly ATMoreProviderDataModels _ATMoreProviderDataModels;
        public ATMoreProvidersController()
        {
            _ATMoreProviderDataModels = new ATMoreProviderDataModels(connnectionString);
        }

        /// <summary>
        /// <param name="FiterSQL"></param>
        /// <param name="OrderSQL"></param>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="PRINT"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreProviders/Provider_Select")]
        public async Task<HttpResponseMessage> Provider_Select()
        {
            try {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreProviderDataModels.Provider_Select(paramIN);
                return this.Request.CreateResponse(Result);
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
