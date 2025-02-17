using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewModdingAPI.Events;
using StardewValley.Objects;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.GameData.Objects;

namespace Boombox
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/Objects"))
            {
                e.Edit(asset =>
                {
                    var data = asset.AsDictionary<string, ObjectData>().Data;

                    data["1234"] = new ObjectData
                    {
                        Name = "Boombox",
                        DisplayName = "Boombox",
                        Description = "Une boombox pour jouer de la musique autour de soi",
                        Type = "Basic",
                        Category = -99,
                        Texture = "Mods/Flamy.Boombox/Boombox",
                        SpriteIndex = 0,
                        Edibility = -300,
                        CanBeGivenAsGift = false,
                        CanBeTrashed = false,
                        ExcludeFromRandomSale = true
                    };
                }, AssetEditPriority.Default);
            }

            if (e.NameWithoutLocale.IsEquivalentTo("Mods/Flamy.Boombox/Boombox"))
            {
                e.LoadFromModFile<Texture2D>("assets/Boombox.png", AssetLoadPriority.Medium);
            }
        }
    }
}