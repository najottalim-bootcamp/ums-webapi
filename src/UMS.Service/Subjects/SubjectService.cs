namespace UMS.Service.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async ValueTask<bool> CreateAsync(SubjectDto subjectDto)
        {
            Subject subject = new Subject()
            {
                Name=subjectDto.Name,
                SpecialtyId=subjectDto.SpecialtyId,
            };

            int result = await _subjectRepository.CreateAsync(subject);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Subject subject = await _subjectRepository.GetByIdAsync(id);
            if (subject is null) throw new SubjectNotFoundException();

            int result = await _subjectRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<Subject>> GetAllAsync()
        {
            IList<Subject> subjects = await _subjectRepository.GetAllAsync();
            return subjects;
        }

        public async ValueTask<Subject> GetByIdAsync(long id)
        {
            Subject subject = await _subjectRepository.GetByIdAsync(id);
            if (subject is null) throw new SubjectNotFoundException();

            return subject;
        }

        public async ValueTask<bool> UpdateAsync(long id, SubjectDto subjectDto)
        {
            Subject subject = await _subjectRepository.GetByIdAsync(id);
            if (subject is null) throw new SubjectNotFoundException();

            subject.Name = subjectDto.Name;
            subject.SpecialtyId = subjectDto.SpecialtyId;
            subject.UpdatedAt = DateTime.Now;
          
            int result = await _subjectRepository.UpdateAsync(id, subject);

            return result > 0;
        }
    }
}

