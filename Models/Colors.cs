using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MotdEditor.Models
{
    public class Colors
    {
        public SolidColorBrush ColorMC {  get; set; }
        public char Code {  get; set; }

        public static SolidColorBrush GetSolidColorBrush(char c) => c switch
        {
            '0' => new SolidColorBrush(Color.FromArgb(255, 00, 00, 00)),
            '1' => new SolidColorBrush(Color.FromArgb(255, 00, 00, 170)),
            '2' => new SolidColorBrush(Color.FromArgb(255, 00, 170, 00)),
            '3' => new SolidColorBrush(Color.FromArgb(255, 00, 170, 170)),
            '4' => new SolidColorBrush(Color.FromArgb(255, 170, 00, 00)),
            '5' => new SolidColorBrush(Color.FromArgb(255, 170, 00, 170)),
            '6' => new SolidColorBrush(Color.FromArgb(255, 255, 170, 00)),
            '7' => new SolidColorBrush(Color.FromArgb(255, 170, 170, 170)),
            '8' => new SolidColorBrush(Color.FromArgb(255, 85, 85, 85)),
            '9' => new SolidColorBrush(Color.FromArgb(255, 85, 85, 255)),
            'a' => new SolidColorBrush(Color.FromArgb(255, 85, 255, 85)),
            'b' => new SolidColorBrush(Color.FromArgb(255, 85, 255, 255)),
            'c' => new SolidColorBrush(Color.FromArgb(255, 255, 85, 85)),
            'd' => new SolidColorBrush(Color.FromArgb(255, 255, 85, 255)),
            'e' => new SolidColorBrush(Color.FromArgb(255, 255, 255, 85)),
            'f' => new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
            'g' => new SolidColorBrush(Color.FromArgb(255, 221, 214, 5)),
            'h' => new SolidColorBrush(Color.FromArgb(255, 227, 212, 209)),
            'i' => new SolidColorBrush(Color.FromArgb(255, 206, 202, 202)),
            'j' => new SolidColorBrush(Color.FromArgb(255, 68, 58, 59)),
            'm' => new SolidColorBrush(Color.FromArgb(255, 151, 22, 7)),
            'n' => new SolidColorBrush(Color.FromArgb(255, 180, 104, 77)),
            'p' => new SolidColorBrush(Color.FromArgb(255, 222, 177, 45)),
            'q' => new SolidColorBrush(Color.FromArgb(255, 17, 160, 54)),
            's' => new SolidColorBrush(Color.FromArgb(255, 44, 186, 168)),
            't' => new SolidColorBrush(Color.FromArgb(255, 33, 73, 123)),
            'u' => new SolidColorBrush(Color.FromArgb(255, 154, 92, 198)),
            _ => new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
        };
}
}
