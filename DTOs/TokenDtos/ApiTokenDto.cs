using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.TokenDtos
{
    public class ApiTokenDto
    {
        public string Id { get; set; }

        public string Key { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
