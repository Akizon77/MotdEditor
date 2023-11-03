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
            _ => new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
        };
}
}
