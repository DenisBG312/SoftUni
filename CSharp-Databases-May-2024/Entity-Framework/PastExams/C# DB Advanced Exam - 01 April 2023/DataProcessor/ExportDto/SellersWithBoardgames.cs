using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
    public class SellersWithBoardgames
    {
        public string Name { get; set; } = null!;
        public string Website { get; set; } = null!;
        public List<BoardgameExportDto> Boardgames { get; set; }
    }
}
