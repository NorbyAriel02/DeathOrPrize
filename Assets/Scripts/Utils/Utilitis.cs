using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Utilitis 
{
    public static int PrecioBase = 15;
    public static int DamageBase = 10;
    public static int IncrementoDamage = 5;
    public static int DefendingBase = 50;
    public static int IncrementoDefending = 10;
    public static float probabilidadGolpeEnArea = 0.35f;
    public static T GetItem<T>(int level, Owner owner, string DataFile) where T : ItemModel, new()
    {
        T item = new T();
        item.level = level;
        item.owner = owner;
        item.DataFile = DataFile;
        item.name = RandomString(15);        
        return item;
    }
    public static T GetItemArmor<T>(int level, Owner owner, string DataFile) where T : ItemArmor, new()
    {
        T item = new T();
        item.level = level;
        item.owner = owner;
        item.DataFile = DataFile;
        item.name = GetNameItem();
        item.armor = level * 10;
        return item;
    }
    public static ItemWeapon GetWeapon(int level, Owner owner, string DataFile)
    {
        ItemWeapon item = new ItemWeapon();
        item.level = level;
        item.owner = owner;
        item.name = GetNameItem();
        item.DataFile = DataFile;
        item.value = level * PrecioBase;
        item.damage = level * 10;
        item.attackSpeed = AttackSpeed(level);
        return item;
    }
    public static ItemModel GetRandomItem(int level, Owner owner, string DataFile)
    {
        ItemModel item = new ItemModel();
        item.level = level;
        item.owner = owner;
        item.name = GetNameItem();
        item.DataFile = DataFile;
        item.value = level * PrecioBase;
        return item;
    }
    public static ItemModel GetRandomItemStack(int level, Owner owner, string DataFile)
    {
        ItemModel item = new ItemModel();
        item.level = level;
        item.owner = owner;
        item.name = RandomString(15);
        item.DataFile = DataFile;
        item.value = level * PrecioBase;
        item.IsStackable = true;
        return item;
    }
    public static ItemApple GetApple(int level, Owner owner, string DataFile)
    {
        ItemApple item = new ItemApple();
        item.level = level;
        item.owner = owner;
        item.name = RandomString(15);
        item.DataFile = DataFile;
        item.value = level * PrecioBase;
        item.IsStackable = true;
        return item;
    }
    
    private static System.Random random = new System.Random();

    static string GetNameItem()
    {
        return System.DateTime.Now.ToString("yyyyMMddHHmmss") + RandomString(15); 
    }
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    static bool IsHitArea()
    {
        float r = Random.Range(0f, 1f);
        return r > probabilidadGolpeEnArea ? false:true;
    }
    static ItemModel GetArmor(int level, Owner owner)
    {
        float r = Random.Range(DefendingBase, DefendingBase+IncrementoDefending);
        ItemModel item = new ItemModel();
        item.owner = owner;
        //item.typeItem = TypeItemInventory.Armor;
        //item.typeSlot = TypeSlot.SlotArmor;
        //item.level = level;
        //item.value = PrecioBase + level;
        //item.armor = level * r;
        //item.weight = 3;
        //item.labelData = item.armor.ToString();

        return item;
    }
    public static ItemModel GetBestItem(ItemModel i, string dataFile)
    {
        int r = Random.Range(1, 3);
        ItemModel item = new ItemModel();
        
        //if (i.typeItem == TypeItemInventory.Armor)
        //{
        //    item = GetArmor(i.level + r, Owner.player);
        //}
        //else
        //{
        //    item = GetWeapon(i.level + r, Owner.player);
        //}
        item.name = RandomString(15);
        item.DataFile = dataFile;
        return item;
    }
    public static float AttackSpeed(int level)
    {
        float b = 6;
        float balance = 0.5f;
        float attacks = (b - level * balance);

        if (attacks < 0.5f)
            attacks = 0.5f;

        float deltaTime = 0.5f;
        
        float attackSpeed = deltaTime / attacks;


        return attackSpeed;
    }
}
