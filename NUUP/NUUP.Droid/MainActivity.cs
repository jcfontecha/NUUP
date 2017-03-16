using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace NUUP.Droid
{
   [Activity(Label = "NUUP.Droid", MainLauncher = true, Icon = "@drawable/icon")]
   public class MainActivity : Activity, ActionBar.ITabListener
   {
      int count = 1;

      public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
      {
      }

      public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
      {
         switch (tab.Position)
         {
            case 0:
               SetContentView(Resource.Layout.Noticias);
               break;
            case 1:
               SetContentView(Resource.Layout.Clases);
               break;
            case 2:
               SetContentView(Resource.Layout.Busqueda);
               break;
            case 3:
               SetContentView(Resource.Layout.Grupos);
               break;
            case 4:
               SetContentView(Resource.Layout.MiPerfil);
               break;
            default:
               break;
         }
      }

      public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
      {
      }

      protected override void OnCreate(Bundle bundle)
      {
         base.OnCreate(bundle);

         ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

         ActionBar.Tab  tab = ActionBar.NewTab();
         tab.SetText("Noticias");
         tab.SetTabListener(this);
         ActionBar.AddTab(tab);

         tab = ActionBar.NewTab();
         tab.SetText("Clases");
         tab.SetTabListener(this);
         ActionBar.AddTab(tab);


         tab = ActionBar.NewTab();
         tab.SetText("Búsqueda");
         tab.SetTabListener(this);
         ActionBar.AddTab(tab);

         tab = ActionBar.NewTab();
         tab.SetText("Grupos");
         tab.SetTabListener(this);
         ActionBar.AddTab(tab);

         tab = ActionBar.NewTab();
         tab.SetText("Perfil");
         tab.SetTabListener(this);
         ActionBar.AddTab(tab);

         // Set our view from the "main" layout resource
         SetContentView(Resource.Layout.Noticias);

         // Get our button from the layout resource,
         // and attach an event to it
         //Button button = FindViewById<Button>(Resource.Id.MyButton);

         //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
      }
   }
}

