using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public class MessageBoxEx
{
    private static IntPtr _owner;
    private static HookProc _hookProc;
    private static IntPtr _hHook;

    public static DialogResult Show(string text)
    {
        Initialize();
        return MessageBox.Show(text);
    }

    public static DialogResult Show(string text, string caption)
    {
        Initialize();
        return MessageBox.Show(text, caption);
    }

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
    {
        Initialize();
        return MessageBox.Show(text, caption, buttons);
    }

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        Initialize();
        return MessageBox.Show(text, caption, buttons, icon);
    }

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
    {
        Initialize();
        return MessageBox.Show(text, caption, buttons, icon, defButton);
       
    }

    public static DialogResult Show(IWin32Window owner, string text)
    {
        _owner = owner.Handle;
        Initialize();
        return MessageBox.Show(owner, text);
    }

    public static DialogResult Show(IWin32Window owner, string text, string caption)
    {
        _owner = owner.Handle;
        Initialize();
        return MessageBox.Show(owner, text, caption);
    }

    public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
    {
        _owner = owner.Handle;
        Initialize();
        return MessageBox.Show(owner, text, caption, buttons);
    }

    public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        _owner = owner.Handle;
        Initialize();
        return MessageBox.Show(owner, text, caption, buttons, icon);
    }

    public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
    {
        _owner = owner.Handle;
        Initialize();
        return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
    }

    public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

    public const int WH_CALLWNDPROCRET = 12;

    public enum CbtHookAction : int
    {
        HCBT_MOVESIZE = 0,
        HCBT_MINMAX = 1,
        HCBT_CREATEWND = 3,
        HCBT_DESTROYWND = 4,
        HCBT_ACTIVATE = 5
    }

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

    [DllImport("user32.dll")]
    private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

    [DllImport("user32.dll")]
    public static extern int UnhookWindowsHookEx(IntPtr idHook);

    [DllImport("user32.dll")]
    public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct CWPRETSTRUCT
    {
        public IntPtr lResult;
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hwnd;
    };

    static MessageBoxEx()
    {
        _hookProc = new HookProc(MessageBoxHookProc);
        _hHook = IntPtr.Zero;
    }

    private static void Initialize()
    {
        if (_hHook != IntPtr.Zero)
        {
            throw new NotSupportedException("Multiple calls are not supported");
        }

        if (_owner != IntPtr.Zero)
        {
            _hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }
    }

    private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode < 0)
        {
            return CallNextHookEx(_hHook, nCode, wParam, lParam);
        }

        CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
        IntPtr hook = _hHook;

        if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
        {
            try
            {
                CenterWindow(msg.hwnd);
            }
            finally
            {
                UnhookWindowsHookEx(_hHook);
                _hHook = IntPtr.Zero;
            }
        }

        return CallNextHookEx(hook, nCode, wParam, lParam);
    }

    private static void CenterWindow(IntPtr hChildWnd)
    {
        Rectangle recChild = new Rectangle(0, 0, 0, 0);
        bool success = GetWindowRect(hChildWnd, ref recChild);

        int width = recChild.Width - recChild.X;
        int height = recChild.Height - recChild.Y;

        Rectangle recParent = new Rectangle(0, 0, 0, 0);
        success = GetWindowRect(_owner, ref recParent);

        Point ptCenter = new Point(0, 0);
        ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
        ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);

        Point ptStart = new Point(0, 0);
        ptStart.X = (ptCenter.X - (width / 2));
        ptStart.Y = (ptCenter.Y - (height / 2));

        ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
        ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

        int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width, height, false);
    }
}
