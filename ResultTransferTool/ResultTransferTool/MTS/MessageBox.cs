using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultTransferTool.MTS
{
    class WindowsMessageBox : IDialog
    {
        public bool UserConfirmToUpdate(string msg)
        {
            var dialogResult = MessageBox.Show(msg, "", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public void ShowMessageBox(string msg)
        {
            Task.Run(() =>
            {
                MessageBox.Show(msg);
            });
        }
    }
}
