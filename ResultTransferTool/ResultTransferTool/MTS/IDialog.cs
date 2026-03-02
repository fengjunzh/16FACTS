namespace ResultTransferTool.MTS
{
    public interface IDialog
    {
        bool UserConfirmToUpdate(string msg);
        void ShowMessageBox(string msg);
    }
}
