using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Blob.Web.Framework.Mvc
{
     public partial class BaseBlobModel
    {

         public BaseBlobModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }

         public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
         {
         }

         /// <summary>
         /// Use this property to store any custom value for your models. 
         /// </summary>
         public Dictionary<string, object> CustomProperties { get; set; }
    }

     /// <summary>
     /// Base Blob entity model
     /// </summary>
     public partial class BaseBlobEntityModel : BaseBlobModel
     {
         public virtual int Id { get; set; }
     }
}
