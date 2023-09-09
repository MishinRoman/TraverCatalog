using Microsoft.Extensions.FileProviders;

using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models
{
    public class Media : BaseModel, IFileInfo
    {
        public bool Exists { get; set; } = false;

        public bool IsDirectory { get; set; } = false;

        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;

        public long Length => 0;
        [Column("FileName")]
        public string Name { get; set; }
        [Column("Path")]
        public string? PhysicalPath { get; set; }
        public TravelModel Travel { get; set; }

         
        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
