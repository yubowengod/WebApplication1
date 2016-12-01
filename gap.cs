using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;


namespace WebApplication1
{
    public class gap
    {
        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        
        public static extern IntPtr calculate_gap1(string teststr);      

        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap2(string teststr);

        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap3", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap3(string teststr);
        
        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap4(string teststr);         

        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap5", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap5(string teststr);        

        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap6", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap6(string teststr);        

        [DllImport("ConsoleApplication3.dll", EntryPoint = "calculate_gap7", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]

        public static extern IntPtr calculate_gap7(string teststr);        

        public string calculate_gap_dll(int gap_flag,string pic_path)
        {

            string str = "";
            if (gap_flag == 1)
            {
                IntPtr intPtr = calculate_gap1(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 2)
            {
                IntPtr intPtr = calculate_gap2(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 3)
            {
                IntPtr intPtr = calculate_gap3(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 4)
            {
                IntPtr intPtr = calculate_gap4(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 5)
            {
                IntPtr intPtr = calculate_gap5(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 6)
            {
                IntPtr intPtr = calculate_gap6(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == 7)
            {
                IntPtr intPtr = calculate_gap7(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }

            return str; 
        }
    }
}