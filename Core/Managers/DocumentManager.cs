using Core.IRepository;
using Core.Models;
using Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class DocumentManager
    {
        private readonly IDocumentRepository _repository;
        private readonly IAssignmentsRepository _assignments;

        public DocumentManager(IDocumentRepository repository, IAssignmentsRepository assignments)
        {
            this._repository = repository;
            this._assignments = assignments;
        }

        public async Task<List<Document>> getAllAsync()
        {
            var listModel = new List<Document>();
            var models = await _repository.GetAllAsync();
            foreach(var item in models)
            {
                listModel.Add(_repository.Find(x => x.Id == item.Id, x => x.Assignment));
            }

            return listModel;
        }
        public Document getByIdAsync(int id) => _repository.Find(x => x.Id == id, x => x.Assignment);

        public async Task<Document> post(DocumentRequest request)
        {
            var model = new Document();
            model.Assignment = await _assignments.GetByIdAsync(request.AssignamentId);
            model.Format = request.Format;
            model.Name = request.Name;
            model.Path = request.Path;

            var newModel = await _repository.PostAsync(model);
            return _repository.Find(x => x.Id == newModel.Id, x => x.Assignment);
        }

        public async Task put(int id, DocumentRequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Assignment = await _assignments.GetByIdAsync(request.AssignamentId);
            model.Format = request.Format;
            model.Name = request.Name;
            model.Path = request.Path;

            await _repository.Put(model);
        }

        public async Task<Document> delete(int id) => await _repository.Delete(id);
        

    }
}
