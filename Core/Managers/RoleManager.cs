using Core.IRepository;
using Core.Models;
using Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class RoleManager
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager( IRoleRepository roleRepository )
        {
            this._roleRepository = roleRepository;
        }

        public async Task<List<Role>> getAllAsync() => await _roleRepository.GetAllAsync();

        public async Task<Role> getById(int id) => await _roleRepository.GetByIdAsync(id);
        

        public async Task<Role> post(RoleRequest requets)
        {
            Role model = new Role();
            model.Name = requets.Name;

            return await _roleRepository.PostAsync(model);
        }

        public async Task Put(int id,RoleRequest request)
        {
            var model = await _roleRepository.GetByIdAsync(id);
            model.Name = request.Name;
            await _roleRepository.Put(model);

        }

        public async Task<Role> delete(int id) => await _roleRepository.Delete(id);
        

    }
}
