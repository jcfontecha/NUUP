﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Category
   {
      public int IdCategory { get; set; }
      public string Label { get; set; }

      public List<Subject> Subjects { get; set; }

      public Category()
      {
      }
   }
}
