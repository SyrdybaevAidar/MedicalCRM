using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.Models.ChatModels;
using MedicalCRM.Models.ChatModels.MessageModels;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;

namespace MedicalCRM.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<UserRegistrationViewModel, UserDTO>();
            CreateMap<PatientRegisterViewModel, UserDTO>();
            CreateMap<UserAuthorizationViewModel, UserDTO>();
            CreateMap<MessageDTO, MessageIndexViewModel> ();
            CreateMap<ChatDTO, ChatDetailsViewModel>()
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages))
                .ForMember(dest => dest.PatientUserName, opt => opt.MapFrom(src => $"{src.PatientUser.Surname} {src.PatientUser.Name} {src.PatientUser.Patronimic}"))
                .ForMember(dest => dest.DoctorUserName, opt => opt.MapFrom(src => $"{src.DoctorUser.Surname} {src.DoctorUser.Name} {src.DoctorUser.Patronimic}"));
            CreateMap<ChatDTO, ChatIndexViewModel>()
                .ForMember(dest => dest.PatientUserName, opt => opt.MapFrom(src => $"{src.PatientUser.Surname} {src.PatientUser.Name} {src.PatientUser.Patronimic}"))
                .ForMember(dest => dest.DoctorUserName, opt => opt.MapFrom(src => $"{src.DoctorUser.Surname} {src.DoctorUser.Name} {src.DoctorUser.Patronimic}"))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientUser.Id))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorUser.Id));
            CreateMap<UserDTO, UserIndexViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Surname} {src.Name} {src.Patronimic}"));
            CreateMap<PatientDTO, UserIndexViewModel>()
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Surname} {src.Name} {src.Patronimic}"));

            CreateMap<MedicalCardViewModel, MedicalCardDTO>()
                .ForMember(i => i.Id, a => a.MapFrom(src => src.MedicalCardId));
            CreateMap<MedicalCardDTO, MedicalCardViewModel>()
                .ForMember(i => i.MedicalCardId, a => a.MapFrom(src => src.Id));

            CreateMap<ConsultationDTO, ConsultationIndexModel>()
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => $"{src.Patient.Surname} {src.Patient.Name} {src.Patient.Patronimic}"))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => $"{src.Doctor.Surname} {src.Doctor.Name} {src.Doctor.Patronimic}"));

            CreateMap<ConsultationDTO, ConsultationViewModel>()
                .ForMember(dest => dest.ConsultationId, opt => opt.MapFrom(src => src.Id) )
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.Patient.Surname} {src.Patient.Name} {src.Patient.Patronimic}"))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor.Surname} {src.Doctor.Name} {src.Doctor.Patronimic}"))
                .ForMember(dest => dest.ChronicalDiseasesIds, opt => opt.MapFrom(src => src.ChronicalDiseases.Select(i => i.DiseaseId).ToList()))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime()));

            CreateMap<ConsultationViewModel, ConsultationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ConsultationId))
                .ForMember(dest => dest.ChronicalDiseasesIds, opt => opt.MapFrom(src => src.ChronicalDiseasesIds))
                .ForMember(dest => dest.ChronicalDiseases, opt => opt.Ignore())
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToUniversalTime()));

            CreateMap<ConsultationDTO, DiseaseIndexViewModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Diseases, opt => opt.MapFrom(src => src.CheckedChronicalDiseases));

            CreateMap<PatientDTO, PatientDetailsViewModel>()
                .ForMember(dest => dest.Diseases, opt => opt.MapFrom(src => src.Consultations))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.BloodType.Name ?? ""))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.FamilyDoctor, opt => opt.MapFrom(src => src.GetFullName()));

            CreateMap<PatientUpdateViewModel, PatientDTO>();
            CreateMap<PatientDTO, PatientUpdateViewModel>();
            CreateMap<PatientUser, PatientUpdateViewModel>()
                .ForMember(dest => dest.BloodTypeId, opt => opt.MapFrom(src => src.BloodTypeId));
            CreateMap<PatientUpdateViewModel, PatientUser>()
                .ForMember(dest => dest.BloodTypeId, opt => opt.MapFrom(src => src.BloodTypeId));
        }
    }
}
