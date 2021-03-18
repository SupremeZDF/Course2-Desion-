using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FtpServer.FTP
{
    public class OneRunModel
    {
        /// <summary>
        /// FTP 上传文件
        /// </summary>
        /// <returns></returns>
        public static void UploadFileInFTP(string filename) 
        {
            Stream stream = null;
            FileStream fileStream = null;
            FtpWebRequest ftpWebRequest = null;
            FtpWebResponse ftpWebResponse = null;
            {
                //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("");
                //httpWebRequest.Method =
            }
            //ip
            string serverIP;
            // user Name
            string userName;
            //密码
            string password;
            //上传 Url
            string uploadurl;

            try
            {
                serverIP = "192.168.31.66:2020";
                userName = "supreme";
                password = "123456";
                uploadurl = "ftp://" + serverIP + "/ImagePath/2020_12_12/" + Path.GetFileName(filename);
                //创建 FTP 请求
                ftpWebRequest = (FtpWebRequest)WebRequest.Create(uploadurl);
                //获取或设置要发送到 FTP 服务器的命令。
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpWebRequest.Proxy = null;
                // 设置Ftp身份验证
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = userName;
                nc.Password = password;
                ftpWebRequest.Credentials = nc;
                ftpWebRequest.KeepAlive = true;
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.UsePassive = true;
                //ftpWebRequest.EnableSsl = true;
                stream = ftpWebRequest.GetRequestStream();
                using (fileStream = File.Open(filename, FileMode.Open)) 
                {
                    byte[] buffer = new byte[1024];
                    var length = 0;
                    do
                    {
                        length = fileStream.Read(buffer, 0,1024);
                        stream.Write(buffer, 0, 1024);
                    } while (length == 1024);
                    //fileStream.Close();
                }
                ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// FTP 上传文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int UploadFtp(string filename)
        {
            FtpWebRequest reqFTP = null;
            string serverIP;
            string userName;
            string password;
            string url;

            try
            {
                FileInfo fileInf = new FileInfo(filename);
                serverIP = "192.168.131.162:2020";
                userName = "supreme";
                password = "123456";
                url = "ftp://" + serverIP + "/" + Path.GetFileName(filename);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.Credentials = new NetworkCredential(userName, password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.UseBinary = true;
                //设置 FTP 请求 内容长度
                reqFTP.ContentLength = fileInf.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                FileStream fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                Stream strm = reqFTP.GetRequestStream();

                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {

                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
                return 0;
            }
            catch (Exception ex)
            {
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
                return -2;
            }
        }

        /// <summary>
        /// 检测文件夹是否存在
        /// </summary>
        /// <param name="destFilePath"></param>
        public static void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath);
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }


        //创建目录  
        public static Boolean FtpMakeDir(string localFile)
        {
            string serverIP;
            string userName;
            string password;
            string url;
            serverIP = "192.168.31.66:2020";
            userName = "supreme";
            password = "123456";
            url = "ftp://" + serverIP +  localFile;
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(url);
            req.Credentials = new NetworkCredential(userName, password);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }


        public static int DownloadFtp(string filename)
        {
            FtpWebRequest reqFTP;
            string serverIP;
            string userName;
            string password;
            string url;

            try
            {
                serverIP = "192.168.131.162:2020";
                userName = "supreme";
                password = "123456";
                url = "ftp://" + serverIP + "/" + Path.GetFileName(filename);

                FileStream outputStream = new FileStream(filename, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return 0;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }
    }
}
