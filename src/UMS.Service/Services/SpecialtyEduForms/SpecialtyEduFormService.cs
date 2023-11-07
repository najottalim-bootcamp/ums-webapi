using UMS.Service.Dtos.Education;

namespace UMS.Service.SpecialtyEduForms
{
    public class SpecialtyEduFormService : ISpecialtyEduFormService
    {
        private readonly ISpecialtyEduFormRepository _specialtyEduFormRepository;

        public SpecialtyEduFormService(ISpecialtyEduFormRepository specialtyEduFormRepository)
        {
            _specialtyEduFormRepository = specialtyEduFormRepository;
        }

        public async Task<long> CountAsync() => await _specialtyEduFormRepository.GetCountAsync();

        public async ValueTask<bool> CreateAsync(SpecialtyEduFormDTO specialtyEduFormDTO)
        {
            SpecialtyEduForm specialtyEduForm = new SpecialtyEduForm()
            {
                SpecialtyId = specialtyEduFormDTO.SpecialtyId,
                EduFormId = specialtyEduFormDTO.EduFormId
            };

            int result = await _specialtyEduFormRepository.CreateAsync(specialtyEduForm);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            SpecialtyEduForm specialtyEduForm = await _specialtyEduFormRepository.GetByIdAsync(id);
            //if (specialtyEduForm is null) throw new SpecialtyEduFormNotFoundException();

            int result = await _specialtyEduFormRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<SpecialtyEduForm>> GetAllAsync()
        {
            IList<SpecialtyEduForm> specialtyEduForm = await _specialtyEduFormRepository.GetAllAsync();
            return specialtyEduForm;
        }

        public async ValueTask<SpecialtyEduForm> GetByIdAsync(long id)
        {
            SpecialtyEduForm specialtyEduForm = await _specialtyEduFormRepository.GetByIdAsync(id);
            //if (specialtyEduForm is null) throw new SpecialtyEduFormNotFoundException();

            return specialtyEduForm;
        }

        public async ValueTask<bool> UpdateAsync(long id, SpecialtyEduFormDTO specialtyEduFormDTO)
        {
            SpecialtyEduForm specialtyEduForm = await _specialtyEduFormRepository.GetByIdAsync(id);

            //if (specialtyEduForm is null) throw new SpecialtyEduFormNotFoundException();

            specialtyEduForm.SpecialtyId = specialtyEduFormDTO.SpecialtyId;
            specialtyEduForm.EduFormId = specialtyEduFormDTO.EduFormId;


            int result = await _specialtyEduFormRepository.UpdateAsync(id, specialtyEduForm);

            return result > 0;
        }
    }
}
