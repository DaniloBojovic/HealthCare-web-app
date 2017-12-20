using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int? PacijentID { get; set; }
        public int? LekarID { get; set; }//
        public virtual Pacijent Pacijent { get; set; }
        public virtual Lekar Lekar { get; set; }//
    }
}