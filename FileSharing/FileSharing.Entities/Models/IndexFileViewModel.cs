using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Models
{
    public class IndexFileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public string Description { get; set; }

        public string UserLogin { get; set; }

        public DateTime DownloadDate { get; set; }

        public int UserId { get; set; }

        public bool IsPublic { get; set; }
    }
}
