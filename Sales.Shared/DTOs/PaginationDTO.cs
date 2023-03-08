using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.DTOs
{
    public class PaginationDTO
    {
        //Cuando quiera páginar los estados debo decirle de que país es
        public int Id { get; set; }

        //Página en la que estamos
        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 10;
        public string? Filter { get; set; }

    }
}
