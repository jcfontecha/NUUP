// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NUUP.iOS
{
    [Register ("DetalleClaseTableViewController")]
    partial class DetalleClaseTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel categoriaLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descripcionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell headerCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel horarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nombreMateriaLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nombreUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel rolUsuarioLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (categoriaLabel != null) {
                categoriaLabel.Dispose ();
                categoriaLabel = null;
            }

            if (descripcionLabel != null) {
                descripcionLabel.Dispose ();
                descripcionLabel = null;
            }

            if (headerCell != null) {
                headerCell.Dispose ();
                headerCell = null;
            }

            if (horarioLabel != null) {
                horarioLabel.Dispose ();
                horarioLabel = null;
            }

            if (nombreMateriaLabel != null) {
                nombreMateriaLabel.Dispose ();
                nombreMateriaLabel = null;
            }

            if (nombreUsuarioLabel != null) {
                nombreUsuarioLabel.Dispose ();
                nombreUsuarioLabel = null;
            }

            if (rolUsuarioLabel != null) {
                rolUsuarioLabel.Dispose ();
                rolUsuarioLabel = null;
            }
        }
    }
}