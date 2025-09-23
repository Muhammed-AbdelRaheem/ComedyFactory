using AutoMapper;
using Data.Service;
using Domain.Models;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Reflection;

namespace Data.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            string? language = null;
            string? userId = null;
            bool? apiAssets = false;
            int parentFilterValueId = 0;
            List<int>? selectedInterests = new List<int>();
            int? eventId = null;
            int allLevelsCount = 0;

            CreateMap<Log, LogViewModel>();
            CreateMap<ApplicationUser, LogUserViewModel>();
            CreateMap<ApplicationUser, UserEditInfoViewModel>();
            CreateMap<ApplicationUser, UserTableViewModel>()
                .ForMember(e => e.Mobile, s => s.MapFrom(s => s.CountryCode + s.Mobile))
                .ForMember(e => e.Gender, s => s.MapFrom(s => s.Gender != null ? s.Gender.DisplayName() : null))
                          .ForMember(e => e.Picture, s =>
                 s.MapFrom(s => (s.Picture != null ? Config.ImageflowS3Key + s.Picture + Config.ImageResizerAdmin : null)))
                 .ForMember(e => e.BirthDay, s => s.MapFrom(s => s.BirthDay != null ? s.BirthDay : null))

                .ForMember(e => e.Roles, s => s.MapFrom(s => string.Join(" / ", s.UserRoles.Select(c => c.Role.Name))));

            CreateMap<ApplicationUser, UserTableFrontViewModel>();

            CreateMap<RoleViewModel, ApplicationRole>().ReverseMap();

            CreateMap<ApplicationUser, UserEditViewModel>()
                .ForMember(e => e.Mobile, s => s.MapFrom(s => s.Mobile))
                .ForMember(e => e.Gender, s => s.MapFrom(s => s.Gender))
             .ForMember(e => e.MobilePicture, s => s.MapFrom(s => (s.Picture != null ? Config.PictureBaseURL + s.Picture : null)))

                .ReverseMap();

            CreateMap<ApplicationUser, UserScoreBoard>()
                .ForMember(e => e.Points, s => s.MapFrom(s => s.TotalScorePoint))
             .ForMember(e => e.Name, s => s.MapFrom(s => s.FullName))
             .ForMember(e => e.Picture, s => s.MapFrom(s => (s.Picture != null ? Config.PictureBaseURL + s.Picture : null)));


            CreateMap<ApplicationUser, DashboardEditViewModel>()
                .ReverseMap();
            CreateMap<UserEditInfoViewModel, UserEditViewModel>()

                .ReverseMap();



            CreateMap<UserInfoModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserLightVM>().ReverseMap();

            CreateMap<IdentityResult, IdentityResultViewModel>().ReverseMap();
            CreateMap<IdentityError, ErrorRequestViewModel>();

            CreateMap<Block, BlockVM>()
             .ForMember(e => e.Name, s =>
                 s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
             .ForMember(e => e.Content, s =>
                 s.MapFrom(s => language == "ar" ? s.ArContent : s.EnContent))

             .ForMember(e => e.Picture, s =>
                 s.MapFrom(s => (language == "ar" ? (s.ArPicture != null ? Config.ImageflowS3Key + s.ArPicture + Config.ImageResizerBox : null) : (s.EnPicture != null ? Config.ImageflowS3Key + s.EnPicture + Config.ImageResizerBox : null))))
             .ReverseMap();


            CreateMap<Block, AboutUsPage>()
             .ForMember(e => e.Title, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
             .ForMember(e => e.Line1, s => s.MapFrom(s => language == "ar" ? s.ArLine1 : s.EnLine1))
             .ForMember(e => e.Line2, s => s.MapFrom(s => language == "ar" ? s.ArLine2 : s.EnLine2))
             .ForMember(e => e.Content, s => s.MapFrom(s => language == "ar" ? s.ArContent : s.EnContent))
             .ForMember(e => e.Picture, s =>
                 s.MapFrom(s => (language == "ar" ? (s.ArPicture != null ? Config.ImageflowS3Key + s.ArPicture + Config.ImageResizerBox : null) : (s.EnPicture != null ? Config.ImageflowS3Key + s.EnPicture + Config.ImageResizerBox : null))))
             .ReverseMap();

            CreateMap<Block, ContactInfoVM>();

            CreateMap<Configuration, ConfigurationLightVM>()
               .ForMember(e => e.FooterBrief, s => s.MapFrom(s => language == "ar" ? s.ArFooterBrief : s.EnFooterBrief))

                ;

            CreateMap<Configuration, ConfigurationVM>()
               .ForMember(e => e.Name, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
               .ForMember(e => e.MetaDescription, s => s.MapFrom(s => language == "ar" ? s.ArMetaDescription : s.EnMetaDescription))
               .ForMember(e => e.Keywords, s => s.MapFrom(s => language == "ar" ? s.ArKeywords : s.EnKeywords))
               .ForMember(e => e.SocialPicture, s => s.MapFrom(s => s.SocialPicture != null ? $"{Config.Schema}{Config.BaseURL}/{s.SocialPicture}{Config.ImageResizerBox}" : null));





            CreateMap<Block, BlockLightVM>()
                     .ForMember(e => e.name, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
                     .ForMember(e => e.content, s => s.MapFrom(s => language == "ar" ? s.ArContent : s.EnContent))
                     ;



            CreateMap<Block, BlockLightVM>()
             .ForMember(e => e.Title, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
             .ForMember(e => e.Line1, s => s.MapFrom(s => language == "ar" ? s.ArLine1 : s.EnLine1))
             .ForMember(e => e.Line2, s => s.MapFrom(s => language == "ar" ? s.ArLine2 : s.EnLine2))
             .ForMember(e => e.Content, s => s.MapFrom(s => language == "ar" ? s.ArContent : s.EnContent))
             .ReverseMap();



          

            CreateMap<ApplicationUser, UserEditInfoViewModel>()

                ;

            CreateMap<UserEditInfoViewModel, RegisterApiViewModel>().ReverseMap();

            CreateMap<RegisterApiViewModel, ApplicationUser>()
                 .ForMember(e => e.PhoneNumber, s => s.MapFrom(s => s.Mobile))
                 .ForMember(e => e.UserName, s => s.MapFrom(s => s.Email + Guid.NewGuid().ToString()))
                 .ForMember(e => e.CreatedOnUtc, s => s.MapFrom(s => Extantion.AddUtcTime()))
                 .ForMember(e => e.UpdatedOnUtc, s => s.MapFrom(s => Extantion.AddUtcTime()))
                 .ForMember(e => e.Active, s => s.MapFrom(s => true))
                 .ForMember(e => e.EnableNotification, s => s.MapFrom(s => true))
                 .ForMember(e => e.EmailConfirmed, s => s.MapFrom(s => true));


            CreateMap<City, CityDataTable>();





            CreateMap<Country, CountryDataTable>();


            CreateMap<PersonalData, PersonalDataTable>()
                .ForMember(e => e.Cities, s => s.MapFrom(s => s.Cities.EnName))
                .ForMember(e => e.Desire, s => s.MapFrom(s => s.Desire.EnName))
                ;


            CreateMap<PersonalData, PersonalDataVM>();



            CreateMap<Master, MasterDataTable>()
                .ForMember(e => e.MasterCategory, s => s.MapFrom(s => s.MasterCategory.EnName))
                .ReverseMap();
            CreateMap<MasterVM, Master>()
        .ForMember(dest => dest.CreatedOnUtc,
            opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedOnUtc, DateTimeKind.Utc)))
        .ForMember(dest => dest.UpdatedOnUtc,
            opt => opt.MapFrom(src => DateTime.SpecifyKind(src.UpdatedOnUtc, DateTimeKind.Utc)))
        .ReverseMap();

            CreateMap<Activities, ActivityTableData>().ReverseMap();

            CreateMap<ActivityVM, Activities>()
       .ForMember(dest => dest.CreatedOnUtc,
         opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedOnUtc, DateTimeKind.Utc)))
     .ForMember(dest => dest.UpdatedOnUtc,
         opt => opt.MapFrom(src => DateTime.SpecifyKind(src.UpdatedOnUtc, DateTimeKind.Utc)))
     .ReverseMap();


            CreateMap<Desire, DesireTableData>().ReverseMap();
            CreateMap<DesireVM, Desire>()
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc.ToUniversalTime()))
                .ForMember(dest => dest.UpdatedOnUtc, opt => opt.MapFrom(src => src.UpdatedOnUtc.ToUniversalTime())).ReverseMap();

            CreateMap<MasterCategory, MasterCategoryTableData>().ReverseMap();

            CreateMap<MasterCategoryVM, MasterCategory>()
            .ForMember(dest => dest.Masters, opt => opt.Ignore()) // Important  
            .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc.ToUniversalTime()))
            .ForMember(dest => dest.UpdatedOnUtc, opt => opt.MapFrom(src => src.UpdatedOnUtc.ToUniversalTime())).ReverseMap();


      

            CreateMap<Category, CategoryLightVM>()
                .ForMember(e => e.Name, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
                ;

      




            CreateMap<Block, AboutUsLight>()
                .ForMember(e => e.Title, s => s.MapFrom(s => language == "ar" ? s.ArName : s.EnName))
                .ForMember(e => e.Line1, s => s.MapFrom(s => language == "ar" ? s.ArLine1 : s.EnLine1))
                .ForMember(e => e.Line2, s => s.MapFrom(s => language == "ar" ? s.ArLine2 : s.EnLine2))
                .ForMember(e => e.Picture, s => s.MapFrom(s => language == "ar" ? (s.ArPicture != null ? Config.ImageflowS3Key + s.ArPicture + Config.ImageResizerBanner : null)
                : (s.EnPicture != null ? Config.ImageflowS3Key + s.EnPicture + Config.ImageResizerBanner : null)))
                ;


            CreateMap<IdentityResult, IdentityResultViewModel>().ReverseMap();


      

            CreateMap<UserNotifictionInfo, ApplicationUser>()
             .ReverseMap();


        


        }

    }
}
