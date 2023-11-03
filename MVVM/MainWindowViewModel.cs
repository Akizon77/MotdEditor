using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        string motd1;

        [ObservableProperty]
        string motd2;
        [ObservableProperty]
        string output;

        [ObservableProperty]
        ObservableCollection<Colors> colorsMC = new();

        public MainWindowViewModel(AppSettings appSettings)
        {
            Settings = appSettings;
            "0123456789abcdef"
                .ToList<char>()
                .ForEach(c =>
                {
                    ColorsMC.Add(new Colors { ColorMC = Colors.GetSolidColorBrush(c), Code = c });
                });
        }

        [RelayCommand]
        void OnLoad()
        {
            Motd1 = Settings.motd1;
            Motd2 = Settings.motd2;
        }
        [RelayCommand]
        void OnSave()
        {
            Settings.motd1 = Motd1;
            Settings.motd2 = Motd2;
            Settings.Save();
        }
    }
}
