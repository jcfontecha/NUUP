using System;
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
   public class User
   {
      [JsonProperty("idUser")]
      public int IdUser { get; set; }

      [JsonProperty("idDreamfactory")]
      public int IdDreamfactory { get; set; }

      [JsonProperty("first_name")]
      public string FirstName { get; set; }

      [JsonProperty("last_name")]
      public string LastName { get; set; }

      [JsonProperty("name")]
      public string DisplayName { get; set; }

      [JsonProperty("email")]
      public string Email { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("birthday")]
      public DateTime Birthday { get; set; }

      [JsonProperty("lat")]
      public float? Lat { get; set; }

      [JsonProperty("lng")]
      public float? Lng { get; set; }

      [JsonProperty("idDegree")]
      public int? IdDegree { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }

      [JsonProperty("ratingTutor")]
      public float? RatingTutor { get; set; }

      [JsonProperty("ratingStudent")]
      public float? RatingStudent { get; set; }

      [JsonProperty("degree_by_idDegree")]
      public Degree Degree { get; set; }

      [JsonProperty("subject_by_usr_looksfor_subject")]
      public List<Subject> LooksForSubjects { get; set; }

      [JsonProperty("session_by_idTutor")]
      public List<Session> TutorSessions { get; set; }

      [JsonProperty("session_by_idStudent")]
      public List<Session> StudentSessions { get; set; }

      [JsonProperty("interval_by_usr_interval")]
      public List<Interval> AvailableIntervals { get; set; }

      [JsonProperty("group_by_idTutor")]
      public List<Group> TutorGroups { get; set; }

      [JsonProperty("offer_by_idUser")]
      public List<Offer> Offers { get; set; }

      [JsonProperty("membership_by_idUser")]
      public List<Membership> Memberships { get; set; }

      [JsonProperty("group_by_membership")]
      public List<Group> Groups { get; set; }

      [JsonProperty("friendship_by_idUser1")]
      public List<Friendship> Friendships1 { get; set; }

      [JsonProperty("friendship_by_idUser2")]
      public List<Friendship> Friendships2 { get; set; }

      [JsonProperty("friend_request_by_idUserTo")]
      public List<FriendRequest> FriendRequests { get; set; }

      [JsonProperty("message_by_idUserFrom")]
      public List<Message> SentMessages { get; set; }

      [JsonProperty("message_by_idUserTo")]
      public List<Message> ReceivedMessages { get; set; }

      [JsonProperty("post_by_idUser")]
      public List<Post> Posts { get; set; }

      public List<User> Friends { get; set; }

      public User()
      {
         LooksForSubjects = new List<Subject>();
         TutorGroups = new List<Group>();
         StudentSessions = new List<Session>();
         AvailableIntervals = new List<Interval>();
         TutorGroups = new List<Group>();
         Offers = new List<Offer>();
         Memberships = new List<Membership>();
         Friendships1 = new List<Friendship>();
         Friendships2 = new List<Friendship>();
         FriendRequests = new List<FriendRequest>();
         Friends = new List<User>();
         SentMessages = new List<Message>();
         ReceivedMessages = new List<Message>();
      }
   }
}
