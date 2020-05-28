using Core.IRepository;
using Core.Models;
using Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class PostManager
    {
        private readonly IPostRepository _repository;
        private readonly IUserTeacherRepository _teacher;
        private readonly IClassroomRepository _classroom;

        public PostManager(IPostRepository repository, IUserTeacherRepository teacher, IClassroomRepository classroom)
        {
            this._repository = repository;
            this._teacher = teacher;
            this._classroom = classroom;
        }

        public async Task<List<Post>> getAllAsync()
        {
            var listModel = new List<Post>();
            var models = await _repository.GetAllAsync();

            foreach(var item in models)
            {
                listModel.Add(_repository.Find(x => x.Id == item.Id, x => x.Classroom, x => x.Teacher));
            }

            return listModel;
        }
        public Post getByIdAsync(int id) => _repository.Find(x => x.Id == id, x => x.Classroom, x => x.Teacher);
        

        public async Task<Post> postAsync(PostRequest request)
        {
            var model = new Post();
            model.Text = request.Text;
            model.Title = request.Title;
            model.Teacher = await _teacher.GetByEmail(request.Teacher);
            model.Classroom = await _classroom.GetByIdAsync(request.ClassroomId);

            var newModel = await _repository.PostAsync(model);
            return _repository.Find(x => x.Id == newModel.Id, x => x.Classroom, x => x.Teacher);
        }

        public async Task put(int id, PostRequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Text = request.Text;
            model.Title = request.Title;
            model.Teacher = await _teacher.GetByEmail(request.Teacher);
            model.Classroom = await _classroom.GetByIdAsync(request.ClassroomId);

            await _repository.Put(model);
        }

        public async Task<Post> delete(int id) => await _repository.Delete(id);
        
    }
}
