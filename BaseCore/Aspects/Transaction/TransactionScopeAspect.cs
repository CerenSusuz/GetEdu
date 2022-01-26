using BaseCore.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Transactions;

namespace BaseCore.Aspects.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        /// <summary>
        /// If an error occurs when the related operation runs, it throws an exception and undone the inner operations that have been made. 
        /// Else transaction completes successfully.
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
