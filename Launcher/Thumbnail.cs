// Copyright 2006 Bart Desmet
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Launcher
{
    [Obfuscation]
    public class Thumbnail : FrameworkElement
    {
        public Thumbnail()
        {
            this.LayoutUpdated += new EventHandler(Thumbnail_LayoutUpdated);
            this.Unloaded += new RoutedEventHandler(Thumbnail_Unloaded);
        }

        public static DependencyProperty SourceProperty;
        public static DependencyProperty ClientAreaOnlyProperty;

        static Thumbnail()
        {
            SourceProperty = DependencyProperty.Register(
                "Source",
                typeof(IntPtr),
                typeof(Thumbnail),
                new FrameworkPropertyMetadata(
                    IntPtr.Zero,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    delegate(DependencyObject obj, DependencyPropertyChangedEventArgs args)
                    {
                        (obj as Thumbnail).InitialiseThumbnail((IntPtr)args.NewValue);
                    }));

            ClientAreaOnlyProperty = DependencyProperty.Register(
                "ClientAreaOnly",
                typeof(bool),
                typeof(Thumbnail),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    delegate(DependencyObject obj, DependencyPropertyChangedEventArgs args)
                    {
                        (obj as Thumbnail).UpdateThumbnail();
                    }));

            OpacityProperty.OverrideMetadata(
                typeof(Thumbnail),
                new FrameworkPropertyMetadata(
                    1.0,
                    FrameworkPropertyMetadataOptions.Inherits,
                    delegate(DependencyObject obj, DependencyPropertyChangedEventArgs args)
                    {
                        (obj as Thumbnail).UpdateThumbnail();
                    }));
        }

        public IntPtr Source
        {
            get { return (IntPtr)this.GetValue(SourceProperty); }
            set { this.SetValue(SourceProperty, value); }
        }

        public bool ClientAreaOnly
        {
            get { return (bool)this.GetValue(ClientAreaOnlyProperty); }
            set { this.SetValue(ClientAreaOnlyProperty, value); }
        }

        public new double Opacity
        {
            get { return (double)this.GetValue(OpacityProperty); }
            set { this.SetValue(OpacityProperty, value); }
        }

        private HwndSource target;
        private IntPtr thumb;

        private void InitialiseThumbnail(IntPtr source)
        {
            if (IntPtr.Zero != thumb)
                ReleaseThumbnail(); // release the old thumbnail

            if (IntPtr.Zero != source)
            {
                // find our parent hwnd
                target = (HwndSource)HwndSource.FromVisual(this);

                // if we have one, we can attempt to register the thumbnail
                if (target != null && 0 == DWM.DwmRegisterThumbnail(target.Handle, source, out this.thumb))
                {
                    DWM.ThumbnailProperties props = new DWM.ThumbnailProperties();
                    props.Visible = false;
                    props.SourceClientAreaOnly = this.ClientAreaOnly;
                    props.Opacity = (byte)(255 * this.Opacity);
                    props.Flags = DWM.ThumbnailFlags.Visible | DWM.ThumbnailFlags.SourceClientAreaOnly | DWM.ThumbnailFlags.Opacity;
                    DWM.DwmUpdateThumbnailProperties(thumb, ref props);
                }
            }
        }

        private void ReleaseThumbnail()
        {
            DWM.DwmUnregisterThumbnail(thumb);
            this.thumb = IntPtr.Zero;
            this.target = null;
        }

        private void UpdateThumbnail()
        {
            if (IntPtr.Zero == thumb) return;

            DWM.ThumbnailProperties props = new DWM.ThumbnailProperties();
            props.SourceClientAreaOnly = this.ClientAreaOnly;
            props.Opacity = (byte)(255 * this.Opacity);
            props.Flags = DWM.ThumbnailFlags.SourceClientAreaOnly | DWM.ThumbnailFlags.Opacity;
            DWM.DwmUpdateThumbnailProperties(thumb, ref props);
        }

        private void Thumbnail_Unloaded(object sender, RoutedEventArgs e)
        {
            ReleaseThumbnail();
        }

        // this is where the magic happens
        private void Thumbnail_LayoutUpdated(object sender, EventArgs e)
        {
            if (IntPtr.Zero == thumb)
                InitialiseThumbnail(this.Source);

            if (IntPtr.Zero != thumb)
            {
                if (target.RootVisual == null || !target.RootVisual.IsAncestorOf(this))
                {
                    //we are no longer in the visual tree
                    ReleaseThumbnail();
                    return;
                }

                GeneralTransform transform = TransformToAncestor(target.RootVisual);
                Point a = transform.Transform(new Point(0, 0));
                Point b = transform.Transform(new Point(this.ActualWidth, this.ActualHeight));

                DWM.ThumbnailProperties props = new DWM.ThumbnailProperties();
                props.Visible = true;
                props.Destination = new DWM.Rect(
                    (int)Math.Ceiling(a.X), (int)Math.Ceiling(a.Y),
                    (int)Math.Ceiling(b.X), (int)Math.Ceiling(b.Y));
                props.Flags = DWM.ThumbnailFlags.Visible | DWM.ThumbnailFlags.RectDetination;
                DWM.DwmUpdateThumbnailProperties(thumb, ref props);
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            try
            {
                DWM.Size size;
                DWM.DwmQueryThumbnailSourceSize(this.thumb, out size);

                double scale = 1;

                // our preferred size is the thumbnail source size
                // if less space is available, we scale appropriately
                if (size.Width > availableSize.Width)
                    scale = availableSize.Width / size.Width;
                if (size.Height > availableSize.Height)
                    scale = Math.Min(scale, availableSize.Height / size.Height);

                return new Size(size.Width * scale, size.Height * scale);
            }
            catch (DllNotFoundException)
            {
                return default(Size);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            try
            {
                DWM.Size size;
                DWM.DwmQueryThumbnailSourceSize(this.thumb, out size);

                // scale to fit whatever size we were allocated
                double scale = finalSize.Width / size.Width;
                scale = Math.Min(scale, finalSize.Height / size.Height);

                return new Size(size.Width * scale, size.Height * scale);
            }
            catch (DllNotFoundException)
            {
                return default(Size);
            }
        }
    }
}