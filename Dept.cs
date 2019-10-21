using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navi2.Data
{
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }

        public string DeptName { get; set; }
        public int Head { get; set; }
        public string Location { get; set; }


        [Display(Name = " UserRoleID")]
        public int UserRID { get; set; }
        [ForeignKey("UserRID")]
        public UserRole UserRoles { get; set; }
    }
}
