﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaciesKitchen.Models.RecipeModels
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Last Updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
