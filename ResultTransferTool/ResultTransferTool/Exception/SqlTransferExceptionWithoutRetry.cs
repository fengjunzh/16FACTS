namespace ResultTransferTool.Exception
{
    class SqlTransferExceptionWithoutRetry : System.Exception
    {
        public SqlTransferExceptionWithoutRetry(string msg) : base(msg)
        {

        }
    }
}
