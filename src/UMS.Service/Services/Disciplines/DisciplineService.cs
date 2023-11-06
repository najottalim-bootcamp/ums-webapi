using UMS.Service.Dtos.Discipline;

namespace UMS.Service.Disciplines
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineService(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        public async Task<long> CountAsync() => await _disciplineRepository.GetCountAsync();

        public async ValueTask<bool> CreateAsync(DisciplineDto disciplineDto)
        {
            Discipline discipline = new Discipline()
            {
                Name = disciplineDto.Name,
                DepartmentId = disciplineDto.DepartmentId,
                TeacherId = disciplineDto.TeacherId,
                LectureHours = disciplineDto.LectureHours,
                PracticeHours = disciplineDto.PracticeHours,
            };

            int result = await _disciplineRepository.CreateAsync(discipline);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Discipline discipline = await _disciplineRepository.GetByIdAsync(id);
            if (discipline is null) throw new DisciplineNotFoundException();

            int result = await _disciplineRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<Discipline>> GetAllAsync()
        {
            IList<Discipline> disciplines = await _disciplineRepository.GetAllAsync();
            return disciplines;
        }

        public async ValueTask<Discipline> GetByIdAsync(long id)
        {
            Discipline discipline = await _disciplineRepository.GetByIdAsync(id);
            if (discipline is null) throw new DisciplineNotFoundException();

            return discipline;
        }

        public async ValueTask<bool> UpdateAsync(long id, DisciplineDto disciplineDto)
        {
            Discipline discipline = await _disciplineRepository.GetByIdAsync(id);
            if (discipline is null) throw new DisciplineNotFoundException();

            discipline.Name = disciplineDto.Name;
            discipline.DepartmentId = disciplineDto.DepartmentId;
            discipline.TeacherId = disciplineDto.TeacherId;
            discipline.LectureHours = disciplineDto.LectureHours;
            discipline.PracticeHours = disciplineDto.PracticeHours;
            discipline.UpdatedAt = DateTime.Now;

            int result = await _disciplineRepository.UpdateAsync(id, discipline);

            return result > 0;
        }
    }
}
