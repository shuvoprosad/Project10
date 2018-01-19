using AutoMapper;
using Project10.Controllers.Resource;
using Project10.Models;

namespace Project10.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to api resource
            CreateMap <Room,RoomResource>()
            .ForMember(rs=>rs.Roomname,opt=>opt.MapFrom(r=>r.Roomname))
            .ForMember(rs=>rs.Reason,opt=>opt.MapFrom(r=>r.Reason))
            .ForMember(rs=>rs.Date,opt=>opt.MapFrom(r=>r.Date))
            .ForMember(rs=>rs.Time,opt=>opt.MapFrom(r=>r.Time))
            .ForMember(rs=>rs.Acceptance,opt=>opt.MapFrom(r=>r.Acceptance));

            CreateMap <User,UserResource>()
            .ForMember(ur=>ur.username,opt=>opt.MapFrom(u=>u.UserName))
            .ForMember(ur=>ur.email,opt=>opt.MapFrom(u=>u.Email))
            .ForMember(ur=>ur.phone,opt=>opt.MapFrom(u=>u.PhoneNumber))
            .ForMember(ur=>ur.password,opt=>opt.MapFrom(u=>u.PasswordHash));
            
            //api resource to domain 
            CreateMap <UserResource,User>()
            .ForMember(u=>u.UserName,opt=>opt.MapFrom(ur=>ur.username))
            .ForMember(u=>u.Email,opt=>opt.MapFrom(ur=>ur.email))
            .ForMember(u=>u.PhoneNumber,opt=>opt.MapFrom(ur=>ur.phone))
            .ForMember(u=>u.PasswordHash,opt=>opt.MapFrom(ur=>ur.password));

            CreateMap <RoomResource,Room>()
            .ForMember(rs=>rs.Roomname,opt=>opt.MapFrom(r=>r.Roomname))
            .ForMember(rs=>rs.Reason,opt=>opt.MapFrom(r=>r.Reason))
            .ForMember(rs=>rs.Date,opt=>opt.MapFrom(r=>r.Date))
            .ForMember(rs=>rs.Time,opt=>opt.MapFrom(r=>r.Time))
            .ForMember(rs=>rs.Acceptance,opt=>opt.MapFrom(r=>r.Acceptance)); 
        }
    }
}