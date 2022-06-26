using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _timer;

        public PerformanceBehaviour(ILogger<TRequest> logger, Stopwatch timer)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();
            var elapsed = _timer.ElapsedMilliseconds;

            if(elapsed > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogInformation("FinancialManagment Long Running Request: {Name} ({elapsed} miliseconds) {@Request}",
                    requestName,elapsed, request);
            }
        }
    }
}
