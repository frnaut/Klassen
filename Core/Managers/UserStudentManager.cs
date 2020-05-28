using Core.IRepository;
using Core.Models;
using Core.Requests;
using Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class UserStudentManager
    {
        private readonly IUserStudentRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public UserStudentManager( IUserStudentRepository repository, IRoleRepository roleRepository )
        {
            this._repository = repository;
            this._roleRepository = roleRepository;
        }

        public async Task<bool> Login(UsersRequest request)
        {
            UserStudent model = await _repository.GetByEmail(request.Email);
            if(model == null) { return false; }

            scriptPass script = new scriptPass();
            request.Password = script.script(request.Password);

            if(model.Password != request.Password) { return false; }

            return true;
        }

        public async Task<List<UserStudent>> getAllAsync() => await _repository.GetAllAsync();

        public async Task<UserStudent> getById(int id) => await _repository.GetByIdAsync(id);

        public async Task<UserStudent> getByEmail(string request) => await _repository.GetByEmail(request);

        public async Task<UserStudent> postAsync(UsersRequest request)
        {
            scriptPass script = new scriptPass();
            UserStudent model = new UserStudent();
            
            model.Email = request.Email;
            model.Role = await _roleRepository.GetByIdAsync(request.RoleId);
            model.Password = script.script(request.Password);

            return await _repository.PostAsync(model);

        }

        public async Task put(int id,UsersRequest request)
        {
            scriptPass script = new scriptPass();
            var model = await _repository.GetByIdAsync(id);

            model.Email = request.Email;
            model.Role = await _roleRepository.GetByIdAsync(request.RoleId);
            model.Password = script.script(request.Password);

            await _repository.Put(model);
        }

        public async Task<UserStudent> delete(int id) => await _repository.Delete(id);
        
    }
}
