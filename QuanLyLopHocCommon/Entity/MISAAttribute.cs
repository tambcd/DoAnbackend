using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{

    /// <summary>
    /// thuộc tính buộc nhập 
    /// @@ cretedby : TVTam(MF1270) (20/2/2023)    
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class Required : Attribute
    {

    }
    /// <summary>
    /// thuộc tính không trùng 
    /// @@ cretedby : TVTam(MF1270) (20/2/2023)    
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class Same : Attribute
    {

    }

    /// <summary>
    /// thuộc tính tràn số 
    /// @@ cretedby : TVTam(MF1270) (20/2/2023)    
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NumberBig : Attribute
    {

    }

    /// <summary>
    /// thuộc tính lấy ra tên trường 
    /// @@ cretedby : TVTam(MF1270) (20/2/2023)
    /// </summary>
    /// cretedby : TVTam(MF1270) (9/8/2022)
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PropNameDisplay : Attribute
    {
        public string PropName { get; set; }
        public PropNameDisplay(string name)
        {
            this.PropName = QuanLyLopHocCommon.CommonResource.GetResoureString(name);
        }

    }
}
