using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ValueObjects;
public class PersonEntity
{
    [Key]
    public int PersonId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}
