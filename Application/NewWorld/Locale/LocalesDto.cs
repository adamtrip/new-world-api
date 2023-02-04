using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.Locale
{
    internal class LocalesDto
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public string ISO { get; set; }
    }
}
