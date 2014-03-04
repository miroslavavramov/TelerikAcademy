namespace AlexandreDumasOOP.Common.Interfaces
{
    using AlexandreDumasOOP.Common.Items;
    using System.Collections.Generic;

    public interface IEquipper
    {
        int Gold { get; set; }

        List<Item> Inventory { get; }

         void Equip(string code);

         void Dequip(string code);
    }
}
