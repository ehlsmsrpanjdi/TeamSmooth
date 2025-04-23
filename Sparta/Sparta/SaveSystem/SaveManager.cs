using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Sparta.SelectorSystem;
using Sparta.NameSpace;
using Sparta.Child.Actors;
using System.Runtime.CompilerServices;


namespace Sparta.SaveSystem
{
    struct ItemSaveData
    {
        public string? ItemName;
        public bool IsEquipment;
    }
    struct PlayerSaveData
    {
        public PlayerSaveData()
        {

        }
        public string? Name;
        public string? Job;
        public int Level;
        public int hp;
        public int ListLength;
        public List<ItemSaveData> ItemList = new List<ItemSaveData>();
    }




    class SaveManager
    {
        string? ResourcePath = null;

        public SaveManager()
        {
            DirectoryInfo? dir = new DirectoryInfo(Environment.CurrentDirectory);
            dir = dir.Parent?.Parent?.Parent?.Parent?.Parent;
            ResourcePath = Path.Combine(dir.FullName, "Resource");
            if (!Directory.Exists(ResourcePath))
            {
                Console.WriteLine("경로에 Resource 폴더가 없습니다 Resource 폴더의 경로가 바뀐 것 같습니다.");
                Console.WriteLine("{0} 의 경로에 Resource 폴더가 존재해야합니다", ResourcePath);
            }
        }
        public void Save()
        {
            string[] files = Directory.GetFiles(ResourcePath);  // 현재 폴더의 파일들 가져오기


            while (true)
            {
                Console.Clear();
                for (int i = 1; i < files.Length + 1; ++i)
                {
                    string str = Path.GetFileName(files[i - 1]);
                    Console.WriteLine("{0}번 세이브 데이터 : {1}", i, str);
                }
                Console.WriteLine("1~5번 중 세이브를 할 공간을 고르시오");
                SelectedIndex = selector.Select();
                if (SelectedIndex == -1)
                {
                    continue;
                }
                else if (SelectedIndex <= 0 || SelectedIndex > 5)
                {
                    Key.WrongKey();
                    continue;
                }
                else
                {
                    break;
                }
            }


            PlayerSaveData SaveData = Player.GetPlayer().MakeSaveData();

            DateTime currentTime = DateTime.Now;
            string timeStamp = currentTime.ToString("yyyyMMdd_HHmmss");
            string FileName = SelectedIndex + "_" + timeStamp;

            string savedir = Path.Combine(ResourcePath, FileName);

            Serializer serializer = new Serializer();
            List<byte> bytelist = serializer.Serialize(SaveData);
            byte[] dataBytes = bytelist.ToArray();
            File.WriteAllBytes(savedir, dataBytes);
        }

        public void Load()
        {
            string[] files = Directory.GetFiles(ResourcePath);  // 현재 폴더의 파일들 가져오기


            while (true)
            {
                Console.Clear();
                for (int i = 1; i < files.Length + 1; ++i)
                {
                    string str = Path.GetFileName(files[i - 1]);
                    Console.WriteLine("{0}번 세이브 데이터 : {1}", i, str);
                }
                Console.WriteLine("몇 번 데이터를 불러옵니까?");

                SelectedIndex = selector.Select();
                if (SelectedIndex == -1)
                {
                    continue;
                }
                else if (SelectedIndex <= 0 || SelectedIndex > files.Length)
                {
                    Key.WrongKey();
                    continue;
                }
                else
                {
                    break;
                }
            }

            string FileName = files[SelectedIndex - 1];
            // 바이트 배열로 데이터 읽기
            byte[] dataBytes = File.ReadAllBytes(FileName);

            Serializer serializer = new Serializer();
            PlayerSaveData Data = serializer.Deserialize(dataBytes);

        }
        Selector selector = new Selector();
        int SelectedIndex = 0;
    }
}
