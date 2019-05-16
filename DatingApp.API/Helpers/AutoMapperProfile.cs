using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,UserForList>()
            .ForMember(dest =>dest.PhotoUrl,opt=>{
                opt.MapFrom(src=>src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age,opt=>{
                opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
            });
            CreateMap<User,UserForDetailed>()
            .ForMember(dest =>dest.PhotoUrl,opt=>{
                opt.MapFrom(src=>src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age,opt=>{
                opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo,PhotosForDetailed>();
            CreateMap<UserForUpdate,User>();
            CreateMap<Photo,PhotoForReturn>();
            CreateMap<PhotoForCreation,Photo>();
            CreateMap<UserForRegister,User>();
            CreateMap<MessageForCreation,Message>().ReverseMap();
            CreateMap<Message,MessageToReturn>()
            .ForMember(m => m.SenderPhotoUrl,opt => opt.MapFrom(u=> u.Sender.Photos.FirstOrDefault(p=> p.IsMain).Url))
            .ForMember(m => m.RecipientPhotoUrl,opt => opt.MapFrom(u=> u.Recipient.Photos.FirstOrDefault(p=> p.IsMain).Url));

        }
    }
}