namespace UMS.Service.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISpecialtyRepository _specialtyRepository;

        public SubjectService(ISubjectRepository subjectRepository,
                              ISpecialtyRepository specialtyRepository)
        {
            _subjectRepository = subjectRepository;
            _specialtyRepository = specialtyRepository;
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

        public async ValueTask<IList<SubjectViewModel>> GetAllAsync()
        {
            IList<Subject> subjects = await _subjectRepository.GetAllAsync();
            IList<Specialty> specialties = await _specialtyRepository.GetAllAsync();

            var combinedData= subjects
                              .Join(specialties,subject=>subject.SpecialtyId, specialtie=>specialtie.Id,
                              (subject, specialtie) =>new SubjectViewModel()
                              {
                                SpecialtyId=specialtie.Id,
                                SubjectName=subject.Name,
                                SpecialtyName=specialtie.Name
                              }).ToList();

            return combinedData;
        }

        public async ValueTask<SubjectViewModel> GetByIdAsync(long id)
        {
            Subject subject = await _subjectRepository.GetByIdAsync(id);
            if (subject is null) throw new SubjectNotFoundException();
            Specialty specialty = await _specialtyRepository.GetByIdAsync(subject.SpecialtyId);

            SubjectViewModel subjectView = new SubjectViewModel()
            {
               SpecialtyId=specialty.Id,
               SubjectName=subject.Name,
               SpecialtyName=specialty.Name,
            };

            return subjectView;
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

