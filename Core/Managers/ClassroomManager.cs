using Core.IRepository;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class ClassroomManager
    {
        private readonly IClassroomRepository _repository;
        private readonly IUserTeacherRepository _teacher;

        public ClassroomManager(IClassroomRepository repository, IUserTeacherRepository teacher)
        {
            this._repository = repository;
            this._teacher = teacher;
        }

        public async Task<List<Classroom>> getAllAsync() {

            var listModel = new List<Classroom>();
            var models = await _repository.GetAllAsync();
            
            foreach(var item in models)
            {
                listModel.Add(item);
            }

            return listModel;
        
        }

        public Classroom getByIdAsync(int id) => _repository.Find(x => x.Id == id);

        public async Task<Classroom> postAsync(ClasroomRequest request)
        {
            Classroom model = new Classroom();
            model.Name = request.Name;
            model.Teacher = await _teacher.GetByEmail(request.Teacher);

            var newModel = await _repository.PostAsync(model);

            return _repository.Find(x => x.Id == newModel.Id, x => x.assignments, x => x.Posts, x => x.Students, x => x.Teacher);
        }

        public async Task put(int id, ClasroomRequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Name = request.Name;
            await _repository.Put(model);
        }

        public async Task<Classroom> delete(int id) => await _repository.Delete(id);
        
    }
}
