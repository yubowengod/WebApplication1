using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Data.OracleClient;


namespace WebApplication1
{
    /// <summary>
    /// 一个操作数据库的类，所有对SQLServer的操作都写在这个类中，使用的时候实例化一个然后直接调用就可以
    /// </summary>
    public class DBOperation : IDisposable
    {
        public static OracleConnection OracleCon;  //用于连接数据库

        //将下面的引号之间的内容换成上面记录下的属性中的连接字符串
        private String ConServerStr = @"Data Source=WSGA1;User ID=xwpolice;Password=njust8032;Unicode=True";

        //默认构造函数
        public DBOperation()
        {
            if (OracleCon == null)
            {
                OracleCon = new OracleConnection();
                OracleCon.ConnectionString = ConServerStr;
                OracleCon.Open();
            }
        }

        //关闭/销毁函数，相当于Close()
        public void Dispose()
        {
            if (OracleCon != null)
            {
                OracleCon.Close();
                OracleCon = null;
            }
        }


        public List<string> select_all_from_UPDATE_PICTURE_INFO_table(string flag, string updatetime, string user, string xianlu, string chehao, string chexiang, string gw, string gx, string xd)
        {
            List<string> list = new List<string>();

            if (flag == "updatetime")
            {
                try
                {
                    string Oracle = "select distinct updatetime from UPDATE_PICTURE_INFO where uploaduser = '" + user + "' and xianlu = '" + xianlu + "' and chehao = '" + chehao + "' and gongwei = '" + gw + "' and gongxu = '" + gx + "' and xiangdian ='" + xd + "' order by updatetime desc ";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }
                catch (Exception)
                {

                }
            }

            else if (flag == "phonetupianlujing")
            {
                try
                {
                    string Oracle = "select phonetupianlujing from UPDATE_PICTURE_INFO where updatetime = to_date('" + updatetime + "', 'yyyy-MM-dd HH24:mi:ss') and uploaduser = '" + user + "' and xianlu = '" + xianlu + "' and chehao = '" + chehao + "' and gongwei = '" + gw + "' and gongxu = '" + gx + "' and xiangdian ='" + xd + "' order by updatetime desc";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();
                }
                catch (Exception)
                {

                }
            }

            return list;
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="gw"></param>
        /// <param name="gx"></param>
        /// <param name="xd"></param>
        /// <returns></returns>
        public List<string> select_all_from_identity_table(string flag, string updatetime, string user, string xianlu, string chehao, string chexiang, string gw, string gx, string xd)
        {

            List<string> list = new List<string>();
            if (flag == "only_updatetime")
            {
                try
                {
                    string Oracle = "select biaodingzhi,  shuipingmax,  shuipingmin,  chuizhimax,  chuizhimin ,phonetupianlujing from FENGXI where updatetime = to_date('" + updatetime + "', 'yyyy-MM-dd HH24:mi:ss') and uploaduser = '" + user + "'";

                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());
                        list.Add(reader[1].ToString());
                        list.Add(reader[2].ToString());
                        list.Add(reader[3].ToString());
                        list.Add(reader[4].ToString());
                        list.Add(reader[5].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }
                catch (Exception)
                {

                }
            }
            if (flag == "updatetime")
            {
                try
                {
                    string Oracle = "select distinct updatetime from FENGXI where uploaduser = '" + user + "' and xianlu = '" + xianlu + "' and chehao = '" + chehao + "' and gognwei = '" + gw + "' and gongxu = '" + gx + "' and xiangdian ='" + xd + "' order by updatetime desc ";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }
                catch (Exception)
                {

                }
            }

            else if (flag == "phonetupianlujing")
            {
                try
                {
                    string Oracle = "select phonetupianlujing from FENGXI where updatetime = to_date('" + updatetime + "', 'yyyy-MM-dd HH24:mi:ss') and uploaduser = '" + user + "' and xianlu = '" + xianlu + "' and chehao = '" + chehao + "' and gognwei = '" + gw + "' and gongxu = '" + gx + "' and xiangdian ='" + xd + "' order by updatetime desc";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();
                }
                catch (Exception)
                {

                }
            }




            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploaduser"></param>
        /// <param name="gongwei"></param>
        /// <param name="gongxu"></param>
        /// <param name="xiangdian"></param>
        /// <param name="fengxileibie"></param>
        /// <param name="fengxibianhao"></param>
        /// <param name="tupianlujing"></param>
        /// <param name="phonetupianlujing"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="updatetime"></param>
        /// <param name="xianlu"></param>
        /// <param name="chehao"></param>
        /// <param name="chexiang"></param>
        /// <returns></returns>
        public string identity_result_frompc(string uploaduser, string gongwei, string gongxu, string xiangdian, string fengxileibie, string fengxibianhao, string tupianlujing, string phonetupianlujing, string a, string b, string c, string d, string e, string updatetime, string xianlu, string chehao, string chexiang)
        {
            try
            {
                string Oracle = "INSERT INTO fengxi (uploaduser,gognwei,gongxu,xiangdian,fengxileibie,fengxibianhao,tupianlujing,phonetupianlujing,biaodingzhi,shuipingmax,shuipingmin,chuizhimax,chuizhimin,updatetime,xianlu,chehao,chexiang)VALUES('" + uploaduser + "','" + gongwei + "','" + gongxu + "','" + xiangdian + "','" + fengxileibie + "','" + fengxibianhao + "','" + tupianlujing + "','" + phonetupianlujing + "'," + a + "," + b + "," + c + "," + d + "," + e + ",to_date('" + updatetime + "', 'yyyy-MM-dd HH24:mi:ss'),'" + xianlu + "','" + chehao + "','" + chexiang + "')";

                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "bingo";

            }
            catch (Exception)
            {
                return "fuck";
            }
        }

        /// <summary>
        /// register_infomation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>

        public string register_infomation(string username, string password, string question, string answer, string level)
        {
            List<string> list = new List<string>();
            string flag = "";

            try
            {
                //insert into user_infomation(username,password,question,answer,userlevel) SELECT 'yu','yu','电话多少','18545055186','1' FROM DUAL  where not exists(select * from user_infomation where username='yu'); 

                string Oracle = "select count(*) from user_infomation where username = '" + username + "'";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中

                    if (reader[0].ToString() == "1")
                    {
                        flag = "1";
                    }
                    else if (reader[0].ToString() == "0")
                    {
                        string Oracle_insert = "insert into user_infomation(username,password,question,answer,userlevel) values ('" + username + "','" + password + "','" + question + "','" + answer + "','1')";
                        cmd = new OracleCommand(Oracle_insert, OracleCon);
                        cmd.ExecuteNonQuery();
                        flag = "0";

                    }
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

            }
            return flag;
        }

        /// <summary>
        /// find_infomation
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public string find_infomation(string flag, string username, string password, string question, string answer)
        {
            string result = "";
            string www = "";
            if (flag == "0")
            {
                string Oracle = "select question from USER_INFOMATION where username = '" + username + "'";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader[0].ToString();

                }
                reader.Close();
                cmd.Dispose();
            }
            if (flag == "1")
            {
                string Oracle = "select password from USER_INFOMATION where username = '" + username + "' and answer = '" + answer + "' and question = '" + question + "'";

                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    result = reader[0].ToString();

                }
                reader.Close();
                cmd.Dispose();

            }

            return result;
        }

        /// <summary>
        /// 获取所有货物的信息
        /// </summary>
        /// <returns>所有货物信息</returns>
        public List<string> username_password(string username, string password)
        {
            List<string> list = new List<string>();

            try
            {
                //select count(*) from USER_INFOMATION where username='ybw'and password='as'
                string Oracle = "select count(*) from USER_INFOMATION where username='" + username + "'and password='" + password + "'";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }


        /// <summary>
        /// 获取所有货物的信息
        /// </summary>
        /// <returns>所有货物信息</returns>
        public List<string> selectAllCargoInfor()
        {
            List<string> list = new List<string>();

            try
            {
                string Oracle = "select * from C order by Cno desc";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());

                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        /// <summary>
        /// 获取BROADVIEW
        /// </summary>
        /// <returns></returns>
        public List<string> select_All_BROADVIEW()
        {
            List<string> list = new List<string>();

            try
            {
                string Oracle = "select * from  BROADVIEW order by BROADVIEW_DATE desc";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    //list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());

                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// 增加一条货物信息
        /// </summary>
        /// <param name="Cname">货物名称</param>
        /// <param name="Cnum">货物数量</param>
        public bool insertCargoInfo(string Cname, int Cnum)
        {
            try
            {
                string Oracle = "insert into C (Cname,Cnum) values ('" + Cname + "'," + Cnum + ")";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条货物信息
        /// </summary>
        /// <param name="Cno">货物编号</param>
        public bool deleteCargoInfo(string Cno)
        {
            try
            {
                string Oracle = "delete from C where Cno=" + Cno;
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="update_user"></param>
        /// <param name="update_picture_name"></param>
        /// <returns></returns>
        public void insert_pic_Info(string update_user, string update_picture_name)
        {
            try
            {
                //string Oracle = "insert into C (Cname,Cnum) values ('" + Cname + "'," + Cnum + ")";

                string Oracle = "insert into update_user_info (update_user,update_picture_name) values ('" + update_user + "','" + update_picture_name + "')";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //return true;
            }
            catch (Exception)
            {
                //return false;
            }
        }

        public bool insert_picInfo_into_UPDATE_PICTURE_INFO(
            string gongwei, 
            string gongxu,
            string xiangdian,
            string uploaduser,
            string xianlu,
            string chehao,
            string chexiang,
            string tupianlujing,
            string updatetime,
            string phonetupianlujing)
   
        {
            try
            { 
                string Oracle = "insert into update_picture_info (gongwei,gongxu,xiangdian,uploaduser,xianlu,chehao,chexiang,tupianlujing,updatetime,phonetupianlujing) values ('"
                    + gongwei + "','" + gongxu + "','" + xiangdian+ "','" + uploaduser+ "','" + xianlu+ "','" + chehao+ "','" + chexiang+ "','" + tupianlujing+ "',"
                    + "to_date('" + updatetime + "', 'yyyy-MM-dd HH24:mi:ss') ,'" + phonetupianlujing + "')";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> selectAlltest_listview()
        {
            List<string> list = new List<string>();

            try
            {
                string Oracle = "select * from test_listview order by id";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> selectAllZAIZHUANGXIANLU()
        {
            List<string> list = new List<string>();

            try
            {
                string Oracle = "select * from ZAIZHUANGXIANLU order by id";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }



        /// <summary>
        /// select_spinner_gongwei
        /// </summary>
        /// <returns></returns>
        public List<string> select_spinner_gongwei()
        {
            List<string> list = new List<string>();

            try
            {
                //select * from GW_GX_XD t
                string Oracle = "select distinct GW from GW_GX_XD order by GW";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }


        /// <summary>
        /// select_spinner_gongwei
        /// </summary>
        /// <returns></returns>
        public List<string> select_spinner_gongxu(string GW)
        {
            List<string> list = new List<string>();

            try
            {
                //select distinct GXID,GX from GW_GX_XD where GW ='A1205' order by GXID
                string Oracle = "select distinct GW,GXID,GX from GW_GX_XD where GW ='" + GW + "' order by GXID";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// select_spinner_gongwei
        /// </summary>
        /// <returns></returns>
        public List<string> select_spinner_xiangdian(string GW, string GX)
        {
            List<string> list = new List<string>();

            try
            {
                //select distinct GW,GXID,GX,jcXD from GW_GX_XD where GW ='A1205' and gxid=4 order by GXID
                string Oracle = "select distinct GW,GX,JCXD,JCSM,GXID from GW_GX_XD where GW ='" + GW + "' and GX='" + GX + "' order by GXID";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());

                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// select_spinner_检测说明
        /// </summary>
        /// <returns></returns>
        public List<string> select_spinner_shuoming(string GW, string GX, string JCXD)
        {
            List<string> list = new List<string>();

            try
            {
                //select distinct GW,GXID,GX,jcXD from GW_GX_XD where GW ='A1205' and gxid=4 order by GXID
                string Oracle = "select distinct GW,GX,JCXD,JCSM,picinfo GXID from GW_GX_XD where GW ='" + GW + "' and GX='" + GX + "' " + "and JCXD ='" + JCXD + "' order by GXID";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// select_spinner_检测项照片
        /// </summary>
        /// <returns></returns>
        public List<string> select_spinner_xiangdian_pic(string GW, string GX)
        {
            List<string> list = new List<string>();

            try
            {
                //select distinct GW,GXID,GX,jcXD from GW_GX_XD where GW ='A1205' and gxid=4 order by GXID
                //string Oracle = "select picinfo GXID from GW_GX_XD where GW ='" + GW + "' and GX='" + GX + "' " + "and JCXD ='" + JCXD + "' order by GXID";
                string Oracle = "select distinct GW,GX,JCXD,JCSM,picinfo GXID from GW_GX_XD where GW ='" + GW + "' and GX='" + GX + "' order by GXID";
                OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// update_user         VARCHAR2(100),
        /// update_picture_name VARCHAR2(500),
        /// updatetime                DATE,
        /// beizhu              VARCHAR2(500)
        /// </summary>
        /// <returns></returns>
        public List<string> selectAll_UPDATE_USER_INFO(string flag, string UPDATE_USER)
        {
            List<string> list = new List<string>();
            try
            {
                if (flag == "1")
                {
                    string Oracle = "select * from UPDATE_USER_INFO order by id";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());
                        list.Add(reader[1].ToString());
                        list.Add(reader[2].ToString());
                        list.Add(reader[3].ToString());
                        list.Add(reader[4].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }

                if (flag == "2")
                {
                    string Oracle = "select update_user,update_picture_name from UPDATE_USER_INFO where UPDATE_USER='" + UPDATE_USER + "' order by update_user";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //将结果集信息添加到返回向量中
                        //list.Add(reader[0].ToString());
                        list.Add(reader[1].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }

                if (flag == "3")
                {
                    string Oracle = "select distinct update_user from UPDATE_USER_INFO order by update_user";
                    OracleCommand cmd = new OracleCommand(Oracle, OracleCon);
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //将结果集信息添加到返回向量中
                        list.Add(reader[0].ToString());

                    }

                    reader.Close();
                    cmd.Dispose();

                }
            }
            catch (Exception)
            {

            }
            return list;

        }
    }
}