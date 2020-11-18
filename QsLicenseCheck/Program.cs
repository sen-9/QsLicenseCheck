using System;
using System.Net;

namespace QsLicenseCheck
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                //ライセンスサーバのURL
                string httpURL = "https://license.qlikcloud.com/";
                //defaultのプロキシ設定を使用しない
                WebRequest.DefaultWebProxy = null;
                //HHTPリクエスト
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(httpURL);
                //タイムアウト設定(5秒)
                req.Timeout = 5000;
                //プロキシサーバの入力
                Console.WriteLine("プロキシサーバのURLを[http://<プロキシーサーバー>:ポート番号]の形式で入力して下さい。");
                Console.WriteLine("プロキシサーバを使用しない場合はEnterを押して下さい");

                //標準入の情報を受取
                string ProxyURL = Console.ReadLine();
              
                if (ProxyURL != "") { 

                    //プロキシ設定
                    WebProxy proxy = new System.Net.WebProxy(ProxyURL);
                    req.Proxy = proxy;

                }

                //HTTPサーバからデータを受け取る
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("\r\n<応答結果>");
                //HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //HttpWebResponseを取得
                    HttpWebResponse errres =(System.Net.HttpWebResponse)ex.Response;
                    //応答したURIを表示する
                    Console.WriteLine("URI: " + errres.ResponseUri);
                    //応答ステータスコードを表示する
                    Console.WriteLine("ステータスコード: " + errres.StatusCode);

                    if (errres.ResponseUri.ToString() == "https://license.qlikcloud.com/" && errres.StatusCode.ToString() == "NotFound") 
                    {
                         Console.WriteLine("\r\n疎通OK");
                    }
                    else
                    {
                         Console.WriteLine("\r\n疎通NG");
                    }

                }
                else
                    Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
