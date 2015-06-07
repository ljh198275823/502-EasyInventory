using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using LJH.InventoryWebAPI.Models;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.InventoryWebAPI.Handlers
{
    public class BasicAuthenticateHandler : DelegatingHandler
    {
        #region 构造函数
        public BasicAuthenticateHandler()
        {
        }
        #endregion

        #region 私有变量
        private readonly string _Sheme = "basic";
        #endregion

        #region 公共属性
        public string Realm { get; set; }
        #endregion

        #region 公共方法
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth != null && auth.Scheme.ToLower() == _Sheme.ToLower()) //如果是基本身分验证
            {
                if (string.IsNullOrEmpty(auth.Parameter)) //
                {
                    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Unauthorized);
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_Sheme, "realm=\"inventory\""));
                    var fuck = new TaskCompletionSource<HttpResponseMessage>();
                    fuck.SetResult(response);
                    return fuck.Task;
                }
                Tuple<string, string> nameAndpwd = ExtractUserNameAndPassword(auth.Parameter);
                if (nameAndpwd == null)
                {
                    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Unauthorized);
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_Sheme, "realm=\"inventory\""));
                    var fuck = new TaskCompletionSource<HttpResponseMessage>();
                    fuck.SetResult(response);
                    return fuck.Task;
                }
                if (!new OperatorBLL(Appsetting.Current.ConnStr).Authentication(nameAndpwd.Item1, nameAndpwd.Item2))
                {
                    HttpResponseMessage response = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "用户名或密码错误");
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_Sheme, "realm=\"inventory\""));
                    var fuck = new TaskCompletionSource<HttpResponseMessage>();
                    fuck.SetResult(response);
                    return fuck.Task;
                }
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(nameAndpwd.Item1), null);
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            var ret = base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(
                (task) =>
                {
                    HttpResponseMessage rs = task.Result;
                    if (rs.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        rs.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_Sheme, "realm=\"inventory\""));
                    }
                    return rs;
                }, cancellationToken);
            return ret;
        }
        #endregion

        #region 私有方法
        private static Tuple<string, string> ExtractUserNameAndPassword(string authorizationParameter)
        {
            byte[] credentialBytes;

            try
            {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return null;
            }

            // The currently approved HTTP 1.1 specification says characters here are ISO-8859-1.
            // However, the current draft updated specification for HTTP 1.1 indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.ASCII;
            // Make a writable copy of the encoding to enable setting a decoder fallback.
            encoding = (Encoding)encoding.Clone();
            // Fail on invalid bytes rather than silently replacing and continuing.
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            string decodedCredentials;

            try
            {
                decodedCredentials = encoding.GetString(credentialBytes);
            }
            catch (DecoderFallbackException)
            {
                return null;
            }

            if (String.IsNullOrEmpty(decodedCredentials))
            {
                return null;
            }

            int colonIndex = decodedCredentials.IndexOf(':');

            if (colonIndex == -1)
            {
                return null;
            }

            string userName = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);
            return new Tuple<string, string>(userName, password);
        }
        #endregion
    }
}