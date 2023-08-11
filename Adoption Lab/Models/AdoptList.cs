using System;
using System.Collections.Generic;

namespace Adoption_Lab.Models;

public partial class AdoptList
{
    public int Id { get; set; }

    public string? Img { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Breed { get; set; }

    public int? Age { get; set; }
}
