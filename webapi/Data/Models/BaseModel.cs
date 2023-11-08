﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Models
{
    public abstract class BaseModel
    {
        [Key]
        
        public Guid? Id { get; set; } = Guid.NewGuid();

    }
}
