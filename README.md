# QsLicenseCheck

本サンプルは、デフォルトのプロキシサーバ設定を使用せずに
Qlik社のライセンスサーバに接続出来るかを確認するプログラムです。
Qlik Senseはデフォルトのプロキシ設定を使用しないため、
Qlik Senseインストール前にプロキシの疎通確認を行いたい時にご使用頂けます。

＜仕様＞
1.コマンドプロンプト上でプロキシのアドレスを設定
　http://サーバ or IP:ポート番号
2.プロキシ経由でQlik社のライセンスサーバ(https://license.qlikcloud.com/)に接続
3.Httpステータスコードを取得
4.404エラー(NotFound)が返れば疎通OK、その他のステータスコードなら疎通NGを表示
