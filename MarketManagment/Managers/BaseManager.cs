using DbManager.RepositoryInterfaces;
using DbModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using MarketManagment.Managers.Validator;

namespace MarketManagment.Managers
{
    public abstract class BaseManager<T,TVIEW> where T:class
    {
        
        public IRepository<T, TVIEW> Repository { get; set; }
        public  BaseManager(IRepository<T,TVIEW> repository)
        {
            this.Repository = repository;
        }
        public BaseManager()
        {

        }
        public void CreateAndSave(TVIEW entity)
        {


            T model= MarketMapper.Mapper.Map<TVIEW, T>(entity);
            Repository.Create(model);
            Repository.Save();

        }
        public async Task<IEnumerable<TVIEW>> GetAllAsync()
        {
            var dtoProducer = await Repository.GetAllAsync();
            var viewList = ConvertDbModelListToViewlList(dtoProducer);
            return viewList;

        }
        //public abstract void Create(TVIEW entity);
        public abstract void  Delete(int Id);
        public abstract TVIEW Read(int Id);
        //public abstract Task<IEnumerable<TVIEW>> GetAllAsync();
        public abstract void Save();
        public abstract void Update(TVIEW entity);
        public abstract IEnumerable<TVIEW> ViewModelList();
        

        //public void CreateAndSave(TVIEW entity)
        //{

        //    Create(entity);
        //    Save();
        //}
        private T ConvertViewModeltoDbModel(TVIEW ViewModel)
        {
            return  MarketMapper.Mapper.Map<TVIEW, T>(ViewModel);
        }

        private TVIEW ConverDTO_View(T DtoModel)
        {
            return MarketMapper.Mapper.Map<T,TVIEW >(DtoModel);
        }

        private IEnumerable<T> ConvertViewList_DTOList(IEnumerable<TVIEW> ViewList)
        {
            foreach(TVIEW Viewitem in ViewList)
             yield return MarketMapper.Mapper.Map<TVIEW, T>(Viewitem);
        }

        private IEnumerable<TVIEW> ConvertDbModelListToViewlList(IEnumerable<T> DtoList)
        {
            foreach(T Dtoitem in DtoList)
               yield return MarketMapper.Mapper.Map<T, TVIEW>(Dtoitem);


        }

        public string Validatation(ValidatorBase<TVIEW> validator)
        {
            MarketValidator validation = new MarketValidator(validator);
            return validation.Validate();
        }
         
    }
}
