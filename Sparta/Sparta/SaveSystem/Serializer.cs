using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.SaveSystem
{
    class Serializer
    {
        public List<byte> Serialize(PlayerSaveData playerSaveData)
        {
            List<byte> ByteList = new List<byte>();

            byte[] NameByte = Encoding.UTF8.GetBytes(playerSaveData.Name);
            byte[] NameLengthByte = BitConverter.GetBytes(NameByte.Length);
            byte[] JobByte = Encoding.UTF8.GetBytes(playerSaveData.Job);
            byte[] JobLengthByte = BitConverter.GetBytes(JobByte.Length);
            byte[] LevelByte = BitConverter.GetBytes(playerSaveData.Level);
            byte[] attackByte = BitConverter.GetBytes(playerSaveData.attack); // 공격력 추가
            byte[] shieldByte = BitConverter.GetBytes(playerSaveData.shield); // 방어력 추가
            byte[] hpByte = BitConverter.GetBytes(playerSaveData.hp);
            byte[] goldByte = BitConverter.GetBytes(playerSaveData.Gold);
            byte[] expByte = BitConverter.GetBytes(playerSaveData.Exp);
            byte[] ListLengthByte = BitConverter.GetBytes(playerSaveData.ListLength);

            ByteList.AddRange(NameLengthByte);
            ByteList.AddRange(NameByte);
            ByteList.AddRange(JobLengthByte);
            ByteList.AddRange(JobByte);
            ByteList.AddRange(LevelByte);
            ByteList.AddRange(attackByte); // 공격력 추가
            ByteList.AddRange(shieldByte); // 방어력 추가
            ByteList.AddRange(hpByte);
            ByteList.AddRange(goldByte);
            ByteList.AddRange(expByte);
            byte[] requiredexpByte = BitConverter.GetBytes(playerSaveData.requiredexp); // 요구 경험치 추가
            ByteList.AddRange(ListLengthByte);

            for (int i = 0; i < playerSaveData.ListLength; ++i)
            {
                ItemSaveData ItemData = playerSaveData.ItemList[i];
                byte[] ItemNameByte = Encoding.UTF8.GetBytes(ItemData.ItemName);
                byte[] ItemLengthByte = BitConverter.GetBytes(ItemNameByte.Length);
                byte[] ItemEquipmentByte = BitConverter.GetBytes(ItemData.IsEquipment);

                ByteList.AddRange(ItemLengthByte);
                ByteList.AddRange(ItemNameByte);
                ByteList.AddRange(ItemEquipmentByte);
            }
            return ByteList;
        }

        public PlayerSaveData Deserialize(byte[] data)
        {
            PlayerSaveData playerSaveData = new PlayerSaveData();
            int offset = 0;  // 데이터 읽기 시작할 위치

            int NameLength = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);
            playerSaveData.Name = Encoding.UTF8.GetString(data, offset, NameLength);
            offset += NameLength;

            int JobLength = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);
            playerSaveData.Job = Encoding.UTF8.GetString(data, offset, JobLength);
            offset += JobLength;

            playerSaveData.Level = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);
            playerSaveData.attack = BitConverter.ToInt32(data, offset); // 공격력 추가
            offset += sizeof(int);
            playerSaveData.shield = BitConverter.ToInt32(data, offset); // 방어력 추가
            offset += sizeof(int);
            playerSaveData.hp = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);
            playerSaveData.Gold = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);
            playerSaveData.Exp = BitConverter.ToSingle(data, offset);
            offset += sizeof(float);
            playerSaveData.requiredexp = BitConverter.ToSingle(data, offset); // 요구 경험치 복원
            offset += sizeof(float);

            playerSaveData.ListLength = BitConverter.ToInt32(data, offset);
            offset += sizeof(int);

            playerSaveData.ItemList = new List<ItemSaveData>();
            for (int i = 0; i < playerSaveData.ListLength; ++i)
            {
                ItemSaveData item = new ItemSaveData();

                int Length = BitConverter.ToInt32(data, offset);
                offset += sizeof(int);

                // ItemName 데이터
                item.ItemName = Encoding.UTF8.GetString(data, offset, Length);
                offset += Length;
                // IsEquipment 데이터
                item.IsEquipment = BitConverter.ToBoolean(data, offset);
                offset += sizeof(bool);

                playerSaveData.ItemList.Add(item);
            }

            return playerSaveData;
        }
    }
}
