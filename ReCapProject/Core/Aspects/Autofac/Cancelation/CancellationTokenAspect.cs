using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Cancelation
{
    public class CancellationTokenAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            var token = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext.RequestAborted;
            Task.Run(() =>
            {
                invocation.Proceed();
            }, token).Wait(token);
        }
    }
}