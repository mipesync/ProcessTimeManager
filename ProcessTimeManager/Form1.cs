using ProcessTimeManager.BLL.Implementations;
using ProcessTimeManager.BLL.Interfaces;
using ProcessTimeManager.Exceptions;
using ProcessTimeManager.Models;
using ProcessTimeManager.UserForms;
using Timer = System.Windows.Forms.Timer;

namespace ProcessTimeManager
{
    public partial class Form1 : Form
    {
        private List<DataItem> DataItems = new List<DataItem>();
        private List<DataItem> CheckedItems = new List<DataItem>();
        private readonly IRepository _repo;

        public Form1()
        {
            InitializeComponent();
            _repo = new DataItemRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var initialize = new Task(() =>
            {
                DataItems = _repo.GetProcesses();
                _repo.InitializeRows(DataItems);
            });
            initialize.Start();
            var waitForm = new WaitForm();
            waitForm.Show();

            CheckCompleted(() =>
            {
                initialize.Wait();
            });

            _repo.RefreshDataGrid(processList, DataItems);

            waitForm.Close();
        }

        private void CheckCompleted(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (AggregateException ex)
            {
                var messageObjects = ex.Message.Split();
                int processId = 0;

                foreach (var item in messageObjects)
                {
                    int.TryParse(item, out processId);

                    if (processId != 0)
                    {
                        _repo.DeleteProcessFromDB(processId);
                        CheckedItems.Remove(CheckedItems.Find(u => u.ProcessId == processId)!);
                        DataItems.Remove(DataItems.Find(u => u.ProcessId == processId)!);
                    }
                }

            }
        }

        private void processList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.processList.CurrentCell as DataGridViewCheckBoxCell;

            if (cell is null) return;

            var row = processList.Rows[e.RowIndex];

            bool IsChecked = Convert.ToBoolean(cell!.Value);

            if (!IsChecked)
            {
                cell.Value = true;

                _repo.AddProcessToDB((int)row.Cells[1].Value);

                MessageBox.Show($"{row.Cells[3].Value} has been added.");
                processList.Refresh();
                return;
            }
            if (IsChecked)
            {
                cell.Value = false;
                try
                {
                    _repo.DeleteProcessFromDB((int)row.Cells[1].Value);

                    CheckedItems.Remove(CheckedItems.Find(u => u.ProcessId == (int)row.Cells[1].Value)!);

                    MessageBox.Show($"{row.Cells[3].Value} has been removed.");
                }
                catch(NotFoundException ex) { MessageBox.Show(ex.Message); }

                processList.Refresh();
                return;
            }
        }

        private void tabs_Click(object sender, EventArgs e)
        {
            var timer = new Timer();
            if (this.tabs.SelectedIndex == 1)
            {
                CheckCompleted(() =>
                {
                    GridRefresher(sender, e);
                });

                timer.Tick += new EventHandler(GridRefresher!);
                timer.Start();
                int seconds = 5;
                timer.Interval = seconds * 1000;
            }
            if(this.tabs.SelectedIndex == 0)
            {
                timer.Stop();
                Form1_Load(sender, e);
            }
        }

        private void GridRefresher(object sender, EventArgs args)
        {
            CheckedItems = _repo.GetProcessesById();
            _repo.RefreshDataGrid(selectedProcesses, CheckedItems);
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}