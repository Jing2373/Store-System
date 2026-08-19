using System.Threading.Tasks;
using Jing.Setting;

namespace Jing.Game
{
    public interface ILoadGameRepository
    {
        Setting_Item_Clothes[] GetAllClothes();
        Setting_Item_Pill[] GetAllPill();
        Setting_Item_Skill[] GetAllSkill();
        Setting_Item_Pill GetPillById(int id);
        Setting_ItemBase GetSettingByItemBase(ItemDetailBase data);
        Task Load();
    }
}