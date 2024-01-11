using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using ApplicationLayer.DTO;
using AutoMapper;
using Business_Access_Layer.ViewModels;
using Data_Access_Layer.Repository.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, StudentDTO>().ReverseMap();

            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<ApplicationUser, StudentStatusDto>().ReverseMap();
            CreateMap<Student, RegisterDTO>().ReverseMap();
            CreateMap<Student, StudentStatusDto>().ReverseMap();
            CreateMap<Question, RequestExamDto>().ReverseMap();
            CreateMap<Choice,AddChoicesDto>().ReverseMap();
            CreateMap<SubmitExamDto, Exam>().ReverseMap();
            CreateMap<RequestExamDto, Question>().ReverseMap();
            CreateMap<RequestExamChoiceDto, Choice>().ReverseMap();
            CreateMap<ApplicationUser, LoginDTO>();
            CreateMap<LoginDTO, ApplicationUser>();
            CreateMap<Subject, SubjectDto>().ReverseMap(); 
            CreateMap<Subject,AddSubjectDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultDto>().ForMember(des => des.subjectName, opt => opt.MapFrom(src => src.SubjectResult.SubjectName))
                .ForMember(des => des.examDate, opt => opt.MapFrom(src => src.ResultExam.ExamDate))
                .ForMember(des => des.examScore, opt => opt.MapFrom(src => src.Score)).ReverseMap();

            CreateMap<ExamResult, AdminExamresultDto>().ForMember(des => des.SubjectName, opt => opt.MapFrom(src => src.SubjectResult.SubjectName))
                .ForMember(des => des.ExamDate, opt => opt.MapFrom(src => src.ResultExam.ExamDate))
                .ForMember(des => des.ExamScore, opt => opt.MapFrom(src => src.Score))
                .ForMember(des => des.StudentName, opt => opt.MapFrom(src => src.StudentResult.StudentFName)).ReverseMap();
            CreateMap<StudentSubject, StudentSubjectDto>().ForMember(des => des.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName)).ReverseMap();
           //CreateMap<Question, QuestionDto>().ForMember(des=>des.AddChoices,opt=>opt.MapFrom(src=>src.QuestionChoices)).ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
        }
    }

}
