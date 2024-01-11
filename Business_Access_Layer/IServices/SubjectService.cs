using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using AutoMapper;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
   public class SubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository,IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SubjectDto>> GetAllSubjectAsync(PagingParameters pagingParameters)
        {
            var studentlist = await _subjectRepository.GetAllSubjectAsync(pagingParameters);
            return _mapper.Map<IEnumerable< Subject>, IEnumerable< SubjectDto>>(studentlist);
        }

        public async Task UpdateSubject( SubjectDto subjectDto)
        {
            if(subjectDto!=null)
            {
                var newsubject = _mapper.Map<SubjectDto, Subject>(subjectDto);
                await _subjectRepository.UpdateSubjectAsync(newsubject);
            }

        }

        public async Task AddNewSubject(AddSubjectDto subjectDto)
        {
            if(subjectDto !=null)
            {
                var newSubject = _mapper.Map<AddSubjectDto, Subject>(subjectDto);
              await  _subjectRepository.AddSubjectAsync(newSubject);
            }
        }
    }
}
