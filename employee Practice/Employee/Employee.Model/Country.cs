using Employee.Shared.Common;
using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Model;

public class Countries : BaseAuditableEntity, IEntity<int>
{
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public string? Courencies {  get; set; }
    [NotMapped]
    public ICollection<States> State { get; set; } = new HashSet<States>();
    [NotMapped]
    public ICollection<Employees> Employee { get; set; } = new HashSet<Employees>();
}
