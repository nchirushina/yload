using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyYTLoader.DAL.Entities
{
    public class VideoEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public VideoState State { get; set; }
    }

    public enum VideoState
    {
        New = 0,
        Processing = 1,
        Done = 2,
        Error = 3,
        Deleted = 4
    }
}
