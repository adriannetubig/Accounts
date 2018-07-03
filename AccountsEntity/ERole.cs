using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("Role")]
    public class ERole : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EUserRole> UserRoles { get; set; }
    }
}
