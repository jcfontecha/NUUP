using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class RecordRequest
   {
      public Path Path { get; set; }
      public int? Id { get; set; }
      public IEnumerable<string> Fields { get; set; }
      public IEnumerable<string> Related { get; set; }
      public string Filter { get; set; }
      public string Limit { get; set; }
      public string Offset { get; set; }
      public string Order { get; set; }
      public IEnumerable<string> Group { get; set; }
      public bool? CountOnly { get; set; }
      public bool? IncludeCount { get; set; }
      public bool? IncludeSchema { get; set; }
      public IEnumerable<int> Ids { get; set; }
      public IEnumerable<string> IdField { get; set; }
      public bool? Continue { get; set; }
      public bool? Rollback { get; set; }
      public string File { get; set; }

      public string CustomQuery { get; set; }

      public RecordRequest()
      {
         InitializeLists();
      }

      public RecordRequest(Path path)
      {
         Path = path;

         InitializeLists();
      }

      public RecordRequest(Path path, IEnumerable<string> fields)
      {
         Path = path;
         Fields = fields;

         InitializeLists();
      }

      private void InitializeLists()
      {
         Fields = new List<string>();
         Related = new List<string>();
         Group = new List<string>();
         Ids = new List<int>();
         IdField = new List<string>();
      }

      public string GetURL()
      {
         string url = "";
         bool firstParameter = true;
         
         // Abstracts checking if we should add ? or & before a parameter
         Action AddParameterChar = () =>
         {
            if (firstParameter)
            {
               url += "?";
               firstParameter = false;
            }
            else
            {
               url += "&";
            }
         };

         Action<string, IEnumerable<object>> AddListParameter = (name, list) =>
         {
            if (list.Count() > 0)
            {
               AddParameterChar();
               url += name + "=" + Uri.EscapeDataString(string.Join(",", list));
            }
         };

         Action<string, IEnumerable<int>> AddIntListParameter = (name, list) =>
         {
            if (list.Count() > 0)
            {
               AddParameterChar();
               url += name + "=" + Uri.EscapeDataString(string.Join(",", list));
            }
         };

         Action<string, string> AddStringParameter = (name, value) =>
         {
            if (!string.IsNullOrEmpty(value))
            {
               AddParameterChar();
               url += name + "=" + Uri.EscapeDataString(value);
            }
         };

         Action<string, bool?> AddBoolParameter = (name, value) =>
         {
            if (value.HasValue)
            {
               AddParameterChar();
               string boolString = value.Value ? "true" : "false";
               url += name + "=" + boolString;
            }
         };

         // Add Path
         url += Path.Value;

         // If we have a custom query, we don't need to build one.
         if (!string.IsNullOrEmpty(CustomQuery))
         {
            return url + CustomQuery;
         }

         // If we only have one Id we can call it directly
         if (Id.HasValue)
         {
            url += "/" + Id;
         }
         
         // Add Parameters
         AddListParameter("fields", Fields);
         AddListParameter("related", Related);
         AddStringParameter("filter", Filter);
         AddStringParameter("limit", Limit);
         AddStringParameter("offset", Offset);
         AddStringParameter("order", Order);
         AddListParameter("group", Group);
         AddBoolParameter("count_only", CountOnly);
         AddBoolParameter("include_count", IncludeCount);
         AddBoolParameter("include_schema", IncludeSchema);
         AddIntListParameter("ids", Ids);
         AddListParameter("IdField", IdField);
         AddBoolParameter("continue", Continue);
         AddBoolParameter("rollback", Rollback);
         AddStringParameter("file", File);

         return url;
      }

      public override string ToString()
      {
         return GetURL();
      }
   }
}
