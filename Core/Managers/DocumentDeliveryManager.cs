using Core.IRepository;
using Core.Models;
using Core.Requests;
using Core.Utlis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class DocumentDeliveryManager
    {
        private readonly IDocumentDeliveryRepository _repository;
        private readonly IDeliveryRepository _delivery;
        private readonly IUserStudentRepository _student;

        public DocumentDeliveryManager(IDocumentDeliveryRepository repository, IDeliveryRepository delivery,
                                       IUserStudentRepository student)
        {
            this._repository = repository;
            this._delivery = delivery;
            this._student = student;
        }

        public async Task<List<DocumentDelivery>> getAll()
        {
            var listModel = new List<DocumentDelivery>();
            var models = await _repository.GetAllAsync();
            foreach(var item in models)
            {
                listModel.Add(_repository.Find(x => x.Id == item.Id, x => x.Delivery, x => x.Student));
            }

            return listModel;
        }
        public DocumentDelivery getById(int id) => _repository.Find(x => x.Id == id, x => x.Delivery, x => x.Student);

        public async Task<DocumentDelivery> post(DocumentDeliveryRequest request)
        {
            var upload = new UploadFiles();

            DocumentDelivery model = new DocumentDelivery();
            model.Delivery = await _delivery.GetByIdAsync(request.DeliveryId);
            model.Format = request.Format;
            model.Name = request.Name;
            model.Path = upload.Upload(request.Name, request.Format, request.Doc);
            model.Student = await _student.GetByEmail(request.Student);

            var newModel = await _repository.PostAsync(model);
            return _repository.Find(x => x.Id == newModel.Id, x => x.Delivery, x => x.Student);
        }

        public async Task put(int id, DocumentDeliveryRequest request)
        {
            var upload = new UploadFiles();
            var model = await _repository.GetByIdAsync(id);
            
            model.Delivery = await _delivery.GetByIdAsync(request.DeliveryId);
            model.Format = request.Format;
            model.Name = request.Name;

            upload.Delete(model.Path);

            model.Path = upload.Upload(request.Name, request.Format, request.Doc);
            model.Student = await _student.GetByEmail(request.Student);

            await _repository.Put(model);
        }

        public async Task<DocumentDelivery> delete(int id) => await _repository.Delete(id);

    }
}
