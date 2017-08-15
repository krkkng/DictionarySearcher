using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DictionarySearcher
{
    public static class Serializer
    {
        public static void Serialize(List<HistoryItem> history)
        {
            var filename = Assembly.GetExecutingAssembly().Location;
            var filepath = System.IO.Path.GetDirectoryName(filename);
            var serializefile = filepath + @"\history.xml";
            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<HistoryItem>));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                serializefile, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, history);
            //ファイルを閉じる
            sw.Close();
        }

        public static List<HistoryItem> DeSerialize()
        {
            var obj = new List<HistoryItem>();
            //保存元のファイル名
            var filename = Assembly.GetExecutingAssembly().Location;
            var filepath = System.IO.Path.GetDirectoryName(filename);
            var serializefile = filepath + @"\history.xml";

            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<HistoryItem>));
            try
            {
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    serializefile, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                obj =  (List<HistoryItem>)serializer.Deserialize(sr);
                sr.Close();
            }
            catch
            {
                return null;
            }
            return obj;
        }
    }
}
