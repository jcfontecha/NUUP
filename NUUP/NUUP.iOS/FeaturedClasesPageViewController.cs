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
         list.Add(new ClasePageViewController(View.Frame, "Matematicas", 0));
			list.Add(new ClasePageViewController(View.Frame, "Italiano", 1));
			list.Add(new ClasePageViewController(View.Frame, "Frances", 2));

         DataSource = dataSource = new PVDataSource(list);

         this.SetViewControllers(new UIViewController[] { list[0] },
            UIPageViewControllerNavigationDirection.Forward, true, s => { });
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