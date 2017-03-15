﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class User
   {
      public int IdUser { get; set; }
      public int IdDreamfactory { get; set; }
      public DateTime Birthday { get; set; }
      public float? Lat { get; set; }
      public float? Lng { get; set; }
      public int? IdDegree { get; set; }
      public DateTime Creation { get; set; }
      public float? RatingTutor { get; set; }
      public float? RatingStudent { get; set; }

      public Degree Degree { get; set; }
      public List<Subject> LooksForSubjects { get; set; }
      public List<Session> TutorSessions { get; set; }
      public List<Session> StudentSessions { get; set; }
      public List<Interval> AvailableIntervals { get; set; }
      public List<Group> TutorGroups { get; set; }
      public List<Offer> Offers { get; set; }
      public List<Membership> Memberships { get; set; }
      public List<Friendship> Friendships { get; set; }
      public List<FriendRequest> FriendRequests { get; set; }
      public List<User> Friends { get; set; }
      public List<Message> SentMessages { get; set; }
      public List<Message> ReceivedMessages { get; set; }

      public User()
      {
         LooksForSubjects = new List<Subject>();
         TutorGroups = new List<Group>();
         StudentSessions = new List<Session>();
         AvailableIntervals = new List<Interval>();
         TutorGroups = new List<Group>();
         Offers = new List<Offer>();
         Memberships = new List<Membership>();
         Friendships = new List<Friendship>();
         FriendRequests = new List<FriendRequest>();
         Friends = new List<User>();
         SentMessages = new List<Message>();
         ReceivedMessages = new List<Message>();
      }
   }
}
