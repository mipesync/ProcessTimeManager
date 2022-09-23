using Microsoft.EntityFrameworkCore;
using ProcessTimeManager.BLL.Interfaces;
using ProcessTimeManager.Data;
using ProcessTimeManager.Exceptions;
using ProcessTimeManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ProcessTimeManager.BLL.Implementations
{
    public class DataItemRepository : IRepository
    {
        private readonly PTMContext _dbContext;

        public DataItemRepository()
        {
            _dbContext = new PTMContext();
        }

        public List<DataItem> ConvertToDataItems(IEnumerable<Process> processes)
        {
            List<DataItem> dataItems = new List<DataItem>();

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

            return dataItems;
        }

        public List<DataItem> GetProcessesById()
        {
            var processes = new List<Process>();

            using (PTMContext _dbContext = new PTMContext())
            {
                var dataProcesses = _dbContext.DataProcesses.ToList();

                foreach (var dataProcess in dataProcesses)
                {
                    try
                    {
                        processes.Add(Process.GetProcessById(dataProcess.ProcessId));
                    }
                    catch (ArgumentException e)
                    {
                        var messageObjects = e.Message.Split();
                        int processId = 0;

                        foreach (var item in messageObjects)
                        {
                            int.TryParse(item, out processId);

                            if (processId != 0)
                            {
                                DeleteProcessFromDB(processId);
                            }
                        }
                    }
                }
            }

            return ConvertToDataItems(processes);
        }

        public List<DataItem> GetProcesses()
        {
            var processes = new List<Process>();
            processes.Clear();
            processes.AddRange(Process.GetProcesses().ToList());

            return ConvertToDataItems(processes);
        }

        public void InitializeRows(List<DataItem> dataItems)
        {
            var checkedItems = GetProcessesById();

            foreach (var item in dataItems)
            {
                foreach (var checkedItem in checkedItems)
                {
                    if (item.ProcessId.Equals(checkedItem.ProcessId))
                    {
                        item.IsChecked = true;
                    }
                }
            }
        }

        public void RefreshDataGrid(DataGridView dataGridView, IEnumerable<DataItem> dataItems)
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

        public async void AddProcessToDB(int processId)
        {
            await _dbContext.DataProcesses.AddAsync(new DataProcess
            {
                ProcessId = processId
            });

            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteProcessFromDB(int processId)
        {
            var entity = await _dbContext.DataProcesses.FirstOrDefaultAsync(u => u.ProcessId == processId);

            if (entity is null) throw new NotFoundException(nameof(DataProcess), processId);

            _dbContext.DataProcesses.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
