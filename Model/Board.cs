using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendo_me
{
    public class Board
    {
        public string Name { get; set; } = string.Empty;
        public string ImageSource { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;

        public Board (string name, string imageSource)
        {
            Name = name;
            ImageSource = imageSource;
        }
    }
}
