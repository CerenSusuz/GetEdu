using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using BaseCore.Utilities.Interceptors;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace BaseCore.Aspects.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
