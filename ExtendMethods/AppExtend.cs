using Microsoft.AspNetCore.Builder;
using System.Net;

namespace MVC.ExtendMethods
{
    public static class AppExtend
    {
        public static void AddStatusCodePage(this IApplicationBuilder app) 
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var respone = context.Response;
                    var code = respone.StatusCode;

                    var content = $@"<html>
                        <head>
                            <meta charset='UTF-8'/>
                            <title>Error {code}</title>
                        </head>
                        <body>
                            <p style='color: red;font-size: 30px'>
                                Co loi xay ra {code} - {(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";

                    await respone.WriteAsync(content);
                });
            });
        }
    }
}
