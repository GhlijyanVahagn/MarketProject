using DbManager.RepositoryInterfaces;
using DbModel;
using MarketManagment.Managers.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public abstract void Create(TVIEW entity);
        public abstract void  Delete(int Id);
        public abstract TVIEW Read(int Id);
        public abstract Task<IEnumerable<TVIEW>> GetAllAsync();
        public abstract void Save();
        public abstract void Update(TVIEW entity);
        public abstract IEnumerable<TVIEW> ViewModelList();

        public void CreateAndSave(TVIEW entity)
        {

            Create(entity);
            Save();
        }
        public T ConvertView_DTO(TVIEW ViewModel)
        {
            return  MarketMapper.Mapper.Map<TVIEW, T>(ViewModel);
        }

        public TVIEW ConverDTO_View(T DtoModel)
        {
            return MarketMapper.Mapper.Map<T,TVIEW >(DtoModel);
        }

        public IEnumerable<T> ConvertViewList_DTOList(IEnumerable<TVIEW> ViewList)
        {
            foreach(TVIEW Viewitem in ViewList)
             yield return MarketMapper.Mapper.Map<TVIEW, T>(Viewitem);
        }

        public IEnumerable<TVIEW> ConverDTOList_ViewlList(IEnumerable<T> DtoList)
        {
            foreach(T Dtoitem in DtoList)
               yield return MarketMapper.Mapper.Map<T, TVIEW>(Dtoitem);


        }

        public int Validatation(IValidator validator)
        {

            MarketValidator validation = new MarketValidator(validator);
            return validation.Validate();
        }
         
    }
}
