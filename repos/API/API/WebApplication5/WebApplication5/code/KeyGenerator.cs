using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApplication5.code
{
    public class KeyGenerator
    {
        public class EncryptionMiddleware
        {
            private readonly RequestDelegate _next;

            public EncryptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext httpContext)
            {
                httpContext.Response.Body = EncryptStream(httpContext.Response.Body);
                httpContext.Request.Body = DecryptStream(httpContext.Request.Body);
                if (httpContext.Request.QueryString.HasValue)
                {
                    string decryptedString = DecryptString(httpContext.Request.QueryString.Value.Substring(1));
                    httpContext.Request.QueryString = new QueryString($"?{decryptedString}");
                }
                await _next(httpContext);
                await httpContext.Request.Body.DisposeAsync();
                await httpContext.Response.Body.DisposeAsync();
            }

            private string DecryptString(string v)
            {
                throw new NotImplementedException();
            }

            private Stream DecryptStream(Stream body)
            {
                throw new NotImplementedException();
            }

            private Stream EncryptStream(Stream body)
            {
                throw new NotImplementedException();
            }
        }
    }
}
