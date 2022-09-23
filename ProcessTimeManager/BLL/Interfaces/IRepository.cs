using ProcessTimeManager.Models;
using System.Diagnostics;

namespace ProcessTimeManager.BLL.Interfaces
{
    public interface IRepository
    {
        List<DataItem> GetProcesses();
        List<DataItem> GetProcessesById();
        List<DataItem> ConvertToDataItems(IEnumerable<Process> processes);
        void InitializeRows(List<DataItem> checkedItems);
        void RefreshDataGrid(DataGridView dataGridView, IEnumerable<DataItem> dataItems);
        void AddProcessToDB(int processId);
        void DeleteProcessFromDB(int processId);
    }
}
