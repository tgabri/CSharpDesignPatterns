using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NetAcademia_CommandWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int progressValue = 0;
        private CancellationTokenSource cancellationTokenSource = null;

        public int ProgressValue
        {
            get => progressValue;
            set
            {
                if (value == ProgressValue) return;
                progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();

            var task = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        ProgressValue = i;
                        Thread.Sleep(50);
                    }

                }
            }, cancellationTokenSource.Token);

            task.Start();

            try
            {
                await Task.WhenAll(task);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Stop()
        {
            if (cancellationTokenSource == null) return;

            cancellationTokenSource.Cancel();
        }

    }
}
