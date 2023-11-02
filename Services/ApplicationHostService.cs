using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotdEditor.Services
{
    internal class ApplicationHostService : IHostedService
    {
        public readonly IServiceProvider _serviceProvider;
        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var mainwindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
