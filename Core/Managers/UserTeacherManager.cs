using Core.IRepository;
using Core.Models;
using Core.Requests;
using Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class UserTeacherManager
    {
        private readonly IUserTeacherRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public UserTeacherManager(IUserTeacherRepository repository, IRoleRepository roleRepository)
        {
            this._repository = repository;
            this._roleRepository = roleRepository;
        }

        public async Task<bool> login(LoginRequest request)
        {
            UserTeacher model = await _repository.GetByEmail(request.Email);
            if(model == null) { return false; }

            scriptPass script = new scriptPass();
            request.Password = script.script(request.Password);

            if(model.Password != request.Password) { return false; }

            return true;
            
        }

        public async Task<List<UserTeacher>> getAllAsync() => await _repository.GetAllAsync();

        public async Task<UserTeacher> getById(int id) => await _repository.GetByIdAsync(id);

        public async Task<UserTeacher> getByEmail(string request) => await _repository.GetByEmail(request);

        public async Task<UserTeacher> post(UsersRequest request)
        {
            scriptPass script = new scriptPass();

            UserTeacher model = new UserTeacher();
            model.Email = request.Email;
            model.Password = script.script(request.Password);
            model.Role = await _roleRepository.GetByIdAsync(request.RoleId);

            return await _repository.PostAsync(model);
        }

        public async Task put(int id, UsersRequest request)
        {
            scriptPass script = new scriptPass();

            var model = await _repository.GetByIdAsync(id);
            model.Email = request.Email;
            model.Password = script.script(request.Password);
            model.Role = await _roleRepository.GetByIdAsync(request.RoleId);
            await _repository.Put(model);

        }

        public async Task<UserTeacher> delete(int id) => await _repository.Delete(id);
        
    }
}
