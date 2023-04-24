﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRadar.Domain.Entities;
public class Workshop
{
    public required int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public WorkshopContactDetails ContactDetails { get; set; } = default!;
    public string EncodedName { get; private set; } = default!;

    private void EndodeName() => EncodedName = Name.ToLowerInvariant().Replace(" ", "-");
}
