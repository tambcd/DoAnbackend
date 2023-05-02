using MISA.Common.Exceptions;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.ImplementService
{
    public class BaseBL<Entity>:IBaseBL<Entity> where Entity : class
    {
        /// <summary>
        /// biến check validate custom 
        /// </summary>
        protected bool isValidCustom = true;
        /// <summary>
        /// danh sách lỗi 
        /// </summary>
        protected List<string> listMsgEr = new List<string>();

        IBaseDL<Entity> _baseDL;

        public BaseBL(IBaseDL<Entity> baseDL)
        {
            _baseDL = baseDL;

        }
        /// <summary>
        /// Thự hiện thêm đối tượng
        /// @created by : tvTam
        /// </summary>
        /// <param name="entity">thông tin đối tường</param>
        /// <returns></returns>
        /// <exception cref="CustomException">khi gặp lỗi trả về</exception>
        public int InsertSevices(Entity entity)
        {
            // check validate chung
            var isValid = Validate(entity);
            // check validate custom
            isValidCustom = ValidateCusrtom(entity);
            if (isValid && isValidCustom)
            {
                var res = _baseDL.Insert(entity);
                return res;
            }
            else
            {
                throw new CustomException(QuanLyLopHocCommon.CommonResource.GetResoureString("InvalidInput"), listMsgEr);
            }
        }
        /// <summary>
        /// thực hiện xửa 1 đối  tường 
        /// @created by : tvTam
        /// </summary>
        /// <param name="entity">thông tin đối tượng </param>
        /// <returns></returns>
        /// <exception cref="CustomException">trả về lỗi </exception>
        public int UpdateSevices(Entity entity)
        {
            // check validate chung
            bool isValid = Validate(entity);
            // check validate custom
            isValidCustom = ValidateCusrtom(entity);
            if (isValid && isValidCustom)
            {
                var res = _baseDL.Update(entity);
                return res;
            }
            else
            {
                throw new CustomException(QuanLyLopHocCommon.CommonResource.GetResoureString("InvalidInput"), listMsgEr);
            }
        }

        public bool Validate(Entity entity)
        {
            var isValid = true;
            var properties = entity.GetType().GetProperties();
            // kiểm tra dữ liệu dựa vào Attribute tự định nghĩa 

            foreach (var property in properties)
            {
                var propName = property.Name;
                var value = property.GetValue(entity);
                var arrProNameDisplay = property.GetCustomAttributes(typeof(PropNameDisplay), false).FirstOrDefault();

                // nếu dữ liệu trống hoặc bằng null 
                if (property.IsDefined(typeof(Required), false) && (value == null || value.ToString() == String.Empty))
                {
                    isValid = false;
                    propName = (arrProNameDisplay as PropNameDisplay).PropName;
                    listMsgEr.Add($"{propName} {QuanLyLopHocCommon.CommonResource.GetResoureString("EmptyCheck")}");
                }
            }

            // validate chung 
            return isValid;
        }

        /// <summary>
        /// validate riêng của mỗi thực thể 
        /// @created by : tvTam
        /// </summary>
        /// <param name="entity"> thực thể cần validate</param>
        /// <returns>bool</returns>
        protected virtual bool ValidateCusrtom(Entity entity)
        {

            return true;
        }
    }
}
