using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Core
{
    public class File
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SizeId { get; set; }

        public DateTime DownloadDate { get; set; }

        public string Expansion { get; set; }

        public string Note { get; set; }

        public int CategoryId { get; set; }

        public string Url { get; set; }
    }
}
