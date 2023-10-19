﻿using Employee.Shared;
using Employee.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Model;

public class States:BaseAuditableEntity,IEntity
{
    public int Id { get; set; }
    public string StateName { get; set; }
    public int CountryId { get; set; }
    public Countries? Country { get; set; }
    [NotMapped]
    public ICollection<Employees> Employee { get; set; } = new HashSet<Employees>();

}
