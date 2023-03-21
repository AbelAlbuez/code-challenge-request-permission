using System.ComponentModel.DataAnnotations;

namespace KHENSYS.HRMANAGER.DOMAIN.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
