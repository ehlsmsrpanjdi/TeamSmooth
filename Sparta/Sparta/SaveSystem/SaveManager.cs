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
using System.Reflection.Metadata.Ecma335;



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

        public int attack;
        public int shield;
        public int dex;

        public int hp;
        public int MaxHp;

        public int Gold;

        public float Exp;
        public float requiredexp; // 요구 경험치 추가

        public int LastFloor;

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
                Directory.CreateDirectory(ResourcePath);
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
                Console.WriteLine("");
                Console.WriteLine("6. 뒤로 가기");
                SelectedIndex = selector.Select();
                if (SelectedIndex == -1)
                {
                    continue;
                }
                else if (SelectedIndex == 6)
                {
                    return;                    
                }
                else if (SelectedIndex <= 0 || SelectedIndex > 6)
                {
                    Key.WrongKey();
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (SelectedIndex  - 1< files.Length)
            {
                Console.WriteLine("이미 세이브파일이 존재합니다. 덮어씌우시겠습니까?");
                Console.WriteLine("1 : 네  /  2 : 아니요");
                int select = selector.Select();
                switch (select)
                {
                    case -1:
                        break;
                    case 1:
                        PlayerSaveData Data = Player.GetPlayer().MakeSaveData();
                        Serializer serialize = new Serializer();
                        List<byte> bytes = serialize.Serialize(Data);
                        byte[] dataByte = bytes.ToArray();
                        File.WriteAllBytes(files[SelectedIndex - 1], dataByte);
                        if (File.Exists(files[SelectedIndex - 1]))
                        {
                            // 파일 이름 변경
                            DateTime CurrentTime = DateTime.Now;
                            string TimeStamp = CurrentTime.ToString("yyyyMMdd_HHmmss");
                            string Savedir = Path.Combine(ResourcePath, TimeStamp);
                            File.Move(files[SelectedIndex - 1], Savedir);
                            Console.WriteLine("파일 이름이 변경되었습니다.");
                            return;
                        }
                        break;
                    case 2:
                        Save();
                        return;
                }
            }


            PlayerSaveData SaveData = Player.GetPlayer().MakeSaveData();

            DateTime currentTime = DateTime.Now;
            string timeStamp = currentTime.ToString("yyyyMMdd_HHmmss");

            string savedir = Path.Combine(ResourcePath, timeStamp);

            Serializer serializer = new Serializer();
            List<byte> bytelist = serializer.Serialize(SaveData);
            byte[] dataBytes = bytelist.ToArray();
            File.WriteAllBytes(savedir, dataBytes);
        }

        public bool Load()
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

                Console.WriteLine("나가기 : 99");

                SelectedIndex = selector.Select();
                if (SelectedIndex == -1)
                {
                    continue;
                }
                else if (SelectedIndex == 99)
                {
                    return false;
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
            /// 이곳에서 플레이어 생성
            Player.GetPlayer(Data);
            return true;

        }
        Selector selector = new Selector();
        int SelectedIndex = 0;
    }
}
