using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;


namespace WebApplication1
{
    public class CSharp2Dll
    {
        [DllImport("idtetity.dll")]
        static extern int identity3(string init);        

        public bool identity_pic(string pic_path)
        {
            if (identity3(pic_path).ToString() == "1")
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