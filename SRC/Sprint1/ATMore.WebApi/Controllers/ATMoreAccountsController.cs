using ATMore.Business.Helper;
using ATMore.Business.Repository.ATMoreAccountDataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ATMore.WebApi.Controllers
{
    public class ATMoreAccountsController : ApiController
    {
        private string connnectionString = ConfigurationManager.ConnectionStrings["ATMoreConnectionString"].ConnectionString;
        private readonly ATMoreAccountDataModels _ATMoreAccountDataModels;
        public ATMoreAccountsController()
        {
            _ATMoreAccountDataModels = new ATMoreAccountDataModels(this.connnectionString);
        }


        /// <summary>
        /// <param name="phone"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreAccounts/Account_CheckPhone/{phone}")]
        public HttpResponseMessage Account_CheckPhone(string phone)
        {
            Dictionary<string, object> paramIN = new Dictionary<string, object>();
            paramIN.Add("Phone", phone);
            var Result = _ATMoreAccountDataModels.Account_CheckPhone(paramIN);
            return this.Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        /// <summary>
        /// <param name="AccountID"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreAccounts/Account_SelectByID/{AccountID}")]
        public HttpResponseMessage Account_SelectByID(Int64 AccountID)
        {
            Dictionary<string, object> paramIN = new Dictionary<string, object>()
            {
                { "AccountID", AccountID }
            };
            var Result = _ATMoreAccountDataModels.Account_Select_ByID(paramIN);
            return this.Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        /// <summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <param name="FacebookID"></param>
        /// <param name="GoogleID"></param>
        /// <param name="Sex"></param>
        /// <param name="Avartar"></param>
        /// <param name="Birthdate"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreAccounts/Account_Create")]
        public async Task<HttpResponseMessage> Account_Create()
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreAccountDataModels.Account_Create(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK,Result);

            }catch(Exception ex){
                return this.Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        /// <summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <param name="FacebookID"></param>
        /// <param name="GoogleID"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreAccounts/Account_Authenticate")]
        public async Task<HttpResponseMessage> Account_Authenticate()
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreAccountDataModels.Account_Authenticate(paramIN);
                return this.Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, AppHelper.GetErrorMessage(ex));
            }
        }

        /// <summary>
        /// <param name="AccountID"></param>
        /// <param name="Sex"></param>
        /// <param name="Avartar"></param>
        /// <param name="Birthdate"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ATMoreAccounts/Account_Update")]
        public async Task<HttpResponseMessage> Account_Update()
        {
            try
            {
                Dictionary<string, object> paramIN = new Dictionary<string, object>();
                paramIN = await getParameterFormData();
                var Result = _ATMoreAccountDataModels.Account_Update(paramIN);
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
