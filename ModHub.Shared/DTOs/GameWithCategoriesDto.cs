using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModHub.Shared.Entities;

namespace ModHub.Shared.DTOs
{
    public class GameWithCategoriesDto
    {
        public Game Game { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
