using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS2024RestAPI;

public class Rating
{
    public int Id { get; set; }
    public string Source { get; set; }
    public string Value { get; set; }
}