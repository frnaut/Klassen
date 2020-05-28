using Core.IRepository;
using Core.Models;
using Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class AssignmetManager
    {
        private readonly IAssignmentsRepository _repository;
        private readonly IUserTeacherRepository _teacher;
        private readonly IClassroomRepository _classroom;

        public AssignmetManager(IAssignmentsRepository repository, IUserTeacherRepository teacher, IClassroomRepository classroom)
        {
            this._repository = repository;
            this._teacher = teacher;
            this._classroom = classroom;
        }

        public async Task<List<Assignment>> getAllAsync()
        {
            var listModel = new List<Assignment>();
            var models = await _repository.GetAllAsync();

            foreach(var model in models)
            {
                var itemModel = _repository.Find(x => x.Id == model.Id, x => x.Classroom, x => x.Teacher);
                listModel.Add(itemModel);
            }

            return listModel;
        }
        
        public Assignment getById(int id)
        {
            var model = _repository.Find(x => x.Id == id, x => x.Classroom, x => x.Teacher);
            return model;
        }
        

        public async Task<Assignment> postAsync(AssignmentRequest request)
        {
            Assignment model = new Assignment();
            model.Title = request.Title;
            model.Text = request.Text;
            model.Teacher = await _teacher.GetByEmail(request.Teacher);
            model.Classroom = await _classroom.GetByIdAsync(request.ClassroomId);

            var newModel = await _repository.PostAsync(model);
            return _repository.Find(x => x.Id == newModel.Id, x => x.Classroom, x => x.Teacher);
        }

        public async Task Put(int id,AssignmentRequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Title = request.Title;
            model.Text = request.Text;

            await _repository.Put(model);
        }

        public async Task<Assignment> delete(int id) =>  await _repository.Delete(id);
            
    }
}
