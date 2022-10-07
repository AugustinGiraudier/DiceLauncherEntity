using ModelAppLib;
using System.Collections.Generic;
using System.Linq;

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

        public static List<DiceSide> ToModel(this IEnumerable<DiceSide_entity> entities)
                => entities.Select(e => e.ToModel()).ToList();

        public static List<DiceSide_entity> ToEntity(this IEnumerable<DiceSide> models)
            => models.Select(m => m.ToEntity()).ToList();


        // --- Dice Side Type --- //

        public static DiceSideType ToModel(this DiceSideType_entity entity)
                => new DiceSideType(entity.NbSide, entity.Prototype.ToModel());
        public static DiceSideType_entity ToEntity(this DiceSideType model)
                => new DiceSideType_entity { NbSide = model.NbSide, Prototype = model.Prototype.ToEntity() };
        public static List<DiceSideType> ToModel(this IEnumerable<DiceSideType_entity> entities)
                => entities.Select(e => e.ToModel()).ToList();
        public static List<DiceSideType_entity> ToEntity(this IEnumerable<DiceSideType> models)
                => models.Select(m => m.ToEntity()).ToList();


        // --- Dice --- //
        public static Dice ToModel(this Dice_entity entity)
        {
            var d = new Dice(entity.Sides.ToModel());
            d.Id = entity.Id;
            return d;
        }
        public static Dice_entity ToEntity(this Dice model)
                => new Dice_entity { Sides = model.SideTypes.ToEntity(), Id = model.Id };
        public static List<Dice> ToModel(this IEnumerable<Dice_entity> entities)
            => entities.Select(e => e.ToModel()).ToList();
        public static List<Dice_entity> ToEntity(this IEnumerable<Dice> models)
            => models.Select(m => m.ToEntity()).ToList();


        // --- Dice Type --- //
        public static DiceType ToModel(this DiceType_entity entity)
                => new DiceType(entity.NbDice, entity.Prototype.ToModel());
        public static DiceType_entity ToEntity(this DiceType model)
            => new DiceType_entity { NbDice = model.NbDices, Prototype = model.Prototype.ToEntity() };
        public static List<DiceType> ToModel(this IEnumerable<DiceType_entity> entities)
            => entities.Select(e => e.ToModel()).ToList();
        public static List<DiceType_entity> ToEntity(this IEnumerable<DiceType> models)
            => models.Select(m => m.ToEntity()).ToList();

        // --- Game --- //
        public static Game ToModel(this Game_entity entity)
        {
            var g = new Game(entity.DiceTypes.ToModel());
            g.Id = entity.Id;
            return g;
        }
        public static Game_entity ToEntity(this Game model)
                => new Game_entity { DiceTypes = model.Dices.ToEntity(), Id = model.Id };
        public static List<Game> ToModel(this IEnumerable<Game_entity> entities)
            => entities.Select(e => e.ToModel()).ToList();
        public static List<Game_entity> ToEntity(this IEnumerable<Game> models)
            => models.Select(m => m.ToEntity()).ToList();

    }
}
