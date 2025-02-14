﻿using Comet.WPF.Handlers;
using Comet.WPF.Services;
using System.Windows;

namespace Comet.WPF
{
    public static class UI
    {
        private static bool _hasInitialized;

        public static void Init()
        {
            if (_hasInitialized) return;
            _hasInitialized = true;

            // Controls
            Registrar.Handlers.Register<Button, ButtonHandler>();
            Registrar.Handlers.Register<Image, ImageHandler>();
            Registrar.Handlers.Register<Text, TextHandler>();
            Registrar.Handlers.Register<TextField, TextFieldHandler>();
            Registrar.Handlers.Register<Toggle, ToggleHandler>();
            //Registrar.Handlers.Register<WebView, WebViewHandler> ();

            // Containers
            Registrar.Handlers.Register<ScrollView, ScrollViewHandler>();
            Registrar.Handlers.Register<ListView, ListViewHandler>();
            Registrar.Handlers.Register<View, ViewHandler>();
            Registrar.Handlers.Register<ContentView, ContentViewHandler>();

            // Common Layout
            Registrar.Handlers.Register<Spacer, SpacerHandler>();

            // Native Layout
            //Registrar.Handlers.Register<VStack, VStackHandler>();
            //Registrar.Handlers.Register<HStack, HStackHandler>();

            // Managed Layout
            Registrar.Handlers.Register<VStack, ManagedVStackHandler>();
            Registrar.Handlers.Register<HStack, ManagedHStackHandler>();
            Registrar.Handlers.Register<ZStack, ManagedZStackHandler>();

            Device.BitmapService = new WPFBitmapService();

            Device.PerformInvokeOnMainThread = a => Application.Current.Dispatcher.Invoke(a);

            ListView.HandlerSupportsVirtualization = false;
        }
    }
}
