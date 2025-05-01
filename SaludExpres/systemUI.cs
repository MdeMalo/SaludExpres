using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SaludExpres
{
    internal class systemUI
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWCOMPOSITIONATTRIBDATA
        {
            public WINDOWCOMPOSITIONATTRIB Attrib;
            public IntPtr pvData;
            public int cbData;
        }

        // Define una enumeración de los atributos de estilo de ventana que se pueden configurar
        public enum WINDOWCOMPOSITIONATTRIB
        {
            WCA_ACCENT_POLICY = 19,
        }

        // Define una estructura que representa la política de acento de la ventana
        [StructLayout(LayoutKind.Sequential)]
        public struct ACCENTPOLICY
        {
            public int nAccentState;
            public int nFlags;
            public int nColor;
            public int nAnimationId;
        }

        // Define una enumeración de los estados de acento de la ventana
        public enum ACCENTSTATE
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
            ACCENT_ENABLE_HOSTBACKDROP = 5,
            ACCENT_INVALID_STATE = 6
        }

        // Define una función externa de la API de Windows que se utiliza para establecer la política de acento de la ventana
        [DllImport("user32.dll")]
        public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WINDOWCOMPOSITIONATTRIBDATA data);


        public static void activeUI(Form actualForm)
        {
            // Obtén el controlador de la ventana actual
            IntPtr hwnd = actualForm.Handle;

            // Crea una estructura que represente la política de acento de la ventana
            ACCENTPOLICY accent = new ACCENTPOLICY();

            // Configura la política de acento para habilitar la transparencia de la barra de título
            accent.nAccentState = (int)ACCENTSTATE.ACCENT_ENABLE_TRANSPARENTGRADIENT;
            accent.nFlags = 0;
            accent.nColor = 0;
            accent.nAnimationId = 0;

            // Crea una estructura que represente la información de estilo de la ventana
            WINDOWCOMPOSITIONATTRIBDATA data = new WINDOWCOMPOSITIONATTRIBDATA();
            data.Attrib = WINDOWCOMPOSITIONATTRIB.WCA_ACCENT_POLICY;
            data.pvData = Marshal.AllocHGlobal(Marshal.SizeOf(accent));
            Marshal.StructureToPtr(accent, data.pvData, false);
            data.cbData = Marshal.SizeOf(accent);


            // Establece la política de acento de la ventana para habilitar la transparencia de la barra de título
            SetWindowCompositionAttribute(hwnd, ref data);

            // Establece el color de fondo de la ventana como el color de fondo de la barra de título
            actualForm.BackColor = SystemColors.ActiveCaption;

        }

        }
    }
