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
using CommunityToolkit.Mvvm.ComponentModel;
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

            Settings.motd1 = ViewModel.Motd1;
            Settings.motd2 = ViewModel.Motd2;
            ViewModel.Output = ui_line1.Text.ReplaceChar().ConvertUnicode()
                + "\\n"
                + ui_line2.Text.ReplaceChar().ConvertUnicode();
            Settings.Save();
            
        }

        void AddOneLine(string rawstr)
        {
            //如果不包含样式代码，直接输出原内容
            if (!rawstr.Contains('§'))
            {
                ui_motd.Inlines.Add(
                    new Run { Text = rawstr, Foreground = Models.Colors.GetSolidColorBrush('f') }
                );
                return;
            }
            //包含样式代码，对内容进行分割
            var contents = rawstr.Split('§');
            var list = contents.ToList();
            //默认的样式
            var lastStyle = FontStyles.Normal;
            FontWeight lastWeight = FontWeights.Normal;
            TextDecorationCollection lastDecorations = new TextDecorationCollection();
            SolidColorBrush lastSolidColorBrush = Models.Colors.GetSolidColorBrush('f');
            //对每一段分割的内容处理样式
            for (int i = 0; i < list.Count; i++)
            {
                //继承上一次的样式
                SolidColorBrush solidColorBrush = lastSolidColorBrush;
                var style = lastStyle;
                var weight = lastWeight;
                TextDecorationCollection decorations = new();
                foreach (var item in lastDecorations)
                    decorations.Add(item);
                //如果内容是空的，跳过
                if (String.IsNullOrEmpty(list[i]))
                    continue;
                //第一段不包含样式，直接输出
                if (i == 0)
                {
                    ui_motd.Inlines.Add(
                        new Run
                        {
                            Text = list[i],
                            Foreground = Models.Colors.GetSolidColorBrush('f')
                        }
                    );
                    continue;
                }
                //颜色调整 由于MC特性，颜色会覆盖格式化
                if ("0123456789abcdef".Contains(list[i].First()))
                {
                    style = FontStyles.Normal;
                    weight = FontWeights.Normal;
                    decorations = new TextDecorationCollection();
                    solidColorBrush = Models.Colors.GetSolidColorBrush(list[i].First());
                }
                //对样式进行调整
                if ("klmnor".Contains(list[i].First()))
                {
                    switch (list[i].First())
                    {
                        case 'k':
                            decorations.Add(TextDecorations.OverLine);
                            break;
                        case 'l':
                            weight = FontWeights.Black;
                            break;
                        case 'm':
                            decorations.Add(TextDecorations.Strikethrough);
                            break;
                        case 'n':
                            decorations.Add(TextDecorations.Underline);
                            break;
                        case 'o':
                            style = FontStyles.Italic;
                            break;
                        case 'r':
                            solidColorBrush = Models.Colors.GetSolidColorBrush('f');
                            style = FontStyles.Normal;
                            decorations.Clear();
                            weight = FontWeights.Normal;
                            break;
                        default:
                            break;
                    }
                }

                ui_motd.Inlines.Add(
                    new Run
                    {
                        Text = list[i].Remove(0, 1),
                        Foreground = solidColorBrush,
                        FontStyle = style,
                        TextDecorations = decorations,
                        FontWeight = weight,
                    }
                );
                lastSolidColorBrush = solidColorBrush;
                lastStyle = style;
                lastWeight = weight;
                lastDecorations = decorations;
            }
        }

        private void ui_output_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }

    static class Extensions
    {
        public static string ReplaceChar(this string str) => str.Replace("&", "§");

        public static string ConvertUnicode(this string input)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in input)
            {
                if (IsUnicode(c))
                {
                    output.Append("\\u");
                    output.Append(((int)c).ToString("X4"));
                }
                else
                {
                    int asciiValue = (int)c;
                    //if (asciiValue >= 32 && asciiValue <= 126)
                    output.Append(c);
                }
            }
            return output.ToString();
        }

        public static bool IsUnicode(this char c)
        {
            //return c >= 127 && c <= 0x9FFF;
            return c > 126;
        }
    }
}
