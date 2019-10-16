using System;
using System.Net;
using System.Threading.Tasks;
using Validation;

namespace Red.Validation
{
    public static class Extensions
    {
        public static Func<Request, Response, Task<HandlerType>> BuildRedFormMiddleware(this ValidatorBuilder builder)
        {
            var validator = builder.Build();

            return async (req, res) =>
            {
                var form = await req.GetFormDataAsync();

                if (!validator.Validate(form))
                {
                    return await res.SendStatus(HttpStatusCode.BadRequest);
                }

                return HandlerType.Continue;
            };
        }
        
        public static Func<Request, Response, Task<HandlerType>> BuildRedQueryMiddleware(this ValidatorBuilder builder)
        {
            var validator = builder.Build();

            return async (req, res) =>
            {
                if (!validator.Validate(req.Queries))
                {
                    return await res.SendStatus(HttpStatusCode.BadRequest);
                }

                return HandlerType.Continue;
            };
        }
    }
}