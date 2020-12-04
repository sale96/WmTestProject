using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationLogger _logger;
        public UseCaseExecutor(IApplicationLogger logger)
        {
            _logger = logger;
        }
        public TResult ExecuteQuery<TSearch, TResult>(
            IQuery<TSearch, TResult> query,
            TSearch search)
        {
            _logger.Log(query.Name, search);
            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            _logger.Log(command.Name, request);
            command.Execute(request);
        }
    }
}
