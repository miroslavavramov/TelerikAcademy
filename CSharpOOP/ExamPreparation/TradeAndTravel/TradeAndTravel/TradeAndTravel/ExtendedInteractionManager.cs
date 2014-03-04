namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            string command = commandWords[1];

            switch (command)
            {
                case "gather":
                    string gatheredItemName = commandWords[2];
                    HandleGatherInteraction(actor, gatheredItemName);
                    break;
                case "craft":
                    string craftedItemType = commandWords[2];
                    string craftedItemName = commandWords[3];
                    HandleCraftInteraction(actor, craftedItemType, craftedItemName);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(Person actor, string gatheredItemName)
        {
            var locationAsGatheringLocation = actor.Location as IGatheringLocation;

            if (locationAsGatheringLocation != null)
            {
                var requiredItemType = locationAsGatheringLocation.RequiredItem;

                if (actor.ListInventory().Exists(x => x.ItemType == requiredItemType))
                {
                    var gatheredItem = locationAsGatheringLocation.ProduceItem(gatheredItemName);
                    
                    this.AddToPerson(actor, gatheredItem);
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string craftedItemType, string craftedItemName)
        {
            bool hasIron = actor.ListInventory().Exists(x => x is Iron);
            bool hasWood = actor.ListInventory().Exists(x => x is Wood);

            if (craftedItemType == "armor")
            {
                if (hasIron)
                {
                    this.AddToPerson(actor, new Armor(craftedItemName));
                }
            }
            else if (craftedItemType == "weapon")
            {
                if (hasIron && hasWood)
                {
                    this.AddToPerson(actor, new Weapon(craftedItemName));
                }
            }
        }
    }
}
