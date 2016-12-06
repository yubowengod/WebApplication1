using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
namespace WebApplication1
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务,请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        DBOperation dbOperation = new DBOperation();

        CSharp2Dll csharp2Dll = new CSharp2Dll();

        gap gap_class = new gap();

        gap_upload_identity_result gap_upload_identity_result_class = new gap_upload_identity_result();

        [WebMethod]
        public string calculate_gap_only_1(int flag, string path) 
        {
           return gap_upload_identity_result_class.calculate_gap_only_1(path);
        }
        [WebMethod(Description = "picture identity")]
        public bool identity_pic(string picpath)
        {
            return csharp2Dll.identity_pic(picpath);
        }
        [WebMethod(Description = "gap1to7")]
        public string gap1to7(int gap_flag,string picpath)
        {
            return gap_class.calculate_gap_dll(gap_flag,picpath);
        }

        [WebMethod(Description = "calculate_gap_dll")]
        public string calculate_gap_dll(string gap_flag, string bytestr)
        {
            return gap_upload_identity_result_class.calculate_gap_dll(gap_flag, bytestr);
        }
        [WebMethod(Description = "gap_upload_identity_result_FileUploadImage")]
        public string gap_upload_identity_result_FileUploadImage(string xianlu_chehao_chexiang, string gognwei_gongxu_xiangdian, string fengxileibie, string gap_flag, string bytestr)
        {
            string[] xianlu_chehao_chexiang_split = xianlu_chehao_chexiang.Split(new char[] { ',' });

            string[] gognwei_gongxu_xiangdian_split = gognwei_gongxu_xiangdian.Split(new char[] { ',' });

            string return_result = "";

            string string_to_file_pic_path = gap_upload_identity_result_class.gap_upload_identity_result_FileUploadImage(gap_flag, bytestr);//生成pic

            string file_identity_reslt = gap_class.calculate_gap_dll(Convert.ToInt32(gap_flag), string_to_file_pic_path);//返回结果

            string[] file_identity_reslt_split = file_identity_reslt.Split(new char[] { ',' });


            if (file_identity_reslt_split.Length == 5)
            {
                //identity_result_frompc(string gongwei,string gongxu,string xiangdian,string fengxileibie, string fengxibianhao, string tupianlujing, string a, string b, string c, string d, string e,string xianlu,string chehao,string chexiang)
                dbOperation.identity_result_frompc(gognwei_gongxu_xiangdian_split[0], gognwei_gongxu_xiangdian_split[1], gognwei_gongxu_xiangdian_split[2], fengxileibie, gap_flag, string_to_file_pic_path, file_identity_reslt_split[0], file_identity_reslt_split[1], file_identity_reslt_split[2], file_identity_reslt_split[3], file_identity_reslt_split[4], xianlu_chehao_chexiang_split[0], xianlu_chehao_chexiang_split[1], xianlu_chehao_chexiang_split[2]);
            }

            else if (file_identity_reslt_split.Length == 3)
            {
                //identity_result_frompc(string gongwei,string gongxu,string xiangdian,string fengxileibie, string fengxibianhao, string tupianlujing, string a, string b, string c, string d, string e,string xianlu,string chehao,string chexiang)
                dbOperation.identity_result_frompc(gognwei_gongxu_xiangdian_split[0], gognwei_gongxu_xiangdian_split[1], gognwei_gongxu_xiangdian_split[2], fengxileibie, gap_flag, string_to_file_pic_path, file_identity_reslt_split[0], file_identity_reslt_split[1], file_identity_reslt_split[2], file_identity_reslt_split[2], file_identity_reslt_split[2], xianlu_chehao_chexiang_split[0], xianlu_chehao_chexiang_split[1], xianlu_chehao_chexiang_split[2]);
            }
            return_result = return_result + string_to_file_pic_path + "@";

            return_result = return_result + file_identity_reslt + "@";

            return return_result;
        }
       
        [WebMethod]
        //gap_upload_identity_result_FileUploadImage(string gap_num, string bytestr)
        //public string HelloWorld(string gapflag, string pic_path)
        public string HelloWorld(string gap_flag, string bytestr)
        {
            string return_result = "";

            string string_to_file_pic_path = gap_upload_identity_result_class.gap_upload_identity_result_FileUploadImage(gap_flag, bytestr);

            return_result = return_result + string_to_file_pic_path + "@";

            return return_result;



            //return string_to_file_pic_path;


            //return gap_upload_identity_result_class.calculate_gap_dll(gap_num, string_to_file_pic_path) + "+" + gap_num + "," + string_to_file_pic_path;

            //return gap_upload_identity_result_class.calculate_gap_dll(gapflag, pic_path) + "+" + gapflag + "," + pic_path;
            
           
        }
        //username_password(string username,string password)

        [WebMethod(Description = "用户、密码")]
        public string[] username_password(string username,string password)
        {
            return dbOperation.username_password(username,password).ToArray();
        }

        [WebMethod(Description = "注册")]
        public string register_infomation(string username, string password, string question, string answer, string level)
        {
            return dbOperation.register_infomation(username, password, question, answer, level);
        }
        //find_infomation(string flag,string username,string password,string question,string answer)
        [WebMethod(Description = "找回")]
        public string find_infomation(string flag, string username, string password, string question, string answer)
        {
            return dbOperation.find_infomation(flag, username, password, question, answer);
        }
        [WebMethod(Description = "获取所有BROADVIEW")]
        public string[] select_All_BROADVIEW()
        {
            return dbOperation.select_All_BROADVIEW().ToArray();
        }

        [WebMethod(Description = "获取所有信息")]
        public string[] selectAllCargoInfor()
        {
            return dbOperation.selectAllCargoInfor().ToArray();
        }
        [WebMethod(Description = "获取testlistview")]
        public string[] selecttestlistview()
        {
            return dbOperation.selectAlltest_listview().ToArray();
        }

        [WebMethod(Description = "增加 hui")]
        public bool insertCargoInfo(string Cname,int Cnum)
        {
            return dbOperation.insertCargoInfo(Cname,Cnum);
        }

        [WebMethod(Description = "删除")]
        public bool deleteCargoInfo(string Cno)
        {
            return dbOperation.deleteCargoInfo(Cno);
        }
        [WebMethod(Description = "创建文件夹")]
        public bool createfile()
        {
            string savePath = Server.MapPath("./webnnn");
            if (!Directory.Exists(savePath))
            {
                //需要注意的是,需要对这个物理路径有足够的权限,否则会报错 
                Directory.CreateDirectory(savePath);
                return true;
               
            }
            else 
            {
                return false;
            }
        }


        [WebMethod(Description = "上传图片_insert_webnn_http://192.168.155.1:8011/webnnn/")]
        public bool FileUploadImage(string title,string contect,string bytestr)
        {
            string name = "";
            if (bytestr == "")
            {
                return false;
            }
            try
            {
                name = DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute +"_"+ DateTime.Now.Second +"_"+ DateTime.Now.Millisecond;

                bool flag = StringToFile(bytestr,"D:\\web\\WebApplication1\\webnnn\\" + name + ".jpg");
                
                //new
                dbOperation.insert_pic_Info("name","http://192.168.155.1:8011/webnnn/" + name + ".jpg");

                return true;
            }
            catch
            {
                return false;
            }

        }
        protected System.Drawing.Image Base64StringToImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                ms.Write(arr,0,arr.Length);
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
        public static bool StringToFile(string base64String,string fileName)
        {
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"/beapp/" + fileName;  

            System.IO.FileStream fs = new System.IO.FileStream(fileName,System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            if (!string.IsNullOrEmpty(base64String) && File.Exists(fileName))
            {
                bw.Write(Convert.FromBase64String(base64String));
            }
            bw.Close();
            fs.Close();
            return true;
        }



        [WebMethod(Description = "image to base64")]
        public string ImgToBase64String(string Imagefilename)
        {
            try
            {

                //D:\web\WebApplication1\webnnn\2016951115_8_910.jpg                                
                Bitmap bmp = new Bitmap("D:/web/WebApplication1/webnnn/6.jpg");
                //this.pictureBox1.Image = bmp;
                //FileStream fs = new FileStream(Imagefilename + ".txt",FileMode.Create);
                //StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr,0,(int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                //sw.Write(strbaser64);

                //sw.Close();
                //fs.Close();
                return strbaser64;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

            
        [WebMethod(Description = "所有upload_pic")]
        public string[] selectAll_UPDATE_USER_INFO(string flag,string UPDATE_USER)
        {
            return dbOperation.selectAll_UPDATE_USER_INFO(flag,UPDATE_USER).ToArray();
        }


        [WebMethod(Description = "在装线路chejian_name_num_pic")]
        public string[] selectAllZAIZHUANGXIANLU()
        {
            return dbOperation.selectAllZAIZHUANGXIANLU().ToArray();
        }

        [WebMethod(Description = "获取所有工位")]
        public string[] select_spinner_gongwei()
        {
            return dbOperation.select_spinner_gongwei().ToArray();
        }

        //public bool insertCargoInfo(string Cname,int Cnum)
        //{
        //    return dbOperation.insertCargoInfo(Cname,Cnum);
        //}
        [WebMethod(Description = "获取工位对应的工序")]
        public string[] select_spinner_gongxu(string GW)
        {
            return dbOperation.select_spinner_gongxu(GW).ToArray();
        }

        [WebMethod(Description = "获取获取工位对应的工序的检查项点")]
        public string[] select_spinner_xiangdian(string GW, string GX)
        {
            return dbOperation.select_spinner_xiangdian(GW, GX).ToArray();
        }

        [WebMethod(Description = "获取获取工位对应的工序的检查项点检查说明")]
        public string[] select_spinner_shuoming(string GW, string GX, string JCXD)
        {
            return dbOperation.select_spinner_shuoming(GW,GX,JCXD).ToArray();
        }
        [WebMethod(Description = "获取获取工位对应的工序的检查项点picture")]
        public string[] select_spinner_xiangdian_pic(string GW, string GX)
        {
            return dbOperation.select_spinner_xiangdian_pic(GW, GX).ToArray();
        }

        
    }
} 


