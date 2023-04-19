using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BackendLab01;

public class Surveys : IIdentity<int>
{
    [Key]
    public int Id { get; set; }
    public string Name { get; init; }

    [ForeignKey("User_id")]
    public int Author_Id { get; init; }

    public string Access { get; init; }

    public virtual Users User { get; set; }
}