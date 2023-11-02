using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using MotdEditor.Models;
using MotdEditor.MVVM;
using Wpf.Ui.Controls;

namespace MotdEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindowViewModel ViewModel { get; }
        AppSettings Settings { get; set; }

        public MainWindow(MainWindowViewModel viewModel, AppSettings appSettings)
        {
            ViewModel = viewModel;
            Settings = appSettings;
            DataContext = this;
            InitializeComponent();
        }

        private void Iuput1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDisplay();
        }

        private void Iuput2_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDisplay();
        }

        void SetDisplay()
        {
            if (ui_line1 is null || ui_line2 is null)
                return;
            ui_motd.Inlines.Clear();
            AddOneLine(ui_line1.Text.ReplaceChar());
            ui_motd.Inlines.Add(new LineBreak());
            AddOneLine(ui_line2.Text.ReplaceChar());
        }

        void AddOneLine(string rawstr)
        {
            if (!rawstr.Contains('§'))
            {
                ui_motd.Inlines.Add(new Run
                {
                    Text = rawstr,
                    Foreground = Models.Colors.GetSolidColorBrush('f')
                }); 
                return;
            }//没有默认是白色
            var contents = rawstr.Split('§');
            var list = contents.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    ui_motd.Inlines.Add(new Run
                    {
                        Text = list[i],
                        Foreground = Models.Colors.GetSolidColorBrush('f')
                    });
                    continue;
                }//添加第一个
                //TODO:判断色彩和字体调整
                ui_motd.Inlines.Add(
                    new Run
                    {
                        Text = list[i].Remove(0, 1),
                        Foreground = Models.Colors.GetSolidColorBrush(list[i].First())
                    }
                );
            }
        }
    }

    static class Extensions
    {
        public static string ReplaceChar(this string str) => str.Replace("&", "§");
    }
}
