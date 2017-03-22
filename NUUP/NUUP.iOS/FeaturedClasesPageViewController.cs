using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace NUUP.iOS
{
   public partial class FeaturedClasesPageViewController : UIPageViewController
   {
      private PVDataSource dataSource;

      public FeaturedClasesPageViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         var list = new List<ClasePageViewController>();
         var vc = new ClasePageViewController(View.Frame, "Matematicas", 0);
         vc.View.BackgroundColor = UIColor.Red;
         list.Add(vc);

         var vc2 = new ClasePageViewController(View.Frame, "Italiano", 1);
         vc2.View.BackgroundColor = UIColor.Green;
         list.Add(vc2);

         var vc3 = new ClasePageViewController(View.Frame, "Frances", 2);
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
         readonly List<ClasePageViewController> pages;

         public PVDataSource(List<ClasePageViewController> pages)
         {
            this.pages = pages;
         }

         public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
         {
            var currentPage = referenceViewController as ClasePageViewController;

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
            var currentPage = referenceViewController as ClasePageViewController;

            return pages[(currentPage.Index + 1) % pages.Count];
         }
      }
   }
}