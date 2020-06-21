using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace Server
{
	public class WorkerRole : RoleEntryPoint
	{
		private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

		public override void Run()
		{
			Trace.TraceInformation("Server is running");

			try
			{
				this.RunAsync(this.cancellationTokenSource.Token).Wait();
			}
			finally
			{
				this.runCompleteEvent.Set();
			}
		}

		public override bool OnStart()
		{
			// Задайте максимальное число одновременных подключений
			ServicePointManager.DefaultConnectionLimit = 12;

			// Дополнительные сведения по управлению изменениями конфигурации
			// см. статью MSDN по адресу https://go.microsoft.com/fwlink/?LinkId=166357.

			bool result = base.OnStart();

			Trace.TraceInformation("Server has been started");

			return result;
		}

		public override void OnStop()
		{
			Trace.TraceInformation("Server is stopping");

			this.cancellationTokenSource.Cancel();
			this.runCompleteEvent.WaitOne();

			base.OnStop();

			Trace.TraceInformation("Server has stopped");
		}

		private async Task RunAsync(CancellationToken cancellationToken)
		{
			// TODO: замените следующее собственной логикой.
			while (!cancellationToken.IsCancellationRequested)
			{
				Trace.TraceInformation("Working");
				await Task.Delay(1000);
			}
		}
	}
}
