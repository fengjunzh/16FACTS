using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class EmployeeTable
    {
        public int Id;
        public string EmpNum;
        public string Name;
        public string LoginName;
        public bool UserPermission;
        public string Department;
        public string userPwd;
        public string UserLevel;
        public int FactoryId;
    }

    interface IEmployeeTable
    {
        EmployeeTable GetEmployeeTable();
        void SetEmployeeId(int id);
    }
}
