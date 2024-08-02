using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
    public class BoardgameExportDto
    {
        public string Name { get; set; } = null!;
        public double Rating { get; set; }
        public string Mechanics { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
