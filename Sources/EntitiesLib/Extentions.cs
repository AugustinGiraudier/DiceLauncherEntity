using ModelAppLib;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StubEntitiesLib")]

namespace EntitiesLib
{
    internal static class Extentions
    {


        // --- Dice Side --- //
        
        public static DiceSide ToModel(this DiceSide_entity entity)
        {
            var ds = new DiceSide(entity.Image);
            ds.Id = entity.Id;
            return ds;
        }
        public static DiceSide_entity ToEntity(this DiceSide model)
                => new DiceSide_entity { Image = model.Image, Id = model.Id };

        public static IEnumerable<DiceSide> ToModel(this IEnumerable<DiceSide_entity> entities)
                => entities.Select(e => e.ToModel());

        public static IEnumerable<DiceSide_entity> ToEntity(this IEnumerable<DiceSide> models)
            => models.Select(m => m.ToEntity());


        // --- Dice Side Type --- //

        public static DiceSideType ToModel(this DiceSideType_entity entity)
                => new DiceSideType(entity.NbSide, entity.Prototype.ToModel());
        public static DiceSideType_entity ToEntity(this DiceSideType model, long DiceId)
                => new DiceSideType_entity { NbSide = model.NbSide, Prototype = model.Prototype.ToEntity(), Side_FK=model.Prototype.Id, Dice_FK=DiceId };
        public static IEnumerable<DiceSideType> ToModel(this IEnumerable<DiceSideType_entity> entities)
                => entities.Select(e => e.ToModel());
        public static IEnumerable<DiceSideType_entity> ToEntity(this IEnumerable<DiceSideType> models, long DiceId)
                => models.Select(m => m.ToEntity(DiceId));


        // --- Dice --- //
        public static Dice ToModel(this Dice_entity entity)
        {
            var d = new Dice(entity.Sides.ToModel());
            d.Id = entity.Id;
            return d;
        }
        public static Dice_entity ToEntity(this Dice model, DiceLauncher_DbContext context)
        {
            var d = new Dice_entity { Sides = model.SideTypes.ToEntity(model.Id).ToList(), Id = model.Id };
            foreach (var side in d.Sides)
                side.Prototype = context.Sides.Where(s => s.Id == side.Side_FK).First();
            return d;
        }
        public static IEnumerable<Dice> ToModel(this IEnumerable<Dice_entity> entities)
            => entities.Select(e => e.ToModel());
        public static IEnumerable<Dice_entity> ToEntity(this IEnumerable<Dice> models, DiceLauncher_DbContext context)
            => models.Select(m => m.ToEntity(context));


        // --- Dice Type --- //
        public static DiceType ToModel(this DiceType_entity entity)
                => new DiceType(entity.NbDice, entity.Prototype.ToModel());
        public static DiceType_entity ToEntity(this DiceType model, long GameId, DiceLauncher_DbContext context)
            => new DiceType_entity { NbDice = model.NbDices, Prototype = model.Prototype.ToEntity(context), Dice_FK = model.Prototype.Id, Game_FK= GameId };
        public static IEnumerable<DiceType> ToModel(this IEnumerable<DiceType_entity> entities)
            => entities.Select(e => e.ToModel());
        public static IEnumerable<DiceType_entity> ToEntity(this IEnumerable<DiceType> models, long GameId, DiceLauncher_DbContext context)
            => models.Select(m => m.ToEntity(GameId, context));

        // --- Game --- //
        public static Game ToModel(this Game_entity entity)
        {
            var g = new Game(entity.DiceTypes.ToModel());
            g.Id = entity.Id;
            return g;
        }
        public static Game_entity ToEntity(this Game model, DiceLauncher_DbContext context)
        {
            var g = new Game_entity { DiceTypes = model.Dices.ToEntity(model.Id, context).ToList(), Id = model.Id };
            foreach (var dice in g.DiceTypes)
                dice.Prototype = context.Dices.Where(d => d.Id == dice.Dice_FK).First();
            return g;
        }
        public static IEnumerable<Game> ToModel(this IEnumerable<Game_entity> entities)
            => entities.Select(e => e.ToModel());
        public static IEnumerable<Game_entity> ToEntity(this IEnumerable<Game> models, DiceLauncher_DbContext context)
            => models.Select(m => m.ToEntity(context));

    }
}
