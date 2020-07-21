using System;
using System.Transactions;

namespace Common.Utils
{
    //Source: https://blogs.msdn.microsoft.com/dbrowne/2010/06/03/using-new-transactionscope-considered-harmful/
    public class TransactionUtil
    {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            //NOTE: Yes setting a transaction this long is bad, but until we get
            //the code refactored, work with it.
            transactionOptions.Timeout = new TimeSpan(2, 0, 0);
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
