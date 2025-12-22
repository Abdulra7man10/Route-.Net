using AutoMapper;
using GymManagmentBLL.ViewModels.SessionViewModel;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service
{
    public class MappingProfile : Profile // only one profile needed for whole project
    {
        public MappingProfile() 
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, option => option.MapFrom(src=> src.SessionCategory.CategoryName))
                .ForMember(dest => dest.TrainerName, option => option.MapFrom(src => src.SessionTrainer.Name))
                .ForMember(dest => dest.AvailableSlots, option => option.Ignore());

            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<Session, UpdateSessionViewModel>().ReverseMap();
            //CreateMap<UpdateSessionViewModel, Session>();
        }
    }
}
