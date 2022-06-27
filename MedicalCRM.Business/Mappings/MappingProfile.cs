using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Mappings {
    public class MappingProfile: Profile {
        public MappingProfile() {
            CreateMap<UserDTO, PatientUser>();
            CreateMap<PatientUser, UserDTO>();
            CreateMap<PatientUser, PatientDTO>()
                .ForMember(src => src.Doctor, opt => opt.MapFrom(src => src.DoctorUser))
                .ForMember(src => src.BloodType, opt => opt.MapFrom(src => src.BloodType))
                .ForMember(src => src.Consultations, opt => opt.MapFrom(src => src.Consultations));

            CreateMap<UserDTO, DoctorUser>();
            CreateMap<DoctorUser, UserDTO>();
            CreateMap<DoctorUser, DoctorDTO>()
                .ForMember(src => src.PositionName, opt => opt.MapFrom(src => src.DoctorDetails!.Position.Name));

            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();
            CreateMap<Chat, ChatDTO>()
                .ForMember(dest => dest.PatientUser, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.DoctorUser, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

            CreateMap<ChatDTO, Chat>()
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

            CreateMap<BloodType, BloodTypeDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Type} - {src.RhesusFactore}"));

            CreateMap<Consultation, ConsultationDTO>()
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor));
            CreateMap<ConsultationDTO, Consultation>();
        }
    }
}
