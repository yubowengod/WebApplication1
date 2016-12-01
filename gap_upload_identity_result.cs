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
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
 
 
 
 
 


namespace WebApplication1
{
    public class gap_upload_identity_result
    {
        /*
             * gap_identity         
             */
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

        public string calculate_gap_only_1(string path)
        {
            IntPtr intPtr = calculate_gap1(path);
            string str = Marshal.PtrToStringAnsi(intPtr);
            return str;
        }
        

        public string calculate_gap_dll(string gap_flag, string pic_path)
        {

            string str = "";
            if (gap_flag == "1")
            {
                IntPtr intPtr = calculate_gap1(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "2")
            {
                IntPtr intPtr = calculate_gap2(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "3")
            {
                IntPtr intPtr = calculate_gap3(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "4")
            {
                IntPtr intPtr = calculate_gap4(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "5")
            {
                IntPtr intPtr = calculate_gap5(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "6")
            {
                IntPtr intPtr = calculate_gap6(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
            if (gap_flag == "7")
            {
                IntPtr intPtr = calculate_gap7(pic_path);
                str = Marshal.PtrToStringAnsi(intPtr);
            }
             

            return str;
        }



        public string gap_upload_identity_result_FileUploadImage(string gap_num, string bytestr)
        {
            string name = "";
            if (bytestr == "")
            {
                return "null!";
            }
            try
            {
                name = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond;

                string filepath = "D:\\web\\WebApplication1\\webnnn\\" + name + ".jpg";

                StringToFile(bytestr, filepath);

                return filepath;
            }
            catch
            {
                return "wrong!";
            }

        }
        protected System.Drawing.Image Base64StringToImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                ms.Write(arr, 0, arr.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                ms.Close();
                return image;
                //return bmp; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// 把经过base64编码的字符串保存为文件  
        /// </summary>  
        /// <param name="base64String">经base64加码后的字符串 </param>  
        /// <param name="fileName">保存文件的路径和文件名 </param>  
        /// <returns>保存文件是否成功 </returns>  
        public static bool StringToFile(string base64String, string fileName)
        {
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"/beapp/" + fileName;  

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            if (!string.IsNullOrEmpty(base64String) && File.Exists(fileName))
            {
                bw.Write(Convert.FromBase64String(base64String));
            }
            bw.Close();
            fs.Close();
            return true;
        }


    }
}
