using Microsoft.EntityFrameworkCore;
using ProcessTimeManager.Data;
using ProcessTimeManager.Models;
using ProcessTimeManager.UserForms;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ProcessTimeManager
{
    public partial class Form1 : Form
    {
        private List<DataItem> DataItems = new List<DataItem>();
        private List<DataItem> SelectedItems = new List<DataItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*var timer = new Timer();
            timer.Tick += new EventHandler(RefreshDataGrid!);
            timer.Start();
            int seconds = 10;
            timer.Interval = seconds * 1000;*/
            var initialize = new Task(() =>
            {
                GetProcesses();
                InitializeRows();
            });
            initialize.Start();
            var waitForm = new WaitForm();
            waitForm.Show();

            initialize.Wait();
            RefreshDataGrid(processList, DataItems);
            waitForm.Close();
        }

        private void GetProcesses()
        {
            var processes = new List<Process>();
            processes.Clear();
            processes.AddRange(Process.GetProcesses().ToList());

            ConvertToDataItems(processes, DataItems);
        }

        private void InitializeRows()
        {
            GetProcessesById();

            foreach (var item in DataItems)
            {
                foreach (var selectedItem in SelectedItems)
                {
                    if (item.ProcessId.Equals(selectedItem.ProcessId))
                    {
                        item.IsChecked = true;
                    }
                }
            }
        }

        private void ConvertToDataItems(List<Process> processes, List<DataItem> dataItems)
        {
            dataItems.Clear();

            foreach (var process in processes)
            {
                try
                {
                    var icon = Icon.ExtractAssociatedIcon(process.MainModule!.FileName!);

                    string startsTimeString = string.Empty;
                    var timeDifference = DateTime.Now - process.StartTime;

                    if (timeDifference.Hours != 0)
                    {
                        startsTimeString = $"Запущен уже {timeDifference.Hours} часов";
                    }
                    else
                    {
                        if (timeDifference.Minutes != 0)
                        {
                            startsTimeString = $"Запущен {timeDifference.Minutes} минут назад";
                        }
                        else
                        {
                            if (timeDifference.Seconds != 0)
                            {
                                startsTimeString = $"Запущен {timeDifference.Seconds} секунд назад";
                            }
                        }
                    }

                    dataItems.Add(new DataItem
                    {
                        ProcessId = process.Id,
                        Image = icon,
                        Name = process.ProcessName,
                        Time = startsTimeString
                    });
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void RefreshDataGrid(DataGridView dataGridView, List<DataItem> dataItems)
        {
            if (dataItems.Count() == 0)
            {
                dataGridView.Rows.Clear();
                return;
            }

            dataGridView.Rows.Clear();
            foreach (DataItem item in dataItems)
            {
                dataGridView.Rows.Add(
                    item.IsChecked,
                    item.ProcessId,
                    item.Image,
                    item.Name,
                    item.Time
                );
            }
        }

        private async void processList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.processList.CurrentCell as DataGridViewCheckBoxCell;

            if (cell is null) return;

            var row = processList.Rows[e.RowIndex];

            bool IsChecked = Convert.ToBoolean(cell!.Value);

            using (PTMContext _dbContext = new PTMContext())
            {
                if (!IsChecked)
                {
                    cell.Value = true;

                    await _dbContext.DataProcesses.AddAsync(new DataProcess
                    {
                        ProcessId = (int)row.Cells[1].Value
                    });

                    await _dbContext.SaveChangesAsync();

                    MessageBox.Show($"{row.Cells[3].Value} has been added.");
                    processList.Refresh();
                    return;
                }
                if (IsChecked)
                {
                    cell.Value = false;

                    var entity = await _dbContext.DataProcesses.FirstOrDefaultAsync(u => u.ProcessId == (int)row.Cells[1].Value);

                    if (entity is null) return;

                    _dbContext.DataProcesses.Remove(entity!);
                    await _dbContext.SaveChangesAsync();

                    SelectedItems.Remove(SelectedItems.Find(u => u.ProcessId == entity!.ProcessId)!);

                    MessageBox.Show($"{row.Cells[3].Value} has been removed.");
                    processList.Refresh();
                    return;
                }
            }
        }

        private void tabs_Click(object sender, EventArgs e)
        {
            if (this.tabs.SelectedIndex == 1)
            {
                GetProcessesById();
                RefreshDataGrid(selectedProcesses, SelectedItems);
            }
            if(this.tabs.SelectedIndex == 0)
            {
                Form1_Load(sender, e);
            }
        }

        private void GetProcessesById()
        {
            var processes = new List<Process>();

            using (PTMContext _dbContext = new PTMContext())
            {
                var dataProcesses = _dbContext.DataProcesses.ToList();

                if (dataProcesses.Count() == 0)
                {
                    SelectedItems.Clear();
                }

                foreach (var dataProcess in dataProcesses)
                {
                    processes.Add(Process.GetProcessById(dataProcess.ProcessId));
                }
            }

            ConvertToDataItems(processes, SelectedItems);
        }
    }
}