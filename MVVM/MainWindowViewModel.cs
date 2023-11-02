using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MotdEditor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MotdEditor.MVVM
{
    public partial class MainWindowViewModel : ObservableObject
    {
        AppSettings Settings;

        [ObservableProperty]
        ObservableCollection<Colors> colorsMC = new();

        [ObservableProperty]
        string line1 = "Chroma Endless 1.1.0 色度无尽";
        [ObservableProperty]
        string line2 = "Travel Around Server 环球旅行 将在 5 天后更换周目";
        [ObservableProperty]
        string output;

        public MainWindowViewModel(AppSettings appSettings)
        {
            Settings = appSettings;
            "0123456789abcdefghijmnpqstu"
                .ToList<char>()
                .ForEach(c =>
                {
                    ColorsMC.Add(new Colors { ColorMC = Colors.GetSolidColorBrush(c), Code = c });
                });
        }

        

    }
}
