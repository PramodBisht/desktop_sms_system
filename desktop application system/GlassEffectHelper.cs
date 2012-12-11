using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace WpfApplication1
{
    class GlassEffectHelper
    {
        
        
            [DllImport("dwmapi.dll", PreserveSig = false)]
            static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            static extern bool DwmIsCompositionEnabled();
           

            public static bool EnableGlassEffect(Window window)
            {
                window.MouseLeftButtonDown += (s, e) =>
                {
                    window.DragMove();
                };
                return EnableGlassEffect(window, true);
            }

            public static bool EnableGlassEffect(Window window, bool enabled)
            {
                return EnableGlassEffect(window, enabled, new Thickness(-1));
            }

            public static bool EnableGlassEffect(Window window, bool enabled, Thickness margin)
            {
                if (!VersionHelper.IsAtLeastVista)
                {
                   
                    return false;
                }

                if (!DwmIsCompositionEnabled())
                {
                    return false;
                }

                if (enabled)
                {
                    IntPtr hwnd = new WindowInteropHelper(window).Handle;


                    window.Background = Brushes.Transparent;


                    HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor =
      
                       Color.FromArgb(56,61,60,59);


                    MARGINS margins = new MARGINS(margin);


                    DwmExtendFrameIntoClientArea(hwnd, ref margins);
                }
                else
                {

                    window.Background = SystemColors.WindowBrush;
                }

                return true;
            }
        }

        struct MARGINS
        {
            public MARGINS(Thickness t)
            {
                Left = (int)t.Left;
                Right = (int)t.Right;
                Top = (int)t.Top;
                Bottom = (int)t.Bottom;
            }

            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }
        public class VersionHelper
        {
            /// <summary>
            /// OS is at least Windows Vista
            /// </summary>
            public static bool IsAtLeastVista
            {
                get
                {
                    if (Environment.OSVersion.Version.Major < 6)
                    {
                        Debug.WriteLine("How about trying this on Vista?");
                        return false;
                    }
                    return true;
                }
            }

         
            public static bool IsWindows7orHigher
            {
                get
                {
                    if (Environment.OSVersion.Version.Major == 6 &&
                        Environment.OSVersion.Version.Minor >= 1)
                    {
                        return true;
                    }
                    else if (Environment.OSVersion.Version.Major > 6)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
