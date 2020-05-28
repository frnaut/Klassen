using Core.IRepository;
using Core.Models;
using Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class DeliveryManager
    {
        private readonly IDeliveryRepository _repository;
        private readonly IAssignmentsRepository _assignments;
        private readonly IUserStudentRepository _student;

        public DeliveryManager(IDeliveryRepository repository, IAssignmentsRepository assignments,
                                IUserStudentRepository student)
        {
            this._repository = repository;
            this._assignments = assignments;
            this._student = student;
        }

        public async Task<List<Delivery>> getAllAsync()
        {
            var listModel = new List<Delivery>();
            var models = await _repository.GetAllAsync();

            foreach(var item in models)
            {
                listModel.Add(_repository.Find(x => x.Id == item.Id, x => x.Assignment, x => x.Documents, x=> x.Student));
            }

            return listModel;
        }
        public Delivery getById(int id) => _repository.Find(x => x.Id == id, x => x.Assignment, x => x.Documents, x => x.Student);
        
        public async Task<Delivery> postAsync(DeliveryRequest request)
        {
            Delivery model = new Delivery();
            model.Assignment = await _assignments.GetByIdAsync(request.AssignmentId);
            model.Student = await _student.GetByEmail(request.Student);

            var newModel = await _repository.PostAsync(model);
            return _repository.Find(x => x.Id == newModel.Id, x => x.Assignment, x => x.Documents, x => x.Student);
        }

        public async Task put(int id, DeliveryRequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Assignment = await _assignments.GetByIdAsync(request.AssignmentId);

            await _repository.Put(model);
        }
        public async Task<Delivery> delete(int id) => await _repository.Delete(id);
        
    }
}
