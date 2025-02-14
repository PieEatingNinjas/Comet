﻿using System;
using Foundation;
using Comet.iOS.Controls;
using UIKit;

// ReSharper disable ClassNeverInstantiated.Global

namespace Comet.iOS.Handlers
{
    public class ListViewHandler : AbstractHandler<ListView, CUITableView>
    {
        public static readonly PropertyMapper<ListView> Mapper = new PropertyMapper<ListView>(ViewHandler.Mapper)
        {
            ["ListView"] = MapListViewProperty,
            [nameof(ListView.ReloadData)] = MapReloadData
        };
        
        public ListViewHandler() : base(Mapper)
        {

        }
        
        protected override CUITableView CreateView()
        {
            return new CUITableView();
        }

        public override void Remove(View view)
        {
            TypedNativeView.ListView = null;
            base.Remove(view);
        }

        public static void MapListViewProperty(IViewHandler viewHandler, ListView virtualView)
        {
            var nativeView = (CUITableView) viewHandler.NativeView;
            nativeView.ListView = virtualView;
            nativeView.SizeToFit();
        }

        public static void MapReloadData(IViewHandler viewHandler, ListView virtualView)
        {
            var nativeView = (CUITableView)viewHandler.NativeView;
            nativeView?.ReloadData();
        }
    }
}
