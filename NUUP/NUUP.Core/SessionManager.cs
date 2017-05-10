using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public enum SessionState
   {
      NotLoggedIn,
      LoggingIn,
      LoggedIn
   }

   public class LoginFailEventArgs
   {
      public string Message { get; set; }
   }

   public class LoginSuccessEventArgs
   {
      public User User { get; set; }
      public string SessionToken { get; set; }
   }

   public class FacebookCallbackEventArgs
   {
      public string Query { get; set; }
   }

   public class SessionManager
   {
      public User User { get; private set; }
      public string SessionToken { get; private set; }
      public string FacebookAccessToken { get; private set; }

      public SessionState State { get; private set; }

      private static SessionManager instance;
      public static SessionManager Instance
      {
         get
         {
            if (instance == null)
            {
               instance = new SessionManager();
            }

            return instance; 
         }
      }

      private SessionManager()
      {
         State = SessionState.NotLoggedIn;
      }

      public void StartLogin()
      {
         State = SessionState.LoggingIn;
         OnLoginStarted(new EventArgs());
      }

      public void SetFacebookCallback(string query)
      {
         OnFacebookCallback(new FacebookCallbackEventArgs()
         {
            Query = query
         });
      }
      
      public async void SetLoginInfoAsync(User user, string sessionToken)
      {
         if (user != null)
         {
            State = SessionState.LoggedIn;

            User = user;
            SessionToken = sessionToken;

            if (string.IsNullOrEmpty(user.FirstName))
            {
               var request = new RecordRequest()
               {
                  Path = Path.User,
                  Id = user.IdUser
               };

               try
               {
                  user = await ServiceManager.Instance.GetResourceAsync<User>(request);
               }
               catch (Exception e)
               {
                  if (e is UnexpectedParsingException)
                  {
                     throw new ServerErrorException("There was an error getting the resource from the server", e);
                  }
                  else
                  {
                     throw e;
                  }
               }
            }

            OnLoginSuccess(new LoginSuccessEventArgs()
            {
               User = user,
               SessionToken = sessionToken
            });
         }
      }

      public void FailLogin(string message)
      {
         State = SessionState.NotLoggedIn;

         OnLoginFail(new LoginFailEventArgs()
         {
            Message = message
         });
      }

      #region Events

      public event EventHandler LoginStarted;
      public event EventHandler<FacebookCallbackEventArgs> FacebookCallback;
      public event EventHandler<LoginSuccessEventArgs> LoginSuccess;
      public event EventHandler<LoginFailEventArgs> LoginFail;

      protected virtual void OnLoginStarted(EventArgs e)
      {
         LoginStarted?.Invoke(this, e);
      }

      protected virtual void OnFacebookCallback(FacebookCallbackEventArgs e)
      {
         FacebookCallback?.Invoke(this, e);
      }

      protected virtual void OnLoginSuccess(LoginSuccessEventArgs e)
      {
         LoginSuccess?.Invoke(this, e);
      }

      protected virtual void OnLoginFail(LoginFailEventArgs e)
      {
         LoginFail?.Invoke(this, e);
      }

      #endregion

   }

}
