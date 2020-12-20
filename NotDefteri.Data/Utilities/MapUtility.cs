using AutoMapper;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;

namespace NotDefteri.Data.Utilities
{
    public static class MapUtility
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            #region Entity to EntityModel

            config.CreateMap<Note, NoteModel>()
                .ForMember(dest => dest.CategoryModel, opt => opt.MapFrom(src => src.Category));
            config.CreateMap<User, UserModel>();
            config.CreateMap<Category, CategoryModel>();
            config.CreateMap<Like, LikeModel>();
            #endregion

            #region EntityModel to Entity

            config.CreateMap<NoteModel, Note>();
            config.CreateMap<UserModel, User>();
            config.CreateMap<CategoryModel, Category>();
            config.CreateMap<LikeModel, Like>();
            #endregion
        }
    }
}