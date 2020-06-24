using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetAcademia_CommandWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            startCommand = new SajatParancs((param) => Start(), (param) => !IsWorking);
            stopCommand = new SajatParancs((param) => Stop(), (param) => IsWorking);

        }
        private int progressValue = 0;
        private CancellationTokenSource cancellationTokenSource = null;
        private Task task = null;
        private ICommand startCommand;
        private ICommand stopCommand;
        public ICommand StartCommand { get => startCommand; }
        public ICommand StopCommand { get => stopCommand; }
        public bool IsWorking
        {
            get
            {
                if (task == null)
                    return false;

                switch (task.Status)
                {
                    case TaskStatus.Created:
                    case TaskStatus.RanToCompletion:
                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                        //nem fut a task
                        return true;
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingToRun:
                    case TaskStatus.Running:
                    case TaskStatus.WaitingForChildrenToComplete:
                        //fut a task
                        return true;
                    default:
                        //ismeretlen a statuszunk, nincs a program erre felkeszitve
                        throw new ArgumentOutOfRangeException(string.Format($"task.Status ismeretlen: {task.Status}"));
                }
            }
        }

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

            task = new Task(() =>
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
            finally
            {
                CommandManager.InvalidateRequerySuggested();
            }

            task = null;
        }
        public void Stop()
        {
            if (cancellationTokenSource == null) return;

            cancellationTokenSource.Cancel();
        }

    }
}
