using DbManager;
using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MarketHelpers
{

    public class UIControlBinder
    {
        public UIControlBinder()
        {

        }
        public void Bind<TSource>(IEnumerable<TSource> source, BaseDataBoundControl control)  where TSource : ViewBase 
        {
            if (control== null)
                throw new InvalidOperationException("Some of controls are null, Binding impossible. ");
            control.DataSource = source;
            control.DataBind();
        }
        public void Bind<TSource1, TSource2>(IEnumerable<TSource1> source1, IEnumerable<TSource2> source2, BaseDataBoundControl control1, BaseDataBoundControl control2)  where TSource1:ViewBase 
                                                                        where TSource2:ViewBase
                                                                      

        {
            if (control1 == null || control2 == null)
                throw new InvalidOperationException("Some of controls are null, Binding impossible. ");
            control1.DataSource = source1;
            control2.DataSource = source2;
          

            control1.DataBind();
            control2.DataBind();
           
        }
        public void Bind<TSource1, TSource2, TSource3>(IEnumerable<TSource1> source1, IEnumerable<TSource2> source2, IEnumerable<TSource3> source3,
                                                       BaseDataBoundControl control1, BaseDataBoundControl control2, BaseDataBoundControl control3) 
                                                                                        where TSource1 : ViewBase
                                                                                        where TSource2 : ViewBase
                                                                                        where TSource3 : ViewBase
        {
            if (control1 == null || control2 == null || control3==null)
                throw new InvalidOperationException("Some of controls are null, Binding impossible. ");
            control1.DataSource = source1;
            control2.DataSource = source2;
            control3.DataSource = source3;

            control1.DataBind();
            control2.DataBind();
            control3.DataBind();
        }
    }





 
}

