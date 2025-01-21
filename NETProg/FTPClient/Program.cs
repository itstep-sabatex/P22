// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text;

FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org");
ftpWebRequest.Credentials = new NetworkCredential("anonymous","");
ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
try
{
    var data = new byte[8000];
    FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
    int bytes = ftpWebResponse.GetResponseStream().Read(data, 0, data.Length);
    ftpWebResponse.Close();
    Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

}
catch (Exception e)
{

}
var request = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org/welcome.msg");
request.Credentials = new NetworkCredential("anonymous", "");
request.Method = WebRequestMethods.Ftp.DownloadFile;
try
{
    var data = new byte[80000];
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    Int32 bytes = response.GetResponseStream().Read(data, 0, data.Length);
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, bytes));

}
catch (Exception e)
{

}