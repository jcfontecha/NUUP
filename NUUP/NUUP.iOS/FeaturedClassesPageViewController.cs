using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace NUUP.iOS
{
   public partial class FeaturedClassesPageViewController : UIPageViewController
   {
      private PVDataSource dataSource;

      public FeaturedClassesPageViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         var list = new List<ClassPageViewController>();
         var vc = new ClassPageViewController(View.Frame, "Matematicas", 0);
         vc.View.BackgroundColor = UIColor.Red;
         list.Add(vc);

         var vc2 = new ClassPageViewController(View.Frame, "Italiano", 1);
         vc2.View.BackgroundColor = UIColor.Green;
         list.Add(vc2);

         var vc3 = new ClassPageViewController(View.Frame, "Frances", 2);
         vc3.View.BackgroundColor = UIColor.Blue;
         list.Add(vc3);

         DataSource = dataSource = new PVDataSource(list);

         this.SetViewControllers(new UIViewController[] { list[0] },
            UIPageViewControllerNavigationDirection.Forward, true, s => { });

         // INTENTOS PARA QUE SE VEA EL INDICADOR
         // ... fallidos hasta ahora
         var pageControlAppearance = UIPageControl.AppearanceWhenContainedIn(typeof(UIPageViewController));
         pageControlAppearance.PageIndicatorTintColor = UIColor.LightGray;
         pageControlAppearance.CurrentPageIndicatorTintColor = UIColor.DarkGray;

         foreach (var subview in View.Subviews)
         {
            if (subview is UIPageControl)
            {
               var pageControl = (UIPageControl)subview;
               pageControl.PageIndicatorTintColor = UIColor.LightGray;
               pageControl.CurrentPageIndicatorTintColor = UIColor.DarkGray;
               pageControl.Layer.ZPosition = 1;
            }
         }
      }

      class PVDataSource : UIPageViewControllerDataSource
      {
         readonly List<ClassPageViewController> pages;

         public PVDataSource(List<ClassPageViewController> pages)
         {
            this.pages = pages;
         }

         public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
         {
            var currentPage = referenceViewController as ClassPageViewController;

            if (currentPage.Index == 0)
            {
               return pages[pages.Count - 1];
            }
            else
            {
               return pages[currentPage.Index - 1];
            }
         }

         public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
         {
            var currentPage = referenceViewController as ClassPageViewController;

            return pages[(currentPage.Index + 1) % pages.Count];
         }
      }
   }
}