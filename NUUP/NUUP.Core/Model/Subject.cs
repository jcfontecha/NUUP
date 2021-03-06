﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace NUUP.Core.Model
{
   public class Subject
   {
      public static readonly string IdSubjectField = "idSubject";
      public static readonly string NameField = "name";
      public static readonly string IdCategoryField = "idCategory";
      public static readonly string OffersField = "offer_by_idSubject";
      public static readonly string IntervalsField = "interval_by_offer";
      public static readonly string UsersWhoOfferItField = "user_by_offer";
      public static readonly string UsersWhoLookForItField = "user_by_usr_looksfor_subject";

      [JsonProperty("idSubject")]
      public int IdSubject { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("idCategory")]
      public int IdCategory { get; set; }

      [JsonProperty("category_by_idCategory")]
      public Category Category { get; set; }

      [JsonProperty("offer_by_idSubject")]
      public List<Offer> Offers { get; set; }

      [JsonProperty("interval_by_offer")]
      public List<Interval> Intervals { get; set; }

      [JsonProperty("user_by_offer")]
      public List<User> UsersWhoOfferIt { get; set; }

      [JsonProperty("user_by_usr_looksfor_subject")]
      public List<User> UsersWhoLookForIt { get; set; }

      public Subject()
      {

      }
   }
}
