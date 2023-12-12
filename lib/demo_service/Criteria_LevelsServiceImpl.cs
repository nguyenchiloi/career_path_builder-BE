using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class Criteria_LevelsServiceImpl : ICriteria_LevelsService
    {
        private readonly ICriteriaRepo _repo;
        public Criteria_LevelsServiceImpl(ICriteriaRepo _repo) {
            this._repo = _repo;
        }
        public ResponseMessage AddCriteriaToLevels(Levels_Criteria levels_Criteria)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.message = "Thêm tiêu chí cho cột mốc thành công";
                rp.status = MessageStatus.success;
                rp.data = _repo.AddCriteriaToLevel(levels_Criteria.point,levels_Criteria.coefficien,levels_Criteria.criteriaid,levels_Criteria.nodeid);
                return rp;
            }catch (Exception ex)
            {
                rp.message = ex.Message;
                rp.status = MessageStatus.error;
                rp.data = null;
                return rp;
            }
        }

        public ResponseMessage GetCriteriaByLevel(int levelid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.message = "Lấy danh sách tiêu chí của một cột mốc thành công";
                rp.status = MessageStatus.success;
                rp.data = _repo.GetCriteriaByLevel(levelid);
                return rp;
            }
            catch (Exception ex)
            {
                rp.message = ex.Message;
                rp.status = MessageStatus.error;
                rp.data = null;
                return rp;
            }
        }
    }
}
